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

public class InventoryData : MonoBehaviour
{
    [SerializeField] private int slotNumber;
    [SerializeField] private SlotsInfos[] slotsInfos;

    [SerializeField] private ItemTemplate[] templates;

    private InventoryController controller;

    public void Init(InventoryController _controller)
    {
        controller = _controller;

        slotsInfos = new SlotsInfos[slotNumber];
        for (int i = 0; i < slotNumber; i++)
        {
            slotsInfos[i] = new SlotsInfos(templates[0], 0);
        }

        slotsInfos[0] = new SlotsInfos(templates[1], 1);
    }

    public int SlotNumber => slotNumber;
    public SlotsInfos[] Slots => slotsInfos;
}
