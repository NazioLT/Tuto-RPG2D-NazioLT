using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private int slotNumber;

    private SlotsController[] slots;

    [SerializeField] private Transform slotPrefab;

    [SerializeField] private Canvas slotCanvas;
    private InventoryController controller;

    public void Init(InventoryController _controller)
    {
        controller = _controller;

        slots = new SlotsController[slotNumber];
        for (var i = 0; i < slotNumber; i++)
        {
            slots[i] = Instantiate(slotPrefab, transform.position, Quaternion.identity, slotCanvas.transform).GetComponent<SlotsController>();
            slots[i].Init(i);
        }
    }
}
