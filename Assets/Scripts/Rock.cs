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
    private GameObject rock_Item_Prefabs;

    [SerializeField]
    private int count;

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

        for ( int i = 0; i<=count; i++)
        {
            Instantiate(rock_Item_Prefabs, rock.transform.position, Quaternion.identity);
        }
        Destroy(rock);

        rock_Debris.SetActive(true);
        Destroy(rock_Debris, destroyTime);
    }
}
