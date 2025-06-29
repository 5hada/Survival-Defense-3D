using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private float gunAccuracy;

    [SerializeField]
    private GameObject crosshairHUD;
    [SerializeField]
    private GunController gunController;

    public void WalkingAnimation(bool flag)
    {
        animator.SetBool("Walking", flag);
    }

    public void RunningAnimation(bool flag)
    {
        animator.SetBool("Running", flag);
    }

    public void CrouchingAnimation(bool flag)
    {
        animator.SetBool("Crouching", flag);
    }

    public void FineSightAnimation(bool flag)
    {
        animator.SetBool("FineSight", flag);
    }

    public void FireAnimation()
    {
        if (animator.GetBool("Walking")) animator.SetTrigger("Walk_Fire");
        else if (animator.GetBool("Crouching")) animator.SetTrigger("Crouch_Fire");
        else animator.SetTrigger("Idle_Fire");
    }

    public float GetAccuracy()
    {
        if (animator.GetBool("Walking")) gunAccuracy = 0.06f;
        else if (animator.GetBool("Crouching")) gunAccuracy = 0.015f;
        else if (gunController.GetFineSight()) gunAccuracy = 0.001f;
        else gunAccuracy = 0.03f;

        return gunAccuracy;
    }
}
