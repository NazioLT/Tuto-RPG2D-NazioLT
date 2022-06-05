using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotController : MonoBehaviour
{
    public int slotID { private set; get; }

    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI numberText;

    public void Init(int _id)
    {
        slotID = _id;
        gameObject.name = "Slot " + (_id + 1);
    }

    public void UpdateDisplay(Sprite _icon, int _number)
    {
        bool _empty = _number == 0;

        numberText.text = _empty ? "" : _number.ToString("00");

        iconImage.enabled = !_empty;

        if (!_empty) iconImage.sprite = _icon;
    }
}
