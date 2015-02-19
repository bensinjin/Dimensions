using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory {
	public List<Item> items = new List<Item>();

	public Inventory() {
		items.Capacity = 30;
	}

	public int getSlotsFilled() {
		int filled = 0;
		foreach (Item i in items) {
			if (i.machineName != null) {
				filled  ++;
			}
		}

		return filled;
	}
}
