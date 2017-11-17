using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 10.0f);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localPosition += Vector3.up;//UI移動
	}
}
