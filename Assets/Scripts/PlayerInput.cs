using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class PlayerInput : MonoBehaviour {
	
	public float speed;
	public Boundary boundary;
	public bool showUi;
	public bool showSystemMessage;
	public bool showTriggerMessage;
	private GameManager gm;

	void Start() {
		gm = GameManager.instance;
	}

	// Player movement
	void FixedUpdate () {
		// Only allow movement when there are no windows open.
		if (!showUi && !showSystemMessage && !showTriggerMessage) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
		
			Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
			rigidbody2D.velocity = movement * speed;
			rigidbody2D.position = new Vector2 (rigidbody2D.position.x, rigidbody2D.position.y);
		}
	}

	// Player inventory and action keys
	void Update() {
		if (Input.GetKeyDown (KeyCode.X)) {
			//Stop player
			rigidbody2D.velocity = Vector2.zero;
			//Toggle ui (also disables movement)
			showUi = !showUi;
		}
		if (Input.GetKeyDown (KeyCode.Z) && gm.systemMessages.Count > 0) {
			//Toggle showMessage (also diables movement)
			showSystemMessage = false;
			gm.systemMessages.Remove(gm.systemMessages[0]);
		}

	}

	void OnGUI() {
		// If we have a system message (removed when z is pressed) show it.
		if (gm.systemMessages.Count > 0) {
			//Stop player
			rigidbody2D.velocity = Vector2.zero;
			showSystemMessage = true;
			Message msg = gm.systemMessages[0];
			Rect rect = GUIBuilder.getTextBox (msg.text, 0, 35);
			GUI.Box (rect, msg.text, gm.textBoxSkin.GetStyle ("Box"));
		}
		if (showUi) {
			GUIBuilder.buildUi(gm.uiSkin, gm.inv);
		}
	}

	/* Use for reference
	void drawUi() {
		int slotsY = gm.inv.slotsY;
		int slotsX = gm.inv.slotsX;
		int i = 0;
		for (int y = 0; y < slotsY; y++) {
			for (int x = 0; x < slotsX; x++) {
				Rect slotRect = new Rect((x + 5) * 20, (y  + 5) * 20, 20, 20);
				GUI.Box (slotRect, "", skin.GetStyle("Slot"));
				gm.inv.slots[i] = gm.inv.inv[i];
				if (gm.inv.slots[i].itemName != null) {
					GUI.DrawTexture (slotRect, gm.inv.slots[i].itemIcon);
				}
				i ++;
			}
		}
	}
	*/
}
