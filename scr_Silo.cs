using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class scr_Silo : MonoBehaviour {

	public Vector2 silovelocity;
	public Vector2 cropvelocity;
	public Vector2 coinvelocity;
	public Vector2 coyotevelocityUp;
	public Vector2 coyotevelocityDown;
	public float coyotecurrent;
	public float minY;
	public float maxY;
	public bool goingUp;
	public int startDirection;
	public float max;
	public float min;
	public GameObject coinburst;
	public GameObject planecrash;
	public GameObject coyotedead;

	public AudioClip coyoteDeath;

	public AudioClip death1;
	public AudioClip death2;
	public AudioClip death3;
	public AudioClip death4;
	public AudioClip death5;
	public AudioClip bang;
	public AudioClip coin;

	public int deathChoice;


	public static float GAMESPEED = 1.0f;

	// Use this for initialization
	void Start () 
	{
		silovelocity = new Vector2 (-2*GAMESPEED, 0);
		cropvelocity = new Vector2 (-8*GAMESPEED, 0);
		coinvelocity = new Vector2 (-2*GAMESPEED, 0);
		coyotevelocityUp = new Vector2 (2*GAMESPEED, 1f);
		coyotevelocityDown = new Vector2 (0.5f*GAMESPEED, -1f);
		coyotecurrent = transform.position.y;
		startDirection = Random.Range (0, 1);
		goingUp = (startDirection == 1);
		max = coyotecurrent + 1;
		min = coyotecurrent - 1;


	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.tag == "silo")
		GetComponent<Rigidbody2D>().velocity = silovelocity;
		else if (this.tag == "cropduster")
		GetComponent<Rigidbody2D>().velocity = cropvelocity;
		else if (this.tag == "coin")
		GetComponent<Rigidbody2D>().velocity = coinvelocity;
		else if (this.tag == "coyote") 
			{
				if(goingUp)
				{
					GetComponent<Rigidbody2D>().velocity = coyotevelocityUp;
					if(transform.position.y >= max)
					goingUp = false;
				}
				else
				{
					GetComponent<Rigidbody2D>().velocity = coyotevelocityDown;
					if(transform.position.y <= min)
					goingUp = true;
				}
			
			}
		if (this.transform.position.x < -18)
			Destroy (this.gameObject);

	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		Vector2 coinMove = new Vector2(transform.position.x+2, transform.position.y);

		if (other.gameObject.tag == "Player" && this.gameObject.tag == "coin")
			KillMe ();
		else if (other.gameObject.tag == "Player" && this.gameObject.tag == "coyote" &&
		    other.transform.position.y > this.transform.position.y + 1) 
		{
			KillMe ();
		}
		if (other.gameObject.tag == "silo" && this.gameObject.tag == "coin")
			transform.position = coinMove;
	}



	public void KillMe()
	{
		if (this.gameObject.tag == "coin") 
		{
			AudioSource.PlayClipAtPoint(coin, transform.position);
			scr_scoreBoard.SCORE += 100; 
			Instantiate (coinburst, transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}
		else if(this.gameObject.tag == "coyote")
		{
			deathChoice = Random.Range(1,5);
			switch(deathChoice)
			{
			case 1:
				coyoteDeath = death1;
				break;
			case 2:
				coyoteDeath = death2;
				break;
			case 3:
				coyoteDeath = death3;
				break;
			case 4:
				coyoteDeath = death4;
				break;
			case 5:
				coyoteDeath = death5;
				break;
			}
			AudioSource.PlayClipAtPoint(bang, transform.position);
			scr_scoreBoard.SCORE += 20;
			AudioSource.PlayClipAtPoint(coyoteDeath, transform.position);
			Instantiate (planecrash, transform.position, Quaternion.identity);
			Instantiate (coyotedead, transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
}
