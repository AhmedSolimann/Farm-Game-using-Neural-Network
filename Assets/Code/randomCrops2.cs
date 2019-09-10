using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomCrops2 : MonoBehaviour
{
	private int value = 1;
	public Sprite[] randomCrop;
	private float width = 2;
	private float height=2;
	public AudioClip clickEffect1;
	public AudioClip clickEffect2;
	// Use this for initialization
	void Start ()
	{
		randoCrop ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("r"))
		{
			AudioManager.instance.RandomizeSfx (clickEffect1);
			randoCrop ();
			gameObject.GetComponent<Renderer>().enabled= true;
		}
	}
	void OnTriggerEnter2D(Collider2D r)
	{
		if(r.name=="Farmer" )
		{
			AudioManager.instance.RandomizeSfx (clickEffect2);
			FindObjectOfType<farm>().score +=value;
			gameObject.GetComponent<Renderer>().enabled= false;
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
