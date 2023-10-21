using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Scene5Controller : MonoBehaviour
{
    [SerializeField] private Button cowButton, garbageButton, treesButton;
    [SerializeField] private GameObject cowObject, garbageObject, treesObject;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GoogleSheetsController sheetsController;
    [SerializeField] private Scene5CanvasController canvasController;
    [SerializeField] private Scene5NarratorController narratorController;
    private static float introAudioLength = 6.2f;
    private DateTime timeStarted;    
    private enum Tcontroller { CANVAS, SPRITE, SELF, SCENE_LOADER }

    public void showHelp()
    {
        playANarratorAudio("playHelpAudio", "leaveHelpInterface", 9f);
        canvasController.changeToHelpInterface();
    }

    private void playANarratorAudio(
        string functionToInvoke, string sceneFunction, float length,
        Tcontroller controller = Tcontroller.CANVAS, float awaitTime = 0f
    )
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

    public void sceneMiss(string audioToInvoke, float audioLength)
    {
        AplicationModel.Scene5Misses++;        
        playANarratorAudio(audioToInvoke, "changeToTryAgainInterface", audioLength);
    }

    // private void sendDataToReport()
    // {
    //     ReportCreator.writeLine("\nAtividade 5");
    //     ReportCreator.writeLine($"Quantidade de erros da fase: {AplicationModel.Scene2Misses}");
    //     ReportCreator.writeResponseTime(AplicationModel.PlayerResponseTime[1]);
    // }

    void Start()
    {
        //timeStarted = DateTime.Now;
        //AplicationModel.SceneAcesses[1]++;

        if(AplicationModel.isFirstTimeScene5) {

            AplicationModel.isFirstTimeScene5 = false;
            canvasController.showBackgroundCover();
            playANarratorAudio("playIntroductionAudio", "hideBackgroundCover", introAudioLength);

        } else {
            introAudioLength = 0f;
        }              

        //Define a ação "treesClicked"
        Action treesClicked = () => {
            AplicationModel.isFirstTimeScene5 = true;

            playANarratorAudio("playTreesSelectedAudio", null, 12.4f);
            playANarratorAudio("playSceneCompletedAudio", "loadScene6", 2f, Tcontroller.SCENE_LOADER, 12.6f);

            if(!Player.Instance.ScenesCompleted[4]) {
                //sendDataToReport();
                new Thread(sheetsController.SavePlayerProgress).Start();
                Player.Instance.ScenesCompleted[4] = true;
            }
        };

        //Define a ação "buttonClicked"
        Action<GameObject, Button> buttonClicked = (gameObject, button) => {
            Button[] buttons = {cowButton, treesButton, garbageButton};

            /*if(!Player.Instance.ScenesCompleted[1] && AplicationModel.PlayerResponseTime[1] == 0.00000f ) {
                AplicationModel.PlayerResponseTime[1] = (DateTime.Now - timeStarted).Seconds - introAudioLength;
            }*/

            //Cobre o jogo, retira os listeners dos botões, destroe o botão clicado e ativa o gameObject
            canvasController.showBackgroundCover();
            foreach (Button btn in buttons) btn.onClick.RemoveAllListeners();
            Destroy(button.gameObject);
            gameObject.SetActive(true);
        };


        //Adiciona os listeners dos botões
        cowButton.onClick.AddListener( () => {
            buttonClicked(cowObject, cowButton);
            sceneMiss("playCowSelectedAudio", 7.76f);
        });

        garbageButton.onClick.AddListener( () => {
            buttonClicked(garbageObject, garbageButton);
            sceneMiss("playTrashSelectedAudio", 8.49f);
        });

        treesButton.onClick.AddListener( () => {
            buttonClicked(treesObject, treesButton);
            treesClicked();
        });
    }
}
