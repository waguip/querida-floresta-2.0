using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class slot4 : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject correctItem;
    [SerializeField] private ConnectController controller;
    [SerializeField] private AudioController audioController;    

    public void OnDrop(PointerEventData eventData)
    {
        var colors = GetComponent<Button>().colors;        

        if (eventData.pointerDrag == correctItem) {
            correctItem.GetComponent<DragAndDrop3>().correct = true;            
            controller.correct += 1;            
            audioController.hitSound();            
            colors.disabledColor = new Color32(80,255,80,180);                                    
        } else {
            controller.correct = -1;
            colors.disabledColor = new Color32(255,80,80,180);            
        }

        GetComponent<Button>().interactable = false;
        GetComponent<Button>().colors = colors;
    }
}
