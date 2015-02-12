using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractableItemTrigger : MonoBehaviour {
	private GameManager gm;
	// Inventory to update
	private Inventory inv;
	// Item database, for item lookups
	private ItemDatabase idb;
	// Messages
	public List<Message> triggerMsgs;
	// Counts z button presses
	private int zCount;
	// Keeps track of our messages index
	private int index;
	// Public, destroyable game object
	public GameObject referencedObject;
	// Public, machine name used to retrieve necessary messages
	public string triggerMachineName;
	// Public, item machine name used to retrieve item from the database;
	public string itemMachineName;



	void Start() {
		gm = GameManager.instance;
		inv = gm.inv;
		idb = gm.idb;
		triggerMsgs = gm.mdb.findForTrigger(triggerMachineName);
		zCount = 0;
		index = 0;
	}

	void OnTriggerExit2D() {
		zCount = 0;
	}

	void OnTriggerStay2D(Collider2D other) {
		if (Input.GetKeyDown (KeyCode.Z)) {
			zCount += 1;
			index = zCount - 1;
			if (zCount > triggerMsgs.Count) {
				// Add our item to the inventory
				inv.inv[0] = idb.findByMachineName(itemMachineName);
				//Remove item from the scene
				GameObject.Destroy(referencedObject);
				//Clear the messages
				triggerMsgs.Clear();
			} 
		}
	}

	void OnGUI() {
		if (zCount >= 1 && zCount <= triggerMsgs.Count) {
			Message msg = triggerMsgs[index];
			Rect rect = GUIBuilder.getTextBox (msg.text, 0, 35);
			GUI.Box (rect, msg.text, gm.textBoxSkin.GetStyle ("Box"));
		}
	}
	
}
