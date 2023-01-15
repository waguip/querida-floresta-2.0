using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene8CanvasController : MonoBehaviour
{
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private GameObject quitBtnObj, backgroundCoverObj, rock;
    [SerializeField] RectTransform caco;    
    [SerializeField] private Sprite rockAfter;
    [SerializeField] private Animator animator;
    
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void tryAgain()
    {        
        SceneManager.LoadScene("Scene 8");
    }   

    public void changeToTryAgainInterface()
    {
        caco.position = new Vector3(0f, 0.75f, 0f);
        backgroundCoverObj.GetComponent<Image>().color = new Vector4(0f, 0f, 0f, 0.5f);
        showBackgroundCover();
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

    public void changeRock() {
        rock.GetComponent<Image>().sprite = rockAfter;
    }

    public void erosionAnimation() {
        animator.SetTrigger("Erode");
    }
}
