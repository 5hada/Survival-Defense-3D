using TMPro;
using UnityEngine;

public class SlotToolTip : MonoBehaviour
{
    [SerializeField]
    private GameObject baseUI;

        [SerializeField]
    private TextMeshProUGUI textItemName;
    [SerializeField]
    private TextMeshProUGUI textItemDesc;
    [SerializeField]
    private TextMeshProUGUI textItemMenual;
    

    public void ShowToolTip(Item item, Vector3 pos)
    {
        baseUI.SetActive(true);
        pos += new Vector3(baseUI.GetComponent<RectTransform>().rect.width * 0.5f, -baseUI.GetComponent<RectTransform>().rect.height * 0.5f, 0f);
        baseUI.transform.position = pos;

        textItemName.text = item.itemName;
        textItemDesc.text = item.itemDescription;

        if (item.itemType == Item.ItemType.Equipment)
        {
            textItemMenual.text = "Right-Equip";
        }
        else if (item.itemType == Item.ItemType.Used)
        {
            textItemMenual.text = "Right-Eat";
        }
        else
        {
            textItemMenual.text = "";
        }

    }

    public void HideToolTip()
    {
        baseUI.SetActive(false);
    }
}
