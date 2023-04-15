using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItemAction : MonoBehaviour
{
	private InventoryData _inventoryData;
	public void ActionRemoveItem()
	{
		SetDataParameters();
		RemoveRandomItem();
	}

	private void SetDataParameters()
	{
		_inventoryData = FindObjectOfType<InventoryData>();
	}

	private void RemoveRandomItem()
	{
		if (_inventoryData.itemSlots.Count > 0 && _inventoryData.ammoSlots.Count > 0)
		{
			switch (RandomTypeItem())
			{
				case 0:
					RemoveItem();
					break;
				case 1:
					RemoveAmmo();
					break;
				default:
					Debug.Log("ERROR: All slots are empty");
					break;
			}
		}
		else if (_inventoryData.itemSlots.Count > 0)
		{
			RemoveItem();
		}
		else if (_inventoryData.ammoSlots.Count > 0)
		{
			RemoveAmmo();
		}
		else
		{
			Debug.Log("ERROR: All slots are empty");
		}
	}

	private void RemoveItem()
	{
		int place = RandomSlot(_inventoryData.itemSlots.Count);
		Item itemObject = _inventoryData.itemSlots[place].GetComponentInChildren<Item>();

		_inventoryData.freeSlots.Add(_inventoryData.itemSlots[place]);

		if (itemObject.GetItemType() == "Head")
		{
			Debug.Log("HER1");
			itemObject.UpdateParametersHubDecrease(_inventoryData.headItems, itemObject.GetId());
		} 
		else if (itemObject.GetItemType() == "Body")
		{
			Debug.Log("HER2");
			itemObject.UpdateParametersHubDecrease(_inventoryData.bodyItems, itemObject.GetId());
		}
		else if (itemObject.GetItemType() == "Gun")
		{
			Debug.Log("HER3");
			itemObject.UpdateParametersHubDecrease(_inventoryData.gunItems, itemObject.GetId());
		}

		_inventoryData.itemSlots.Remove(_inventoryData.itemSlots[place]);

		itemObject.DestroyItem();

		SortList(_inventoryData.freeSlots);
	}
	private void RemoveAmmo()
	{
		int place = RandomSlot(_inventoryData.ammoSlots.Count);
		Item itemObject = _inventoryData.ammoSlots[place].GetComponentInChildren<Item>();

		_inventoryData.freeSlots.Add(_inventoryData.ammoSlots[place]);

		itemObject.UpdateParametersHubDecrease(_inventoryData.ammoItems, itemObject.GetId());

		_inventoryData.ammoSlots.Remove(_inventoryData.ammoSlots[place]);

		itemObject.DestroyItem();

		SortList(_inventoryData.freeSlots);
	}
	
	private int RandomSlot(int count)
	{
		return Random.Range(0, count);
	}
	private int RandomTypeItem()
	{
		return Random.Range(0, 2);
	}
	private void SortList(List<GameObject> slots)
	{
		GameObject test = slots[slots.Count-1];
		for (int i = slots.Count - 2; i >= 0; i--) 
		{
			slots[i+1] = slots[i];
		}
		slots[0] = test;
	}
}
