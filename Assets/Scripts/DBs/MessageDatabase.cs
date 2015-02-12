using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MessageDatabase {
	public List<Message> messages = new List<Message>(); 
		
	public Message findByMachineName(string machineName) {
		foreach (Message m in messages) {
			if ( m.machineName == machineName) {
				return m;
			}
		}
		Debug.LogWarning("There were no message results back for " + machineName);
		return null;
	}

	public List<Message> findForTrigger(string triggerMachineName) {
		List<Message> msgs = new List<Message>();
		foreach (Message m in messages) {
			if (m.triggerMachineName != null && m.triggerMachineName == triggerMachineName) {
				msgs.Add(m);
			}
		}

		if (msgs.Count == 0) {
			Debug.LogWarning("There were no message results back for " + triggerMachineName);
		}
		return msgs;
	}

	public void populate() {
		// System
		messages.Add(
			new Message(
				"chp1_i_would_leave",
				"I would leave that night.",
				Message.MessageType.System
			)
		);
		// Hints
		messages.Add(
			new Message(
				"chp1_its_pitch_black",
		        "It's pitch black, I need to find some light.",
				Message.MessageType.Hint
			)
		);
		// Triggers
		messages.Add(
			new Message(
				"chp1_oh_shit_kylans",
				"Oh shit, this must be kylan's smoke stash, looks like he's got a lighter.",
				Message.MessageType.Trigger,
				"chp1_lighter_trigger"
			)
		);
		messages.Add(
			new Message(
				"chp1_recieve_lighter",
				"You receive Kylan's firestick.",
				Message.MessageType.Trigger,
				"chp1_lighter_trigger"
			)
		);
	}
}
