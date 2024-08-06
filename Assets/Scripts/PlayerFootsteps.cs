﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFootsteps : MonoBehaviour
{

    public AudioSource footstepPlayer;

    //public AudioClip[] tileSteps;
    //public AudioClip[] metalSteps;
    public AudioClip[] streetStepsWalk;
    public AudioClip[] streetStepsRun;




    // Start is called before the first frame update
    void Start()
    {
        footstepPlayer = GetComponent<AudioSource>();
    }

    private void PlayFootsteps()   
    {
        int randomIndex = Random.Range(0, streetStepsWalk.Length);
        AudioClip randomClip = streetStepsWalk[randomIndex];

        footstepPlayer.clip = randomClip;
        footstepPlayer.Play();
    }

    private void PlayRunningFootsteps()
    {
        int randomRunIndex = Random.Range(0, streetStepsRun.Length);
        AudioClip randomRunClip = streetStepsRun[randomRunIndex];

        footstepPlayer.clip = randomRunClip;
        footstepPlayer.Play();
    }
}