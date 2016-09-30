using UnityEngine;
using System.Collections;

public class scr_mydeath : MonoBehaviour {

	private Vector2 jumpForce = new Vector2(0,150);

	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody2D>().AddForce (jumpForce);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.gameObject.tag == "imdead" && this.transform.position.y < -8) 
		{
			scr_Silo.GAMESPEED = 1;
			Application.LoadLevel ("endScene");
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "wall" && this.gameObject.tag == "imdead")
			Application.LoadLevel ("endScene");
		else
			Destroy (this.gameObject);
	}
}
