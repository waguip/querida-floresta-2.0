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
    private RainScript2D rainScript;
    [SerializeField] private GameObject wind, rock;    
    [SerializeField] private Transform hotZoneSlot, target;    
    [SerializeField] private Sprite rockAfter;
    private bool toTarget = false, toHotZone = false;

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

        //Quado acumula 2 acertos no "Slot"
        if (correct >= 2) {                    
            win();
            toTarget = true;
            correct = 0;
        }

        if(toTarget) {
            //move o vento em direção ao alvo
            wind.transform.position = Vector3.MoveTowards(wind.transform.position, target.position, 5 * Time.deltaTime);
        }

        //Quando o vento passa pela rocha, troca o sprite dela
        if (Vector3.Distance(wind.transform.position, target.transform.position) < 0.01f) {
            rock.GetComponent<Image>().sprite = rockAfter;
            toTarget = false;
            toHotZone = true;            
        }

        if(toHotZone) {
            //move o vento em direção a zona quente            
            wind.transform.position = Vector3.MoveTowards(wind.transform.position, hotZoneSlot.position, 5 * Time.deltaTime);
        }
    }

    private void win() {
        wind.SetActive(true);
        audioController.sceneCompletedSound();        
        narratorController.Invoke("playCongratsAudio", 3f);
        audioLength = narratorController.congratsAudioLength() + 5f;
        sceneLoader.Invoke("loadScene9", audioLength);
    }
}
