﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item>(); 

	void Start() {
		items.Add (new Item ("Great Sword", 0, "The Greatest Sword", Item.ItemType.Weapon));
	}
}