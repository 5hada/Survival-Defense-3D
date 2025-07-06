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
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip effect_Sound;
    [SerializeField]
    private AudioClip effect_Sound_2;

    public void Mining()
    {
        audioSource.clip = effect_Sound;
        audioSource.Play();
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
        audioSource.clip = effect_Sound_2;
        audioSource.Play();
        col.enabled = false;
        Destroy(rock);

        rock_Debris.SetActive(true);
        Destroy(rock_Debris, destroyTime);
    }
}
