using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CursorManager : MonoBehaviour
{
    public static CursorManager _instance;

    public Texture2D cursor_attack;
    public Texture2D cursor_lockTarget;
    public Texture2D cursor_npctalk;
    public Texture2D cursor_normal;
    public Texture2D cursor_pick;

    private Vector2 host = Vector2.zero;
    private CursorMode model = CursorMode.Auto;

    void Awake()
    {
        _instance = this;
    }

    public void SetCursorNormal()
    {
        Cursor.SetCursor(cursor_normal, host, model);
    }

    public void SetCursorNpcTalk()
    {
        Cursor.SetCursor(cursor_npctalk,host,model);
    }
}
