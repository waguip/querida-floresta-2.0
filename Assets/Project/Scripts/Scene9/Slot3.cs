using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot3 : MonoBehaviour, IDropHandler
{

    [SerializeField] private GameObject correctItem;
    [SerializeField] private Scene9Controller controller;
    [SerializeField] private AudioController audioController;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == correctItem) {
            correctItem.GetComponent<DragAndDrop2>().correct = true;
            eventData.pointerDrag.transform.position = transform.position;      
            controller.correct += 1;
            audioController.hitSound();
            gameObject.SetActive(false);
        } else {
            controller.correct = -1;
        }
    }
}
