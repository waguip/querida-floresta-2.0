using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ConnectCanvasController : MonoBehaviour
{    
    [SerializeField] private GameObject backgroundCoverObj;
    [SerializeField] private LineRenderer[] lines;
    [SerializeField] private Button[] buttons;
    [SerializeField] private CanvasGroup[] canvasGroups;

    public void hideBackgroundCover() 
    {
        backgroundCoverObj.SetActive(false);
    }

    public void showBackgroundCover() 
    {
        backgroundCoverObj.SetActive(true);        
    }   
}
