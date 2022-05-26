using UnityEngine;

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
        for (int i = 0; i < slotNumber; i++) slotsInfos[i] = new SlotsInfos(templates[0], 0);

        slotsInfos[0] = new SlotsInfos(templates[1], 1);
    }

    public int SlotNumber => slotNumber;
    public SlotsInfos[] Slots => slotsInfos;
}
