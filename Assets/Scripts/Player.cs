using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Helicopter helicopter;
    public Transform playerSpawnsPoints;

    public AudioClip whatHappened;

    private bool respawn;
    private Transform[] spawnPoints;
    private bool lastToggled = false;
    private AudioSource innerVoice;

    // Use this for initialization
    void Start () {
        spawnPoints = playerSpawnsPoints.GetComponentsInChildren<Transform>();

        AudioSource[] audioSources = GetComponents<AudioSource>();

        foreach (AudioSource audioSource in audioSources) {
            if (audioSource.priority == 1) {
                innerVoice = audioSource;
            }
        }

        innerVoice.clip = whatHappened;
        innerVoice.Play();

    }
	
	// Update is called once per frame
	void Update () {
	    if (lastToggled != respawn) {
            Respawn();
            respawn = false;
        }	else {
            lastToggled = respawn;
        }
	}

    private void Respawn() {
        int i = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[i].transform.position;
    }

    void OnFindClearArea() {
        helicopter.Call();
    }
}
