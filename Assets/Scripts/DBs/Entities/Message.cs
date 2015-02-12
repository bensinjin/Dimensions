using UnityEngine;
using System.Collections;

[System.Serializable]
public class Message : Entity {
	
	public string text;
	public MessageType type;
	public string triggerMachineName;
	public bool displayed;
	
	public enum MessageType {
		System,
		NPC,
		Hint,
		Trigger
	}
	
	public Message(string machineName, string text, MessageType type, string triggerMachineName = null) {
		this.machineName = machineName;
		this.text = text;
		this.type = type;
		this.triggerMachineName = triggerMachineName;
		this.displayed = false;
	}
	
	public Message() {}
}

