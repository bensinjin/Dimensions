using UnityEngine;
using System.Collections;

public class GUIBuilder : MonoBehaviour {

	public static Rect getTextBox(string text, int addedWidth = 0, int addedHeight = 0, int addedY = 0) {
		Vector2 textDimensions = GUI.skin.label.CalcSize(new GUIContent(text));
		float width = textDimensions.x;
		float height = GUI.skin.label.CalcHeight (new GUIContent (text), width);
		float yPos = 150.0f;
		width += addedWidth;
		height += addedHeight;
		yPos += addedY;
		Rect rect = new Rect (Screen.width/2 - width/2, yPos, width, height);

		return rect;
	}	
}
