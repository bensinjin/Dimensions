using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour  {
	// Databases
	public MessageDatabase mdb = new MessageDatabase();
	public ItemDatabase idb = new ItemDatabase();
	// Misc
	public Inventory inv = new Inventory(4, 5);
	// Styles
	public GUISkin textBoxSkin;
	// Message Queues
	public List<Message> systemMessages = new List<Message>();
	public List<Message> hintMessages = new List<Message>();
	private bool showHint;

	/**END OF PUBLIC VARIABLES**/

	private static GameManager _instance;
	
	public static GameManager instance {
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<GameManager>();
				
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}

	// Populate our dbs and initialize showHint
	void Start() {
		mdb.populate();
		idb.populate();
		showHint = false;
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Z) && systemMessages.Count > 0) {
			systemMessages.Remove(systemMessages[0]);
		}
		
		if (Input.GetKeyDown (KeyCode.X) && hintMessages.Count > 0) {
			showHint = !showHint;
		}
	}

	void OnGUI() {
		// If we have a system message (removed when z is pressed) show it.
		if (systemMessages.Count > 0) {
			Message msg = systemMessages[0];
			Rect rect = GUIBuilder.getTextBox (msg.text, 0, 35);
			GUI.Box (rect, msg.text, textBoxSkin.GetStyle ("Box"));
		}
		if (showHint) {
			Message msg = hintMessages[0];
			Rect rect = GUIBuilder.getTextBox (msg.text, 0, 35, 150);
			GUI.Box (rect, msg.text, textBoxSkin.GetStyle ("Box"));
		}
	}
	
	void Awake() {
		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}

}