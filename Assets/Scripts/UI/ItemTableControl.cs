using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Item;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ItemTableControl : MonoBehaviour
{
    public BagControl bagControl;
    [Inject] private Bag bag;
    private ItemGrid[] itemGrids;
    // current page index, start from 0
    private int page;
    private int maxPage;
    // page offset
    private int offset => page * BagControl.PAGE_CAPCITY;
    [SerializeField] private Button nextPage;
    [SerializeField] private Button prevPage;

    public void Bind(BagControl _bagControl)
    {
        this.bagControl = _bagControl;
    }

    void Start()
    {
        // get grids under panel
        this.itemGrids = GetComponentsInChildren<ItemGrid>();
        Debug.Assert(
            this.itemGrids.Length == BagControl.PAGE_CAPCITY,
            "Grid number doesn't match the bag's capcity!"
        );
        // fill item info into panel
        this.updateGrids();
        // setup listeners
        this.nextPage.onClick.AddListener(() => this.updatePage(1));
        this.prevPage.onClick.AddListener(() => this.updatePage(-1));
    }

    void Update()
    {
        // calculate page count
        this.maxPage = this.bag.Content.Count / BagControl.PAGE_CAPCITY;
    }

    // update grids by current state
    void updateGrids()
    {
        var items = this.bag.Content
            .Skip(this.offset)
            .Take(BagControl.PAGE_CAPCITY);
        // empty items
        if(!items.Any())
        {
            // not the first page
            if(this.offset != 0)
                Debug.LogWarning("Got empty items");
            return;
        }
        // clear grids
        this.itemGrids.ToList().ForEach(grid => grid.Clear());
        // bind items
        var itemAndGrids = items.Zip(this.itemGrids, (item, grid) => (item, grid));
        foreach(var(item, grid) in itemAndGrids)
        {
            grid.BindItem(ItemCategoryManager.Instance.GetItemCategory(item.Key), item.Value);
        }
    }

    void updatePage(int delta)
    {
        int newPage = this.page + delta;
        // invalid page index
        if(newPage < 0 || newPage >= this.maxPage)
            return;
        this.page = newPage;
    }
}