using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCamera : MonoBehaviour {

    public int moveTime = 5;
    public GameObject[] gameObjects;

    private float maxZ = -30;

    private void Awake()
    {
        DOTween.Init();
    }

    // Use this for initialization
    void Start ()
    {
        Tweener tweener = transform.DOMoveZ(maxZ, moveTime);
        tweener.OnComplete(new TweenCallback(showTitle));
        tweener.SetEase(Ease.Linear);
    }
	
	// Update is called once per frame
	void Update () {

	}

    void showTitle()
    {
        foreach (var gameObject in gameObjects)
        {
            gameObject.SendMessage("doSomething");
        }
    }
}
