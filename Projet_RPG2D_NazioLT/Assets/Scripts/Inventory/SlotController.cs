using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    public int slotID { private set; get; }

    public void Init(int _id)
    {
        slotID = _id;
        gameObject.name = "Slot " + (_id + 1);
    }
}
