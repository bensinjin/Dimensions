using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwordTrigger : MonoBehaviour {
	private bool swordTextDisplayed = false;
	public Inventory inv;
	public ItemDatabase db;
	public GameObject sword;
	
	void OnTriggerStay2D(Collider2D other) {
		if (Input.GetKeyDown (KeyCode.Z) &&  !swordTextDisplayed) {
			inv.inventory[0] = db.items[0];
			GameObject.Destroy(sword);
			swordTextDisplayed = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (swordTextDisplayed) {
			Destroy (this);
		}
	}

	void OnGUI() {
		if (swordTextDisplayed) {
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "You recieve the sword.");
		}
	}

}
