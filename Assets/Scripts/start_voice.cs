using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_voice : MonoBehaviour {
    public AudioClip[] voice;
    AudioSource AS;

	// Use this for initialization
	void Start () {
        AS = GetComponent<AudioSource>();
        AS.PlayOneShot(voice[Random.Range(0, voice.Length)]);
	}

}
