
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class PathNodes : MonoBehaviour {
	public Material  putokazMat;
	iTweenPath path;
	GameObject go,s,putnik;
	Component[] comps;
	List<Vector3> nodes;
	bool lastOne,onlyFirst=false;
	bool smerb =true;
	Vector3 smer,startPos;
	Vector3 dest;
	//float i=0f;
	static int brojPathova,sledeciPutokaz = 0;  // broj pathova na slovu, index sledeceg patha
	 

	// Use this for initialization
	public void novoSlovo (string objectName) {
		comps = null;
		go = null;
		brojPathova = sledeciPutokaz = 0;
		GameObject[] destroy = GameObject.FindGameObjectsWithTag ("putokaz");
		if (destroy != null) {
						foreach (GameObject des in destroy)
								Destroy (des);
				}
		Debug.Log ("OBJECTTT:" + objectName);
		go = GameObject.Find (objectName);
	//	Debug.Log ("Prefab :" + go.transform.parent.name);
		if (go.GetComponentInChildren  <iTweenPath> () != null) {
						Debug.Log ("NASAOOOOOO");
						comps = go.GetComponentsInChildren <iTweenPath> ();
						pathovi ();
						kreirajPutokaz ();
				}
	}


	public void pathovi () {
	//	putnik = GameObject.Find ("Cube");
//		startPos = putnik.transform.position;


		brojPathova = comps.Length; 

	
	}

	public void kreirajPutokaz ()
	{
		//Destroy (GameObject.Find ("putokaz2(Clone)"));
		if (sledeciPutokaz < brojPathova)
		{

//			comps = go.GetComponents <iTweenPath> ();
			iTweenPath ip = (iTweenPath) comps [sledeciPutokaz];

			nodes = ip.nodes;
            if (nodes.Count== 2) {
                       
                                   nodes.Insert (1, nodes[0] + 0.5f*(nodes[1] - nodes[0]));
                    }
			for (int i =0; i< nodes.Count; i++) {
				if (i == nodes.Count - 1) {
					lastOne = true;
					//s = GameObject.CreatePrimitive (PrimitiveType.Sphere);
					// nodes [i].z
					s =  Instantiate(Resources.Load ("cilj"))as GameObject;
				//	s.renderer.material= putokazMat ;
					s.transform.position = new Vector3 (nodes [i].x, nodes [i].y,nodes [i].z );
				//	s.name ="cilj";
					s.tag="putokaz";
					if (sledeciPutokaz == brojPathova-1) s.name="cilj_kraj";
					if(smerb)
					{ 
						dest= new Vector3 (nodes [i].x, nodes [i].y, nodes [i].z);
						smerb=false;
					}
				}
				
                 else if (i == 0){
						//  s = Instantiate (Resources.Load ("putokaz1")) as GameObject ;
						s = Instantiate(Resources.Load ("putokaz2"))as GameObject;
						s.transform.localPosition  = new Vector3 (nodes [i].x, nodes [i].y, nodes [i].z);
						smer = new Vector3 (nodes [i+1].x, nodes [i+1].y, -10f);
						//smer = new Vector3 (-2.8f, 1.2f, 0);
						Quaternion rot = Quaternion.LookRotation(s.transform.position - smer , Vector3.forward    );
						
						s.transform.localRotation = rot;   
						
						s.transform.eulerAngles = new Vector3(0, 0,s.transform.eulerAngles.z +90 ); 
					    //onlyFirst=true;
					
					
				}
                else {
                    s = Instantiate(Resources.Load ("putokaz"))as GameObject;
                    s.transform.localPosition  = new Vector3 (nodes [i].x, nodes [i].y, nodes [i].z);
                }

				lastOne=false;
				// paths = ip.nodes ;
				//	            foreach (Vector3 node in ip.nodes ){
				//s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				//s.transform.position = node;
				//		            s=(GameObject)Instantiate(Resources.Load("putokaz"));
				//			            s.transform.position = node;
				Debug.Log (ip.pathName + "  " + nodes[i].ToString ());
				//					}
				
			}
			sledeciPutokaz++;
		}

	}
	
	// Update is called once per frame
	void Update () {

	//	float rate = 1.0f/4.0f;
	//	i += Time.deltaTime*rate ;
	//	putnik.transform.position = Vector3.Lerp(putnik.transform.position, dest, i);
	}
}
