using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class close : MonoBehaviour {
	public GameObject manager;
	public GameObject[] model;

	public void closebutton()
	{
		
		if (manager.GetComponent<text_name_script> ().closecheck) {
			manager.GetComponent<text_name_script> ().closecheck = false;
		}
	}

	public void topbutton()
	{
		fadeout.next="title";
		fadeout.fade_ok = true;
	}
}
