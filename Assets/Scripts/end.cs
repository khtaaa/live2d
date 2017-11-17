using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour {

	public Text Nametext;//名前
	public string[] name;//名前

	float instcount=0;
	float insttime=3;

	public GameObject canvas;

	int nunber=0;

	// Use this for initialization
	void Start () {
		inst ();
	}
	
	// Update is called once per frame
	void Update () {
		instcount += Time.deltaTime;
		if (instcount > insttime) {
			instcount = 0;
			inst ();
		}
	}

	void inst(){
		if (nunber < name.Length) {
			Text _text = Instantiate (Nametext) as Text;//テキスト作成
			_text.transform.SetParent (canvas.transform, false);//テキストをキャンバスの子に
			_text.text = "" + name [nunber];
			nunber++;
		} else {
			Invoke ("go_title", 10.0f);
		}

	}

	void go_title()
	{
		SceneManager.LoadScene ("title");
	}
}
