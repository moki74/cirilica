
using UnityEngine;
using System.Collections;
using PlayerPrefs = PreviewLabs.PlayerPrefs;


public class snimanje : MonoBehaviour {
	public UIInput ime,prezime;
	// Use this for initialization
	void OnClick () {
		Debug.Log ("PRE SNIMI");
		PlayerPrefs.SetString ("ime", ime.text);
//		PlayerPrefs.SetString ("prezime", prezime.text);
		PlayerPrefs.Flush ();

		Debug.Log ("POSLE SNIMI");
	}
	
	// Update is called once per frame
	//void Update () {
	//
	//}
}
