using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Database : MonoBehaviour {

	public List<Entity> entities = new List<Entity>(); 

	public Entity findByMachineName(string machineName) {
		foreach (Entity e in entities) {
			if (e.machineName == machineName) {
				return e;
			}
		}
		
		return null;
	}
}
