﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene4CanvasController : MonoBehaviour
{
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private GameObject quitBtnObj, backgroundCoverObj;
    [SerializeField] RectTransform caco;
    [SerializeField] private Animator landslideAnim;

    public void tryAgain()
    {        
        SceneManager.LoadScene("Scene 4");
    }

    public void changeToTryAgainInterface()
    {
        caco.position = new Vector3(0f, 0.75f, 0f);
        backgroundCoverObj.GetComponent<Image>().color = new Vector4(0f, 0f, 0f, 0.5f);
        showBackgroundCover();
        tryAgainButton.gameObject.SetActive(true);        
    }

    public void landslide() {
        landslideAnim.SetBool("Win", true);
    }

    public void hideBackgroundCover()
    {
        backgroundCoverObj.SetActive(false);
    }

    public void showBackgroundCover()
    {
        backgroundCoverObj.SetActive(true);
    }
}
