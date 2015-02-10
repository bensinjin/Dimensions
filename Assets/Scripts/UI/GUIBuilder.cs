using UnityEngine;
using System.Collections;

public class GUIBuilder : MonoBehaviour {
	public static Rect getTextBox(string text, int addedWidth, int addedHeight) {
		Vector2 textDimensions = GUI.skin.label.CalcSize(new GUIContent(text));
		float width = textDimensions.x;
		float height = GUI.skin.label.CalcHeight (new GUIContent (text), width);
		width += addedWidth;
		height += addedHeight;
		Rect rect = new Rect (Screen.width/2 - width/2, 150, width, height);

		return rect;
	}
}
