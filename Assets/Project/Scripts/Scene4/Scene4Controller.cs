using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DigitalRuby.RainMaker;
using System;

public class Scene4Controller : MonoBehaviour
{

    public int correct;
    float audioLength;

    [SerializeField] private AudioController audioController;
    [SerializeField] private Scene4NarratorController narratorController;
    [SerializeField] private Scene4CanvasController canvasController;
    [SerializeField] private SceneLoader sceneLoader;
    private RainScript2D rainScript;
    [SerializeField] private GameObject rainPrefab;

    void Start() {
        if(AplicationModel.isFirstTimeScene4) {
            AplicationModel.isFirstTimeScene4 = false;
            
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
            audioController.missSound();
            canvasController.Invoke("changeToTryAgainInterface", 1f);
            narratorController.Invoke("playMissClickAudio", 1f);
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
        Invoke("startRaining", 1f);
        narratorController.Invoke("playCongratsAudio", 3f); 
        canvasController.Invoke("landslide", 4f);
        audioLength = narratorController.congratsAudioLength() + 5f;
        sceneLoader.Invoke("loadScene5", audioLength);
    }

    private void startRaining()
    {
        rainScript = (Instantiate(rainPrefab)).GetComponent<RainScript2D>();
        rainScript.RainHeightMultiplier = 0f;
        rainScript.RainWidthMultiplier = 1.12f;
        Destroy(rainScript.gameObject, 8f);
    }
}
