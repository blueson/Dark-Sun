using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{

    private AudioSource audio;

	// Use this for initialization
	void Start ()
	{
	    audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGameButtonClick()
    {
        PlayButtonSound();
        Application.LoadLevel(1);
    }

    public void LoadGameButtonClick()
    {
        PlayButtonSound();
    }

    void PlayButtonSound()
    {
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }
}
