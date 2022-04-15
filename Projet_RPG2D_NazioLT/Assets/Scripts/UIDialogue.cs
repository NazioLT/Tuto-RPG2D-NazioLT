using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        CloseDialogue();
    }

    public void SetDialogue(string _text)
    {
        canvas.enabled = true;

        text.text = _text;
    }

    public void CloseDialogue()
    {
        canvas.enabled = false;
    }
}
