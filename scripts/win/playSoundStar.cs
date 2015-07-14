using UnityEngine;
using System.Collections;

public class playSoundStar : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int i=1;
        sound.playSounds = false;
        sound.playSound ("coin");
        TweenColor [] tc = gameObject.GetComponentsInChildren<TweenColor>() as TweenColor [];
        for (i =1 ; i < tc.Length ;i++)
        {
             Debug.Log(i);
             Invoke("playSound",i);
        }
        Invoke ("unisti" ,i +1);
	}
	
	// Update is called once per frame
	void playSound () {
       
            sound.playSound ("coin");
    	
	}

    void unisti () {
        
        DestroyImmediate (this.gameObject);
        
    }
}
