using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour {
	public allmanager[] AM;
	[System.Serializable]
	public struct allmanager
	{
		public string name;//名前
		public int gazou;//キャラの画像番号
		public int buckgraund;//背景の番号
		public bool Event;//イベント確認
		public string text;//シナリオ
	}

	public Text nametext;//名前テキスト
	[SerializeField]Text storytext;//シナリオテキスト
	//[SerializeField][Range(0.001f, 0.3f)]

	public int storynunber=0;//現在のシナリオ番号

	public Image IM;
	public Sprite[] SP;

	//public string[] scenarios;
	//[SerializeField] Text uiText;


	float intervalForCharacterDisplay = 0.05f;

	private string currentText = string.Empty;
	private float timeUntilDisplay = 0;
	private float timeElapsed = 1;
	//public static int textnunber = 0;//現在のテキストナンバー
	private int lastUpdateCharacter = -1;



	// 文字の表示が完了しているかどうか
	public bool IsCompleteDisplayText 
	{
		get { return  Time.time > timeElapsed + timeUntilDisplay; }
	}

	void Start () {
		Eventcheck ();
	}
	
	// Update is called once per frame
	void Update () {
		if (storynunber < AM.Length && Input.GetMouseButtonDown (0) && fade_to_black.fade_doun==false && fade_to_black.fade_up==false) {
			Debug.Log ("クリック");
			if (IsCompleteDisplayText) {
				Eventcheck ();
			} else {
				// 完了してないなら文字をすべて表示する
					timeUntilDisplay = 0;
			}
		}

		int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
		if( displayCharacterCount != lastUpdateCharacter ){
			//uiText.text = currentText.Substring(0, displayCharacterCount);
			storytext.text = currentText.Substring(0, displayCharacterCount);
			lastUpdateCharacter = displayCharacterCount;
		}
	}

	void SetNextLine()
	{
		currentText = AM[storynunber].text;
		timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
		timeElapsed = Time.time;
		lastUpdateCharacter = -1;
		//textnunber ++;

	}

	void Eventcheck()
	{
		IM.color = new Color (IM.color.r, IM.color.b, IM.color.g, 1);
		if (AM [storynunber].gazou == 0) {
			IM.color = new Color (IM.color.r, IM.color.b, IM.color.g, 0);
		}
		IM.sprite = SP [AM[storynunber].gazou];
		nametext.text = AM [storynunber].name;//現在の名前表示
		if (AM [storynunber].Event) {
			Debug.Log ("暗転");
			fade_to_black.imageN = AM [storynunber].buckgraund;//暗転後の画像の番号を指定
			fade_to_black.fade_doun = true;//暗転開始
			nametext.text = null;//名前を空白に
			storytext.text = null;//テキストを空白に

		} else {
			//イベントじゃなければテキストを更新
			SetNextLine ();
		}
		storynunber++;//次のシナリオに

	}
}
