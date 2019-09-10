using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rewards : MonoBehaviour
{
	public GameObject textt;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	public void rew()
	{
		textt.SetActive(true);
		StartCoroutine( waitForS() );
	}
	
	IEnumerator waitForS()
	{
		yield return new WaitForSeconds(3);
		textt.SetActive(false);
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
