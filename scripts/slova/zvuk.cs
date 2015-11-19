using UnityEngine;
using System.Collections;

public class zvuk : MonoBehaviour {

	public UILabel file;
	// Use this for initialization
	void OnClick (){
		Debug.Log (file.text);
		string filename = file.text;
		sound.playEffect ( filename.ToLower (),0.5f);
	}
}
