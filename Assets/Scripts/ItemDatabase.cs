using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item>(); 

	void Start() {
		items.Add(new Item ("Great Sword", "great_sword", "The Greatest Sword", Item.ItemType.Weapon));
	}

	public Item findByMachineName(string machineName) {
		foreach (Item i in items) {
			if (i.itemMachineName == machineName) {
				return i;
			}
		}

		return null;
	}
}
