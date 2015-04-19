using UnityEngine;
using System.Collections;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class ucitavanje : MonoBehaviour {

	public UIInput ime,prezime;

	// Use this for initialization
	void Start () {
		Debug.Log ("PRE LOAD");
		ime.text = PlayerPrefs.GetString ("ime");
//		prezime.text = PlayerPrefs.GetString ("prezime");
		Debug.Log ("POSLE LOAD");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
