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
	public string storytext;//text次の保存用
	public Text nametext;//名前用のtext
	public Text textbox;//text
	public int textnunber=0;//文字カウント（現在の現在の文字数）
	public int alltextnunber=0;//テキストの配列の番号
	public float speed;//一文字表示の時間
	public bool textcheck;//テキストが表示されてる最中かそうでないか

	void Start () {
		Eventcheck ();
	}

	void Update () {

		if (textcheck) {
			//テキスト表示最中にクリックしたとき最後までテキストを表示させる
			if (Input.GetMouseButtonUp (0)) {
				nexttext();
				textcheck = false;
			}

			//現在の文字数が最後まで表示されるまで起動
			if (textnunber < storytext.Length) {

				timer += Time.deltaTime;//時間カウント

				//一定時間ごとに文字の判定
				if (timer > speed) {
					//表示する文字が半角スペースなら改行それ以外ならそのまま表示
					if (storytext [textnunber] == ' ') {
						textbox.text += "\n";//改行
					} else {
						textbox.text += storytext [textnunber];//一文字追加
					}
					timer = 0;//タイマー初期化
					textnunber++;//文字カウントを進める
				}
			}

			//文字をすべて表示されていたら表示を終了
			if (textnunber ==storytext.Length) {
				textcheck = false;//表示終了
			}

		} else {
			//表示が終了してるときにクリックしたら次のテキストに切り替える
			if (Input.GetMouseButtonUp (0) && GetComponent<fade_black> ().fade_check ==false){ 
				Eventcheck ();
			}
		}
	}

	//いっきにテキストを最後まで表示させる
	void nexttext()
	{
		for (; textnunber<storytext.Length; textnunber++) {
			if (storytext[textnunber] == ' ') {
				textbox.text += "\n";//改行
			} else {
				textbox.text +=storytext [textnunber];//１文字追加
			}
		}
	}

	void Eventcheck()
	{
		//次の文章があれば実行
		if (alltextnunber < TS.Length) {
			//暗転のイベントがあるか判定
			if (TS [alltextnunber].Event) {
				GetComponent<fade_black> ().next = TS [alltextnunber].buckguraundcount;
				GetComponent<fade_black> ().fade_check = true;
				textbox.text = "";//テキスト初期化
				nametext.text="";//名前初期化
			} else {
				//イベントがなければ次のテキストを表示
				nametext.text = TS [alltextnunber].Name;//次の名前を表示
				storytext = TS [alltextnunber].text;//次のテキスト代入
				textnunber = 0;//文字数カウント初期化
				textbox.text = "";//テキスト初期化
				textcheck = true;//表示開始	
			}
			alltextnunber++;//次の配列に
		}
	}
}

