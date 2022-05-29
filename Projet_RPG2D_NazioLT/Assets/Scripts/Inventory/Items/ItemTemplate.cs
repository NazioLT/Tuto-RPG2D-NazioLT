using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class ItemTemplate : ScriptableObject
{
    [Header("Main infos")]
    [SerializeField] private string itemName;
    [SerializeField] private int id;
    [SerializeField] private Sprite icon;

    [Header("Item infos")]
    [SerializeField] private int stack;

    public string Name => itemName;
    public int ItemId => id;
    public Sprite Icon => icon;

    public int Stack => stack;
}