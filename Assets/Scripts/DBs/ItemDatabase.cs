﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : Database {
	public List<Item> items = new List<Item>(); 

	void Start() {
		items.Add(new Item ("Great Sword", "great_sword", "The Greatest Sword", Item.ItemType.Weapon));
	}	
}