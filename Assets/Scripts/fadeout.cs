using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using live2d;

public class fadeout : MonoBehaviour {
	public float speed = 0.01f;
	public float alfa;
	public static bool fade_ok;
	public static string next;

	// Use this for initialization
	void Start () {
		alfa = 0;
		fade_ok = false;
		next = null;
	}

	// Update is called once per frame
	void Update () {
		if (fade_ok) {
			alfa += speed;
			GetComponent<Image> ().color = new Color (0, 0, 0, alfa);
			if (alfa > 1) {
				fade_ok = false;
				SceneManager.LoadScene (next);
			}
		}
	}
}
