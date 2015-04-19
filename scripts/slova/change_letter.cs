using UnityEngine;
using System.Collections;

public class change_letter : MonoBehaviour {
	GameObject slovoPrefab; 
	GameObject exi;
	void OnClick()
	{
		exi = (GameObject)GameObject.FindWithTag("slovoPrefab");
		if(exi != null )
			Destroy (exi);
		string slovo = this.name;
		slovoPrefab= (GameObject)Instantiate(Resources.Load(slovo +"Pref"));
		Debug.Log ("Kliknuto A");
		//  pokreni timer za pokazivanje demoa
		GameObject.Find ("Manager").GetComponent<setup>().startTime=true;
		foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("losPath"))
		{
			//	   fooObj.AddComponent<Rigidbody>();
			//	fooObj.rigidbody.mass=100;
			Destroy (fooObj);
		}
		
		foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("dobarPath"))
		{
			  Destroy (fooObj);
		}
		//GameObject.Find ("Plane").
	}
}
