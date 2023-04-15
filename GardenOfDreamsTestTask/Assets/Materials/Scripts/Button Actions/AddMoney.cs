using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{
    public void AddManyMoney()
	{
		PlayerData playerData = FindObjectOfType<PlayerData>();
		playerData.SetMoney(playerData.GetMoney() + 50);
		playerData.UpdateHub();
	}
}
