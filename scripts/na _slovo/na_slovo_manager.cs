using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class na_slovo_manager : MonoBehaviour {
	public static int num_correct = 0;
	public static int num_uncorrect = 0;
	public static List<string> slike = new List<string>();
	public static List<string> reci = new List<string>();
	// Use this for initialization
	void Start () {
		num_correct = 0;
		num_uncorrect = 0;
		slike.Clear ();
	
	}

	void Update () {
		if (num_correct > 2) {

			num_correct =0;

			pobeda();
				
		}
		
	}

	private void pobeda(){
		reci.Clear ();
		int j = 1;
		GameObject slovo_prefab = GameObject.FindGameObjectWithTag ("slovoPrefab");
		TweenTransform  twsf = slovo_prefab.AddComponent<TweenTransform> () as TweenTransform;
		twsf.from = slovo_prefab.transform;
		twsf.to = GameObject.Find ("slovo_pref_pos").transform;
		twsf.duration = 1f;
		twsf.PlayForward ();
		
		for (int i = 1; i< 7; i++){

			GameObject go = GameObject.Find ("slika" + i.ToString ());

			if (slike.Contains (go.name)){

				TweenTransform  tw = go.AddComponent<TweenTransform> () as TweenTransform;
				tw.from = go.transform;
				tw.to = GameObject.Find ("pos" + j.ToString ()).transform;
				tw.duration = 1f;
				tw.PlayForward ();
				j++;
				go.GetComponentInChildren<UILabel>().enabled=true;
				reci.Add (go.GetComponentInChildren<UILabel>().text.ToLower ());
			}
			else go.transform.position = new Vector3(1000f, 0f, 0f);
			go.GetComponent<UITexture>().color=Color.white;
		}

		slike.Clear ();
        showWin.show(gameObject.GetComponent<na_slovo_setup>().timer,2f);
		sound.playSound (reci [0]);
		StartCoroutine ("sacekaj_i_pusti", 1f);
	
		
	}


	IEnumerator sacekaj_i_pusti(float time) {
		
		yield return new WaitForSeconds(time);
		//Debug.Log ("YIEEEELLLLLD");
		sound.playSound (reci[1],1f);

		yield return new WaitForSeconds(time);
		sound.playSound (reci[2],1f);
		reci.Clear ();

	}

	// Update is called once per frame
	public static void spremi_slike()
	{
	

	}

}
