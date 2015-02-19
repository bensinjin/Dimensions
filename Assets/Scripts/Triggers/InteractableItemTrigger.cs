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
	// We'll  need this to stop the player
	private PlayerInput pi;
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
		pi = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
	}

	void OnTriggerExit2D() {
		zCount = 0;
	}

	void OnTriggerStay2D(Collider2D other) {
		if (Input.GetKeyDown (KeyCode.Z) && triggerMsgs.Count > 0) {
			// Stop the player
			pi.showTriggerMessage = true;
			zCount += 1;
			index = zCount - 1;
			// Last message in the queue add the item to the inventory
			if (zCount == triggerMsgs.Count) {
				// Remove item from the scene
				GameObject.Destroy(referencedObject);
				// Add our item to the inventory
				inv.items.Add(idb.findByMachineName(itemMachineName));

			}
			if (zCount == triggerMsgs.Count + 1) {
				// Remove this script from the scene
				GameObject.Destroy(gameObject);
				// Resume movement
				pi.showTriggerMessage = false;
			} 
		}
	}

	void OnGUI() {
		// If the number of times z is pressed >= 1
		// and it is not greater than the number of
		// messages in the queue, show the message.
		if (zCount >= 1 && zCount <= triggerMsgs.Count) {
			Message msg = triggerMsgs[index];
			Rect rect = GUIBuilder.getTextBox (msg.text, 0, 35);
			GUI.Box (rect, msg.text, gm.textBoxSkin.GetStyle ("Box"));
		}
	}
	
}
