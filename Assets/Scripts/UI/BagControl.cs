using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEngine;
using Zenject;

/*
 * controller of bag UI, hold current state of UI, and which item the player current select
 * 
 */
public class BagControl : MonoBehaviour
{
    public enum BagState
    {
        // normal state, player can browse items he/she want
        Browse,
        // click right mouse button on one item, the inspect panel was popped-up
        Inspect,
        // player choose one item to craft
        Craft,
    }
    // which item the player is hover
    public ItemCategory item;
    // capcity for each page
    public const int PAGE_CAPCITY = 30;
    [Inject] private Bag bag;
    public BagState state { get; private set; } = BagState.Browse;
}