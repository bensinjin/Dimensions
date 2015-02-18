using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class PlayerInput : MonoBehaviour {
	
	public float speed;
	public Boundary boundary;
	private GUISkin uiSkin;
	private bool showUi;
	private GameManager gm;

	void Start() {
		gm = GameManager.instance;
		uiSkin = gm.uiSkin;
	}
	
	// Player movement
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rigidbody2D.velocity = movement * speed;
		rigidbody2D.position = new Vector2( 
        	Mathf.Clamp (rigidbody2D.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp (rigidbody2D.position.y, boundary.yMin, boundary.yMax)
         );
	}

	// Player ui
	void Update() {
		if (Input.GetKeyDown (KeyCode.C)) {
			//Toggle ui
			showUi = !showUi;
		}
	}

	void OnGUI() {
		if (showUi) {
			drawUi();
		}
	}

	void drawUi() {
		GUI.BeginGroup (GUIBuilder.getUiBorder(), uiSkin.GetStyle("Box"));
		GUI.EndGroup ();
	}

	/*
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
