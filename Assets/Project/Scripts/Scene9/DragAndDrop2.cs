using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{    

    [SerializeField] private AudioController audioController;
    private CanvasGroup canvasGroup;
    private RectTransform panel, trans;
    [SerializeField] private Canvas canvas;
    public bool correct;
    private Vector2 originalPosition, originalSize;
    [SerializeField] private RectTransform slotSize;

    private void Awake() 
    {
        trans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        panel = GetComponentInParent<RectTransform>();        
        originalPosition = trans.anchoredPosition;     
        originalSize = GetComponent<RectTransform>().sizeDelta;
        correct = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        audioController.buttonClickedSound();
        panel.SetAsLastSibling();

        GetComponent<RectTransform>().sizeDelta = slotSize.sizeDelta;
    }

    public void OnDrag(PointerEventData eventData)
    {
        trans.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }    

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!correct) {            
            canvasGroup.blocksRaycasts = true;     
            trans.anchoredPosition = originalPosition;   
            GetComponent<RectTransform>().sizeDelta = originalSize;
        } else {
            canvasGroup.interactable = false;
        }
    }
}
