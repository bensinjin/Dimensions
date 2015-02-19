using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour  {
	// Databases
	public MessageDatabase mdb = new MessageDatabase();
	public ItemDatabase idb = new ItemDatabase();
	// Misc
	public Inventory inv = new Inventory();
	// Styles
	public GUISkin textBoxSkin;
	public GUISkin uiSkin;
	// System Message Queue
	public List<Message> systemMessages = new List<Message>();

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