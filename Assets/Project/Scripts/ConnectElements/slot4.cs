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
        if (eventData.pointerDrag == correctItem) {
            correctItem.GetComponent<DragAndDrop3>().correct = true;            
            controller.correct += 1;
            audioController.hitSound();
            GetComponent<Button>().interactable = false;
        } else {
            controller.correct = -1;
        }
    }
}
