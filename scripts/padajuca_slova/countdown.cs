using UnityEngine;
using System.Collections;

public class countdown : MonoBehaviour {

	// Use this for initialization
	void OnClick() {
		manager man = GameObject.Find ("Manager").GetComponent<manager> ();
		man.mesaj = true;
		//man.razmesti_slova ();
	
	}
	
	// Update is called once per frame

}
