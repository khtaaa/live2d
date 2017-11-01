using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scroll : MonoBehaviour {
	　public float speed = 0.1f;// スクロールスピード
	public Camera came;
	public int spritecount=3;
	public string test;
	float hight;
	float width;
	void Start()
	{
		//スプライトの幅、高さを獲得
		 width=GetComponent<SpriteRenderer>().bounds.size.x;
		 hight = GetComponent<SpriteRenderer> ().bounds.size.y;
	}

	void Update () {
		transform.localPosition += (Vector3.left + Vector3.up) * speed * Time.deltaTime;

		if (came.transform.position.y + hight * 2 < transform.position.y) {
			transform.localPosition += Vector3.down * hight * spritecount;
		} else if (came.transform.position.x - width * 2 > transform.position.x) {
			transform.localPosition += Vector3.right * width * spritecount;
		}
	}

}
