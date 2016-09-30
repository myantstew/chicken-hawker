using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreUpdate : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start () 
	{
		text = GetComponent<Text> ();
		scr_scoreBoard.SCORE = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = "SCORE: " + scr_scoreBoard.SCORE;
	}
}
