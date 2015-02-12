using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChapOneAwake : MonoBehaviour {
	private GameManager gm;

	void Start () {
		gm = GameManager.instance;
		// Setup our intial system messages queue
		gm.systemMessages.Add(
			gm.mdb.findByMachineName("chp1_i_would_leave")
		);
		
		// Setup our initial hint message queue
		gm.hintMessages.Add(
			gm.mdb.findByMachineName("chp1_its_pitch_black")
		);	
	}


}
