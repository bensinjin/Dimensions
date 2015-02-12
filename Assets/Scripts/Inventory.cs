using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Inventory {
	public List<Item> inv = new List<Item>();
	public List<Item> slots = new List<Item>();
	public int slotsX;
	public int slotsY;

	public Inventory(int x, int y) {
		this.slotsX = x;
		this.slotsY = y;

		for (int i = 0; i <  (slotsX * slotsY); i ++) {
			slots.Add (new Item());
			inv.Add (new Item());
		}
	}
}
