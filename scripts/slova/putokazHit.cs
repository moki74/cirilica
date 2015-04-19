using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class putokazHit : MonoBehaviour {
	Ray ray;
	RaycastHit hit;
	UITexture zivotinja,biljka;
	List<string> na_slovo = new List<string>();
	public UITexture stvar;
	public UILabel lbl;

	// Use this for initialization
	void Start () {

	//	stvar = GameObject.Find ("stvar").GetComponent<UITexture> ();
	//	zivotinja = GameObject.Find ("zivotinja").GetComponent<UITexture> ();
	//	biljka = GameObject.Find ("biljka").GetComponent<UITexture> ();
		//stvar.spriteName = zivotinja.spriteName = biljka.spriteName = "";
		spremi ();
	}

	public void spremi ()
	{
		stvar.gameObject.SetActive (false); 
	//	zivotinja.enabled = false;
	//	biljka.enabled = false;
		string slovo = slova.trenutno_slovo ;
		string file = "";
//		foreach (string str in reci.biljke)
//		{
//			Debug.Log ("U FOREASCHHHHH");
//			if (str.StartsWith (slovo)) file = str;
//		}
		
////		biljka.mainTexture=Resources.Load ("azbuka_pics/biljke/" + file) as Texture2D ;
//		
//		foreach (string str in reci.zivotinje)
//		{
//			if (str.StartsWith (slovo)) file = str;
//		}
//		
//		zivotinja.mainTexture=Resources.Load ("azbuka_pics/zivotinje/" + file) as Texture2D ;
		
		foreach (string str in reci.sve_reci)
		{
			if (str.StartsWith (slovo.ToUpper ())) na_slovo.Add (str) ;

		}
		//Debug.Log (" REC    " + reci.sve_reci[0]);
		file = na_slovo [Random.Range (0, na_slovo.Count)];

		stvar.mainTexture=Resources.Load ("azbuka_pics/velike/" + file) as Texture2D ;

		lbl.text = file.Split ('_')[0];
		//stvar.MakePixelPerfect ();
		//stvar.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		na_slovo.Clear ();

		sound.playSound ("napisi_slovo",1f);
		StartCoroutine ("sacekaj", 2.2f);
		//string dir, file;
		
		//	StartCoroutine (sacekaj (1.5f));
	}
	
	
	IEnumerator sacekaj(float time) {
		
		yield return new WaitForSeconds(time);
		//Debug.Log ("YIEEEELLLLLD");
		sound.playSound (slova.trenutno_slovo,0.3f);
		
	}


	
	
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay (ray.origin, ray.direction * 0.1f);
		if (Physics.Raycast(ray, out hit) && Input.GetMouseButton (0)) {
			if(hit.transform.name.Contains ("putokaz")){
				path.bCrtaj=true;
				GameObject s = Instantiate(Resources.Load ("particle"))as GameObject;
				s.transform.position  = hit.transform.position;
			    Destroy(hit.transform.gameObject);
			}

		     if(hit.transform.name.Contains ("cilj") && GameObject.Find ("putokaz2(Clone)") == null ){
					GameObject s = Instantiate(Resources.Load ("particle"))as GameObject;
					s.transform.position  = hit.transform.position;
					Destroy(hit.transform.gameObject);

					
//                  PathNodes pn = (PathNodes)Camera.main.GetComponent<PathNodes> ();
				    Invoke ("sledeciPutokaz",0.5f);

				   if(hit.transform.name.Contains ("kraj") ) {
				  	 GameObject.Find("Manager").GetComponent<setup>().CancelInvoke ();
					Debug.Log (slova.trenutno_slovo);
					stvar.gameObject.SetActive (true); 
				

					//zivotinja.enabled = true;
				//	biljka.enabled = true;

					//						 stvar.spriteName="ауто";
//						 stvar.spriteName="ауто";
//						 zivotinja.spriteName="ајкула";	
//					//zivotinja.MakePixelPerfect (); 
//						 biljka.spriteName="ананас 03";
//					//biljka.MakePixelPerfect ();

					}
					
				}
			
			// Do something with the object that was hit by the raycast.
		}
	 
	
	}

    public void sledeciPutokaz(){
					path.bCrtaj= false;	
					PathNodes pn = (PathNodes)Camera.main.GetComponent<PathNodes> ();
					pn.kreirajPutokaz ();

		}

	public void OnPress(){
		Debug.Log ("PREESSS");
	
	}
}
