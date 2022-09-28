using UnityEngine;

public class Scene6NarratorController : NarratorController
{
    [SerializeField] private AudioSource introductionAudio, treesSelectedAudio, sceneCompletedAudio, helpAudio;
    [SerializeField] private AudioController audioController;

    /* All invoked by Scene2Controller */
    public void playIntroductionAudio()
    {
        playAudio(introductionAudio);
    }

    public void playTreesSelectedAudio()
    {
        playAudio(treesSelectedAudio);
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
