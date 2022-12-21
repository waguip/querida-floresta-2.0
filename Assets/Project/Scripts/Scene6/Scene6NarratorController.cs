using UnityEngine;

public class Scene6NarratorController : NarratorController
{
    [SerializeField] private AudioSource introductionAudio, sceneCompletedAudio;
    [SerializeField] private AudioController audioController;

    /* All invoked by Scene2Controller */
    public void playIntroductionAudio()
    {
        playAudio(introductionAudio);
    }

    public void playSceneCompletedAudio()
    {        
        audioController.sceneCompletedSound();
        playAudio(sceneCompletedAudio);        
    }    
}
