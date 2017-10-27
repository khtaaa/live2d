using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scroll : MonoBehaviour {
	　public float speed = 0.1f;// スクロールスピード
	public Camera came;
	public int spritecount=3;

	void Update () {
		transform.localPosition += (Vector3.left+Vector3.up) * speed * Time.deltaTime;
		}

	void OnBecameInvisible()
	{
		//スプライトの幅、高さを獲得
		float width=GetComponent<SpriteRenderer>().bounds.size.x;
		float hight = GetComponent<SpriteRenderer> ().bounds.size.y;


		if (came.transform.position.y < transform.position.y) {
			transform.localPosition+=Vector3.down*hight*spritecount;
		}

		if(came.transform.position.x > transform.position.x)
		{
			transform.localPosition+=Vector3.right*width*spritecount;
		}
	}
}
