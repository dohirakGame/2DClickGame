using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
	[SerializeField] private int _count = 0;
	[SerializeField] private string _itemType = "";
	[SerializeField] private int _id;
	[SerializeField] private float _weight;
	[SerializeField] private float _armor;
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
	public float GetWeight()
	{
		return _weight;
	}
	public void SetWeight(float value)
	{
		_weight = value;
	}
	public float GetArmor()
	{
		return _armor;
	}
	public void SetArmor(float value)
	{
		_armor = value;
	}


    public void SetAmmoParameters(List<ItemData> data, int id)
	{
		GetComponent<Image>().sprite = data[id].Icon;
		SetItemType(data[id].ItemType.ToString());
		SetCount(data[id].CountInStack);
		SetId(data[id].Id);
		SetWeight(data[id].Weight);
		UpdateItemUI();
	}
	public void SetItemParameters(List<ItemData> data, int id)
	{
		GetComponent<Image>().sprite = data[id].Icon;
		SetItemType(data[id].ItemType.ToString());
		SetCount(data[id].CountInStack);
		SetId(data[id].Id);
		SetWeight(data[id].Weight);
		SetArmor(data[id].Armor);
		UpdateItemUI();
	}

	public void UpdateParametersHubIncrease(List<ItemData> data, int id)
	{
		PlayerData playerData = FindObjectOfType<PlayerData>();

		if (data[id].ItemType == ItemEnum.Body) playerData.SetBodyArmor(playerData.GetBodyArmor() + data[id].Armor);
		else playerData.SetHeadArmor(playerData.GetHeadArmor() + data[id].Armor);

		playerData.SetWeight(playerData.GetWeight() + (data[id].Weight*data[id].CountInStack));
		playerData.UpdateHub();
	}
	public void UpdateParametersHubDecrease(List<ItemData> data, int id)
	{
		PlayerData playerData = FindObjectOfType<PlayerData>();

		if (data[id-1].ItemType == ItemEnum.Body) playerData.SetBodyArmor(playerData.GetBodyArmor() - data[id-1].Armor);
		else playerData.SetHeadArmor(playerData.GetHeadArmor() - data[id-1].Armor);

		playerData.SetWeight(playerData.GetWeight() - (data[id-1].Weight * data[id-1].CountInStack));
		playerData.UpdateHub();
	}

	public void UpdateAmmoParametersHubIncrease(List<ItemData> data, int id)
	{
		PlayerData playerData = FindObjectOfType<PlayerData>();

		playerData.SetWeight(playerData.GetWeight() + data[id-1].Weight);
		playerData.UpdateHub();
	}
	public void UpdateAmmoParametersHubDecrease(List<ItemData> data, int id)
	{
		PlayerData playerData = FindObjectOfType<PlayerData>();

		playerData.SetWeight(playerData.GetWeight() - data[id-1].Weight);
		playerData.UpdateHub();
	}

	public void UpdateItemUI()
	{
		if (GetCount() > 1) GetComponentInChildren<TextMeshProUGUI>().text = GetCount().ToString();
		else GetComponentInChildren<TextMeshProUGUI>().text = "";
	}

	public void DestroyItem()
	{
		Destroy(gameObject);
	}
}
