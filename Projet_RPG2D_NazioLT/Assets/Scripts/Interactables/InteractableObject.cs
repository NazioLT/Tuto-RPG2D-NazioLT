using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class InteractableObject : MonoBehaviour
{
    //Checkers
    protected bool isReach = false;
    protected bool open = false;

    //Refs
    protected GameManager manager;

    private void Start()
    {
        manager = GameManager.GetInstance();
        InputsManager.instance.InteractionEvent.AddListener(Interact);
    }

    public abstract void Interact(bool _performed = true);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == GameInfos.PLAYER_TAG)
        {
            isReach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == GameInfos.PLAYER_TAG)
        {
            isReach = false;
            open = false;
            Interact();
        }
    }
}
