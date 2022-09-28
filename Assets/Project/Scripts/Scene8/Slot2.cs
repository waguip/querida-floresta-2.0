using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot2 : MonoBehaviour, IDropHandler
{

    [SerializeField] private GameObject correctItem;
    [SerializeField] private Scene8Controller controller;
    [SerializeField] private AudioController audioController;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == correctItem) {
            correctItem.GetComponent<DragAndDrop>().correct = true;
            eventData.pointerDrag.transform.position = transform.position;      
            controller.correct += 1;
            audioController.hitSound();
            gameObject.SetActive(false);
        } else {
            controller.correct = -1;
        }
    }
}
