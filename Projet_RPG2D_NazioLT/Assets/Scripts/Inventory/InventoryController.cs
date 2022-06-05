using UnityEngine;

[RequireComponent(typeof(InventoryData), typeof(InventoryDisplay))]
public class InventoryController : MonoBehaviour
{
    private InventoryData data;
    private InventoryDisplay display;

    private void Start()
    {
        data = GetComponent<InventoryData>();
        display = GetComponent<InventoryDisplay>();

        data.Init(this);
        display.Init(this);

        display.UpdateDisplay(data.Slots);
    }

    public void SwitchSlots(int _slot1, int _slot2)
    {
        data.SwitchSlots(_slot1, _slot2);
        display.UpdateDisplay(data.Slots);
    }

    public int SlotNumber => data.SlotNumber;
}