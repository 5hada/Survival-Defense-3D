using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private int hp;

    [SerializeField]
    private float destroyTime;

    [SerializeField]
    private SphereCollider col;

    [SerializeField]
    private GameObject rock;
    [SerializeField]
    private GameObject rock_Debris;
    [SerializeField]
    private GameObject effect_Prefabs;

    [SerializeField]
    private string strike_Sound;
    [SerializeField]
    private string destroy_Sound;

    public void Mining()
    {
        SoundManager.Instance.PlaySE(strike_Sound);
        var clone = Instantiate(effect_Prefabs, col.bounds.center, Quaternion.identity);
        Destroy(clone, destroyTime);

        hp--;
        if ( hp <= 0 )
        {
            Destruction();
        }
    }
    private void Destruction()
    {
        SoundManager.Instance.PlaySE(destroy_Sound);
        col.enabled = false;
        Destroy(rock);

        rock_Debris.SetActive(true);
        Destroy(rock_Debris, destroyTime);
    }
}
