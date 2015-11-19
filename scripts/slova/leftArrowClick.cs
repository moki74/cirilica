using UnityEngine;
using System.Collections;

public class leftArrowClick : MonoBehaviour {
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
		Instantiate(Resources.Load (slova.prethodno ().ToString() + "vsPrefab"));
		// proba sa TTFTextom
//        if (GameObject.Find ("TTFCreator").transform.childCount > 0)
//            DestroyImmediate( GameObject.Find ("TTFCreator").transform.GetChild(0).gameObject);
//        GameObject.Find ("TTFCreator").GetComponent<TTFText> ().Text="";
//        GameObject.Find ("TTFCreator").GetComponent<TTFText> ().Text=slova.trenutno_slovo.ToUpper();
//		GameObject.Find ("Manager").GetComponent<setup> ().novoVreme ();
		
	
	}
}
