using RotaryHeart.Lib.SerializableDictionary;

namespace Item.Serialize
{
    [System.Serializable]
    /*
     * key: item id
     * value: item amount
     */
    public class BagDictionary : SerializableDictionaryBase<int,int>{}
}