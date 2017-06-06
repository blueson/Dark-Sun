using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))] //添加该脚本的物体上会自动添加CanvasGroup这个组件，该组件用来判断是否检测作用
public class ItemMove : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private Vector2 begin_pos = Vector2.zero; //开始拖拽物体的位置
    private Transform parentGameObject; // 开始拖拽物体的父物体

    private GameObject drage_icon;

    public void OnBeginDrag(PointerEventData eventData)
    {
        begin_pos = eventData.pointerDrag.GetComponent<RectTransform>().localPosition; // 记录开始拖拽物体的位置
        parentGameObject = eventData.pointerDrag.transform.parent;// 记录开始拖拽物体的父物体

        eventData.pointerDrag.transform.SetParent(GameObject.Find("Canvas").transform,false);
        eventData.pointerDrag.transform.SetAsLastSibling();//设置排在最后的hierarchy层级面板上
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(GetComponent<RectTransform>(),
            eventData.position,eventData.pressEventCamera,out worldPos))
        {
            transform.position = worldPos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        eventData.pointerDrag.transform.SetParent(parentGameObject);
        eventData.pointerDrag.GetComponent<RectTransform>().localPosition = begin_pos;
    }

    public void SetId(int id)
    {
        ObjectInfo ob = ObjectsInfo._instance.GetInfoByKey(id);
        print(ob.icon);
        Sprite sp = Resources.Load("Icon/" + ob.icon,typeof(Sprite)) as Sprite;
        GetComponent<Image>().sprite = sp;
    }
}
