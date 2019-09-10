using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasp : MonoBehaviour
{

    public float movespeed;
    public bool isfacingright;

	
	public void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        isfacingright = !isfacingright;
    }
	
    void FixedUpdate()
	{
		if (isfacingright)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-movespeed, GetComponent<Rigidbody2D>().velocity.y);
		}

	}
	void OnMouseDown()
	{
		if (gameObject.name == "wasp(Clone)")
		{
			Destroy(this.gameObject);
		}
	}
	
}
