using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "NewItem/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public Sprite itemImage;
    public GameObject itemPrefab;

    public string weaponType;

    public enum ItemType
    {
        Equipment,
        Used,
        Ingredient,
        Etc
    }

}
