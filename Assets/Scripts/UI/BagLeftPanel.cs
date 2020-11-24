using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEngine;
using UnityEngine.UI;

public class BagLeftPanel : MonoBehaviour
{
    [SerializeField] private BagControl bagControl;
    [SerializeField] private Image image;
    [SerializeField] private Text header;
    [SerializeField] private Text content;

    private ItemCategory item => this.bagControl.item;

    void Update()
    {
        if(!this.item)
            return;
        switch(this.bagControl.state)
        {
            case BagControl.BagState.Browse:
            case BagControl.BagState.Inspect:
                this.image.sprite = this.item.Icon;
                this.header.text = this.item.ItemName;
                this.content.text = this.item.HelpText;
                break;
            case BagControl.BagState.Craft:
                break;
        }
    }
}