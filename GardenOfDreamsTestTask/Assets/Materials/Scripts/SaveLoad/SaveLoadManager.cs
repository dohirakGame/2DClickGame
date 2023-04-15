using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
	string filePath;

	public InventoryData inventoryData = new InventoryData();

	private void Start()
	{
		filePath = Application.persistentDataPath + "/save.gamesave";
	}
	public void SaveGame()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream fs = new FileStream(filePath, FileMode.Create);

		Save save = new Save();

		save.SaveAmmoList(inventoryData.ammoSlots);

		bf.Serialize(fs, save);

		fs.Close();
	}
	public void LoadGame()
	{
		if (!File.Exists(filePath)) return;

		BinaryFormatter bf = new BinaryFormatter();
		FileStream fs = new FileStream(filePath, FileMode.Open);

		Save save = (Save)bf.Deserialize(fs);
		fs.Close();
	}

	// Добавить 2 кнопки: сохранить, загрузить
	// В них реализовать методы, которые вызывают данные методы для сохранения и загрузки
	// А во время загрузки перенести все данные на те данные
}

[System.Serializable]
public class Save
{
	public List<GameObject> ammoList = new List<GameObject>();

	public void SaveAmmoList(List<GameObject> ammo)
	{
		foreach (var obj in ammo)
		{
			ammo.Add(obj);
		}
	}
}