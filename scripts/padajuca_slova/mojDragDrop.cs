using UnityEngine;
using System.Collections;

public class mojDragDrop : UIDragDropItem {

	public GameObject prefab;
	private int all;
	//private int curr=0;
	static int curr = 0;
	
	/// <summary>
	/// Drop a 3D game object onto the surface.
	/// </summary>
	
	protected override void OnDragDropRelease (GameObject surface)
	{

		Debug.Log ("RELASE:");
		if (surface != null)
		{

			Debug.Log (surface.name);
			if (surface.name.Contains (this.gameObject.name) ||surface.name.Contains (this.gameObject.name.Substring (1,1)) )
			   {
					Debug.Log ("U REDU");
					curr++;
					Debug.Log (curr);
					Destroy ( this.gameObject.rigidbody);
					this.gameObject.transform.parent=surface.transform ;
					this.gameObject.transform.localPosition=Vector3.zero ;
					this.gameObject.transform.SetSiblingIndex  (1);
					
					all = GameObject.FindGameObjectsWithTag("padajuce_slovo").Length;
//					foreach (GameObject go in GameObject.FindGameObjectsWithTag("padajuce_slovo"))
//						{
//					        
//							Transform t = go.transform.GetChild (1);
//
////							if (t.localPosition == Vector3.zero) 
////							{
////								
////							}
//						}
						
						if (curr==all) 
						{
								GameObject.Find ("Manager").GetComponent<manager>().win.SetActive (true);
								curr = 0;
								Invoke("disabluj",4);

						}
			}

			else
			{
					Debug.Log ("LOSE");

				    this.gameObject.transform.Translate (Random.Range(-0.3f,0.3f),Random.Range(0.2f,0.8f),0);
					

			}
			//ExampleDragDropSurface dds = surface.GetComponent<ExampleDragDropSurface>();
			
		//	if (dds != null)
		//	{
		//		GameObject child = NGUITools.AddChild(dds.gameObject, prefab);
				
		//		Transform trans = child.transform;
		//		trans.position = UICamera.lastHit.point;
				
		//		if (dds.rotatePlacedObject)
		//		{
				//	trans.rotation = Quaternion.LookRotation(UICamera.lastHit.normal) * Quaternion.Euler(90f, 0f, 0f);
		//		}
				
				// Destroy this icon as it's no longer needed
		//		NGUITools.Destroy(gameObject);
		//		return;
		//	}
		}
		base.OnDragDropRelease(surface);

		if (this.gameObject.transform.localPosition != Vector3.zero)
						this.gameObject.transform.parent = GameObject.Find ("Container").transform;

	}

    	


	public  void disabluj()
		{
			GameObject.Find ("Manager").GetComponent<manager>().win.SetActive (false);
			manager man = GameObject.Find ("Manager").GetComponent<manager> ();
			man.formirajnovurec ();
		}
}

