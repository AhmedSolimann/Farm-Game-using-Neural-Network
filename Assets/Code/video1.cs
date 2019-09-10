using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


public class video1 : MonoBehaviour
{
	private VideoPlayer videoPlayerr;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	public void playVideo()
	{
		videoPlayerr = GetComponent<VideoPlayer> ();
		videoPlayerr.Play();

	}
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
