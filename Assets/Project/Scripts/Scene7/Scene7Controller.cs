using System;
using UnityEngine;
using UnityEngine.UI;

using DigitalRuby.RainMaker;
using System.Threading;

public class Scene7Controller : MonoBehaviour
{
    private Button wrong1Button, wrong2Button, correctButton;
    [SerializeField] private GameObject wrong1Object, wrong2Object, correctObject, correctPlace;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GoogleSheetsController sheetsController;
    [SerializeField] private Scene7CanvasController canvasController;
    [SerializeField] private Scene7NarratorController narratorController;
    private static float introAudioLength = 12f;
    private DateTime timeStarted;
    private RainScript2D rainScript;
    private enum Tcontroller { CANVAS, SELF, SCENE_LOADER }

    private void Awake() {
        wrong1Button = wrong1Object.GetComponent<Button>();
        wrong2Button = wrong2Object.GetComponent<Button>();
        correctButton = correctObject.GetComponent<Button>();
    }

    private void playANarratorAudio( string functionToInvoke, string sceneFunction, float length, Tcontroller controller = Tcontroller.CANVAS, float awaitTime = 0f )
    {
        narratorController.Invoke(functionToInvoke, awaitTime + 1f);

        if(sceneFunction != null)
        {
            length += awaitTime;
            switch (controller)
            {
                case Tcontroller.CANVAS:
                    canvasController.Invoke(sceneFunction, length); break;
                case Tcontroller.SCENE_LOADER:
                    sceneLoader.Invoke(sceneFunction, length); break;
                
                default: Invoke(sceneFunction, length); break;
            }
        }
    }

    public void sceneMiss(string audioToInvoke, float audioLength)
    {
        AplicationModel.Scene2Misses++;
        playANarratorAudio(audioToInvoke, "changeToTryAgainInterface", audioLength);
    }

    private void sendDataToReport()
    {
        ReportCreator.writeLine("\nAtividade 7");
        ReportCreator.writeLine($"Quantidade de erros da fase: {AplicationModel.Scene2Misses}");
        ReportCreator.writeResponseTime(AplicationModel.PlayerResponseTime[1]);
    }

    void Start()
    {
        timeStarted = DateTime.Now;
        AplicationModel.SceneAcesses[1]++;

        if(AplicationModel.isFirstTimeScene7) {

            AplicationModel.isFirstTimeScene7 = false;
            canvasController.showBackgroundCover();
            playANarratorAudio("playIntroductionAudio", "hideBackgroundCover", introAudioLength);

        } else {
            introAudioLength = 0f;
        }              

        //Define a ação "correctClicked"
        Action correctClicked = () => {   

            playANarratorAudio("playCorrectAudio", "loadScene8", 6.5f, Tcontroller.SCENE_LOADER);            

            if(!Player.Instance.ScenesCompleted[4]) {
                //sendDataToReport();
                new Thread(sheetsController.SavePlayerProgress).Start();
                Player.Instance.ScenesCompleted[4] = true;
            }
        };

        //Define a ação "buttonClicked"
        Action<GameObject> buttonClicked = (gameObject) => {
            Button[] buttons = {correctButton, wrong2Button};

            if(!Player.Instance.ScenesCompleted[1] && AplicationModel.PlayerResponseTime[1] == 0.00000f ) {
                AplicationModel.PlayerResponseTime[1] = (DateTime.Now - timeStarted).Seconds - introAudioLength;
            }

            //Cobre o jogo, retira os listeners dos botões, destroi o botão clicado e ativa a imagem na parede
            canvasController.showBackgroundCover();        
            foreach (Button btn in buttons) btn.onClick.RemoveAllListeners();
            Destroy(gameObject);
            correctPlace.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
            correctPlace.SetActive(true);            
        };


        //Adiciona os listeners dos botões    
        wrong1Button.onClick.AddListener(() => {
            buttonClicked(wrong1Object);
            sceneMiss("playMissAudio", 2f);
        });

        wrong2Button.onClick.AddListener(() => {
            buttonClicked(wrong2Object);
            sceneMiss("playMissAudio", 2f);
        });

        correctButton.onClick.AddListener(() => {
            buttonClicked(correctObject);
            correctClicked();
        });
    }
}
