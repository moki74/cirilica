using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class manager : MonoBehaviour {
	static UIGrid grid;
	public  GameObject gridObject;
	public  string rec="jabuka";
	char [] recarray;
	private  Rigidbody[] odabrana_slova ;
	private List  <GameObject> unistiti = new List<GameObject> ();
	private bool shake =true;
	public Transform randevou;
	public UILabel protresi;
	//UISprite slika;
	UITexture slika;
	public bool mesaj = false;
	public bool novo = true;
	public static float timer = 0;
	//accelerometer variables

	float accelerometerUpdateInterval ;
	
	// The greater the value of LowPassKernelWidthInSeconds, the slower the filtered value will converge towards current input sample (and vice versa).
	float lowPassKernelWidthInSeconds  = 5.0f;
	
	// This next parameter is initialized to 2.0 per Apple's recommendation, or at least according to Brady! <img src="http://www.lucedigitale.com/blog/wp-includes/images/smilies/icon_wink.gif" alt=";)" class="wp-smiley">
	float shakeDetectionThreshold  = 0.8f;
	
	float  lowPassFilterFactor ;
	Vector3  lowPassValue = Vector3.zero;
	Vector3  acceleration ;
	Vector3  deltaAcceleration ;

	// Use this for initialization
	void Start () {
		//formiraj_rec ();
		slika = GameObject.Find ("Texture").GetComponent<UITexture> ();
		//slika.spriteName = "";
		accelerometerUpdateInterval  = 1.0f / 60.0f;
		lowPassFilterFactor  = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
		grid = gridObject.GetComponent<UIGrid> ();
		grid.sorted = true;

		//acellerometer
		shakeDetectionThreshold *= shakeDetectionThreshold;
		lowPassValue = Input.acceleration;
		formirajnovurec ();
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		acceleration = Input.acceleration;
		lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
		deltaAcceleration = acceleration - lowPassValue;
		if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold && shake == true)
		{
			mesaj = true;
			// Perform your "shaking actions" here, with suitable guards in the if check above, if necessary to not, to not fire again if they're already being performed.

		}
	
	}

	void FixedUpdate () {
		if (mesaj) {

						razmesti_slova ();
						mesaj = false;
				}
	}

	public  void formirajnovurec()
	{

		shake = true;
		protresi.enabled = true;
		if (unistiti != null){
			
			for (int i =0; i< unistiti.Count; i++)
				Destroy (unistiti [i]);
			grid.Reposition ();
		}
		unistiti.Clear ();
		Invoke ("formiraj_rec", 0.5f);
	}


	public  void formiraj_rec(){
		if (!novo)
						return;
		novo = false;
		string file;
		rec = reci.sve_reci [Random.Range (0, reci.sve_reci.Count)];
		file = rec;
		rec = rec.Split ('_') [0];
		slika.mainTexture = Resources.Load ("azbuka_pics/velike/" + file) as Texture2D;
		//slika.MakePixelPerfect ();
		slika.SetDimensions (1024,1024);
		slika.SetDirty ();
		//
		slika.transform.localScale = new Vector3 (0.6f, 0.6f, 0.6f);

	
			StartCoroutine (sacekaj (1f));
	}

//	public  void formiraj_rec()
//	{
//				string dir, file;
//				
//				string[] path_word = reci.getWordandPath ().Split (',');
//				int grupa = int.Parse (path_word [0]);
//				if (grupa == 1)
//						dir = "biljke";
//				else if (grupa == 2)
//						dir = "zivotinje";
//				else
//						dir = "stvari";
//				file = path_word [1];
//				rec = file.Split (' ') [0];
//				Debug.Log (dir + file + rec);
//				slika.mainTexture = Resources.Load ("azbuka_pics/" + dir + "/" + file) as Texture2D;
//				slika.MakePixelPerfect ();
//				slika.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
//				StartCoroutine (sacekaj (1.5f));
//	}

	public void postavi_rec()
	{
				int j = 0;
				rec = rec.ToUpper ();
				UIWidget uiw = gridObject.GetComponent<UIWidget> ();

				float razmera = ((float) Screen.width / (float) Screen.height) * 750 ;
				Debug.Log (razmera);
		         int center = (int) razmera  ;
				Debug.Log (center);
				uiw.rightAnchor.absolute = center - (rec.Length * 90) ;

				recarray = rec.ToCharArray ();
				odabrana_slova = new Rigidbody[recarray.Length] ;
				
				for (int i =0; i< recarray.Length; i++) {
						GameObject padslo = Instantiate (Resources.Load ("padajuce_slovo"))as GameObject;
						
						padslo.name = i.ToString() + recarray [i].ToString () + "padajuce_slovo";
						GameObject slo = padslo.transform.FindChild ("slovo").gameObject;
						slo.name =  i.ToString() + recarray [i].ToString ();
						
						padslo.transform.parent = gridObject.transform;
						padslo.transform.localScale = Vector3.one;
						
						UILabel lbl = padslo.GetComponentInChildren<UILabel> ();
						lbl.text = recarray [i].ToString ();
						int x = Random.Range (0, 2);
				//		if ((x == 0 || j == 0) && (i > 0)) {
								Rigidbody rb = slo.AddComponent ("Rigidbody") as Rigidbody;
								rb.drag   = 0.5f;
								odabrana_slova[j] = rb;
								//rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic ;
								j++;
								rb.useGravity=false;
								rb.constraints=RigidbodyConstraints.FreezePositionZ |  RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
								
								rb.freezeRotation=true;
								
								
					//	}
			
					unistiti.Add( padslo);
					
			
			
				}   

		grid.Reposition ();
		novo = true;

		
	}

	IEnumerator sacekaj(float time) {

		yield return new WaitForSeconds(time);
		//Debug.Log ("YIEEEELLLLLD");
		postavi_rec ();

	}
	
	public  void razmesti_slova()
	{
		if (!shake)
			  return;
		protresi.enabled = false;
		shake = false;
		float x = 1f;
		for (int i =0; i < odabrana_slova.Length; i++) {
			        if (odabrana_slova[i] != null)  {
						int togle = Random.Range (-1,2);
						if (togle >0) togle = 1; 
						else togle =1;
				        float force = Random.Range (10f,50f);
						odabrana_slova[i].transform.localPosition=new Vector3(0f,Random.Range (150f,350f),0f);
						//odabrana_slova[i].transform.position=randevou.position ;
						odabrana_slova[i].constraints=RigidbodyConstraints.FreezePositionZ;
						
						odabrana_slova[i].freezeRotation=true;	
						odabrana_slova[i].AddForce (new Vector3 (Random.Range (-40f,40f),Random.Range (-30f,30f),0f) *5);
				//odabrana_slova[i].AddExplosionForce(force,new Vector3 (Random.Range (-100f,100f),Random.Range (-10f,10f),-1f),10);
						x=-1*x;
					//odabrana_slova[i].AddForce(new Vector3 (Random.Range (-2f,4f),-1f,-1f),ForceMode.Impulse );

			}
		}
		//dodatna_slova ();
		Invoke ("dodatna_slova" , 0.1f);

	}

	public void dodatna_slova()
	{
		int broj_slova = 3;
		GameObject slo = null;
		float x = -900f;
		float y = 0f;
		for (int i =0 ; i<broj_slova; i++)
		{
//			int togle = Random.Range (-1,2);
//			if (togle >0) togle = 1; 
//			else togle =-1;
			string slovo = slova.strAzbuka.ToUpper().ToCharArray()[Random.Range(0,slova.strAzbuka.Length)].ToString ();
			x = Random.Range (-950f,-50f);
			y = Random.Range(0f,250);
//			y=y*togle;
			Vector3 pos = new Vector3(x,y,0);

			slo =NGUITools.AddChild(GameObject.Find ("Container"), Resources.Load ("slovo") as GameObject);
			slo.name=i.ToString () + slovo;

						
			slo.transform.localPosition = pos;
			slo.rigidbody.AddForce (new Vector3 (Random.Range (-20f,20f),Random.Range (-20f,20f),0f) *2);





			x+=Random.Range(100f,250f);
			//Destroy (padslo.transform.FindChild ("okvir").gameObject);
		//	GameObject slo = padslo.transform.FindChild ("slovo").gameObject;

			UILabel lbl = slo.GetComponentInChildren <UILabel> ();
			lbl.text = slovo;
			unistiti.Add( slo);
		}
		timer = 0;
		//slo.transform.position=new Vector3(-100,30,0);
	}
}
