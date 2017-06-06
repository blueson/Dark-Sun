using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInfo : MonoBehaviour
{

    public static ObjectsInfo _instance;
    public TextAsset textAsset;

    private Dictionary<int,ObjectInfo> objectsDict = new Dictionary<int, ObjectInfo>();

    private void Awake()
    {
        _instance = this;
        ReadObjectsInfo();
    }

    void ReadObjectsInfo()
    {
        string objectsStr = textAsset.text;
        string[] objectsStrArray = objectsStr.Split('\n');

        foreach (var str in objectsStrArray)
        {
            string[] objectInfoStrArray = str.Split(',');

            ObjectInfo info = new ObjectInfo();
            info.id = int.Parse(objectInfoStrArray[0]);
            info.name = objectInfoStrArray[1];
            info.icon = objectInfoStrArray[2];
            string type = objectInfoStrArray[3];
            switch (type)
            {
                case "Drug":
                    info.type = ObjectType.Drug;

                    info.hp = int.Parse(objectInfoStrArray[4]);
                    info.mp = int.Parse(objectInfoStrArray[5]);
                    info.price_sell = int.Parse(objectInfoStrArray[6]);
                    info.price_buy = int.Parse(objectInfoStrArray[7]);

                    break;
                case "Equip":
                    info.type = ObjectType.Equip;
                    break;
                case "Mat":
                    info.type = ObjectType.Mat;
                    break;
            }

            objectsDict.Add(info.id,info);
        }
    }

    public ObjectInfo GetInfoByKey(int id)
    {
        ObjectInfo info = null;
        objectsDict.TryGetValue(id, out info);
        return info;
    }
}

public enum ObjectType
{
    Drug,
    Equip,
    Mat
}

public class ObjectInfo
{
    public int id;
    public string name;
    public string icon;
    public ObjectType type;
    public int hp;
    public int mp;
    public int price_sell;
    public int price_buy;


}
