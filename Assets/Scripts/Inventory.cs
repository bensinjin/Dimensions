using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int slotsX, slotsY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item>();
	private bool showInv = false;

	void Start() {
		for (int i = 0; i <  (slotsX * slotsY); i ++) {
			slots.Add (new Item());
			inventory.Add (new Item());
		}
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.X)) {
			//Toggle inventory
			showInv = !showInv;
		}
	}

	void OnGUI() {
		GUI.skin = skin;
		if (showInv) {
			drawInventory();
		}
	}

	void drawInventory() {
		int i = 0;
		for (int x = 0; x < slotsX; x++) {
			for (int y = 0; y < slotsY; y++) {
				Rect slotRect = new Rect(x * 20, y * 20, 20, 20);
				GUI.Box (slotRect, "", skin.GetStyle("Slot"));
				slots[i] = inventory[i];
				if (slots[i].itemName != null) {
					GUI.DrawTexture (slotRect, slots[i].itemIcon);
				}
				i ++;
			}
		}
	}
}
