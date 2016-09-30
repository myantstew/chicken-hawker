using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class scr_enemyGenerator : MonoBehaviour {

	public GameObject silo;
	public GameObject cropduster;
	public GameObject barn;
	public GameObject coyote;
	public GameObject coin;

	public int myScore;
	public float coyoteFreq = 6f;

	public bool speed1, speed2, speed3, speed4, speed5, speed6, speed7, speed8;

	public AudioClip crow;


	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("CreateObstacle", 1f, 10f);
		InvokeRepeating ("CreateCropduster", 10f, 20f);
		InvokeRepeating ("CreateBarn", 3f, 16f);
		InvokeRepeating ("CreateCoyote", 2f, coyoteFreq);
		InvokeRepeating ("CreateCoin", 1f, 3f);

	}
	
	// Update is called once per frame
	void CreateObstacle () 
	{
		float height = Random.Range (-1f, 3.5f);
		Vector2 offScreen = new Vector2 (16, height);
		Instantiate (silo, offScreen, Quaternion.identity);
	}
	void CreateCropduster () 
	{
		float height = Random.Range (1.5f, 4.5f);
		Vector2 offScreen = new Vector2 (16, height);
		Instantiate (cropduster, offScreen, Quaternion.identity);
	}
	void CreateBarn () 
	{
		float height = Random.Range (0f, 2f);
		Vector2 offScreen = new Vector2 (16, height);
		Instantiate (barn, offScreen, Quaternion.identity);
	}
	void CreateCoyote () 
	{
		float height = Random.Range (-2.5f, 4.5f);
		Vector2 offScreen = new Vector2 (-16, height);
		Instantiate (coyote, offScreen, Quaternion.identity);
		coyoteFreq = Random.Range (2f, 6f);
	}
	void CreateCoin () 
	{
		float height = Random.Range (-5f, 5f);
		Vector2 offScreen = new Vector2 (16, height);
		Instantiate (coin, offScreen, Quaternion.identity);
	}
	void Update()
	{
		myScore = scr_scoreBoard.SCORE;

		if (myScore > 1500 && !speed2) 
		{
			speed2 = true;
			SpeedUp ();
		}
		if (myScore > 5000 && !speed3) 
		{
			speed3 = true;
			SpeedUp ();
		}
		if (myScore > 10000 && !speed4) 
		{
			speed4 = true;
			SpeedUp ();
		}
		if (myScore > 15000 && !speed5) 
		{
			speed5 = true;
			SpeedUp ();
		}
		if (myScore > 20000 && !speed6) 
		{
			speed6 = true;
			SpeedUp ();
		}
		if (myScore > 30000 && !speed7) 
		{
			speed7 = true;
			SpeedUp ();
		}
		if (myScore > 45000 && !speed8) 
		{
			speed8 = true;
			SpeedUp ();
		}


		if (Input.GetKeyDown (KeyCode.Escape)) 
			Application.Quit (); 
	}

	void SpeedUp()
	{
		scr_Silo.GAMESPEED += 0.5f;
		Vector2 center = new Vector2 (0, 0);
		AudioSource.PlayClipAtPoint(crow, center);
	}
}
