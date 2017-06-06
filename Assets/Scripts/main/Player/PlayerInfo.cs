using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    public int hp = 100;
    public int mp = 100;
    public int coin = 200;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddCoin(int coin)
    {
        this.coin += coin;
    }
}
