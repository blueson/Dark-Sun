using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Moving,
    Idle
}

public class PlayerMove : MonoBehaviour
{

    public int speed = 4;
    public PlayerState state;

    private PlayerDir dir;
    private CharacterController controller;

	// Use this for initialization
	void Start ()
	{
	    dir = GetComponent<PlayerDir>();
	    controller = GetComponent<CharacterController>();
	    state = PlayerState.Idle;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float distance = Vector3.Distance(dir.targetPosition, transform.position);
	    if (distance >= 0.5f)
	    {
	        controller.SimpleMove(transform.forward * speed);
	        state = PlayerState.Moving;
	    }
	    else
	    {
            state = PlayerState.Idle;
	    }
	}
}
