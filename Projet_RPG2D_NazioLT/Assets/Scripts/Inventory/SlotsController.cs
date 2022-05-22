using UnityEngine;

public class SlotsController : MonoBehaviour
{
    public int slotID { private set; get; }

    public void Init(int _id)
    {
        slotID = _id;
    }
}
