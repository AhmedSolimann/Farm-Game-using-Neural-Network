using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheep : MonoBehaviour
{
	public GameObject Animal1;
	public GameObject Animal2;
	public AudioClip sheep1;

	void OnMouseDown()
	{
		if (Animal1.name == "sheep")
		{
			AudioManager.instance.RandomizeSfx (sheep1);
		} 
		if (Animal2.name == "sheep1")
		{
			AudioManager.instance.RandomizeSfx (sheep1);
		} 
	}
}
