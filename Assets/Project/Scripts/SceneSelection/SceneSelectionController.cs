using UnityEngine;
using UnityEngine.UI;

public class SceneSelectionController : MonoBehaviour
{
    [SerializeField] private Button scene1Btn, scene2Btn, scene3Btn, scene4Btn, scene5Btn, scene6Btn, scene7Btn;

    void Start()
    {
        Button[] btns = {scene1Btn, scene2Btn, scene3Btn, scene4Btn, scene5Btn, scene6Btn, scene7Btn};        

        //Passa por todos os botões e os ativa
        for (int i = 0; i < btns.Length; i++) {
            btns[i].interactable = true;
            //Sai do loop ao encontrar uma fase ainda não completada
            if(!Player.Instance.ScenesCompleted[i]) break;          
        }
    }
}