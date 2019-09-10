using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource exfxSource;
	public AudioSource musicSource;
	public static AudioManager instance = null;
	public float lowpitchRange = .95f;
	public float highpitchRange = 1.05f;
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void Awake ()
	{
		if (instance == null)
			instance = this;

		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	public void PlaySingle(AudioClip clip)
	{
		exfxSource.clip = clip;
		exfxSource.Play();
	}

	public void RandomizeSfx (params AudioClip[] Clips)
	{
		int randomIndex = Random.Range(0, Clips.Length);

		float randomPitch = Random.Range(lowpitchRange, highpitchRange);

		exfxSource.pitch = randomPitch;
		exfxSource.clip = Clips[randomIndex];
		exfxSource.Play();

	}
}
