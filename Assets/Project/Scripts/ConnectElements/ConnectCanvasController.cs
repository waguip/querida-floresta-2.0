using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ConnectCanvasController : MonoBehaviour
{    
    [SerializeField] private GameObject backgroundCoverObj, toucanObj, tryAgainInterface;
    [SerializeField] private LineRenderer[] lines;

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
        tryAgainInterface.SetActive(true);
        foreach (var line in lines)        
            line.positionCount = 0;        
    }

    public void setAnswerEffect(Button button, bool isRightAnswer) {

        Func<Color> getAnswerEffect = () => {
            return isRightAnswer ? new Color(0f, 1f, 0f) : new Color(1f, 0f, 0f);
        };

        Outline outline = button.gameObject.GetComponent<Outline>();

        if(outline != null) {
            outline.effectColor = getAnswerEffect();            
        } else {
            Image image = button.gameObject.GetComponent<Image>();
            image.color = getAnswerEffect();            
        }
    }
}
