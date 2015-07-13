using UnityEngine;
using System.Collections;

public class rightArrow : MonoBehaviour {

	// Use this for initialization
	void OnClick()
	{
		//Debug.Log (slova.sledece ());


		GameObject go = GameObject.FindWithTag ("slovoPrefab");
		if (go != null) {
		
						Destroy (go);
			          Debug.Log ("U destroy :" + go.name);
				}

		path.ocisti ();
		GameObject gos = Instantiate (Resources.Load (slova.sledece().ToString() + "vsPrefab")) as GameObject ;
		// Proba sa TTFTextom
//        if (GameObject.Find ("TTFCreator").transform.childCount > 0)
//            DestroyImmediate( GameObject.Find ("TTFCreator").transform.GetChild(0).gameObject);
//        GameObject.Find ("TTFCreator").GetComponent<TTFText> ().Text="";
//        GameObject.Find ("TTFCreator").GetComponent<TTFText> ().Text=slova.trenutno_slovo.ToUpper();
       
		GameObject.Find ("Manager").GetComponent<setup> ().novoVreme ();
	
	

	
		//Destroy (GameObject.Find("0Pref(Clone)"));
	//	PathNodes pn = (PathNodes)Camera.main.GetComponent<PathNodes> ();
	//	pn.kreirajPutokaz ();
	}
}
