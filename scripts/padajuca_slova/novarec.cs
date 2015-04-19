using UnityEngine;
using System.Collections;

public class novarec : MonoBehaviour {
	public GameObject btnmesaj;

	// Use this for initialization
	void OnClick() {
		manager man = GameObject.Find ("Manager").GetComponent<manager> ();
		man.formirajnovurec ();
		//GameObject go = GameObject.Find ("Container");
		btnmesaj.SetActive(true);

	}
}
