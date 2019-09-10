using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class challange3 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		if(FindObjectOfType<plantcontrol>().counter == 6)
		{
			SceneManager.LoadScene(7);
			
		}
    }
}
