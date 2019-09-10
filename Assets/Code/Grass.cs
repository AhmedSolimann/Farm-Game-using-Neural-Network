using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour {

	public Transform grassObj;
	public static string currentTool="none";
	// Use this for initialization
	void Start () {
		for (int xPos = -8; xPos < 10; xPos += 2)
		{
			for (int yPos = 5; yPos>-6; yPos -= 2)
			{
				Instantiate (grassObj,new Vector2(xPos,yPos),grassObj.rotation);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
