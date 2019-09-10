using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomCrops : MonoBehaviour {
	

	public Sprite[] randomCrop;
	private float width = 2;
	private float height=2;
	
	// Use this for initialization
	void Start ()
	{
		randoCrop();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("r"))
		{
			randoCrop();
		}
	}

	public void randoCrop()
	{
		int i = Random.Range (0, randomCrop.Length);
		GetComponent<SpriteRenderer> ().sprite = randomCrop [i];
		Vector3 scale = new Vector3 (width, height, 0f);
		transform.localScale = scale;
	}
	
	

}
