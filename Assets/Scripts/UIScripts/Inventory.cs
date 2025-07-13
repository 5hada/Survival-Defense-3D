using Mono.Cecil.Cil;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false;

    [SerializeField]
    private GameObject inventoryBase;
    [SerializeField]
    private GameObject slotsParent;

    private Slot[] slots;



    void Start()
    {
        slots = slotsParent.GetComponentsInChildren<Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        TryOpenInventory();
    }

    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryActivated = !inventoryActivated;

            if (inventoryActivated)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }

        }
    }    

    private void OpenInventory()
    {
        inventoryBase.SetActive(true);
    }
    private void CloseInventory()
    {
        inventoryBase.SetActive(false);
    }

    public void AcquireIntem(Item item, int count)
    {
        if (Item.ItemType.Equipment != item.itemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].item.itemName == item.itemName)
                    {
                        slots[i].SetSlotCount(count);
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(item, count);
                return;
            }
        }
    }    
}
