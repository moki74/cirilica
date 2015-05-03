using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class na_slovo_setup : MonoBehaviour {
	public GameObject leftPanel;
	public GameObject rightPanel;
	public GUIText log;
	private float scale = 810f;
	public bool startTime = false;
	private float timer =0;
	public UITexture slika;


	// Use this for initialization
	void Start () {

		GameObject go= (GameObject) Instantiate(Resources.Load (slova.sledece().ToString() + "vsPrefab"));

		// check if right / left handed
		if (checkPrefs.current_user != null && checkPrefs.current_user._ruka == "леворук") {
						GameObject.Find ("Slike").GetComponent<UIWidget> ().leftAnchor.absolute = -2145;
						go.transform.position = new Vector3 (8f, 0f, 0f);
				}
		go.GetComponent<slovoPathovi> ().enabled = false;
		ucitaj_slikice ();
	//	PathNodes pn = (PathNodes)Camera.main.GetComponent<PathNodes> ();
	//	pn.novoSlovo  (go.name);
		//if(Screen.width>840f && Screen.width<900f)scale=800f;
	//	if(Screen.width>900f)scale=850f;
	//	Debug.Log ("DPI : " +Screen.dpi);
	//	log.text=  Screen.dpi.ToString ();
	//	leftPanel.transform.localPosition  = new Vector3(0-Screen.width*(scale/Screen.width) ,leftPanel.transform.localPosition.y,leftPanel.transform.localPosition.z);
	//	rightPanel.transform.localPosition = new Vector3(Screen.width*(scale/Screen.width) ,rightPanel.transform.localPosition.y,rightPanel.transform.localPosition.z);
		InvokeRepeating  ("pokreniVremeIgre", 0.5f,0.1f);

	}
	
	// Update is called once per frame
	void Update () {
		//if(startTime) pokreniVreme();
	 
	}

	void pokreniVreme(){
	//	Debug.Log ("pokrenuto demo VREME");
		timer+= Time.deltaTime;
	//	Debug.Log (timer);
		if(true)
		{
			GameObject.FindGameObjectWithTag("slovoPrefab").SetActiveRecursively(true);
			timer=0;
			startTime=false;
		}

	}


	void pokreniVremeIgre(){
	//	Debug.Log ("pokrenuto VREME igre ");
		timer += 1 ;

		UILabel vreme = GameObject.Find ("lblVreme").GetComponent<UILabel> () as UILabel;
		int mins = (int) timer  / 10;
		int secs = (int) timer % 10;
	//	Debug.Log (timer );
		//vreme.text = timer.ToString();
		vreme.text = string.Format("{0:00}:{1:00}", mins, secs);
	}


	public void novoVreme(){
		timer = 0;
		ucitaj_slikice ();
		CancelInvoke ();
		InvokeRepeating  ("pokreniVremeIgre", 0.5f,0.1f); 
	}

	public void ucitaj_slikice(){
		string postojece ="";

		string  file = "";
		int[] slike = rnr.numNoRepeat (0, reci.sve_reci.Count, 12);
		slike [0] = 0;
		slike [1] = 0;

		for (int i=1;i< 7;i++) {
		
			GameObject go = GameObject.Find ("slika" + i.ToString ());
			go.collider.enabled=true;
			go.GetComponent<UITexture>().color=Color.white;
			go.GetComponentInChildren <UISprite > ().spriteName = "";
			UILabel lbl = go.transform.GetComponentInChildren<UILabel>() as UILabel;
			lbl.text="";
			lbl.enabled = false;
			go.transform.position = GameObject.Find("poc_pos" + i.ToString ()).transform.position;
			slika = go.GetComponent<UITexture>();
				

			file = reci.sve_reci [slike[i-1]];
						//if (file.StartsWith (slova.trenutno_slovo.ToUpper())) file = reci.sve_reci[slike[i+5]];
			if (file.StartsWith (slova.trenutno_slovo.ToUpper()) ||  postojece.Contains(file)) //file = reci.sve_reci.Find (x=> !x.StartsWith (slova.trenutno_slovo.ToUpper()) );
			{
				do {
					file = reci.sve_reci[Random.Range (0,reci.sve_reci.Count)];
					}
					while (
							 file.StartsWith (slova.trenutno_slovo.ToUpper()) ||  postojece.Contains(file)
						  );
			}
			postojece = postojece+","+file;
			Debug.Log (postojece);
			slika.mainTexture = Resources.Load ("azbuka_pics/u_krugu/" + file) as Texture2D;
		//	slika.MakePixelPerfect ();
			slika.SetDimensions (512,512);
			slika.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
		}

		file = "";
		string slovo = slova.trenutno_slovo ;
		Debug.Log (slovo);
		int [] position = rnr.numNoRepeat (1, 7, 3);
		Debug.Log (position.ToString ());


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
		int j = 0;
	//	List <string> na_slovo = new List<string> ();
		foreach (string str in reci.sve_reci)
		{
			if (str.StartsWith (slovo.ToUpper ()) && j < 3) {

				string rec = str.Split ('_')[0];
				Debug.Log ("VREDNOST J : " + j + "  Pos " + position[j] );
				slika = GameObject.Find ("slika" + position[j].ToString ()).GetComponent<UITexture>();
				slika.mainTexture=Resources.Load ("azbuka_pics/u_krugu/" + str) as Texture2D ;
				j++;
				UILabel lbl = slika.transform.GetComponentInChildren<UILabel>() as UILabel;
				lbl.text=rec;
				lbl.enabled = false;

			}
		}

		sound.playSound ("na_slovo",1f);
		StartCoroutine ("sacekaj", 2.2f);
		//string dir, file;
		
	//	StartCoroutine (sacekaj (1.5f));
	}


	IEnumerator sacekaj(float time) {
		
		yield return new WaitForSeconds(time);
		//Debug.Log ("YIEEEELLLLLD");
		sound.playSound (slova.trenutno_slovo,0.3f);
		
	}

}
