using UnityEngine;
using System.Threading;

public class Scene8Controller : MonoBehaviour
{

    public int correct;
    float audioLength;

    [SerializeField] private AudioController audioController;
    [SerializeField] private Scene8NarratorController narratorController;
    [SerializeField] private Scene8CanvasController canvasController;
    [SerializeField] private GoogleSheetsController sheetsController;
    [SerializeField] private SceneLoader sceneLoader;            

    void Start() {
        //Se for a primeira vez nessa fase
        if(AplicationModel.isFirstTimeScene8) {
            AplicationModel.isFirstTimeScene8 = false;            
            playIntroductionAudio();
        }
    }

    void Update()
    {
        //Enviado por "Slot" quando erra
        if(correct == -1) {
            AplicationModel.Scene8Misses++;
            audioController.missSound();
            canvasController.Invoke("changeToTryAgainInterface", 1f);
            narratorController.Invoke("playMissClickAudio", 1f);
            correct = 0;
        }

        //Quado acumula 2 acertos no "Slot"
        if (correct >= 2) {                    
            win();            
            correct = 0;
        }
    }

    public void playIntroductionAudio() {
        //"Cobre" a tela para impedir clicks
        canvasController.showBackgroundCover();
        //Toca o audio
        audioLength = narratorController.playIntroductionAudio();
        //Retira o cover após o audio tocar
        canvasController.Invoke("hideBackgroundCover", audioLength);
    }

    private void win() {
        AplicationModel.isFirstTimeScene8 = true;
        if(!Player.Instance.ScenesCompleted[7]) {            
            new Thread(sheetsController.SavePlayerProgress).Start();
            Player.Instance.ScenesCompleted[7] = true;
        }

        //Toca animação
        canvasController.showBackgroundCover();
        canvasController.erosionAnimation();
        audioController.sceneCompletedSound();        
        narratorController.Invoke("playCongratsAudio", 3f);
        audioLength = narratorController.congratsAudioLength() + 5f;
        sceneLoader.Invoke("loadScene9", audioLength);
    }
}
