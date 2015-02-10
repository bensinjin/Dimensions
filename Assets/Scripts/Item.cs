﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	public string itemName;
	public string itemMachineName;
	public string itemDescription;
	public Texture2D itemIcon;
	public ItemType itemType;

	public enum ItemType {
		Weapon,
		Consumeable,
		Quest
	}

	public Item(string name, string machineName, string desc, ItemType type) {
		this.itemName = name;
		this.itemMachineName = machineName;
		this.itemDescription = desc;
		this.itemIcon = Resources.Load<Texture2D>("Item Icons/"  + name);
		this.itemType = type;
	}

	public Item() {}
}
