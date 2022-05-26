using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemTemplate : ScriptableObject
{
    [Header("Main Infos")]
    [SerializeField, InspectorName("Name")] private string itemName;
    [SerializeField] private int id;
    [SerializeField] private Sprite icon;

    [Header("Item Infos")]
    [SerializeField] private int stack;

    public string Name => itemName;
    public int ItemID => id;
    public Sprite Icon => icon;

    public int Stack => stack;
}