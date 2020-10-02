using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    [CreateAssetMenu(menuName = "item/item category manager")]
    public class ItemCategoryManager : ScriptableObject
    {
        [SerializeField] private List<ItemCategory> categories = new List<ItemCategory>();
        [SerializeField] private string instanceLoadPath = "";

        private static ItemCategoryManager mInstance;
        private void OnEnable()
        {
            mInstance = Resources.Load<ItemCategoryManager>(instanceLoadPath);
        }

        /*
         * get the current instance of this manager (result can be null)
         */
        public ItemCategoryManager GetInstance() => mInstance;
        /*
         * get the id of specify item (return -1 if not existed) 
         */
        public int GetID(ItemCategory it) => categories.FindIndex(x =>x.name == it.name);
        /*
         * get ItemCategory on specify id (return null on failure)
         */
        public ItemCategory GetItemCategory(int id) => id >= categories.Count ? null : categories[id];
        
    }
}