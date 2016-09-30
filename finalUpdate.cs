using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finalUpdate : MonoBehaviour {

	Text text;
	int myScore = scr_scoreBoard.SCORE;
	// Use this for initialization
	void Start () 
	{
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.gameObject.tag == "text1")
			text.text = "YOUR SCORE: " + myScore;
		else if (this.gameObject.tag == "text2") 
		{
			if(myScore <= 50)
			text.text = "Did you even try?";
			else if(myScore > 50 && myScore <= 100)
				text.text = "Noobish Effort!";
			else if(myScore > 100 && myScore <= 200)
				text.text = "Needs Improvement!";
			else if(myScore > 200 && myScore <= 500)
				text.text = "Pretty Average!";
			else if(myScore > 500 && myScore <= 800)
				text.text = "Decent Job!";
			else if(myScore > 800 && myScore <= 1000)
				text.text = "Pretty Solid!";
			else if(myScore > 1000 && myScore <= 2000)
				text.text = "Somewhat Impressed!";
			else if(myScore > 2000 && myScore <= 5000)
				text.text = "Very Nice!";
			else if(myScore > 5000 && myScore <= 8000)
				text.text = "Well Above Average!";
			else if(myScore > 8000 && myScore <= 10000)
				text.text = "Superior Effort!";
			else if(myScore > 10000 && myScore <= 15000)
				text.text = "Rooster Pro!";
			else if(myScore > 15000 && myScore <= 20000)
				text.text = "Rooster Expert!";
			else if(myScore > 20000 && myScore <= 30000)
				text.text = "Rooster Master!";
			else if(myScore > 30000 && myScore <= 50000)
				text.text = "IMMORTAL!!";
		}

		if (Input.GetKeyDown ("return"))
			NextLevel ();
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit(); 
	}
	public void NextLevel()
	{
		Application.LoadLevel("gameScene");
	}
}
