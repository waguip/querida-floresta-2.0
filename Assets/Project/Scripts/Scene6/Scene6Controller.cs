using System;
using UnityEngine;
using UnityEngine.UI;

using DigitalRuby.RainMaker;
using System.Threading;

public class Scene6Controller : MonoBehaviour
{
    [SerializeField] private Button wave;
    [SerializeField] private GameObject rainPrefab, waveObject, bgAfter, target;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GoogleSheetsController sheetsController;
    [SerializeField] private Scene6CanvasController canvasController;
    [SerializeField] private Scene6NarratorController narratorController;
    private static float introAudioLength = 10f;
    private DateTime timeStarted;
    private RainScript2D rainScript;
    private enum Tcontroller { CANVAS, SELF, SCENE_LOADER }
    private bool clicked;    

    private void playANarratorAudio( string functionToInvoke, string sceneFunction, float length, Tcontroller controller = Tcontroller.CANVAS, float awaitTime = 0f) 
    {
        narratorController.Invoke(functionToInvoke, awaitTime);
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

    private void sendDataToReport()
    {
        ReportCreator.writeLine("\nAtividade 6");
        ReportCreator.writeLine($"Quantidade de erros da fase: {AplicationModel.Scene2Misses}");
        ReportCreator.writeResponseTime(AplicationModel.PlayerResponseTime[1]);
    }

    void Start()
    {
        timeStarted = DateTime.Now;
        AplicationModel.SceneAcesses[1]++;

        if(AplicationModel.isFirstTimeScene2) {

            AplicationModel.isFirstTimeScene2 = false;
            canvasController.showBackgroundCover();
            playANarratorAudio("playIntroductionAudio", "hideBackgroundCover", introAudioLength);

        } else {
            introAudioLength = 0f;
        }              

        //Define a a????o "waveClicked"
        Action waveClicked = () => {            
            clicked = true;                        
            playANarratorAudio("playSceneCompletedAudio", "loadScene7", 10f, Tcontroller.SCENE_LOADER, 2.7f);
            
            if(!Player.Instance.ScenesCompleted[1]) {
                sendDataToReport();
                new Thread(sheetsController.SavePlayerProgress).Start();
                Player.Instance.ScenesCompleted[1] = true;
            }
        };

        //Define a a????o "buttonClicked"
        Action<GameObject, Button> buttonClicked = (gameObject, button) => {

            if(!Player.Instance.ScenesCompleted[1] && AplicationModel.PlayerResponseTime[1] == 0.00000f ) {
                AplicationModel.PlayerResponseTime[1] = (DateTime.Now - timeStarted).Seconds - introAudioLength;
            }

            //Cobre o jogo, retira os listener dos bot??o, destroe o bot??o clicado e ativa o gameObject
            canvasController.showBackgroundCover();
            wave.onClick.RemoveAllListeners();            
        };

        wave.onClick.AddListener(() => {
            buttonClicked(waveObject, wave);
            waveClicked();
        });
    }

    private void Update() {        
        if(clicked) {
            waveObject.transform.position = Vector3.MoveTowards(waveObject.transform.position, target.transform.position, 2 * Time.deltaTime);
        }        

        if (Vector3.Distance(waveObject.transform.position, target.transform.position) < 0.001f) {
            bgAfter.SetActive(true);
        }
    }
}
