using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MessageDatabase : Database {
	public List<Message> messages = new List<Message>(); 
	
	void Start() {
		messages.Add(new Message("chp1_i_would_leave", "I would leave that night.", false, Message.MessageType.System));
	}
}
