using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WhiteScreen : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    Image image = GetComponent<Image>();
	    image.DOFade(0, 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
