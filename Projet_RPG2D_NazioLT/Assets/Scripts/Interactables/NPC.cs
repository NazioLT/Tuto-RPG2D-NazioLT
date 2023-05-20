using UnityEngine;

public class NPC : InteractableObject
{
    [SerializeField] private Dialogue[] dialogue;
    private int currentID = -1;

    private UIDialogue uiDialogue;

    private void Awake()
    {
        uiDialogue = FindObjectOfType<UIDialogue>();
    }

    public override void Interact(bool _performed = true)
    {
        if (dialogue != null && isReach && currentID + 1 < dialogue.Length)
        {
            currentID++;
            uiDialogue.SetDialogue(dialogue[currentID]);
            return;
        }

        currentID = -1;
        uiDialogue.CloseDialogue();
    }
}
