using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryData : MonoBehaviour
{
    [Header ("Заданные ScriptableObject")]
    public List<ItemData> ammoItems;
    public List<ItemData> headItems;
    public List<ItemData> bodyItems;
    public List<ItemData> gunItems;

    [Header ("Цены для закрытых ячеек")]
    public List<int> priceForSlots;

    [Header ("Все доступные ячейки")]
    public List<GameObject> slots;

    [Header("Различные листы для работы")]
    public List<GameObject> ammoSlots;
    public List<GameObject> freeSlots;
    public List<GameObject> itemSlots;
    public List<GameObject> notFullStackSlots;
}
