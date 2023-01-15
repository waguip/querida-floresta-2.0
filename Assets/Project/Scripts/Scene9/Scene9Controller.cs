using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DigitalRuby.RainMaker;
using System;
using System.Threading;

public class Scene9Controller : MonoBehaviour
{

    public int correct;
    float audioLength;
    [SerializeField] private GoogleSheetsController sheetsController;
    [SerializeField] private AudioController audioController;
    [SerializeField] private Scene9NarratorController narratorController;
    [SerializeField] private Scene9CanvasController canvasController;
    [SerializeField] private SceneLoader sceneLoader;

    void Start() {
        if(AplicationModel.isFirstTimeScene9) {
            AplicationModel.isFirstTimeScene9 = false;
            
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
            AplicationModel.Scene9Misses++;
            audioController.missSound();
            canvasController.Invoke("changeToTryAgainInterface", 1f);
            narratorController.Invoke("playMissClickAudio", 1f);
            correct = 0;
        }

        //Quado acumula 2 acertos no "Slot"
        if (correct >= 3) {                    
            win();            
            correct = 0;            
        }
        
    }

    private void win() {        
        AplicationModel.isFirstTimeScene9 = true;
        if(!Player.Instance.ScenesCompleted[8]) {            
            new Thread(sheetsController.SavePlayerProgress).Start();
            Player.Instance.ScenesCompleted[8] = true;
        }

        canvasController.windPreventionAnimation();
        audioController.sceneCompletedSound();        
        narratorController.Invoke("playCongratsAudio", 3f);
        audioLength = narratorController.congratsAudioLength() + 5f;
        sceneLoader.Invoke("loadQuiz2", audioLength);
    }
}
