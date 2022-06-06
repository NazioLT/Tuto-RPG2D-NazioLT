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


    public Sprite Icon => template.Icon;
    public int ItemId => template.ItemId;
    public int Stack => template.Stack;

    public int Number => number;
}
