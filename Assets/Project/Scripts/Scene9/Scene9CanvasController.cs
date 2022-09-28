using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene9CanvasController : MonoBehaviour
{
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private GameObject toucanObj, quitBtnObj, backgroundCoverObj;

    public void tryAgain()
    {        
        SceneManager.LoadScene("Scene 9");
    }   

    public void changeToTryAgainInterface()
    {
        toucanObj.SetActive(false);
        backgroundCoverObj.GetComponent<RectTransform>().SetAsLastSibling();
        backgroundCoverObj.GetComponent<Image>().color = new Vector4(0f, 0f, 0f, 0.5f);
        showBackgroundCover();
        tryAgainButton.GetComponent<RectTransform>().SetAsLastSibling();
        tryAgainButton.gameObject.SetActive(true);        
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
