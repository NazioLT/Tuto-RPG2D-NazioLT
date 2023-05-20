using UnityEngine;

public class Chest : InteractableObject
{
    //Stats
    [SerializeField] private Item[] content;

    //Renderers
    [SerializeField] private SpriteRenderer[] graphisms;
    [SerializeField] private Sprite[] openSprite;
    [SerializeField] private Sprite[] closedSprite;

    public override void Interact(bool _performed = true)
    {
        if (isReach)
        {
            ChangeState(true, openSprite);
        }
        else
        {
            ChangeState(false, closedSprite);
        }
    }

    private void ChangeState(bool _state, Sprite[] _sprites)
    {
        open = _state;
        if(open) EmptyChest();

        for (int i = 0; i < graphisms.Length; i++)//pour chaque sprite Renderer
        {
            graphisms[i].sprite = _sprites[i];
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
}
