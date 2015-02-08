using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public List<Item> inventory = new List<Item>();
	private ItemDatabase db;
	// Use this for initialization
	void Start () {
		db = GameObject.FindGameObjectWithTag ("Item Database").GetComponent<ItemDatabase>();
	}
	
	void OnGUI() {
		if (Input.GetKeyDown (KeyCode.X)) {
			for (int i = 0; i < inventory.Count; i++) {
				print (inventory[i].itemName);
				GUI.Label (new Rect(5,i * 20, 200, 50), inventory[i].itemName);
			}
		}
	}
}
