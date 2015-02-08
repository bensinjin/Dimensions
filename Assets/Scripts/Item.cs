using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	public string itemName;
	public int itemId;
	public string itemDescription;
	public Texture2D itemIcon;
	public itemType type;

	public enum itemType {
		Weapon,
		Consumeable,
		Quest
	}
}
