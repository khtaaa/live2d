using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_name_script : MonoBehaviour {

	[System.Serializable] //inspectorに表示
	public struct textStatus
	{
		public string Name;//名前
		public int imagecount;//画像番号
		public int buckguraundcount;//背景番号
		public string text;//テキスト
		public bool Event;//イベント
	}
	public textStatus[] TS;//structを配列

	public float timer;//一文字表示タイマー
	public string nextstory;//text次の保存用
	public Text nametext;//名前用のtext
	public Text storytext;//text
	public int textnunber=0;//文字カウント（現在の現在の文字数）
	public int alltextnunber=0;//テキストの配列の番号
	public float speed;//一文字表示の時間
	public bool textcheck;//テキストが表示されてる最中かそうでないか
	public bool closecheck=true;//textboxが表示か非表示か

	public GameObject textbox;//テキストボックス
	public Image nextsin;//次のテクストが表示可能なら右下あるやつ

	public GameObject[] chracter;//キャラクター立ち絵（live2d）
	public GameObject closeobj;//閉じるボタン
	public GameObject topbutton;//topボタン

	void Start () {
		Eventcheck ();

	}

	//閉じるボタンにカーソルあるかどうか
	public bool pos()
	{
		float width = closeobj.transform.GetComponent<RectTransform>().sizeDelta.x;
		float height = closeobj.transform.GetComponent<RectTransform>().sizeDelta.y;
		float mposx = Input.mousePosition.x;
		float mposy = Input.mousePosition.y;
		return ((mposx > closeobj.transform.position.x-width/2) &&
			(mposx<closeobj.transform.position.x+width/2)&&
			(mposy>closeobj.transform.position.y-height/2)&&
			(mposy<closeobj.transform.position.y+height/2));
	}

	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) {
			Application.Quit ();
		}

		if (closecheck) {
			
			//-----すべて表示-----
			nametext.enabled = true;//名前用テキスト
			storytext.enabled = true;//シナリオ用テキスト
			nextsin.enabled = true;//右下のやつ
			textbox.SetActive (true);//テキストボックス
			closeobj.SetActive (true);//閉じるボタン
			topbutton.SetActive(true);//topボタン

			//-----すべて表示-----

			if (textcheck) {
			
				nextsin.enabled = false;
				//口パク
				for (int i = 0; i < chracter.Length; i++) {
					chracter [i].GetComponent<live2dscript> ().mouthcheck = true;
				}

				//テキスト表示最中にクリックしたとき最後までテキストを表示させる
				if ((Input.GetMouseButtonUp (0)) && !pos()) {
					nexttext ();
					textcheck = false;
				}

				//現在の文字数が最後まで表示されるまで起動
				if (textnunber < nextstory.Length) {

					timer += Time.deltaTime;//時間カウント

					//一定時間ごとに文字の判定
					if (timer > speed) {
						//表示する文字が半角スペースなら改行それ以外ならそのまま表示
						if (nextstory [textnunber] == ' ') {
							storytext.text += "\n";//改行
						} else {
							storytext.text += nextstory [textnunber];//一文字追加
						}
						timer = 0;//タイマー初期化
						textnunber++;//文字カウントを進める
					}
				}

				//文字をすべて表示されていたら表示を終了
				if (textnunber == nextstory.Length) {
					textcheck = false;//表示終了
				}

			} else {
				nextsin.enabled = true;//右下のやつ
				//口パク
				for (int i = 0; i < chracter.Length; i++) {
					chracter [i].GetComponent<live2dscript> ().mouthcheck = false;
				}

				//表示が終了してるときにクリックしたら次のテキストに切り替える
				if (Input.GetMouseButtonUp (0) && GetComponent<fade_black> ().fade_check == false) { 
					Eventcheck ();
				}
			}
		} else {

			//-----キャラクター以外非表示-----
			nametext.enabled = false;//名前用テキスト
			storytext.enabled = false;//シナリオ用テキスト
			nextsin.enabled = false;//右下のやつ
			textbox.SetActive (false);//テキストボックス
			closeobj.SetActive (false);//閉じるボタン
			topbutton.SetActive(false);//topボタン

			//-----キャラクター以外非表示-----

			//口パク停止
			for (int i = 0; i < chracter.Length; i++) {
				chracter [i].GetComponent<live2dscript> ().mouthcheck = false;
			}

			//非表示解除
			if (Input.GetMouseButtonDown (0)) {
				closecheck = true;
			}
		}
	}

	//いっきにテキストを最後まで表示させる
	void nexttext()
	{
		for (; textnunber<nextstory.Length; textnunber++) {
			if (nextstory[textnunber] == ' ') {
				storytext.text += "\n";//改行
			} else {
				storytext.text +=nextstory [textnunber];//１文字追加
			}
		}
	}

	void Eventcheck()
	{
		

		//次の文章があれば実行
		if (alltextnunber < TS.Length) {
			for (int c = 0; c < chracter.Length; c++) {
				if (c == TS[alltextnunber].imagecount-1) {
					chracter [c].SetActive (true);
				} else {
					chracter [c].SetActive (false);
				}
			}

			//暗転のイベントがあるか判定
			if (TS [alltextnunber].Event) {
				GetComponent<fade_black> ().next = TS [alltextnunber].buckguraundcount;//背景番号入力
				GetComponent<fade_black> ().fade_check = true;//フェードアウト開始
				storytext.text = "";//テキスト初期化
				nametext.text="";//名前初期化
			} else {
				//イベントがなければ次のテキストを表示
				nametext.text = TS [alltextnunber].Name;//次の名前を表示
				nextstory = TS [alltextnunber].text;//次のテキスト代入
				textnunber = 0;//文字数カウント初期化
				storytext.text = "";//テキスト初期化
				textcheck = true;//表示開始	
			}
			alltextnunber++;//次の配列に
		}
	}
}

