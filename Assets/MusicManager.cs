﻿using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	private AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	public void playSound(AudioClip clip){
		audioSource.Stop();
		audioSource.loop = false;
		audioSource.clip = clip;
		audioSource.Play();
	}
	
	
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
