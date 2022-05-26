using UnityEngine;

[System.Serializable]
public class SlotsInfos
{
    public SlotsInfos(ItemTemplate _template, int _number)
    {
        template = _template;

        name = template.name;
        number = _number;
    }

    [SerializeField, HideInInspector] private string name;

    [SerializeField] private int number = 0;

    private ItemTemplate template;

    #region Getters

    public Sprite Icon => template.Icon;
    public int itemID => template.ItemID;
    public int Stack => template.Stack;

    public int Number => number;

    #endregion
}