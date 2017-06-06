using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject itemPanel;
    public GameObject[] itemList;
    public Text coinText;

    public int col = 5;
    public int row = 4;

    private PlayerInfo playerInfo;
    private Rect rect;

	// Use this for initialization
	void Start ()
	{
	    playerInfo = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerInfo>();
	    coinText.text = playerInfo.coin.ToString();
        itemList = new GameObject[col * row];
	    InitItems();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitItems()
    {
        rect = itemPanel.GetComponent<RectTransform>().rect;
        float width = rect.width;
        float height = rect.height;

        float itemWidth = width / col;
        float itemHeight = height / row;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                GameObject go = GameObject.Instantiate(itemPrefab, Vector3.zero,
                    Quaternion.identity);
                go.transform.parent = itemPanel.transform;
                go.transform.localPosition = new Vector3(itemWidth * j + itemWidth / 2, itemHeight * i + itemHeight / 2, 0);

                itemList[i * col + j] = go;
            }
        }
    }
}
