using UnityEngine;

namespace Item
{
    [CreateAssetMenu(menuName = "item/category")]
    public class ItemCategory : ScriptableObject
    {
        [SerializeField] private string itemName;
        [SerializeField] private Sprite icon;
        [SerializeField] private GameObject function; // TBD
        [SerializeField][TextArea] private string helpText;

        public string ItemName => itemName;
        public Sprite Icon => icon;
        public string HelpText => helpText;
    }
}