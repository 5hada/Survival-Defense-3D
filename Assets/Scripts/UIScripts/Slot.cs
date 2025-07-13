using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;
    public int itemCount;
    public Image itemImage;

    [SerializeField]
    private TextMeshProUGUI textCount;
    [SerializeField]
    private GameObject countImage;

    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }    

    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;
        if (item.itemType != Item.ItemType.Equipment)
        {
        countImage.SetActive(true);
        textCount.text = itemCount.ToString();
        }
        else
        {
            textCount.text = "0";
            countImage.SetActive(false);
        }

        SetColor(1f);
    }

    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        textCount.text = itemCount.ToString();
        if (itemCount <= 0)
        {
            ClearSlot();
        }
    }

    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0f);

        countImage.SetActive(false);
        textCount.text = "0";
    }
}
