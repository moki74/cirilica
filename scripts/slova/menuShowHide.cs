using UnityEngine;
using System.Collections;

public class menuShowHide : MonoBehaviour {

	public GameObject target;
	bool radi =false;
	bool open = false;
	private GameObject[] gadgets;
	// Use this for initialization
	void OnClick()
	{
		if(!open)
		{
			if(!radi) 
			{
				iTweenEvent.GetEvent(target, "Open").Play();
				open = radi=true;
				mangerScript.Draw=false;
				Debug.Log("TOVORENO");
			}
		}
		else
		{
			if(!radi) 
			{
				string gadgetName = target.name;
				gadgets=GameObject.FindGameObjectsWithTag(gadgetName +"Gadgets");
				
				foreach (GameObject gadget in gadgets) {
					gadget.SetActive (false);
				

				}
				iTweenEvent.GetEvent(target, "Close").Play();
				open=false;
				radi=true;
				mangerScript.Draw=true;
			}
		}
	}
	void zavrseno()
	{
		radi = false;
		Debug.Log ("STOP");
	}
}
