using UnityEngine;
using System.Collections;

public class slova : MonoBehaviour {
	//public static string strAzbuka = "абвгдђежзијклљмнњопрстћуфхцчџш" ;
	//public int[] azbuka_random = new int[30] ;
	//public int[] azbuka = new int[30] ;
	public static string strAzbuka = "абвгд" ;
	public int[] azbuka_random = new int[5] ;
	public int[] azbuka = new int[5] ;
	public static int[] odabrano = new int[5];
	public static int indeks = -1; 
	bool ret = false;
	public static string trenutno_slovo = "a";

	// Use this for initialization
	void Start () {
		int broj;
		//for (int i =0; i<30; i++) {    // ovo je za punu verziju
		for (int i =0; i<5; i++) {       // ovo je za demo 
			azbuka[i]=i;  
					
			do
			{    
				// broj = Random.Range (0,30); // ovo je za punu verziju
				broj = Random.Range (0,5); // ovo je za demo 
				postoji(broj,i);
			
	
			}
			while (ret);

				azbuka_random[i]=broj;
				//Debug.Log (azbuka_random[i]);
		 }		

		odabrano = azbuka;
		//Instantiate(Resources.Load (slova.sledece().ToString() + "vsPrefab"));
	}
	

	bool postoji (int num, int index)
		{
		//Debug.Log (" U postoji");
		ret = false;
		for (int i =0;i<index; i++) {
				   
					if (num == azbuka_random[i]) ret = true;
				       
				}
		  return ret;

		}
	
	// Update is called once per frame
	public void change () {
		Debug.Log ("u CHANGE");
		if (odabrano == azbuka_random)
						odabrano = azbuka;
				else
						odabrano = azbuka_random;
	
	}

	public static int sledece()
	{
		Debug.Log (odabrano.Length.ToString ());
			
		if (indeks < 4 ) {
					indeks ++;
					Debug.Log ("IMA JOS");
					Debug.Log (indeks.ToString ());
						
						trenutno_slovo = strAzbuka.Substring (odabrano [indeks], 1);
						return odabrano [indeks];
				} else {
						Debug.Log ("NEMA VISE");
						trenutno_slovo = strAzbuka.Substring (odabrano [indeks], 1);
						return odabrano [indeks];
				}

	}

	public static int prethodno()
	{
		if (indeks > 0) {
						indeks --;
			trenutno_slovo= strAzbuka.Substring (odabrano [indeks],1);
			return odabrano [indeks];
				} else {
			trenutno_slovo= strAzbuka.Substring (odabrano [indeks],1);
			return odabrano [0];
				}
		
	}
}
