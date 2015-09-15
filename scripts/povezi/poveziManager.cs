using UnityEngine;
using System.Collections;

public class poveziManager : MonoBehaviour {
	public static string[] vSlova = new string[5];
	public static string[] mSlova = new string[5];
	public static GameObject[] gslova = new GameObject[10];
	public static float timer = 0f;



	// Use this for initialization
	void Start () {
		startNovo ();

	
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
	}
	public static void startNovo(){

		LineRenderer[] lrs = FindObjectsOfType(typeof(LineRenderer)) as LineRenderer[];
		foreach (LineRenderer lr in lrs) {
			lr.SetVertexCount (0);
		}
		
		novaSlova ();

	
//		int index = 0;
//		for (int i=1; i<10; i=i+2) {
//			int sl = i+1;
//
//			GameObject slovo  =GameObject.Find ("slovo" + i.ToString ());
//			GameObject sledece  =GameObject.Find ("slovo" + sl.ToString ());
//		
//			slovo.tag="velikoSlovo";
//			sledece.tag="maloSlovo";
//						int m = Random.Range (1, 3);
//						if (m > 1) {
//								if (slovo.tag== "velikoSlovo"){
//									slovo.tag="maloSlovo";
//									sledece.tag="velikoSlovo";
//							    }
//								else {
//									slovo.tag="velikoSlovo";
//									sledece.tag="maloSlovo";
//								}
//						}
// 				
//				gslova[index] = slovo;
//				gslova[index + 1] = sledece;
//				index += 2;
//			 	
//				}
//
//		int velika = 0 ;
//		int mala = 0 ;
//		for (int i=0; i<10; i++) {
//
//			if(gslova[i].tag=="velikoSlovo"){
//				gslova[i].transform.Find ("slovo").Find("Label").gameObject.GetComponent<UILabel>().text=vSlova[velika];
//				velika ++;	
//			}
//			else{
//				gslova[i].transform.Find ("slovo").Find("Label").gameObject.GetComponent<UILabel>().text=mSlova[mala];
//				mala ++;	
//
//			}
//		}


		int j = 0;
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("levoSlovo")){
			go.name = vSlova[j];
			go.transform.Find ("slovo").Find("Label").gameObject.GetComponent<UILabel>().text=vSlova[j];
			
			j++;
			
		}
		j = 0;
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("desnoSlovo")){
			go.name = mSlova[j];
			go.transform.Find ("slovo").Find("Label").gameObject.GetComponent<UILabel>().text=mSlova[j];
			
			j++;
			
		}
		timer = 0f;

	}

	public static void novaSlova(){
		int[] iSlova = rnr.numNoRepeat (0, 5, 5);
		for (int i=0; i<5 ; i++){
			int vm = Random.Range(1,3);
			if (vm > 1)
			vSlova[i]=slova.strAzbuka.Substring(iSlova[i],1).ToUpper ();
			else vSlova[i]=slova.strAzbuka.Substring(iSlova[i],1);
		}

		razmestiMala();	                                              	
	}

	static void razmestiMala(){
		  
			int [] raspored = rnr.numNoRepeat (0, 5, 5);
			for (int i=0; i<5; i++) {
						if (vSlova [raspored [i]].ToLower () == vSlova [raspored [i]])
								mSlova [i] = vSlova [raspored [i]].ToUpper ();
						else
								mSlova [i] = vSlova [raspored [i]].ToLower ();
				}
		
	}



}
