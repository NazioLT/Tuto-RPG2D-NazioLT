using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryData : MonoBehaviour
{
    private InventoryController controller;

    public void Init(InventoryController _controller)
    {
        controller = _controller;
    }
}
