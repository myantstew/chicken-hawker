using UnityEngine;
using System.Collections;

public class scr_deathAnimation : MonoBehaviour {

	public GameObject deadman;
	public GameObject deadbird;
	public AudioSource audiosource;
	public AudioClip birdDeath;
	public AudioClip birdFall;

	// Use this for initialization
	void Start () 
	{
		DeathAction ();
	}
	
	// Update is called once per frame
	public void DeathAction() 
	{
		GameObject man = Instantiate (deadman, transform.position, transform.rotation) as GameObject;
		GameObject bird = Instantiate (deadbird, transform.position, transform.rotation) as GameObject;
	}
}
