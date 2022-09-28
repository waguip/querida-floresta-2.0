using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene5CanvasController : MonoBehaviour
{
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private GameObject backgroundCoverObj, toucanObj, tryAgainToucanObj, helpBtnObj, quitBtnObj, helpSignObj;

    public void hideBackgroundCover()
    {
        backgroundCoverObj.SetActive(false);
    }

    public void showBackgroundCover()
    {
        backgroundCoverObj.SetActive(true);
    }

    public void changeToTryAgainInterface()
    {
        toucanObj.SetActive(false);
        backgroundCoverObj.GetComponent<Image>().color = new Vector4(0f, 0f, 0f, 0.5f);
        showBackgroundCover();
        tryAgainToucanObj.SetActive(true);
        tryAgainButton.gameObject.SetActive(true);
    }

    private void setBtnsAndSignActive(bool isHelpInterfaceOn)
    {
        helpBtnObj.SetActive(!isHelpInterfaceOn);
        quitBtnObj.SetActive(!isHelpInterfaceOn);
        helpSignObj.SetActive(isHelpInterfaceOn);
    }

    public void changeToHelpInterface()
    {
        showBackgroundCover();
        setBtnsAndSignActive(true);
    }

    public void leaveHelpInterface()
    {
        setBtnsAndSignActive(false);
        hideBackgroundCover();
    }

    void Start()
    {
        tryAgainButton.onClick.AddListener(() => {
            SceneManager.LoadScene("Scene 5");
        });
    }
}
