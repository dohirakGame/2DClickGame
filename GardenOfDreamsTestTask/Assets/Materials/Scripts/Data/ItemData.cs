using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item Data", menuName = "Data/ItemData", order = 3)]
public class ItemData : ScriptableObject
{
    [Header ("��� ��������")]
    [SerializeField] private ItemEnum itemType;
    [SerializeField] private Sprite icon;
    [SerializeField] private string itemName;
    [SerializeField] private int id;

    [Header("���-�� � �����")]
    [SerializeField] private int countInStack;

    [Header ("��� (��)")]
    [SerializeField] private float weight;

	[Header("�����")]
    [SerializeField] private int armor;

	[Header("����")]
	[SerializeField] private float damage;

    public ItemEnum ItemType { get { return itemType; } }
    public Sprite Icon { get { return icon; } }
    public string ItemName { get { return itemName; } }
    public int Id { get { return id; } }
    public int CountInStack { get { return countInStack; } }
    public float Weight { get { return weight; } } 
    public int Armor { get { return armor; } }
    public float Damage { get { return damage; } }
}

public enum ItemEnum
{
    Head,
    Body,
    Ammo,
    Gun
}