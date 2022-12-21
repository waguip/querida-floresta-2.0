using UnityEngine;

public class ConnectNarratorController : NarratorController
{
    [SerializeField] private AudioSource introductionAudio, missClickAudio, congratsAudio;
    
    public float playIntroductionAudio()
    {
        playAudio(introductionAudio);
        return introductionAudio.clip.length;
    }

    public void playMissClickAudio()
    {
        playAudio(missClickAudio);
    }

    public void playCongratsAudio()
    {
        playAudio(congratsAudio);        
    }

    public float congratsAudioLength() {
        return congratsAudio.clip.length;
    }
}
