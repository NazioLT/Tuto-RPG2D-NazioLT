using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{   
    private int startDragID = 9999999;

    private SlotController[] slots;

    [SerializeField] private Transform slotPrefab;

    [SerializeField] private Canvas slotCanvas;
    private InventoryController controller;

    public void Init(InventoryController _controller)
    {
        controller = _controller;

        slots = new SlotController[controller.SlotNumber];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = Instantiate(slotPrefab, transform.position, Quaternion.identity, slotCanvas.transform).GetComponent<SlotController>();
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

    #region DragAndDrop

    public void StartDrag(int _startDragID) => startDragID = _startDragID;
    public void EndDrag(int _endDragID) =>  controller.SwitchSlots(startDragID, _endDragID);

    #endregion
}
