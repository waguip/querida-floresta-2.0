using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop3 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler       
{

    [SerializeField] private AudioController audioController;
    private CanvasGroup canvasGroup;
    private RectTransform trans;
    private LineRenderer line;
    [SerializeField] private Canvas canvas;
    public bool correct;

    private Vector2 originalPosition;

    private void Awake() 
    {
        trans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = trans.anchoredPosition;        
        line = GetComponent<LineRenderer>();
        correct = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        audioController.buttonClickedSound();

        line.positionCount = 1;        
        line.SetPosition(0, new Vector3(eventData.pointerCurrentRaycast.worldPosition.x, eventData.pointerCurrentRaycast.worldPosition.y, 0));
    }

    public void OnDrag(PointerEventData eventData)
    {
        line.positionCount = 2;
        line.SetPosition(1, new Vector3(eventData.pointerCurrentRaycast.worldPosition.x, eventData.pointerCurrentRaycast.worldPosition.y, 0));
        trans.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }    

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!correct) {            
            canvasGroup.blocksRaycasts = true;     
            trans.anchoredPosition = originalPosition;            
        } else {
            canvasGroup.interactable = false;
            GetComponentInParent<Button>().interactable = false;
        }
    }
}
