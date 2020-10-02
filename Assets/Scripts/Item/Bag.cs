using Item.Serialize;
using UnityEngine;

namespace Item
{
    [CreateAssetMenu(menuName = "item/bag")]
    public class Bag : ScriptableObject
    {
        [SerializeField] private string instanceLoadPath;
        [SerializeField] private BagDictionary content;
    }
    
}