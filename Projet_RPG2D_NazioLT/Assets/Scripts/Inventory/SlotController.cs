using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SlotController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public int slotID { private set; get; }

    private Sprite iconSprite;

    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI numberText;

    [Header("Prefabs")]
    [SerializeField] private Transform dragPrefab;
    private GameObject dragObject;

    private InventoryDisplay display;

    public void Init(int _id, InventoryDisplay _display)
    {
        display = _display;

        slotID = _id;
        gameObject.name = "Slot " + (_id + 1);
    }

    public void UpdateDisplay(Sprite _icon, int _number)
    {
        iconSprite = _icon;

        bool _empty = _number == 0;

        numberText.text = _empty ? "" : _number.ToString("00");

        iconImage.enabled = !_empty;

        if (!_empty) iconImage.sprite = _icon;
    }

    #region DragAndDrop

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragObject = Instantiate(dragPrefab, transform.position, Quaternion.identity, transform).gameObject;
        Image _img = dragObject.GetComponent<Image>();
        _img.sprite = iconSprite;
        _img.color = iconSprite == null ? new Color(0,0,0,0) : Color.white;

        RectTransform _rect = (RectTransform)(dragObject.transform);
        RectTransform _slotRect = (RectTransform)transform;

        _rect.sizeDelta = _slotRect.sizeDelta;

        dragObject.GetComponent<Canvas>().overrideSorting = true;

        display.StartDrag(slotID);
    }

    public void OnDrag(PointerEventData eventData) => dragObject.transform.position = eventData.position;
    public void OnEndDrag(PointerEventData eventData)=> Destroy(dragObject);
    public void OnDrop(PointerEventData eventData) => display.EndDrag(slotID);

    #endregion
}