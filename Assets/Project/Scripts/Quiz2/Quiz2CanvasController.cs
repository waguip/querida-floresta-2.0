using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Quiz2CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject backgroundCoverObj, question1, question2;

    public void deactivateBackgroundCover() 
    {
        backgroundCoverObj.SetActive(false);
    }

    public void activateBackgroundCover(float timeToDeactivate) 
    {
        backgroundCoverObj.SetActive(true);
        Invoke("deactivateBackgroundCover", timeToDeactivate);
    }

    public void changeToQuestionTwo()
    {
        question1.SetActive(false);
        question2.SetActive(true);        
    }
}
