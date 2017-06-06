using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility.Inspector;

public class FllowPlayer : MonoBehaviour
{
    public float distanceSpeed = 10.0f;
    public float rotationSpeed = 2.0f;
    private Transform player;
    private Vector3 offset;

    private bool isRotating = false;

	// Use this for initialization
	void Start ()
	{
	    player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(player);

	    offset = transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = player.position + offset;

	    if (Input.GetMouseButtonDown(1))
	    {
	        isRotating = true;
	    }

	    if (Input.GetMouseButtonUp(1))
	    {
	        isRotating = false;
	    }

	    // 控制镜头转动的方法
	    RotatingView();

        // 控制镜头远近的方法
	    ScrollView();
	}

    void ScrollView()
    {
        if (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) > 0)
        {
            float distance = offset.magnitude;
            distance += Input.GetAxis("Mouse ScrollWheel") * distanceSpeed;
            distance = Mathf.Clamp(distance, 3, 18);
            offset = offset.normalized * distance;
        }
    }

    void RotatingView()
    {
        if (isRotating)
        {
            transform.RotateAround(player.position, player.up, Input.GetAxis("Mouse X") * rotationSpeed);

            Vector3 oldPosition = transform.position;
            Quaternion oldQuaternion = transform.rotation;

            transform.RotateAround(player.position,-transform.right,Input.GetAxis("Mouse Y") * rotationSpeed);

            float x = transform.eulerAngles.x;
            if (x < 10 || x > 80)
            {
                transform.position = oldPosition;
                transform.rotation = oldQuaternion;
            }

            offset = transform.position - player.position;
        }
    }
}
