using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Quest : MonoBehaviour
{

    public float inScreenX = 285;

    private Tweener tweener;

    // Use this for initialization
    void Start ()
	{
	    tweener = transform.DOLocalMoveX(inScreenX, 0.5f);
	    tweener.SetAutoKill(false);
	    tweener.Pause();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowQuest()
    {
        tweener.PlayForward();
    }

    public void HideQuest()
    {
        tweener.PlayBackwards();
    }
}
