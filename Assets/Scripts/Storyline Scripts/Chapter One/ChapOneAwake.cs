using UnityEngine;
using System.Collections;

public class ChapOneAwake : MonoBehaviour {
	public GUISkin skin;
	private bool showIntroBox = true;

	void Update() {
		if (Input.GetKeyDown (KeyCode.Z)) {
			showIntroBox  = false;
		}
	}

	void OnGUI() {
		if (showIntroBox) {
			string text = "I would leave tonight. Tonight was the darkest I'd seen. [z]";
			Rect rect = GUIBuilder.getTextBox (text, -200, 30);
			GUI.Box (rect, text, skin.GetStyle ("Box"));
		}
	}

}
