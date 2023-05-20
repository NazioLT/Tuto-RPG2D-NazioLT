using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    private int startDragSlotID = 999999;

    private SlotController[] slots;

    [SerializeField] private Transform slotPrefab;

    [SerializeField] private Transform slotParent;
    private InventoryController controller;

    public void Init(InventoryController _controller)
    {
        controller = _controller;

        slots = new SlotController[controller.SlotNumber];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = Instantiate(slotPrefab, transform.position, Quaternion.identity, slotParent).GetComponent<SlotController>();
            slots[i].Init(i, this);
        }
    }

    public void UpdateDisplay(SlotsInfos[] _slotInfos)
    {
        for (int i = 0; i < _slotInfos.Length; i++)
        {
            slots[i].UpdateDisplay(_slotInfos[i].Icon, _slotInfos[i].Number);
        }
    }

    public void StartDrag(int _startSlotID) => startDragSlotID = _startSlotID;
    public void EndDrag(int _endSlotID) => controller.SwitchSlots(startDragSlotID, _endSlotID);
}
