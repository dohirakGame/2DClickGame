using UnityEngine;

public class AddAmmoAction : MonoBehaviour
{
	private InventoryData _inventoryData;
	private GameObject _itemPrefab;

	public void ActionAddAmmo()
	{
		SetDataParameters();
		AddAmmoItems();
	}

	private void SetDataParameters()
	{
		_inventoryData = FindObjectOfType<InventoryData>();
		_itemPrefab = FindObjectOfType<ButtonAction>().prefab;
	}
	private void AddAmmoItems()
	{
		for (int i = 0; i < _inventoryData.ammoItems.Count; i++)
		{
			CheckSlotsForIncrese(i);
		}
	}


	private void CheckSlotsForIncrese(int index)
	{
		if (_inventoryData.freeSlots.Count > 0)
		{
			InitAmmoItem(_inventoryData.freeSlots[0], index);
			UpdateElementsAndSetCount(index);
		}
		else if (_inventoryData.ammoSlots.Count > 0)
		{
			ReplenishmentAmmo(index);
		}
	}


	private void InitAmmoItem(GameObject slot, int id)
	{
		Vector3 spawnPoint = new Vector3(slot.transform.position.x, slot.transform.position.y, slot.transform.position.z);
		GameObject item = Instantiate(_itemPrefab, spawnPoint, Quaternion.identity);
		item.transform.SetParent(slot.transform);

		item.AddComponent<UIItem>();
		item.AddComponent<CanvasGroup>();
		item.AddComponent<Item>();
		item.GetComponent<Item>().SetAmmoParameters(_inventoryData.ammoItems, id);
		item.GetComponent<Item>().UpdateParametersHubIncrease(_inventoryData.ammoItems, id);
	}
	private void UpdateElementsAndSetCount(int index)
	{
		_inventoryData.ammoSlots.Add(_inventoryData.freeSlots[0]);
		_inventoryData.freeSlots.Remove(_inventoryData.freeSlots[0]);
		_inventoryData.ammoSlots[_inventoryData.ammoSlots.Count - 1]
			.GetComponentInChildren<Item>().SetCount(_inventoryData.ammoItems[index].CountInStack);
	}


	private void ReplenishmentAmmo(int index)
	{
		int countForIncrease = _inventoryData.ammoItems[index].CountInStack;
		for (int j = 0; j < _inventoryData.ammoSlots.Count; j++)
		{
			if (_inventoryData.ammoSlots[j].GetComponentInChildren<Item>().GetId() == index + 1)
			{
				for (int k = 0; k < countForIncrease; countForIncrease--)
				{
					if (_inventoryData.ammoSlots[j].GetComponentInChildren<Item>().GetCount() < _inventoryData.ammoItems[index].CountInStack)
					{
						int currentCount = _inventoryData.ammoSlots[j].GetComponentInChildren<Item>().GetCount();
						Item ammoItem = _inventoryData.ammoSlots[j].GetComponentInChildren<Item>();
						ammoItem.SetCount(currentCount + 1);
						ammoItem.UpdateAmmoParametersHubIncrease(_inventoryData.ammoItems, ammoItem.GetId());
						ammoItem.UpdateItemUI();
					}
					else break;
				}
			}
		}
	}
}
