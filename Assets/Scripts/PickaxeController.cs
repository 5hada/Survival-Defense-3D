using System.Reflection;
using System.Collections;
using UnityEngine;

public class PickaxeController : CloseWeaponController
{
    public static bool isActivate = false;

    void Update()
    {
        if (isActivate)
        {
            TryAttack();
        }
    }

    protected override IEnumerator Hitcoroutine()
    {


        while (isSwing)
        {
            if (CheckObject())
            {
                if (hitInfo.transform.tag == "Rock")
                {
                    hitInfo.transform.GetComponent<Rock>().Mining();
                }
                else if (hitInfo.transform.tag == "NPC")
                {
                    SoundManager.Instance.PlaySE("Animal_Hit");
                    hitInfo.transform.GetComponent<PIg>().Damage(currentCloseWeapon.damage, transform.position);

                }
                    



                isSwing = false;

            }
            yield return null;
        }
    }

    public override void CloseWeaponChange(CloseWeapon closeWeapon)
    {
        base.CloseWeaponChange(closeWeapon);
        isActivate = true;
    }
}
