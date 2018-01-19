using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform playerSpawnsPoints;
    public bool respawn;

    private Transform[] spawnPoints;
    private bool lastToggled = false;

    // Use this for initialization
    void Start () {
        spawnPoints = playerSpawnsPoints.GetComponentsInChildren<Transform>();	

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
}
