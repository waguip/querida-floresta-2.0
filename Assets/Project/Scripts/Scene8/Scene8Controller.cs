using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DigitalRuby.RainMaker;
using System;

public class Scene8Controller : MonoBehaviour
{

    public int correct;
    float audioLength;

    [SerializeField] private AudioController audioController;
    [SerializeField] private Scene8NarratorController narratorController;
    [SerializeField] private Scene8CanvasController canvasController;
    [SerializeField] private SceneLoader sceneLoader;        
    [SerializeField] private Transform hotZoneSlot, target;    
    [SerializeField] private Sprite rockAfter;
    private bool toTarget = false, toHotZone = false;

    void Start() {
        //Se for a primeira vez nessa fase
        if(AplicationModel.isFirstTimeScene8) {
            AplicationModel.isFirstTimeScene8 = false;
            
            //"Cobre" a tela para impedir clicks
            canvasController.showBackgroundCover();
            //Toca o audio
            audioLength = narratorController.playIntroductionAudio();
            //Retira o cover após o audio tocar
            canvasController.Invoke("hideBackgroundCover", audioLength);
        }
    }

    void Update()
    {
        //Enviado por "Slot" quando erra
        if(correct == -1) {
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

    private void win() {
        //Toca animaçãp        
        canvasController.erosionAnimation();
        audioController.sceneCompletedSound();        
        narratorController.Invoke("playCongratsAudio", 3f);
        audioLength = narratorController.congratsAudioLength() + 5f;
        sceneLoader.Invoke("loadScene9", audioLength);
    }
}
