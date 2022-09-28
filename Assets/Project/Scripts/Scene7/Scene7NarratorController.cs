using UnityEngine;

public class Scene7NarratorController : NarratorController
{
    [SerializeField] private AudioSource introductionAudio, correctAudio, missAudio, sceneCompletedAudio, helpAudio;
    [SerializeField] private AudioController audioController;

    /* All invoked by Scene2Controller */
    public void playIntroductionAudio()
    {
        playAudio(introductionAudio);
    }

    public void playCorrectAudio() {
        playAudio(correctAudio);
    }

    public void playMissAudio() {
        playAudio(missAudio);
    }

    public void playSceneCompletedAudio()
    {
        audioController.sceneCompletedSound();
        playAudio(sceneCompletedAudio);
    }

    public void playHelpAudio()
    {
        playAudio(helpAudio);
    }
}
