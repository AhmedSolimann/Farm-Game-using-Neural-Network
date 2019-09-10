using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartMenu : MonoBehaviour
{
	public AudioMixer audioMixer;
	
    public void playGame()
	{
		SceneManager.LoadScene(1);
	}
	public void nn1()
	{
		SceneManager.LoadScene(2);
	}
	public void nn2()
	{
		SceneManager.LoadScene(3);
	}
	public void chalange1()
	{
		SceneManager.LoadScene(4);
	}
	public void chalange2()
	{
		SceneManager.LoadScene(5);
	}
	public void chalange6()
	{
		SceneManager.LoadScene(6);
	}
	public void quitGame()
	{
		Application.Quit();
	}
	public void setVolume(float volume)
	{
		audioMixer.SetFloat("volume", volume);
	}
}
