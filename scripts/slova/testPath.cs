using UnityEngine;
using System.Collections;

public class testPath : MonoBehaviour {
	Component []  tweens;

	// Use this for initialization
	void sledeciPath(string i)
	{
		Debug.Log ("SADA DRUGI");
		//tweens =     this.GetComponents(typeof(iTweenEvent));
		//tweens = this.GetComponents<iTweenEvent>();
		//Debug.Log (tweens.Length);
		//foreach(iTweenEvent  tween in tweens)
		//	Debug.Log (tween.tweenName);
		string pathName =  "path" + i;
		iTweenEvent.GetEvent(this.gameObject , pathName).Play();

	}
}
