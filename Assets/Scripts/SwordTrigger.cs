using UnityEngine;
using System.Collections;

public class SwordTrigger : MonoBehaviour {
	public bool drawSwordText = false;

	void OnTriggerStay2D(Collider2D other) {
		if (Input.GetKeyDown(KeyCode.Z)) {
			drawSwordText = true;
		}
	}

	void OnGUI() {
		if (drawSwordText) {
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Ooo shiny sword!");
		}
	}
	void OnTriggerExit2D(Collider2D other) {
		drawSwordText = false;
	}
}
