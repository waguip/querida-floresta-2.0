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

    public void setAnswerEffect(Button button, bool isRightAnswer) {

        Func<Color> getAnswerEffect = () => {
            return isRightAnswer ? new Color(0f, 1f, 0f) : new Color(1f, 0f, 0f);
        };

        Outline outline = button.gameObject.GetComponent<Outline>();

        if(outline != null) {
            outline.effectColor = getAnswerEffect();
            StartCoroutine( ResetEffect(outline, true) );
        } else {
            Image image = button.gameObject.GetComponent<Image>();
            image.color = getAnswerEffect();
            StartCoroutine( ResetEffect(image, false) );
        }
    }

    IEnumerator ResetEffect(Component component, bool isOutline) {
        yield return new WaitForSeconds(2f);
        
        if(isOutline)
            ((Outline) component).effectColor = new Color(0.312f, 0.208f, 0f);
        else
            ((Image) component).color = new Color(1f, 1f, 1f);
    }
}
