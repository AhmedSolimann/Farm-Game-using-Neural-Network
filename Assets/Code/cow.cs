using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cow : MonoBehaviour
{
	public GameObject Animal1;
	public AudioClip cow1;

	void OnMouseDown()
	{
		if (Animal1.name == "cow")
		{
			AudioManager.instance.RandomizeSfx (cow1);
		} 
	}
	

}
