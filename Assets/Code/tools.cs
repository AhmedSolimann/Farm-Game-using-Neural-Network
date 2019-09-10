using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tools : MonoBehaviour {


	public Transform curserObj;
	public Transform scythe;
	public Transform seeds;
	public Transform water;
	public Transform harvest;
	public Transform collector;
	public AudioClip click1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}
	void OnMouseDown()
	{
		if (gameObject.name == "scythe")
		{
			Grass.currentTool = "scythe";
			AudioManager.instance.RandomizeSfx (click1);
		}

		if (gameObject.name == "seeds")
		{
			Grass.currentTool = "seeds";
			AudioManager.instance.RandomizeSfx (click1);
		}

		if (gameObject.name == "water")
		{
			Grass.currentTool = "water";
			AudioManager.instance.RandomizeSfx (click1);
		}

		if (gameObject.name == "collector")
		{
			Grass.currentTool = "collector";
			AudioManager.instance.RandomizeSfx (click1);
		}

		if (gameObject.name == "harvest")
		{
			Grass.currentTool = "harvest";
			AudioManager.instance.RandomizeSfx (click1);
		}
		
		curserObj.transform.position = transform.position;
		Debug.Log (Grass.currentTool);

	}
	void OnMouseEnter()
	{
		if (gameObject.name == "scythe")
		{
			scythe.transform.position = transform.position;
			scythe.GetComponent<Renderer>().enabled = true;
		}

		if (gameObject.name == "seeds")
		{
			seeds.transform.position = transform.position;
			seeds.GetComponent<Renderer>().enabled = true;
		}

		if (gameObject.name == "water")
		{
			water.transform.position = transform.position;
			water.GetComponent<Renderer>().enabled = true;
		}

		if (gameObject.name == "collector")
		{
			collector.transform.position = transform.position;
			collector.GetComponent<Renderer>().enabled = true;
		}

		if (gameObject.name == "harvest")
		{
			harvest.transform.position = transform.position;
			harvest.GetComponent<Renderer>().enabled = true;
		}

	}
	void OnMouseExit ()
	{
		if (gameObject.name == "scythe")
		{
			scythe.GetComponent<Renderer>().enabled = false;
		}

		if (gameObject.name == "seeds")
		{
			seeds.GetComponent<Renderer>().enabled = false;
		}

		if (gameObject.name == "water")
		{
			water.GetComponent<Renderer>().enabled = false;
		}

		if (gameObject.name == "collector")
		{
			collector.GetComponent<Renderer>().enabled = false;
		}

		if (gameObject.name == "harvest")
		{
			harvest.GetComponent<Renderer>().enabled = false;
		}
	}

}
