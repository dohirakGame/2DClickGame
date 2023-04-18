using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSerAndDeser : MonoBehaviour
{
	private InventoryData _inventoryData;
	string json;

	private void Start()
	{
		_inventoryData = FindObjectOfType<InventoryData>();
	}
	public void SerData() 
    {
		SerializableGameObjectList serializableList = new SerializableGameObjectList(_inventoryData.ammoSlots);
		json = JsonUtility.ToJson(serializableList);
		Debug.Log($"SerData {serializableList}");
    }

	public void DeserData()
	{
		SerializableGameObjectList serializableList = JsonUtility.FromJson<SerializableGameObjectList>(json);
		List<GameObject> gameObjectsList = serializableList.GetGameObjectList();
		Debug.Log($"DeserData {gameObjectsList}");
	}
}
