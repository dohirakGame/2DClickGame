using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemAction : MonoBehaviour
{
	private InventoryData inventoryData;
	private GameObject itemPrefab;
	public void ActionAddItem()
	{
		SetDataParameters();
		OccupiedSlot();
	}

	private void SetDataParameters()
	{
		inventoryData = FindObjectOfType<InventoryData>();
		itemPrefab = FindObjectOfType<ButtonAction>().prefab;
	}
	private void OccupiedSlot()
	{
		for (int i = 0; i < 3; i++)
		{
			if (inventoryData.freeslots.Count > 0)
			{
				inventoryData.occupiedSlots.Add(inventoryData.freeslots[0]);
				InitItem(inventoryData.freeslots[0], i);
				inventoryData.freeslots.Remove(inventoryData.freeslots[0]);
			}
		}
	}

	private void InitItem(GameObject slot, int itemType)
	{
		int id = GetRandomNumber();
		Vector3 spawnPoint = new Vector3(slot.transform.position.x, slot.transform.position.y, slot.transform.position.z);
		GameObject item = Instantiate(itemPrefab, spawnPoint, Quaternion.identity);
		item.transform.SetParent(slot.transform);

		item.AddComponent<Item>();
		switch (itemType)
		{
			case 0:
				item.GetComponent<Item>().SetItemParameters(inventoryData.gunItems, id);
				break;
			case 1:
				item.GetComponent<Item>().SetItemParameters(inventoryData.headItems, id);
				break;
			case 2:
				item.GetComponent<Item>().SetItemParameters(inventoryData.bodyItems, id);
				break;
			default:
				break;
		}
	}

	private int GetRandomNumber()
	{
		return Random.Range(0, 2);
	}
}
