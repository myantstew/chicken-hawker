using UnityEngine;
using System.Collections;

public class scr_trophy : MonoBehaviour {

	public Sprite blank;
	public Sprite bronze;
	public Sprite silver;
	public Sprite gold;
	public int myScore;

	// Use this for initialization
	void Start () 
	{
		myScore = scr_scoreBoard.SCORE;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Trophy ();
	}

	void Trophy() 
	{
		if (myScore > 20000)
			gameObject.GetComponent<SpriteRenderer> ().sprite = gold;
		else if(myScore > 8000)
			gameObject.GetComponent<SpriteRenderer>().sprite = silver;
		else if(myScore > 1000)
			gameObject.GetComponent<SpriteRenderer>().sprite = bronze;
		else
			gameObject.GetComponent<SpriteRenderer>().sprite = blank;
	}
}
