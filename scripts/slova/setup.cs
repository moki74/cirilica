using UnityEngine;
using System.Collections;

public class setup : MonoBehaviour {
	public GameObject leftPanel;
	public GameObject rightPanel;
	public GUIText log;
	private float scale = 810f;
	public bool startTime = false;
	private float timer =0;
	// Use this for initialization
	void Start () {

		GameObject go= (GameObject) Instantiate(Resources.Load (slova.sledece().ToString() + "vsPrefab"));
		if (checkPrefs.current_user._ruka == "леворук") {
			GameObject.Find ("Slike").GetComponent<UIWidget> ().leftAnchor.absolute = -1670;
			Camera.main.transform.position = new Vector3 (-3.7f, -0.18f, -10f);
		}
		PathNodes pn = (PathNodes)Camera.main.GetComponent<PathNodes> ();
		pn.novoSlovo  (go.name);
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
		//Debug.Log ("pokrenuto demo VREME");
		timer+= Time.deltaTime;
		//Debug.Log (timer);
		if(true)
		{
			GameObject.FindGameObjectWithTag("slovoPrefab").SetActiveRecursively(true);
			timer=0;
			startTime=false;
		}

	}


	void pokreniVremeIgre(){
		//Debug.Log ("pokrenuto VREME igre ");
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
		GameObject.Find ("Main Camera").GetComponent<putokazHit> ().spremi();
	}

}
