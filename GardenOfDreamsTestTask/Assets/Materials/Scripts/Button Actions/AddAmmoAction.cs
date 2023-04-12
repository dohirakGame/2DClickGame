using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddAmmoAction : MonoBehaviour
{
	private InventoryData inventoryData;
	private GameObject itemPrefab;

	public void ActionAddAmmo()
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
		for (int i = 0; i < inventoryData.ammoItems.Count; i++)
		{
			if (inventoryData.freeslots.Count > 0)
			{
				int indexNotFullStack = 0;
				InitAmmoItem(inventoryData.freeslots[0], i);
				inventoryData.occupiedSlots.Add(inventoryData.freeslots[0]);
				inventoryData.notFullStackSlots.Add(inventoryData.freeslots[0]);
				inventoryData.freeslots.Remove(inventoryData.freeslots[0]);
				for (int j = 0; j < inventoryData.ammoItems[i].CountInStack; j++)
				{
					indexNotFullStack = CheckNotFullStackIndex(i);
					int currentCount = inventoryData.notFullStackSlots[indexNotFullStack].GetComponentInChildren<Item>().GetCount();
					inventoryData.notFullStackSlots[indexNotFullStack].GetComponentInChildren<Item>().SetCount(currentCount + 1);
				}
			} 
			else if (inventoryData.notFullStackSlots.Count > 0)
			{
				for (int j = 0; j < inventoryData.notFullStackSlots.Count; j++)
				{
					if (inventoryData.notFullStackSlots[j].GetComponentInChildren<Item>().GetItemType() == "Ammo")
					{
						for (int k = 0; k < inventoryData.ammoItems[i].CountInStack; k++)
						{
							if (inventoryData.notFullStackSlots[j].GetComponentInChildren<Item>().GetCount() < inventoryData.ammoItems[i].CountInStack)
							{
								int currentCount = inventoryData.notFullStackSlots[j].GetComponentInChildren<Item>().GetCount();
								inventoryData.notFullStackSlots[j].GetComponentInChildren<Item>().SetCount(currentCount + 1);
							}
							else break;
						}
					}
				}
			}
		}
	}
	
	private int CheckNotFullStackIndex(int index)
	{
		int notFullSlotIndex = 0;
		for (int k = 0; k < inventoryData.notFullStackSlots.Count; k++)
		{
			if (inventoryData.notFullStackSlots[k].GetComponentInChildren<Item>().GetItemType() == "Ammo")
			{
				if (inventoryData.notFullStackSlots[k].GetComponentInChildren<Item>().GetCount() < inventoryData.ammoItems[index].CountInStack)
				{
					notFullSlotIndex = k;
					break;
				}
				else
				{
					//InitAmmoItem(inventoryData.freeslots[0], index);
					inventoryData.occupiedSlots.Add(inventoryData.freeslots[0]);
					inventoryData.notFullStackSlots.Remove(inventoryData.notFullStackSlots[k]);
				}
			}
		}
		return notFullSlotIndex;
	}
	private void InitAmmoItem(GameObject slot, int id)
	{
		Vector3 spawnPoint = new Vector3(slot.transform.position.x, slot.transform.position.y, slot.transform.position.z);
		GameObject item = Instantiate(itemPrefab, spawnPoint, Quaternion.identity);
		item.transform.SetParent(slot.transform);

		item.AddComponent<Item>();
		item.GetComponent<Item>().SetAmmoParameters(inventoryData.ammoItems, id);
	}
}
