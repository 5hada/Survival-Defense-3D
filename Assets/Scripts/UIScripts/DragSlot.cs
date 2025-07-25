using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class DragSlot : MonoBehaviour
{
    static public DragSlot instance;

    public Slot dragSlot;

    [SerializeField]
    private Image imageItem;

    private void Start()
    {
        instance = this;
    }

    public void DragSetImage(Image itemImage)
    {
        imageItem.sprite = itemImage.sprite;
        SetColor(1f);
    }    

    public void SetColor(float _alpha)
    {
        Color color = imageItem.color;
        color.a = _alpha;
        imageItem.color = color;
    }
}
