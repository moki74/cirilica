using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public  class reci : MonoBehaviour {


	private static reci instanceRef;
	public static List<string> biljke = new List<string>();
	public static List<string> zivotinje = new List<string>();
	public static List<string> stvari = new List<string>();
	public static List<string> ukrugu = new List<string>();
	//public static List<string> sve_reci = new List<string>();
	public static List<string> sve_reci =new List<string>(new string[]
	                                                      { "Авион_01", "Ананас_01", "Ајкула_01","Аутобус_01",
		"Бик_01", "Бицикл_01","Булдожер_01",	
		"Виолина_01", "Воз_01", "Врабац_01","Вук_01",																
		"Гитара_01", "Голуб_01","Горила_01","Грожђе_01",
        "Делфин_01", "Диња_01", "Добош_01" ,"Диносаурус_01"
	
	
	
														});

	bool ucitano = false;

	static string [] words= new string[] {//"Јабука","Крушка","Бресква","Банана","Шљива",
		//  "Крава","Куца","Маца","Делфин",
		//  "Књига","Авион","Сто","Ђинђува","Кутија",	
		
		"ајкула","медвед","голуб","пиле","тигар","јаје","ауто","јелен","камила"	,"кокошка","мрав","патка","паук","столица"													
	};
	// Use this for initialization
	
	
//	static string [] biljke= new string[] {//"Јабука","Крушка","Бресква","Банана","Шљива",
		//  "Крава","Куца","Маца","Делфин",
		//  "Књига","Авион","Сто","Ђинђува","Кутија",	
		
//		"ananas","медвед","голуб","пиле","тигар","јаје","ауто","јелен","камила"	,"кокошка","мрав","патка","паук","столица"													
//	};
	
	// Use this for initialization

	void Awake()
	{
		if(instanceRef == null)
		{
			instanceRef = this;
			DontDestroyOnLoad(gameObject);
		}else
		{
			DestroyImmediate(this.gameObject);
		}
	}

	
	
	void Start () {



	//	spremi_txt_file ();

		//if (! ucitano)
		//				ucitaj ();

	
	}

	public void ucitaj(){
		
				string sText = "";
		
				TextAsset ta = Resources.Load <TextAsset> ("azbuka_pics/reci") as TextAsset;
				sText = ta.text;
				//	StreamWriter sw = new StreamWriter ("biljke.txt");
				//	Object[] go=Resources.LoadAll("azbuka_pics/biljke") ;
				foreach (string rec in sText.Split ('\n')) {
                      Debug.Log(rec +"\n");    
						sve_reci.Add (rec);
						//		sw.WriteLine (f.name);
			
				}
				sve_reci.Remove ("");
				
				ucitano = true;
				Debug.Log ("UCITAJ :" + sve_reci.ToString ());
		}

	public void spremi_txt_file(){

			StreamWriter sw = new StreamWriter ("reci.txt");
			Object[] go = Resources.LoadAll ("azbuka_pics/velike");
			
			foreach (Object f in go) {
				//	zivotinje.Add (f.name);
					sw.WriteLine (f.name);
					
			
			}	
		sw.Close ();
		}

	public void ucitaj_grupe(){

				string sText = "";
				
				TextAsset ta = Resources.Load <TextAsset> ("azbuka_pics/biljke") as TextAsset;
				sText = ta.text;
				//	StreamWriter sw = new StreamWriter ("biljke.txt");
				//	Object[] go=Resources.LoadAll("azbuka_pics/biljke") ;
				foreach (string biljka in sText.Split ('\n')) {
		
						biljke.Add (biljka);
						//		sw.WriteLine (f.name);
		
				}
				biljke.Remove ("");

	
				//	sw.Close ();
				//	go=Resources.LoadAll("azbuka_pics/zivotinje");
	
				//	sw = new StreamWriter ("zivotinje.txt");
	
				//		foreach (Object f in go) {
				//	zivotinje.Add (f.name);
				//		sw.WriteLine (f.name);
	
				//		}
				//	sw.Close ();
				//	go=Resources.LoadAll("azbuka_pics/stvari");
				//	sw = new StreamWriter ("stvari.txt");
	
				//		foreach (Object f in go) {
				//	stvari.Add (f.name);
				//			sw.WriteLine (f.name);
	
				//	}
				//	sw.Close ();
				//	Resources.UnloadUnusedAssets ();

				ta = Resources.Load <TextAsset> ("azbuka_pics/zivotinje") as TextAsset;
				sText = ta.text;
				//	StreamWriter sw = new StreamWriter ("biljke.txt");
				//	Object[] go=Resources.LoadAll("azbuka_pics/biljke") ;
				foreach (string zivotinja in sText.Split ('\n')) {
					
					zivotinje.Add (zivotinja);
					//		sw.WriteLine (f.name);
					
				}
				zivotinje.Remove ("");

				ta = Resources.Load <TextAsset> ("azbuka_pics/stvari") as TextAsset;
				sText = ta.text;
				//	StreamWriter sw = new StreamWriter ("biljke.txt");
				//	Object[] go=Resources.LoadAll("azbuka_pics/biljke") ;
				foreach (string stvar in sText.Split ('\n')) {
					
					stvari.Add (stvar);
					//		sw.WriteLine (f.name);
					
				}
				stvari.Remove ("");


				ta = Resources.Load <TextAsset> ("azbuka_pics/ukrugu") as TextAsset;
				sText = ta.text;
				//	StreamWriter sw = new StreamWriter ("biljke.txt");
				//	Object[] go=Resources.LoadAll("azbuka_pics/biljke") ;
				foreach (string krug in sText.Split ('\n')) {
					
					ukrugu.Add (krug);
					//		sw.WriteLine (f.name);
					
				}
				stvari.Remove ("");
	
//				for (int i = 0; i < biljke.Count; i++)
//						Debug.Log (biljke [i]);

				ucitano = true;

		}
	

	public static string getWordandPath () {

		List<string> sGrupa;
		int grupa = Random.Range (1, 4);
		if (grupa == 1)
						sGrupa = biljke;
				else if (grupa == 2)
						sGrupa = zivotinje;
				else
						sGrupa = stvari;
		string ret = "";
		ret = sGrupa[Random.Range(0,sGrupa.Count)] ;
		//ret = ret.Split (' ') [0];
		ret = grupa.ToString () + "," + ret;
		return ret;
	
	}
}
