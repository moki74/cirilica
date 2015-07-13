using UnityEngine;
using System.Collections;

public class ns_leftArrowClick : MonoBehaviour {
	GameObject go;

	// Use this for initialization
	void OnStart()
	{
		//sl = Camera.main.GetComponent<slova> ();
	}

	void OnClick()
	{
		//go=(GameObject)Instantiate(Resources.Load("0Pref", typeof(GameObject)));
		//go.transform.parent = GameObject.Find ("Camera").transform;
	//	go.transform.localPosition = new Vector3 (0, 0, 0);
	//	go.transform.localScale = new Vector3 (129, 10, 0);

		//Debug.Log (slova.prethodno ());

		GameObject go = GameObject.FindWithTag ("slovoPrefab");

		if (go != null) {
						Destroy (go);
						Debug.Log ("U destroy :" + go.name);
				}
		path.ocisti ();
		na_slovo_manager.spremi_slike ();
		GameObject gos = Instantiate (Resources.Load (slova.prethodno ().ToString() + "vsPrefab")) as GameObject ;
		if (checkPrefs.current_user != null && checkPrefs.current_user._ruka == "леворук")
						gos.transform.position = new Vector3 (8f, 0f, 0f);
		gos.GetComponent<slovoPathovi> ().enabled = false;
		na_slovo_manager.spremi_slike ();
		GameObject.Find ("Manager").GetComponent<na_slovo_setup>().novoVreme ();
		
	
	}
}
