using UnityEngine;
using System.Collections;

[System.Serializable]
public class Message : Entity {

	public string text;
	public bool displayed;
	public MessageType type;
	
	public enum MessageType {
		System,
		NPC
	}
	
	public Message(string machineName, string text, bool displayed, MessageType type) {
		this.machineName = machineName;
		this.text = text;
		this.displayed = displayed;
		this.type = type;
	}
	
	public Message() {}
}

