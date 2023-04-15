using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public InventoryData inventoryData;

	private void Start()
	{
		AddInventorySlotsOnStart();
		CheckOnClosedSlotOnStart();
		AddOtherInventorySlotsOnStart();
	}
	private void AddInventorySlotsOnStart()
	{
		foreach (var obj in GameObject.FindGameObjectsWithTag("Inventory"))
		{
			inventoryData.slots.Add(obj);
		}
	}
	private void AddOtherInventorySlotsOnStart()
	{
		for (int i = 0; i < inventoryData.slots.Count; i++)
		{
			Slot slot = inventoryData.slots[i].GetComponent<Slot>();
			if (slot.GetOpenState())
			{
				inventoryData.freeSlots.Add(inventoryData.slots[i]);
			}
			else if (!slot.GetClosedState())
			{
				inventoryData.itemSlots.Add(inventoryData.slots[i]);
				if (!slot.GetFullStackState())
				{
					inventoryData.notFullStackSlots.Add(inventoryData.slots[i]);
				}
			}
		}
	}
	private void CheckOnClosedSlotOnStart()
	{
		for (int i = 0; i < inventoryData.priceForSlots.Count; i++)
		{
			if (inventoryData.priceForSlots[i] > 0)
			{
				CloseSlot(i);
			}
			else
			{
				OpenSlot(i);
			}
		}
	}

	private void CloseSlot(int index)
	{
		inventoryData.slots[index].GetComponent<Slot>().SetOpenState(false);
		inventoryData.slots[index].GetComponent<Slot>().SetClosedState(true);
		inventoryData.slots[index].GetComponent<Slot>().SetPrice(inventoryData.priceForSlots[index]);

		inventoryData.slots[index].GetComponentInChildren<TextMeshProUGUI>().text = inventoryData.priceForSlots[index].ToString() + "$";

		inventoryData.slots[index].GetComponent<Transform>().GetChild(0).gameObject.SetActive(true);
	}
	private void OpenSlot(int index)
	{
		inventoryData.slots[index].GetComponent<Slot>().SetOpenState(true);
		inventoryData.slots[index].GetComponent<Slot>().SetClosedState(false);
	}
}
