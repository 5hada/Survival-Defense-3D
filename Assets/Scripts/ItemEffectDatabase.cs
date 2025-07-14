using UnityEngine;

[System.Serializable]
public class ItemEffect
{
    public string itemName;
    [Tooltip("Hp, Sp, Dp, Hungry, Thirsty, Satisfy")]
    public string[] part;
    public int[] num;
}

public class ItemEffectDatabase : MonoBehaviour
{
    [SerializeField]
    private ItemEffect[] itemEffects;

    [SerializeField]
    private StatusController statusController;
    [SerializeField]
    private WeaponManager weaponManager;

    private const string HP = "HP", SP = "SP", DP = "DP", HUNGRY = "HUNGRY", THIRSTY = "THIRSTY", SATISFY = "SATISFY";

    public void UseItem(Item item)
    {
        if (item.itemType == Item.ItemType.Equipment)
        {
            StartCoroutine(weaponManager.ChangeWeaponCoroutine(item.weaponType, item.itemName));
        }
        if (item.itemType == Item.ItemType.Used)
        {
            for (int i = 0; i < itemEffects.Length; i++)
            {
                if (itemEffects[i].itemName == item.itemName)
                {

                    for (int j = 0; j < itemEffects[i].part.Length; j++)
                    {
                        switch (itemEffects[i].part[j])
                        {
                            case "HP":
                                statusController.IncreaseHp(itemEffects[i].num[j]);
                                break;
                            case "SP":
                                statusController.IncreaseSp(itemEffects[i].num[j]);
                                break;
                            case "DP":
                                statusController.IncreaseDp(itemEffects[i].num[j]);
                                break;
                            case "HUNGRY":
                                statusController.IncreaseHungry(itemEffects[i].num[j]);
                                break;
                            case "THIRSTY":
                                statusController.IncreaseThirsty(itemEffects[i].num[j]);
                                break;
                            case "SATISFY":
                                break;
                            default:
                                Debug.Log("잘못된 Status부위");
                                break;
                        }
                        Debug.Log(item.itemName + "사용");
                    }
                    return;
                }
                Debug.Log("ItemEffectDatabase에 일치하는 ItemName이 없습니다");
            }
        }
    }
}
