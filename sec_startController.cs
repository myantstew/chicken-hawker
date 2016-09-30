using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class sec_startController : MonoBehaviour {


	public AudioClip bgAudio;

	// Use this for initialization
	void Start () 
	{
		AudioSource.PlayClipAtPoint(bgAudio, transform.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("return"))
			NextLevel ();
		if (Input.GetKeyDown(KeyCode.Escape)) 
			EndGame();   
	}

	public void NextLevel()
	{
		Application.LoadLevel("gameScene");
	}
	public void EndGame()
	{
		Application.Quit();
	}
}
