using UnityEngine;
using System.Collections;

public class rnr : MonoBehaviour {
	public static int min,max;
	public static int length;
	public static int [] nums;
	static bool ret = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static int [] numNoRepeat(int minimum, int maximum, int mLength){
	
		nums = new int[mLength];
		int broj;
		for (int i =0; i<mLength; i++) {
			
			
						do {    
								broj = Random.Range (minimum, maximum);
								//Debug.Log ("U DO");
								postoji (broj, i);
				
				
						} while (ret);

						nums[i] = broj;

				}
		return nums;
	}


	static bool postoji (int num, int index)
	{
		//Debug.Log (" U postoji");
		ret = false;
		for (int i =0;i<index; i++) {
			
			if (num == nums[i]) ret = true;
			
		}
		return ret;
		
	}

					

}
