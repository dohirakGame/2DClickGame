using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryData : MonoBehaviour
{
    [Header ("�������� ScriptableObject")]
    public List<ItemData> ammoItems;
    public List<ItemData> headItems;
    public List<ItemData> bodyItems;
    public List<ItemData> gunItems;

    [Header ("���� ��� �������� �����")]
    public List<int> priceForSlots;

    [Header ("��� ��������� ������")]
    public List<GameObject> slots;

    [Header ("��������� ����� ��� ������")]
    public List<GameObject> freeslots;
    public List<GameObject> occupiedSlots;
    public List<GameObject> notFullStackSlots;
}
