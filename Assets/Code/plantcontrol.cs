using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class plantcontrol : MonoBehaviour {
	public Text scoreUI;
	public Sprite noPlantObj;
	public Sprite sunFlower1;
	public Sprite sunFlower2;
	public Sprite sunFlower3;
	public float growTime = 0;
	public float endTime = 0;

	public Transform soilObj;
	public string watered="n";

	public int counter=0;
	public AudioClip click1;
	

	
	
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update ()
	{

		scoreUI.text = "" + counter;
		
		if (GetComponent<SpriteRenderer> ().sprite == sunFlower1)
		{
			growTime += Time.deltaTime;

		}	
			
		if (growTime > 5 &&GetComponent<SpriteRenderer> ().sprite == sunFlower1) {
			if (watered == "y") {
				GetComponent<SpriteRenderer> ().sprite = sunFlower2;
			} else {
				growTime = 0;
				GetComponent<SpriteRenderer> ().sprite = noPlantObj;

			}
		} 


		if (soilObj.GetComponent<SpriteRenderer> ().color == Color.blue)
		{
			endTime += Time.deltaTime;
		}


		if (endTime > 4)
		{
			if (watered == "y") 
			{
				soilObj.GetComponent<SpriteRenderer> ().color = Color.clear;

			}
			else
			{
				endTime = 0;
				soilObj.GetComponent<SpriteRenderer> ().color = Color.clear;
			}
		}

		if ((Grass.currentTool == "harvest"))
		{	
			if (Input.GetMouseButtonDown(1))
			{
				counter++;
			}	

		}
		if(counter == 10)
		{
			SceneManager.LoadScene(6);
		}

	}
	


	void OnMouseDrag()
	{

		if (Grass.currentTool == "scythe") {
			//Destroy (gameObject);
			GetComponent<SpriteRenderer> ().sprite = noPlantObj;
			AudioManager.instance.RandomizeSfx (click1);
		}

		if ((Grass.currentTool == "seeds") && (GetComponent<SpriteRenderer> ().sprite == noPlantObj)) {
			GetComponent<SpriteRenderer> ().sprite = sunFlower1;
			AudioManager.instance.RandomizeSfx (click1);
		}

		if (Grass.currentTool == "water") {
			soilObj.GetComponent<SpriteRenderer> ().color = Color.blue;
			watered = "y";
			AudioManager.instance.RandomizeSfx (click1);
		}
		if ((Grass.currentTool == "collector") && (GetComponent<SpriteRenderer> ().sprite == sunFlower2))
		{
			GetComponent<SpriteRenderer> ().sprite =sunFlower3;	
			AudioManager.instance.RandomizeSfx (click1);
		}
		if (Grass.currentTool == "harvest" &&  GetComponent<SpriteRenderer> ().sprite==sunFlower3)
		{
			GetComponent<SpriteRenderer> ().sprite = noPlantObj;				
			AudioManager.instance.RandomizeSfx (click1);
		}
		
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "wasp(Clone)")
		{
			Destroy(this.gameObject);
		}
	}


}
