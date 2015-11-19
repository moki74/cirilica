using UnityEngine;
using System.Collections;

public class showWin : MonoBehaviour {



	public static void show(float vreme,float scale = 1f,float up = 1.5f, float triZvezde=30f , float dveZvezde=45f)
    {
        GameObject win = null;
        if (vreme < triZvezde)
            win = NGUITools.AddChild(GameObject.Find ("Camera"), Resources.Load ("win3") as GameObject);
        
        else  if (vreme < dveZvezde)
            win =NGUITools.AddChild(GameObject.Find ("Camera"), Resources.Load ("win2") as GameObject);  
        else
            win =NGUITools.AddChild(GameObject.Find ("Camera"), Resources.Load ("win1") as GameObject); 
        win.name="win";
		win.transform.localScale = new Vector3 (scale,scale,scale);
        win.transform.position  = Vector3.up * up;
    }
}
