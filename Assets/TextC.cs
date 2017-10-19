using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextC : MonoBehaviour {
	public string[] scenarios;
	[SerializeField] Text uiText;

	[SerializeField][Range(0.001f, 0.3f)]
	float intervalForCharacterDisplay = 0.05f;

	private string currentText = string.Empty;
	private float timeUntilDisplay = 0;
	private float timeElapsed = 1;
	public static int textnunber = 0;//現在のテキストナンバー
	private int lastUpdateCharacter = -1;
	public bool Event=false;
	public int[] FadeBlack_nunber;

	// 文字の表示が完了しているかどうか
	public bool IsCompleteDisplayText 
	{
		get { return  Time.time > timeElapsed + timeUntilDisplay; }
	}

	void Start()
	{
		Event = false;
		SetNextLine();

	}

	void Update () 
	{
		

		// 文字の表示が完了してるならクリック時に次の行を表示する
		if( IsCompleteDisplayText ){
			if(textnunber < scenarios.Length && Input.GetMouseButtonDown(0)){
				FadeBlackEvent ();

				if (Event == false) {
					
					SetNextLine ();
				}
			}
		}else{
			// 完了してないなら文字をすべて表示する
			if(Input.GetMouseButtonDown(0)){
				timeUntilDisplay = 0;
			}
		}

		int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
		if( displayCharacterCount != lastUpdateCharacter ){
			uiText.text = currentText.Substring(0, displayCharacterCount);
			lastUpdateCharacter = displayCharacterCount;
		}
	}


	void SetNextLine()
	{
		currentText = scenarios[textnunber];
		timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
		timeElapsed = Time.time;
		lastUpdateCharacter = -1;
		textnunber ++;
		//FadeBlackEvent ();

	}

	void FadeBlackEvent()
	{
		for (int i = 0; i < FadeBlack_nunber.Length; i++) {
			Debug.Log (i);
			if (FadeBlack_nunber [i] == textnunber) {
				Event = true;
				fade_to_black.fade_doun = true;
				fade_to_black.imageN++;
				if (fade_to_black.fadefinish==true) {
					Event = false;
				}
			}
		}
	}
}
