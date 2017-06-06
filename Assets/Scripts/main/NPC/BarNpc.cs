using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BarNpc : NPC
{

    public Quest quest;
    public Text text;
    public GameObject acceptButton;
    public GameObject cancelButton;
    public GameObject okButton;
    public int killCount = 0;

    private bool isTask = false;
    private int targetKillCount = 10;
    private PlayerInfo playerInfo;

	// Use this for initialization
	void Start ()
	{
	    playerInfo = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerInfo>();

	    ShowQuestView();

	}

    void ShowQuestView()
    {
        if (isTask)
        {
            showTaskStatus();
        }
        else
        {
            showTaskInfo();
        }
    }

    // Update is called once per frame
	void Update () {
	    
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            quest.ShowQuest();
            ShowQuestView();
        }
    }

    void showTaskInfo()
    {
        text.text = "任务：\n击杀10只小狼\n\n奖励：\n1000金币";
        acceptButton.SetActive(true);
        cancelButton.SetActive(true);
        okButton.SetActive(false);
    }

    void showTaskStatus()
    {
        text.text = "任务进度：\n击杀" + killCount + "/" + targetKillCount + "只狼\n\n奖励：\n1000金币";
        acceptButton.SetActive(false);
        cancelButton.SetActive(false);
        okButton.SetActive(true);
    }

    public void acceptButtonClick()
    {
        isTask = true;
        showTaskStatus();
    }

    public void okButtonClick()
    {
        if (killCount >= targetKillCount)
        {
            playerInfo.AddCoin(1000);
            isTask = false;
            showTaskInfo();
        }
    }
}
