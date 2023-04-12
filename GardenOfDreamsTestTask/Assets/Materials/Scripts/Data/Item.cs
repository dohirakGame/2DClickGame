using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
	[SerializeField] private int _count = 0;
	[SerializeField] private string _itemType = "";
	[SerializeField] private int _id;

	public int GetCount()
	{
		return _count;
	}
	public void SetCount(int value)
	{
		_count = value;
	}
	public string GetItemType()
	{
		return _itemType;
	}
	public void SetItemType(string value)
	{
		_itemType = value;
	}
	public int GetId()
	{
		return _id;
	}
	public void SetId(int value)
	{
		_id = value;
	}


    public void SetAmmoParameters(List<ItemData> data, int id)
	{
		GetComponent<Image>().sprite = data[id].Icon;
		SetItemType(data[id].ItemType.ToString());
		SetId(id);
		//if (data[id].CountInStack > 1) GetComponentInChildren<TextMeshProUGUI>().text = data[id].CountInStack.ToString();
		//if (GetCount() > 1) GetComponentInChildren<TextMeshProUGUI>().text = GetCount().ToString();
	}
	public void SetItemParameters(List<ItemData> data, int id)
	{
		GetComponent<Image>().sprite = data[id].Icon;
	}

	public void CheckCountInStack(List<GameObject> slot)
	{

	}
}
