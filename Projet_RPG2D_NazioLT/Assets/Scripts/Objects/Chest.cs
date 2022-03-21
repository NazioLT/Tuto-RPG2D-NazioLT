using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    //Stats
    [SerializeField] private Item[] content;

    //Renderers
    [SerializeField] private SpriteRenderer[] graphisms;
    [SerializeField] private Sprite[] openSprite;
    [SerializeField] private Sprite[] closedSprite;

    //Checkers
    private bool isReach = false;
    private bool open = false;

    //Refs
    private GameManager manager;
    private InputManager inputs;

    private void Start()
    {
        manager = GameManager.GetInstance();
        inputs = InputManager.GetInstance();

        inputs.interactionEvent.AddListener(Interact);
    }

    private void Interact()
    {
        if (isReach) ChangeState(true, openSprite);
        else ChangeState(false, closedSprite);
    }

    private void ChangeState(bool _state, Sprite[] _chestSprites)
    {
        open = _state;

        if (open) EmptyChest();

        for (int i = 0; i < graphisms.Length; i++)//pour chaque sprite Renderer
        {
            graphisms[i].sprite = _chestSprites[i];
        }
    }

    private void EmptyChest()
    {
        foreach (var _item in content)
        {
            CharacterInfos.AddItem(_item._id, _item.number);
            _item.number = 0;
        }
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
        }
    }
}
