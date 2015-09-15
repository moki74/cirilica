using UnityEngine;
using System.Collections;

public class pocni : MonoBehaviour {
	public float width = 0.02f;
	LineRenderer lr;
	Vector3 mouseWorld,mousePos;
	public Camera cam;
	public Material dobroMat,losMat;
	bool press = false;
	bool crtaj = false;
	static int brojDobrih =0;
	// Use this for initialization
	void Start () {
		brojDobrih = 0;
		lr= gameObject.AddComponent<LineRenderer>();
		lr.material = losMat;
		
		lr.SetVertexCount (2);	
		lr.SetWidth (width, width);
	}
	
	// Update is called once per frame
	void OnClick () {
//		Debug.Log ("KLIK");
//		lr= gameObject.AddComponent<LineRenderer>();
//		lr.material = dobroMat;
//	
//		lr.SetVertexCount (2);
//		lr.SetWidth (width, width);
//		crtaj = true;
	}

	void OnPress () {

		press = !press;
		crtaj = true;
	
	}


	void Update () {

		if (press) {

						mousePos = Input.mousePosition;
						mousePos.z = transform.Find ("pocetnaTacka").transform.position.z;
						mouseWorld = cam.ScreenToWorldPoint (mousePos);
						lr.material = losMat;
						lr.SetVertexCount (2);	
						lr.SetPosition (0, transform.Find ("pocetnaTacka").transform.position);

						lr.SetPosition (1, mouseWorld);
		

				} else if (!press && crtaj) {
						
						string name  = UICamera.hoveredObject.name;
			            
						if (name.ToLower () == gameObject.name.ToLower () && name !=null) {
							lr.material=dobroMat;
							lr.SetPosition (0, transform.Find ("pocetnaTacka").transform.position);
							lr.SetPosition (1,  UICamera.hoveredObject.transform.Find ("krajnjaTacka").transform.position);
							brojDobrih ++;
							Debug.Log(brojDobrih);
							if (brojDobrih > 4)
							{
								Debug.Log(poveziManager.timer);
								showWin.show(poveziManager.timer,0.5f,0.7f,6f,12f);
								brojDobrih = 0;
						
							}
							
						}
						
						else {
								lr.SetPosition (0, transform.Find ("pocetnaTacka").transform.position);
								lr.SetPosition (1, transform.Find ("pocetnaTacka").transform.position);					
						}
					crtaj = false;

				}
		
		
		
	}

	public void proveri() {

		Debug.Log ("PROVERA");
		lr.material = dobroMat;


	}

	
	

}
