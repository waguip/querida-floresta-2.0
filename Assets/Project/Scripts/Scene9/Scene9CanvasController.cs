using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene9CanvasController : MonoBehaviour
{
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private GameObject quitBtnObj, backgroundCoverObj;
    [SerializeField] RectTransform caco;
        private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void tryAgain()
    {        
        SceneManager.LoadScene("Scene 9");
    }   

    public void changeToTryAgainInterface()
    {            
        backgroundCoverObj.GetComponent<RectTransform>().SetAsLastSibling();
        backgroundCoverObj.GetComponent<Image>().color = new Vector4(0f, 0f, 0f, 0.5f);
        showBackgroundCover();
        tryAgainButton.GetComponent<RectTransform>().SetAsLastSibling();
        tryAgainButton.gameObject.SetActive(true);
        caco.SetAsLastSibling();
        caco.position = new Vector3(0f, 0.75f, 0f);        
    }

    public void hideBackgroundCover()
    {
        backgroundCoverObj.SetActive(false);
    }

    public void showBackgroundCover()
    {
        backgroundCoverObj.SetActive(true);
    }

    public void windPreventionAnimation() {
        animator.SetTrigger("wind");
    }
}
