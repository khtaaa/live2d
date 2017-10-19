using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event_script : MonoBehaviour {
	public int[] fade_black;
	public bool ok=false;

	// Use this for initialization
	void Start () {
		ok = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (ok == false) {
			for (int i=0; i == fade_black.Length; i++) {
				if (fade_black [i] == TextC.textnunber) {
					ok = true;
					//TextC.Event = true;

				}
			}
		}
	}
}
