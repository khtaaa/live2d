using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			if (fade_to_black.fade_doun == false && fade_to_black.fade_up == false) {
				fade_to_black.fade_doun = true;
				fade_to_black.imageN++;
			}
		}
	}
}
