using UnityEngine;

public class Scene7NarratorController : NarratorController
{
    [SerializeField] private AudioSource introductionAudio, correctAudio, missAudio;
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
}
