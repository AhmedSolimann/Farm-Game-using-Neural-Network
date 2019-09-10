using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseCursor : MonoBehaviour {

	// Use this for initialization
	public SpriteRenderer rend;
	public Sprite curs1;
	public Sprite curs2;
	public Sprite curs3;
	public Sprite curs4;
	public Sprite curs5;
	public Sprite normalCursor;
	public GameObject clickEffect;

	void Start () {
		
		rend = GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		Vector2 cursorPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = cursorPos;
		
		
		
		if (Input.GetMouseButton (0) && Grass.currentTool == "scythe")
		{
			Cursor.visible = false;
			rend.sprite = curs1;
			Instantiate (clickEffect, transform.position, Quaternion.identity);
		}
		else if (Input.GetMouseButton (0) && Grass.currentTool == "seeds")
		{
			Cursor.visible = false;
			rend.sprite = curs2;
			Instantiate (clickEffect, transform.position, Quaternion.identity);
		}
		else if (Input.GetMouseButton (0) && Grass.currentTool == "water")
		{
			Cursor.visible = false;
			rend.sprite = curs3;
			Instantiate (clickEffect, transform.position, Quaternion.identity);
		}
		else if (Input.GetMouseButton (0) && Grass.currentTool == "collector")
		{
			Cursor.visible = false;
			rend.sprite = curs4;
			Instantiate (clickEffect, transform.position, Quaternion.identity);
		}
		else if (Input.GetMouseButton (0) && Grass.currentTool == "harvest")
		{
			Cursor.visible = false;
			rend.sprite = curs5;
			Instantiate (clickEffect, transform.position, Quaternion.identity);
		}
		else if (Input.GetMouseButton (1))
		{
			rend.sprite = normalCursor;
			Instantiate (clickEffect, transform.position, Quaternion.identity); 
			Cursor.visible = true;
		}


	}

}
