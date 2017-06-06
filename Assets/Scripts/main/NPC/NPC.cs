using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPC : MonoBehaviour {

    void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            CursorManager._instance.SetCursorNpcTalk();
        }
    }

    void OnMouseExit()
    {
        CursorManager._instance.SetCursorNormal();
    }
}
