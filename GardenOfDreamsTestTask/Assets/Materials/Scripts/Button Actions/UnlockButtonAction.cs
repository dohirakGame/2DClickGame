using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockButtonAction : MonoBehaviour
{
	[SerializeField] private GameObject lockIcon;
	[SerializeField] private GameObject slot;

	private InventoryData _inventoryData;

	private void SetParameters()
	{
		_inventoryData = FindObjectOfType<InventoryData>();
	}
	public void UnlockSlot()
	{
		SetParameters();

		PlayerData playerData = FindObjectOfType<PlayerData>();

		if (playerData.GetMoney() >= slot.GetComponent<Slot>().GetPrice())
		{
			playerData.SetMoney(playerData.GetMoney() - slot.GetComponent<Slot>().GetPrice());
			playerData.UpdateHub();
			slot.GetComponent<Slot>().SetClosedState(false);
			slot.GetComponent<Slot>().SetOpenState(true);
			lockIcon.SetActive(false);
			gameObject.SetActive(false);
			_inventoryData.freeSlots.Add(slot);
		}
		else Debug.Log("You need more money");
	}
}
