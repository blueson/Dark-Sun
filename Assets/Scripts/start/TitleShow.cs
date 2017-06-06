using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TitleShow : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void doSomething()
    {
        Image image = GetComponent<Image>();
        image.DOFade(1, 2);
    }
}
