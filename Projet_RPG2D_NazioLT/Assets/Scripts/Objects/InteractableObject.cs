using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class InteractableObject : MonoBehaviour
{
    //Checkers
    protected bool isReach = false;
    protected bool open = false;

    //Refs
    protected GameManager manager;

    public abstract void Interact();

    protected virtual void Start()
    {
        manager = GameManager.GetInstance();
        InputsManager.instance.interactionEvent.AddListener(Interact);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isReach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isReach = false;
            open = false;
            Interact();
        }
    }
}
