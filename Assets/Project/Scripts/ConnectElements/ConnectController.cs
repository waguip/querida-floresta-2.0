using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DigitalRuby.RainMaker;
using System;
using System.Threading;

public class ConnectController : MonoBehaviour
{

    public int correct = 0;
    float audioLength;

    [SerializeField] private AudioController audioController;
    [SerializeField] private ConnectNarratorController narratorController;
    [SerializeField] private ConnectCanvasController canvasController;
    [SerializeField] private GoogleSheetsController sheetsController;
    [SerializeField] private SceneLoader sceneLoader;

    void Start() {
        if(AplicationModel.isFirstTimeSceneConnect) {
            AplicationModel.isFirstTimeSceneConnect = false;
            
            //"Cobre" a tela para impedir clicks
            canvasController.showBackgroundCover();
            //Retira o cover após o audio tocar
            audioLength = narratorController.playIntroductionAudio();
            canvasController.Invoke("hideBackgroundCover", audioLength);
        }
    }

    void Update()
    {
        //Enviado por "Slot" quando erra
        if(correct == -1) {

            AplicationModel.Scene10Misses[2]++;
        
            canvasController.showBackgroundCover();
            audioController.missSound();            
            narratorController.playMissClickAudio();
            sceneLoader.Invoke("loadConnectFigures", 6f);
            correct = 0;
        }

        //Quado acumula 3 acertos no "Slot"
        if (correct >= 3) {        
            correct = 0;
            win();
        }
    }

    private void win() {
        audioController.sceneCompletedSound();
        narratorController.Invoke("playCongratsAudio", 2f);
        audioLength = narratorController.congratsAudioLength() + 4f;

        AplicationModel.isFirstTimeSceneConnect = true;
        if(!Player.Instance.ScenesCompleted[9]) {
            //sendDataToReport();
            new Thread(sheetsController.SavePlayerProgress).Start();
            Player.Instance.ScenesCompleted[9] = true;
        }

        sceneLoader.Invoke("loadMainMenu", audioLength);
    }
}
