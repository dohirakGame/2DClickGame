using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableGameObject
{
    public string name;
    public float[] position;   // хранение позиции как массив float для сериализации
    public float[] quaternion; // хранение поворота как массив float для сериализации

    public SerializableGameObject(GameObject go)
    {
        name = go.name;
        Vector3 pos = go.transform.position;
        position = new float[] { pos.x, pos.y, pos.z };
        Quaternion rot = go.transform.rotation;
        quaternion = new float[] { rot.x, rot.y, rot.z, rot.w };
    }

    public GameObject GetGameObject()
    {
        GameObject go = new GameObject(name);
        go.transform.position = new Vector3(position[0], position[1], position[2]);
        go.transform.rotation = new Quaternion(quaternion[0], quaternion[1], quaternion[2], quaternion[3]);
        return go;
    }
}

[System.Serializable]
public class SerializableGameObjectList
{
    public List<SerializableGameObject> list;

    public SerializableGameObjectList(List<GameObject> gameObjectList)
    {
        list = new List<SerializableGameObject>();
        foreach (GameObject go in gameObjectList)
        {
            // Создание экземпляра SerializableGameObject из каждого игрового объекта
            SerializableGameObject sgo = new SerializableGameObject(go);
            list.Add(sgo);
        }
    }

    public List<GameObject> GetGameObjectList()
    {
        List<GameObject> gameObjectList = new List<GameObject>();
        foreach (SerializableGameObject sgo in list)
        {
            // Создание экземпляра игрового объекта из каждого SerializableGameObject
            GameObject go = sgo.GetGameObject();
            gameObjectList.Add(go);
        }
        return gameObjectList;
    }
}
