using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]
public class InputsManager : MonoBehaviour
{
    public static InputsManager instance { private set; get; }

    private InputAction moveAction;

    [SerializeField] private UnityEvent<bool> interactionEvent;
    [SerializeField] private UnityEvent<bool> inventoryEvent;

    private PlayerInput inputs;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;

        inputs = GetComponent<PlayerInput>();

        moveAction = inputs.actions.FindAction("Move");
    }

    public Vector2 GetMovingInputs()
    {
        return moveAction.ReadValue<Vector2>();
    }

    public void OnInteractPerformed(InputAction.CallbackContext _ctx)
    {
        interactionEvent.Invoke(_ctx.performed);
    }

    public void OnInventoryPerformed(InputAction.CallbackContext _ctx)
    {
        inventoryEvent.Invoke(_ctx.performed);
    }

    public UnityEvent<bool> InteractionEvent => interactionEvent;
    public UnityEvent<bool> InventoryEvent => inventoryEvent;
}
