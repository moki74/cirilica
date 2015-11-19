using UnityEngine;
using System.Collections;

public class ns_rightArrow : MonoBehaviour {

	// Use this for initialization
	void OnClick()
	{
		//Debug.Log (slova.sledece ());


		GameObject go = GameObject.FindWithTag ("slovoPrefab");
		if (go != null) {
		
						Destroy (go);
			          Debug.Log ("U destroy :" + go.name);
				}

		//path.ocisti ();


		GameObject gos = Instantiate (Resources.Load (slova.sledece().ToString() + "vsPrefab")) as GameObject ;
		if (checkPrefs.current_user != null && checkPrefs.current_user._ruka == "леворук")
			gos.transform.position = new Vector3 (8f, 0f, 0f);
		gos.GetComponent<slovoPathovi> ().enabled = false;
		na_slovo_manager.num_correct = 0;
		na_slovo_manager.spremi_slike ();
		GameObject.Find ("Manager").GetComponent<na_slovo_setup> ().novoVreme ();
	
	

	
		//Destroy (GameObject.Find("0Pref(Clone)"));
	//	PathNodes pn = (PathNodes)Camera.main.GetComponent<PathNodes> ();
	//	pn.kreirajPutokaz ();
	}
}
