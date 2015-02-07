using UnityEngine;
using System.Collections;


public class SignTrigger : MonoBehaviour {
	private bool drawSignText = false;

	void OnTriggerEnter2D(Collider2D other) {
		drawSignText = true;
	}
	void OnTriggerExit2D(Collider2D other) {
		drawSignText = false;
	}

	void OnGUI() {
		if (drawSignText) {
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Danger! Fuck faces ahead!");
		}
	}
}
