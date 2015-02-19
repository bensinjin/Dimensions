using UnityEngine;
using System.Collections;

public class GUIBuilder : MonoBehaviour {
	// Private constructor, this class cannot be instantiated
	private GUIBuilder() {}

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

	public static void buildUi(GUISkin skin, Inventory inv) {
		Rect border = new Rect (Screen.width/2 - 250, 30, 500, 350);
		GUI.BeginGroup (border, skin.GetStyle("Box"));
		GUI.DrawTexture (new Rect(10, 25, 200, 300), Resources.Load<Texture2D>("Character/Character"));
		for (int i = 0; i < inv.getSlotsFilled(); i ++) {
			Rect labelRect = new Rect(350, i + 30, 100, 30);
			GUI.Box(labelRect, inv.items[i].itemName, skin.GetStyle("ItemBox"));
		}
		GUI.EndGroup ();
	}
}
