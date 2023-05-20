using UnityEngine;

[RequireComponent(typeof(InventoryData), typeof(InventoryDisplay))]
public class InventoryController : MonoBehaviour
{
    private InventoryData data;
    private InventoryDisplay display;

    [SerializeField] private Canvas inventoryCanvas;

    private void Start()
    {
        data = GetComponent<InventoryData>();
        display = GetComponent<InventoryDisplay>();

        data.Init(this);
        display.Init(this);

        display.UpdateDisplay(data.Slots);

        InputsManager.instance.InventoryEvent.AddListener(ToggleInventory);
    }

    public void SwitchSlots(int _slot1, int _slot2)
    {
        data.SwitchSlots(_slot1, _slot2);
        display.UpdateDisplay(data.Slots);
    }

    private void ToggleInventory(bool performed)
    {
        if(!performed) return;

        inventoryCanvas.enabled = !inventoryCanvas.enabled;
    }

    public int SlotNumber => data.SlotNumber;
}