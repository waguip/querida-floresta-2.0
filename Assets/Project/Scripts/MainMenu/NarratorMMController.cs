using UnityEngine;

public class NarratorMMController : NarratorController
{
    [SerializeField] private AudioSource speechAudio, cacoIntro;

    public AudioSource SpeechAudio { get { return speechAudio; } }

    public float playSpeechAudio() {
        playAudio(speechAudio);
        return speechAudio.clip.length;
    }

    public float playSpeechAudioCaco() {
        playAudio(cacoIntro);
        return cacoIntro.clip.length;
    }
}
