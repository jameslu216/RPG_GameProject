using Item;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemGrid : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private Image image;
    [SerializeField] private Text numberText;
    [SerializeField] private BagControl bagControl;
    private ItemCategory item;

    void Start()
    {
        this.Clear();
    }

    public void BindItem(ItemCategory item, int count)
    {
        if(item == null)
        {
            // TODO: set default image
            this.numberText.text = "";
            this.item = null;
            return;
        }
        // setup display
        this.image.sprite = item.Icon;
        this.numberText.text = $"x{count:02d}";
        this.item = item;
    }

    public void Clear() => this.BindItem(null, 0);

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.item && this.bagControl.state != BagControl.BagState.Inspect)
            this.bagControl.item = this.item;
    }
}