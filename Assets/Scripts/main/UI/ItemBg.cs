using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBg : MonoBehaviour
{
    private int id = 0;
    private Text nameLabel;
    private int num = 0;

	// Use this for initialization
	void Start ()
	{
	    nameLabel = transform.Find("nameLabel").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.A))
	    {
            SetItemId(1003);
	    }
	}

    public void SetItemId(int id, int num = 1)
    {
        ItemMove item = GetComponentInChildren<ItemMove>();
        item.SetId(id);

        this.num = num;

        nameLabel.text = num.ToString();
        nameLabel.gameObject.SetActive(true);
    }

    public void Clear()
    {
        id = 0;
        Destroy(GetComponentInChildren<ItemMove>().gameObject);
        num = 0;

        nameLabel.gameObject.SetActive(false);
    }
}
