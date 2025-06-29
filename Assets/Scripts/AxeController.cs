using System.Collections;
using UnityEngine;

public class AxeController : CloseWeaponController
{

    public static bool isActivate = false;
    void Start()
    {
        //WeaponManager.currentWeapon = currentCloseWeapon.GetComponent<Transform>();
        //WeaponManager.currentWeaponAnim = currentCloseWeapon.anim;
    }

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
