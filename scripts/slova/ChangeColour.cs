using UnityEngine;
using System.Collections;

public class ChangeColour : MonoBehaviour
{
	public Texture2D colourTexture;
	public Material material;
	private Rect textureRect = new Rect (Screen.width - Screen.width/2.5f, 5, 200, 200);
	
	void OnGUI ()
	{
		GUI.DrawTexture (textureRect, colourTexture);
		
		if (Event.current.type == EventType.MouseDrag) {
			Vector2 mousePosition = Event.current.mousePosition;
			
			if (mousePosition.x > textureRect.xMax || mousePosition.x < textureRect.x || mousePosition.y > textureRect.yMax || mousePosition.y < textureRect.y) {
				return;
			}
			
			float textureUPosition = (mousePosition.x - textureRect.x) / textureRect.width;
			float textureVPosition = 1.0f - ((mousePosition.y - textureRect.y) / textureRect.height);
			
			Color textureColour = colourTexture.GetPixelBilinear (textureUPosition, textureVPosition);
			//colouredCube.material.color = textureColour;
			changeMeshColour (textureColour);
		}
	}
	
	void changeMeshColour (Color newColor)
	{
		//Color[] colorArray = new Color[colouredCube.GetComponent<MeshFilter> ().mesh.vertexCount];
	//	
	//	for (int i = 0; i < colorArray.Length; i++) {
	//		colorArray [i] = newColor;
	//	}
		
		material.color = newColor;
	}
	
}
