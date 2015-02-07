using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class PlayerMover : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public ArrayList inventory;
	
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
	
}
 