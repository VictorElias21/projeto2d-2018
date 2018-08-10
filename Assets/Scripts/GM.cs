﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

	public static GM instance = null;

	public float yMinLive = -9f;
	public Transform SpawnPoint;

	public GameObject PlayerPrefab;

	PlayerCtrl player;

	public float timeToRespawn = 2f;

	void Awake() {
		if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		if (player == null) {
			RespawnPlayer();

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			GameObject obj = GameObject.FindGameObjectWithTag("Player");
			if (obj != null) {
				player = obj.GetComponent<PlayerCtrl>();
			}
		}
	}

	public void RespawnPlayer(){
		Instantiate(PlayerPrefab, SpawnPoint.position, SpawnPoint.rotation);
	}

	public void KillPlayer(){
		if(player != null){
			Destroy(player.gameObject);
			Invoke("RespawnPlayer", timeToRespawn);
		}
	}	

}
