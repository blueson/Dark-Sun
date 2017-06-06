using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlayer : MonoBehaviour
{

    public GameObject[] createPlayerPrefabs;
    public InputField nameInput;

    private GameObject[] createPlayerGameObjects;
    private int selectIndex;
    private int createPlayerLength;

	// Use this for initialization
	void Start ()
	{
	    selectIndex = 0;
	    createPlayerLength = createPlayerPrefabs.Length;
        createPlayerGameObjects = new GameObject[createPlayerLength];

        for (int i = 0; i < createPlayerLength; i++)
	    {
	        createPlayerGameObjects[i] = GameObject.Instantiate(createPlayerPrefabs[i], transform.position,
	            transform.rotation);
	    }
	    ShowSelectPlayer();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowSelectPlayer()
    {
        foreach (var player in createPlayerGameObjects)
        {
            player.SetActive(false);
        }

        createPlayerGameObjects[selectIndex].SetActive(true);
    }

    public void PrevButtonClick()
    {
        selectIndex--;
        if (selectIndex < 0)
        {
            selectIndex = createPlayerLength - 1;
        }
        ShowSelectPlayer();
    }

    public void NextButtonClick()
    {
        selectIndex++;
        selectIndex %= createPlayerLength;
        ShowSelectPlayer();
    }

    public void OkButtonClick()
    {
        PlayerPrefs.SetInt("PlayerType",selectIndex);
        print(nameInput.text);
        PlayerPrefs.SetString("PlayerName",nameInput.text);
    }
}
