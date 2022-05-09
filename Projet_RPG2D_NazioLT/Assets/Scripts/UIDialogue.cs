using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Canvas))]
public class UIDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI contentText;
    [SerializeField] private Image charImage;

    private Canvas canvas;
    private RectTransform charImageRect;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        charImageRect = charImage.GetComponent<RectTransform>();

        CloseDialogue();
    }

    public void SetDialogue(Dialogue _dialogue)
    {
        canvas.enabled = true;

        contentText.text = _dialogue.getCharName + " : " + _dialogue.getContent;

        Sprite _current = _dialogue.getCharSprite;

        charImage.sprite = _dialogue.getCharSprite;
        charImageRect.sizeDelta = new Vector2(charImageRect.sizeDelta.y * (_current.bounds.size.x / _current.bounds.size.y), charImageRect.sizeDelta.y);
    }

    public void CloseDialogue() { canvas.enabled = false; }
}
