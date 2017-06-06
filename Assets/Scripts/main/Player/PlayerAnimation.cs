using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private PlayerMove move;
    private Animation animation;

	// Use this for initialization
	void Start ()
	{
	    move = GetComponent<PlayerMove>();
	    animation = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (move.state == PlayerState.Moving)
	    {
            animation.CrossFade("Run");
	    }
	    else if(move.state == PlayerState.Idle)
	    {
	        animation.CrossFade("Idle");
	    }
	}
}
