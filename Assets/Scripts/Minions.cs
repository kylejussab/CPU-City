﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
public class Minions : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent navAgent;
    //private Animator animator;
    private Vector3 lastPosition;
    private float speed;

    public List<AudioClip> minionSFX;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = GameObject.FindObjectOfType<OneWheelMovement>().transform;

        navAgent = this.GetComponent<NavMeshAgent>();
        //animator = this.GetComponent<Animator>();
        audioSource = this.GetComponent<AudioSource>();

        lastPosition = this.transform.position;
        navAgent.speed = Random.Range(0.5f, 1.25f);
        navAgent.SetDestination(player.position);

        StartCoroutine(PlaySFX());
    }

    // Update is called once per frame
    void Update()
    {
        if (navAgent.remainingDistance < 2f || (this.transform.position - lastPosition).sqrMagnitude > 10f)
            navAgent.SetDestination(player.position);

        speed = (this.transform.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = this.transform.position;

        //animator.SetFloat("speed", speed);
    }

    IEnumerator PlaySFX()
    {
        if (!audioSource.isPlaying)
        {
            yield return new WaitForSeconds(Random.Range(1, 20));
            AudioClip clip = minionSFX[Random.Range(0, minionSFX.Count)];
            audioSource.PlayOneShot(clip);
            StartCoroutine(PlaySFX());
        }
        else
        {
            yield return null;
            StartCoroutine(PlaySFX());
        }
    }

    public void Die()
    {
        //animator.SetTrigger("dead");
        StopAllCoroutines();
        audioSource.PlayOneShot(minionSFX[Random.Range(0, minionSFX.Count)]);
        navAgent.isStopped = true;
        this.enabled = false;
    }
}