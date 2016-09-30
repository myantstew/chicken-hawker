using UnityEngine;
using System.Collections;

public class scr_backgroundScroll : MonoBehaviour {

	float speed;
	public float x;
	// Use this for initialization
	void Start () 
	{
		speed = scr_Silo.GAMESPEED * 0.1f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		x = Mathf.Repeat (Time.time * speed, 1);
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", new Vector2 (x, 0));
	}
}
