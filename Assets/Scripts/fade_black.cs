using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade_black : MonoBehaviour {
	public bool fade_check=false;//フェード確認
	public int next=0;//次の画像
	public float speed;//フェードインフェードアウト速度
	public Image panel;//フェードインフェードアウト用パネル
	public SpriteRenderer SR;//切り替わる画像
	public Sprite[] SP;

	void Start () {
		fade_check = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (fade_check ) {
			StartCoroutine ("Fade");//フェードをコルーチンで開始
		}
	}

	IEnumerator Fade() {
		//フェードアウト
		for (float f = 0; f <= 1; f += Time.deltaTime*speed) {
			panel.color =new Color(0,0,0,f);

			yield return null;
		}
			
		panel.color =new Color(0,0,0,1);

		SR.sprite = SP [next];//画像切り替え

		//フェードイン
		for (float f = 1f; f >= 0; f -=  Time.deltaTime*speed) {
			panel.color =new Color(0,0,0,f);

			yield return null;
		}

		panel.color =new Color(0,0,0,0);

		fade_check = false;//フェード終了
	}
}
