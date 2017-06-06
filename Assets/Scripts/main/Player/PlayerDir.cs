using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDir : MonoBehaviour
{

    public GameObject clickPrefab;
    public Vector3 targetPosition;

    private bool isMoving = false;

	// Use this for initialization
	void Start ()
	{
        targetPosition = transform.position;
	    isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
	    {
	        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	        RaycastHit hitInfo;
	        bool isCast = Physics.Raycast(ray, out hitInfo);
	        if (isCast && hitInfo.collider.tag == Tags.ground)
	        {
	            ShowClickEffect(hitInfo.point);
	            isMoving = true;
                LookAtTargetPoint(hitInfo.point);
	        }
	    }

	    if (Input.GetMouseButtonUp(0))
	    {
	        isMoving = false;
	    }

	    if (isMoving)
	    {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isCast = Physics.Raycast(ray, out hitInfo);
            if (isCast && hitInfo.collider.tag == Tags.ground)
            {
                LookAtTargetPoint(hitInfo.point);
            }
        }
	}

    void LookAtTargetPoint(Vector3 hitInfoPoint)
    {
        targetPosition = hitInfoPoint;
        targetPosition = new Vector3(hitInfoPoint.x, transform.position.y, hitInfoPoint.z);
        transform.LookAt(targetPosition);
    }

    void ShowClickEffect(Vector3 hitInfoPoint)
    {
        hitInfoPoint = new Vector3(hitInfoPoint.x, hitInfoPoint.y + 0.1f, hitInfoPoint.z);
        GameObject.Instantiate(clickPrefab, hitInfoPoint, Quaternion.identity);
    }
}
