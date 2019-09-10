using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tools2 : MonoBehaviour
{
	public GameObject curser;
	public GameObject b1;
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	
	public void ButtonClick()
    {
		curser.transform.position =b1.GetComponent<RectTransform>().position;
	}

}
