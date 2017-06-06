using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PressAnyKey : MonoBehaviour
{

    private Image image;
    private bool isCanAnyKey = false;

    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCanAnyKey && Input.anyKey)
        {
            showButtons();
        }
    }

    void showButtons()
    {
        GameObject go = this.transform.parent.Find("Buttons").gameObject;
        go.SetActive(true);

        this.gameObject.SetActive(false);
    }

    public void doSomething()
    {
        isCanAnyKey = true;
        image.DOFade(1, 2).OnComplete(new TweenCallback(blinkHide));
    }

    void blinkHide()
    {
        image.DOFade(0, 1f).OnComplete(new TweenCallback(blinkShow));
    }

    void blinkShow()
    {
        image.DOFade(1, 1f).OnComplete(new TweenCallback(blinkHide));
    }

}
