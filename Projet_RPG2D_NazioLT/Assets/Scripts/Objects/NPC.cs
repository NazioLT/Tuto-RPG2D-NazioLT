using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : InteractableObject
{
    public string text;

    private UIDialogue dialogue;

    private void Awake()
    {
        dialogue = FindObjectOfType<UIDialogue>();
    }

    public override void Interact()
    {
        Debug.Log(isReach);
        if (isReach)
        {
            dialogue.SetDialogue(text);
        }
        else
        {
            dialogue.CloseDialogue();
        }
    }
}
