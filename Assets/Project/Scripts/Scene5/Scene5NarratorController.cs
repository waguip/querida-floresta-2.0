﻿using UnityEngine;

public class Scene5NarratorController : NarratorController
{
    [SerializeField] private AudioSource introductionAudio, trashSelectedAudio, 
    cowSelectedAudio, treesSelectedAudio, aboutRootsAudio,
    aboutEvaporationAudio, aboutRainAudio, sceneCompletedAudio, helpAudio;
    [SerializeField] private AudioController audioController;

    /* All invoked by Scene5Controller */
    public void playIntroductionAudio()
    {
        playAudio(introductionAudio);
    }

    public void playTrashSelectedAudio()
    {
        playAudio(trashSelectedAudio);
    }

    public void playCowSelectedAudio()
    {
        playAudio(cowSelectedAudio);
    }

    public void playTreesSelectedAudio()
    {
        playAudio(treesSelectedAudio);        
    }

    public void playAboutRootsAudio()
    {
        playAudio(aboutRootsAudio);
    }

    public void playAboutEvaporationAudio()
    {
        playAudio(aboutEvaporationAudio);
    }

    public void playAboutRainAudio()
    {
        playAudio(aboutRainAudio);
    }

    public void playSceneCompletedAudio()
    {
        audioController.sceneCompletedSound();        
    }

    public void playHelpAudio()
    {
        playAudio(helpAudio);
    }
}
