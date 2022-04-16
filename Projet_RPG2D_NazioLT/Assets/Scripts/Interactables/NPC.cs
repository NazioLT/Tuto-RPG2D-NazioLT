using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : InteractableObject
{
    [SerializeField] private Dialogue[] dialogues;
    private int currentID;

    private UIDialogue uiDialogue;

    private void Awake()
    {
        uiDialogue = FindObjectOfType<UIDialogue>();
    }

    public override void Interact()
    {
        if (isReach && currentID + 1  < dialogues.Length)
        {
            currentID++;
            uiDialogue.SetDialogue(dialogues[currentID]);
        }
        else
        {
            currentID = -1;
            uiDialogue.CloseDialogue();
        }
    }
}
