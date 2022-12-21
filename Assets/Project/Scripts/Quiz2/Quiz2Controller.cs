using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz2Controller : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GoogleSheetsController sheetsController;
    [SerializeField] private Quiz2CanvasController canvasController;
    [SerializeField] private AudioController audioController;
    [SerializeField] private Quiz2NarratorController narratorController;    
    private int index = 0;

    private void Start() {        
        narratorController.playIntroductionAudio();
    }

    //Chamado pelo botão correto
    public void rightAnswer(Button button)
    {
        canvasController.setAnswerEffect(button, true);
        audioController.hitSound();
        narratorController.playRightAnswerAudio();
        index++;

        if(index <= 1) {    
            canvasController.Invoke("changeToQuestionTwo", narratorController.RightAnswerAudio.clip.length);
            narratorController.Invoke("playQuestion2Audio", narratorController.RightAnswerAudio.clip.length + 1f);
        } else {
            narratorController.Invoke("playSceneCompletedAudio", narratorController.RightAnswerAudio.clip.length);
            sceneLoader.Invoke("loadConnectFigures", narratorController.RightAnswerAudio.clip.length + 1f);
        }
    }

    //Chamado pelo botão incorreto
    public void wrongAnswer(Button button)
    {        
        canvasController.setAnswerEffect(button, false);
        audioController.missSound();
        narratorController.playWrongAnswerAudio();
        AplicationModel.Scene3Misses[index]++;
    }

    public void repeatQuestionBtn() {
        if (index <= 1) {
            narratorController.playQuestion1Audio();
        } else {
            narratorController.playQuestion2Audio();
        }
    }
}
