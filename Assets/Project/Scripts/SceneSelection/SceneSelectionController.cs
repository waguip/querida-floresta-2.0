using UnityEngine;
using UnityEngine.UI;

public class SceneSelectionController : MonoBehaviour
{
    [SerializeField] private Button scene1Btn, scene2Btn, scene3Btn, scene4Btn, scene6Btn, scene8Btn, scene10Btn;
    [SerializeField] private AudioSource introAudio;

    void Start()
    {
        Button[] btns = {scene1Btn, scene2Btn, scene3Btn, scene4Btn, scene6Btn, scene8Btn, scene10Btn};        

        int x = 0;
        //Passa por todos os botões e os ativa
        for (int i = 0; i < btns.Length; i++) {            
            btns[i].interactable = true;                        

            //Pra continuar do 4, confere se passou do 5
            if(i == 3)
                x = 4;

            //Pra continuar do 6, confere se passou do 7
            if(i == 4)
                x = 6;

            //Pra continuar do 8, confere se passou do 9
            if(i == 5)
                x = 8;
            
            //Sai do loop ao encontrar uma fase ainda não completada
            if(x >= 9 || !Player.Instance.ScenesCompleted[x]) break;

            x++;
        }
    }

    public void playIntroductionAudio() {
        introAudio.Play();
    }
}