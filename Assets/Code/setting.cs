using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class setting : MonoBehaviour
{
    public AudioMixer audioMixer;
	Resolution[] resolutions;
	public Dropdown resolutionDropdown;
	
	void Start()
	{
		resolutions=Screen.resolutions; //this value holds all possible resolution for the screen
		resolutionDropdown.ClearOptions(); //clear all options in the drop down
		List<string> options =new List<string>(); //create the list which would hold the resolution values
		int currentResolutionIndex=0;
		for(int i=0; i<resolutions.Length; i++ )
		{
			string option=resolutions[i].width+" x "+resolutions[i].height;
			options.Add(option); //add every resolution to the list
			if(resolutions[i].width==Screen.currentResolution.width && resolutions[i].height==Screen.currentResolution.height)
			{
				currentResolutionIndex=i;
			}
		}
		resolutionDropdown.AddOptions(options); //add the option to the dropdown menu
		resolutionDropdown.value=currentResolutionIndex; //Apply value of resolution to each dropdown
		resolutionDropdown.RefreshShownValue(); //refresh the dropdown list when selecing the value
	}
	
	public void setVolume(float volume)
	{
		audioMixer.SetFloat("volume", volume); //connect the slider to the audiomixer
	}
	
	public void setQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex); //set the quality of graphic
		
	}
	
	public void setFullscreen(bool isFullscreen)
	{
		Screen.fullScreen=isFullscreen; //check if screen is full or not
	}
	
	public void setResolution(int resolutionIndex)
	{
		Resolution resolution=resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);//Applky resolution value to the screen
	}
}
