
using UnityEngine;
using System.Collections;

public class odaberi_igru : MonoBehaviour {

	void Awake()
	{
				//Screen.orientation = ScreenOrientation.LandscapeRight;
	}

	// Use this for initialization

	void Start()
	{
		slova.indeks = -1;
	}
	void OnClick(){
		Debug.Log (gameObject.name);

		if (gameObject.name != "exit")
						Application.LoadLevel (this.gameObject.name);
				else {
						Debug.Log ("QUIT");
						Application.Quit ();
				}
		}
}
