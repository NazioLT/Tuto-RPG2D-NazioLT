using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    private PlayerInput inputs;

    //Valeurs
    private InputAction moveAction;

    //Events
    public UnityEvent interactionEvent;

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

    public static InputManager GetInstance()
    {
        return instance;
    }

    private void OnInteract()
    {
        interactionEvent.Invoke();
    }

    public Vector2 GetMoveInputs()
    {
        return moveAction.ReadValue<Vector2>();
    }
}
