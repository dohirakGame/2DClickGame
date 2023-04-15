using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemAction : MonoBehaviour
{
	private InventoryData _inventoryData;
	private GameObject _itemPrefab;
	public void ActionAddItem()
	{
		SetDataParameters();
		AddItem();
	}

	private void SetDataParameters()
	{
		_inventoryData = FindObjectOfType<InventoryData>();
		_itemPrefab = FindObjectOfType<ButtonAction>().prefab;
	}
	private void AddItem()
	{
		for (int i = 0; i < 3; i++)
		{
			if (_inventoryData.freeSlots.Count > 0)
			{
				_inventoryData.itemSlots.Add(_inventoryData.freeSlots[0]);
				InitItem(_inventoryData.freeSlots[0], i);
				_inventoryData.freeSlots.Remove(_inventoryData.freeSlots[0]);
			}
		}
	}

	private void InitItem(GameObject slot, int itemType)
	{
		int id = GetRandomId();
		Vector3 spawnPoint = new Vector3(slot.transform.position.x, slot.transform.position.y, slot.transform.position.z);
		GameObject item = Instantiate(_itemPrefab, spawnPoint, Quaternion.identity);
		item.transform.SetParent(slot.transform);

		item.AddComponent<UIItem>();
		item.AddComponent<CanvasGroup>();
		item.AddComponent<Item>();
		switch (itemType)
		{
			case 0:
				item.GetComponent<Item>().SetItemParameters(_inventoryData.gunItems, id);
				item.GetComponent<Item>().UpdateParametersHubIncrease(_inventoryData.gunItems, id);
				break;
			case 1:
				item.GetComponent<Item>().SetItemParameters(_inventoryData.headItems, id);
				item.GetComponent<Item>().UpdateParametersHubIncrease(_inventoryData.headItems, id);
				break;
			case 2:
				item.GetComponent<Item>().SetItemParameters(_inventoryData.bodyItems, id);
				item.GetComponent<Item>().UpdateParametersHubIncrease(_inventoryData.bodyItems, id);
				break;
			default:
				break;
		}
	}

	private int GetRandomId()
	{
		return Random.Range(0, 2);
	}
}
