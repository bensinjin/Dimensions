using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChapOneAwake : MonoBehaviour {
	private GameManager gm;
	private bool lightOn;
	private GameObject player;

	void Start () {
		lightOn = false;
		gm = GameManager.instance;
		player = GameObject.FindGameObjectWithTag("Player");

		// Setup our intial system messages queue
		gm.systemMessages.Add(
			gm.mdb.findByMachineName("chp1_i_would_leave")
		);
		
		// Setup our initial hint message queue
		gm.hintMessages.Add(
			gm.mdb.findByMachineName("chp1_its_pitch_black")
		);	
	}

	void Update() {
		if (gm.inv.inv.Contains(gm.idb.findByMachineName("lighter")) && lightOn == false) {
			player.light.intensity = 1.0f;
			lightOn = true;
		}
	}


}
