using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class farm : MonoBehaviour {
	
	public int score;
	public Text scoreUI;
	private float speed=1.7f ;
	private Animator Animator;
	
	void Start()
	{
		Animator = GetComponent<Animator> ();
	}


	public void animateMovement(Vector2 directon)
	{
		
		Animator.SetLayerWeight (1, 1);
		Animator.SetFloat ("x", directon.x);
		Animator.SetFloat ("y", directon.y);	
	}

	void OnTriggerEnter2D(Collider2D r)
	{
		if( r.name=="crop-2" ||  r.name=="crop-4"  || r.name=="crop-6" )
		{
			Animator.SetTrigger("Readyy");			
		}

	}

	void Update() {
		
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal,moveVertical,0);
		transform.position += movement * speed * Time.deltaTime;
		scoreUI.text =""+score;
		if(score==5)
		{
			SceneManager.LoadScene(5);
		}
		if (movement.x != 0 || movement.y != 0) 
		{
			animateMovement (movement);
		} 
		else 
		{
			Animator.SetLayerWeight (1, 0);
		}
	}
}
