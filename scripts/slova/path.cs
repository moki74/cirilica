using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class path : MonoBehaviour {
	//public GUITexture myImg;
	public Material dobroMat,losMat;
	private Ray ray;
	private RaycastHit rayCastHit;
	bool ontrack,andra,stari = false;
	LineRenderer lrDobar,lrLos;
	int lineCount,errlineCount = 0;
	List<Vector3> linePoints = new List<Vector3>();
	List<Vector3> errlinePoints = new List<Vector3>();
	List<Vector3> put = new List<Vector3>();
	Vector3 mouseWorld,mousePos;
	private float width = 0.5f;
	Texture2D tex ;
	bool preseciDobar,preseciLos =false;
	public static bool bCrtaj = false;




	public static bool boolCrtaj(){

		bCrtaj = !bCrtaj;
		return bCrtaj;
	
	
	}

	
	void Awake()
	{
		//Screen.orientation = ScreenOrientation.Landscape ;
		  if (Application.platform == RuntimePlatform.Android)
            andra =true;
		dobroMat.color = Color.green;
		//myImg = GameObject.Find("Povrsina").guiTexture;


	
	}
		
	
	void Update ()
	{
		//if (!mangerScript.Draw) return;
		 if(Input.touchCount >0 || Input.GetMouseButton(0)){
		// for(int i=0; i<=Input.touchCount; i++){
 	 	  if (andra) mousePos = (Vector3)Input.GetTouch(0).position;
	      else  mousePos = Input.mousePosition;
			
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out rayCastHit) && bCrtaj)
			{
				
				if (rayCastHit.transform.tag =="slovo" || rayCastHit.transform.tag =="slovoPrefab")
					{
					Debug.Log (rayCastHit.transform.name);
					  // Da se ne pokrene demo
					GameObject go ;
					if ( go = GameObject.Find ("Prst"))go.SetActive (false);
					  GameObject.Find ("Manager").GetComponent<setup>().startTime=false;
					  //
					   mousePos.z = 10f;
  			           mouseWorld = Camera.mainCamera.ScreenToWorldPoint(mousePos);
					//Debug.Log ("X: " +mouseWorld.x + " Y: " + mouseWorld.y );

					//if(mouseWorld.x < -0.4f || mouseWorld.x > 0.4f || mouseWorld.y < -0.25f || mouseWorld.y > 0.5)return; 
					 
					put.Add (mouseWorld);
//					    tex = (Texture2D)rayCastHit.transform.renderer.material.mainTexture;
//					    float track = tex.GetPixelBilinear(rayCastHit.textureCoord2.x, rayCastHit.textureCoord2.y).a;
//					Color col = tex.GetPixelBilinear(rayCastHit.textureCoord2.x, rayCastHit.textureCoord2.y);
//					Debug.Log(track);
//					Color[] pix = tex.GetPixels(0, 0, tex.width,tex.height);
					//for (int j=512;j<pix.Length;j=j+100)
						//if (pix[j] == Color.black) Debug.Log ("NASAO CRNO " +j)
						// Debug.Log ("J = " + j + " BOJA :" + pix[j]);


					//if (track>0)
					if (rayCastHit.transform.tag =="slovo")
					    {
							//Debug.Log ("HIT");
					
						    crtajDobro();
						    ontrack=true;
						    
						    
					    }
					    else
						{
						   if (!mangerScript.Draw) return;
							//crtajLose();
							Debug.Log("Lose");

						    crtajLose();
							ontrack=false;
						   
					    }
					
					}
			}
		}
		
		if( Input.GetMouseButtonUp(0))
		{
			// ocisti();

			//Debug.Log (put.Count);
		
			preseciDobar=preseciLos=true;
		}
	}
	
	void crtajDobro()
	{
		//mousePos.z=9.3f;
		if(!ontrack || GameObject.Find ("dobarPath")==null || preseciDobar)
		{
			novipathdobar ();

		}
		
		preseciDobar=false;

		linePoints.Add(mouseWorld);
		
		lrDobar.SetWidth(width, width);
        lrDobar.SetVertexCount(linePoints.Count);
		//lrDobar.material = new Material(Shader.Find("Particles/Multiply"));
		lrDobar.material=dobroMat;
		//lrDobar.material = new Material(Shader.Find("Unlit"));
		//lrDobar.SetColors(Color.green, Color.green);

    	// Debug.Log (lineCount + ", " + linePoints.Count);
   		 for(int i = lineCount; i < linePoints.Count; i++)
   		 {
			// if(path)
   			 lrDobar.SetPosition(i, linePoints[i]);
    	 }
		
         lineCount = linePoints.Count;
		
		
	}
	
	void crtajLose()
	{
		if(ontrack || GameObject.Find ("losPath")==null || preseciLos)
		{
			novipathlos ();
		}
		
		preseciLos=false;
		errlinePoints.Add(mouseWorld);
		lrLos.SetWidth(width, width);
		lrLos.material = losMat;
	//	lrLos.SetColors(Color.red, Color.red);
        lrLos.SetVertexCount(errlinePoints.Count);
	  
   // 	 Debug.Log (errlineCount + ", " + errlinePoints.Count);
   		 for(int i = errlineCount; i < errlinePoints.Count; i++)
   		 {
			// if(path)
   			 lrLos.SetPosition(i, errlinePoints[i]);
    	 }
         errlineCount = errlinePoints.Count;
		
		
	}

	void novipathdobar()
	{

		lrDobar= new GameObject("dobarPath").AddComponent<LineRenderer>();
		lrDobar.tag="dobarPath";
		lineCount=0;
		linePoints = new List<Vector3>();



	}

	void novipathlos()
	{
		lrLos= new GameObject("losPath").AddComponent<LineRenderer>();
		lrLos.tag="losPath";
		errlineCount=0;
		errlinePoints = new List<Vector3>();

	}

	public static void ocisti()
	{
		    foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("losPath"))
		    {
				Destroy (fooObj);
		//	   fooObj.AddComponent<Rigidbody>();
		//	fooObj.rigidbody.mass=100;
		    }
		
		    foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("dobarPath"))
		    {
			   Destroy (fooObj);
		    }

			foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("slikice"))
			{
				UITexture  uit = fooObj.GetComponent<UITexture>();
				uit.mainTexture=null;
			//	uis.spriteName="";
			}

	}
	
}
	
			
