using System.Collections.Generic;
using UnityEngine;

public class ClosedSlotController : MonoBehaviour
{
	public List<GameObject> freeSlots;

	public void SetListOfFreeSlots()
	{
		foreach (var obj in GameObject.FindGameObjectsWithTag("Inventory"))
		{
			if (obj.GetComponent<Slot>().GetOpenState())
			{
				AddFreeSlotInList(obj);
			}
		}
	}

	private void AddFreeSlotInList(GameObject slot)
	{
		freeSlots.Add(slot);
	}
}
