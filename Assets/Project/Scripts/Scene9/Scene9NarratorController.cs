using UnityEngine;

public class Scene9NarratorController : NarratorController
{
    [SerializeField] private AudioSource introductionAudio, missClickAudio, rightClickAudio, helpAudio, congratsAudio;
    
    public float playIntroductionAudio()
    {
        playAudio(introductionAudio);
        return introductionAudio.clip.length;
    }
    
    public void playRightClickAudio()
    {
        playAudio(rightClickAudio);
    }

    public void playMissClickAudio()
    {
        playAudio(missClickAudio);
    }

    public void playHelpAudio()
    {
        playAudio(helpAudio);
    }

    public void playCongratsAudio()
    {
        playAudio(congratsAudio);        
    }

    public float congratsAudioLength() {
        return congratsAudio.clip.length;
    }
}
