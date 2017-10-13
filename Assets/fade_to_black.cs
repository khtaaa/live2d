using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade_to_black : MonoBehaviour {
	public float speed=0.01f;
	public float alfa;
	float red,blue,green;
	public static bool fade_doun;
	public static bool fade_up;
	public GameObject panel;
	public Sprite[] SP;
	SpriteRenderer IM;
	public static int imageN;

	// Use this for initialization
	void Start () {
		imageN = 0;
		red =  panel.GetComponent<Image> ().color.r;
		green =  panel.GetComponent<Image> ().color.g;
		blue =  panel.GetComponent<Image> ().color.b;
		alfa = 0;
		fade_doun = false;
		fade_up = false;
		IM =GetComponent < SpriteRenderer > ();
		IM.sprite = SP [imageN];
	}
	
	// Update is called once per frame
	void Update () {
		if (fade_doun) {
			alfa += speed;
			panel.GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			if (alfa > 1) {
				fade_doun = false;
				IM.sprite= SP [imageN];
				fade_up = true;

			}
		}

		if (fade_up) {
			alfa -= speed;
			panel.GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			if (alfa <= 0) {
				fade_up = false;

			}
		}
	}
}
