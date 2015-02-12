using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase {
	public List<Item> items = new List<Item>(); 

	public void populate() {
		// Quest
		items.Add(
			new Item ("Lighter", "lighter", "Kylan's firestick.", Item.ItemType.Quest)
		);
	}

	public Item findByMachineName(string machineName) {
		foreach (Item i in items) {
			if (i.machineName == machineName) {
				return i;
			}
		}

		Debug.LogWarning("There were no item results back for " + machineName);
		return null;
	}
}
