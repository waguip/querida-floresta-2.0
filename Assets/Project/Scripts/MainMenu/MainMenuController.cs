using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private Button startButton, speechButton, speechButton2, statisticsButton;
    [SerializeField] private GameObject buttonsObj, toco, caco;
    [SerializeField] private NarratorMMController narratorController;
    [SerializeField] private GoogleSheetsController sheetsController;
    private AudioClip speechClip;
    private float clipLength;    
    [SerializeField] private Animator animatorCaco;

    void Start() // Start is called before the first frame update
    {
        speechClip = narratorController.SpeechAudio.clip; 
        statisticsButton.interactable = Player.Instance.ScenesCompleted[0];

        if(!Player.Instance.ScenesCompleted[0]) {
            startButton.onClick.AddListener(NewGameStarted);
        }
        else {
            startButton.GetComponentInChildren<Text>().text = "ATIVIDADES";
            startButton.onClick.AddListener(sceneLoader.loadSceneSelection);
        }
    }

    private void NewGameStarted()
    {
        if (AplicationModel.isFirstTimeScene1) {
            HideButtonsPlaySpeech(false);
            sceneLoader.Invoke("loadScene1", speechClip.length + 1);
            AplicationModel.isFirstTimeScene1 = false;
        }
        else sceneLoader.loadScene1();
    }

    private void ShowButtons() // Invoked by hideButtonsPlaySpeech()
    {
        buttonsObj.SetActive(true);
        toco.SetActive(true);
        caco.SetActive(true);
    }

    public void HideButtonsPlaySpeech(bool isCaco) // Called by button (BtSpeech)
    {
    
        buttonsObj.SetActive(false);

        if(isCaco){
            clipLength = narratorController.playSpeechAudioCaco();            
            toco.SetActive(false);
            animatorCaco.SetBool("isSpeaking", true);
            Invoke("stopSpeakingAnimation", clipLength);
        } else {
            clipLength = narratorController.playSpeechAudio();
            caco.SetActive(false);            
        }

        Invoke("ShowButtons", clipLength + 1);        
    }

    private void stopSpeakingAnimation()
    {
        animatorCaco.SetBool("isSpeaking", false);
    }

    public void QuitButtonAction()
    {
        Player.Instance.ClearData();
        sceneLoader.loadAuthMenu();
    }
}
