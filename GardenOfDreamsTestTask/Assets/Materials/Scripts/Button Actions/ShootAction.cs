using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAction : MonoBehaviour
{
	private InventoryData _inventoryData;
	public void ActionShoot()
	{
		SetDataParameters();
		Shoot();
	}

	private void SetDataParameters()
	{
		_inventoryData = FindObjectOfType<InventoryData>();
	}

	private void Shoot()
	{
		int ammoID = RandomAmmoId();
		bool isShoot = false;
		Item ammoItem;
		if (_inventoryData.ammoSlots.Count > 0)
		{ 
			for (int i = 0; i < _inventoryData.ammoSlots.Count; i++)
			{
				ammoItem = _inventoryData.ammoSlots[i].GetComponentInChildren<Item>();
				if (ammoItem.GetId() == ammoID)
				{
					DecreaseCount(ammoItem);
					ammoItem.UpdateAmmoParametersHubDecrease(_inventoryData.ammoItems, ammoItem.GetId());
					CheckCountInStack(ammoItem, i);

					isShoot = true;
					break;
				}
			}
			if (!isShoot)
			{
				ammoItem = _inventoryData.ammoSlots[0].GetComponentInChildren<Item>();
				ammoItem.UpdateAmmoParametersHubDecrease(_inventoryData.ammoItems, ammoItem.GetId());
				DecreaseCount(ammoItem);
				CheckCountInStack(ammoItem, 0);
			}
		}
	}

	private void CheckCountInStack(Item item, int index)
	{
		if (item.GetCount() == 0)
		{
			_inventoryData.freeSlots.Add(_inventoryData.ammoSlots[index]);
			_inventoryData.ammoSlots.Remove(_inventoryData.ammoSlots[index]);
			item.DestroyItem();
			SortList(_inventoryData.freeSlots);
		}
	}
	private void DecreaseCount(Item ammo)
	{
		ammo.SetCount(ammo.GetCount() - 1);
		ammo.UpdateItemUI();
	}

	private int RandomAmmoId()
	{
		return Random.Range(1,3);
	}
	private void SortList(List<GameObject> slots)
	{
		GameObject test = slots[slots.Count - 1];
		for (int i = slots.Count - 2; i >= 0; i--)
		{
			slots[i + 1] = slots[i];
		}
		slots[0] = test;
	}
}
