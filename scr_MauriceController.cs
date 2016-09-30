using UnityEngine;
using System.Collections;

public class scr_MauriceController : MonoBehaviour {

	public Vector2 jumpForce = new Vector2(0,300);
	public float moveSpeed = 5;
	public GameObject death;
	public Vector2 left = new Vector2(-1,0);

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp ("space")) 
		Jump ();
		if (Input.GetKeyDown ("left"))
		MoveLeft ();
		else if (Input.GetKeyDown ("right"))
		MoveRight ();
	}

	public void Jump()
	{
		GetComponent<Rigidbody2D>().AddForce (jumpForce);
		if(jumpForce.y > 500)
			jumpForce.y = 500;
	}

	public void MoveLeft()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2 (-1*moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}

	public void MoveRight()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2 (1*moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "coyote" && other.transform.position.y + 1 > this.transform.position.y)
			Die ();
	}
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "backwall" && other.transform.position.x > this.transform.position.x)
			Die();
	}
	void Die()
	{
		GameObject dying = Instantiate (death, transform.position, transform.rotation) as GameObject;
		Destroy (this.gameObject);
	}

}
