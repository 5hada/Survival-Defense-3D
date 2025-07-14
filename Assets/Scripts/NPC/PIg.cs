using UnityEngine;

public class PIg : MonoBehaviour
{
    [SerializeField]
    private string amimalName;
    [SerializeField]
    private int hp;

    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float applySpeed;

    private Vector3 direction;

    private bool isAction;
    private bool isWalking;
    private bool isRunning;
    private bool isDead;

    [SerializeField]
    private float walkTime;
    [SerializeField]
    private float runTime;
    [SerializeField]
    private float waitTime;
    private float currentTime;

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private BoxCollider boxCollider;
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] audioPigNormal;
    [SerializeField]
    private AudioClip audioPigHurt;
    [SerializeField]
    private AudioClip audioPigDead;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentTime = waitTime;
        isAction = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Move();
            Rotation();
            ElapseTime();

        }
    }

    private void Move()
    {
        if (isWalking || isRunning)
        {
            rb.MovePosition(transform.position + transform.forward * walkSpeed * Time.deltaTime);
        }
    }

    private void Rotation()
    {
        if (isWalking || isRunning)
        {
            Vector3 rotation = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, direction.y, 0f), 0.01f);
            rb.MoveRotation(Quaternion.Euler(rotation));
        }
    }

    private void ElapseTime()
    {
        if (isAction)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0f)
            {
                Reset();
            }
        }
    }

    private void Reset()
    {
        isWalking = false;
        isRunning = false;
        isAction = true;
        applySpeed = walkSpeed;

        anim.SetBool("Walking", isWalking);
        anim.SetBool("Running", isRunning);

        direction.Set(0f, Random.Range(0f,360f), 0f);
        RandomAction();
    }

    private void RandomAction()
    {
        RandomSound();
        int random = Random.Range(0, 4);

        if (random == 0)
            Wait();
        else if (random == 1)
            Eat();
        else if (random == 2)
            Peek();
        else if (random == 3)
            TryWalk();
    }

    private void Wait()
    {
        currentTime = waitTime;
    }
    private void Eat()
    {
        currentTime = waitTime;
        anim.SetTrigger("Eat");
    }
    private void Peek()
    {
        currentTime = waitTime;
        anim.SetTrigger("Peek");
    }
    private void TryWalk()
    {
        isWalking = true;
        currentTime = walkTime;
        applySpeed = walkSpeed;
        anim.SetBool("Walking", isWalking);
    }
    private void Run(Vector3 targetPos)
    {
        direction = Quaternion.LookRotation(transform.position - targetPos).eulerAngles;

        currentTime = runTime;
        isWalking = false;
        isRunning = true;
        applySpeed = runSpeed;
        anim.SetBool("Running", isRunning);
    }

    public void Damage(int dmg, Vector3 targetPos)
    {
        if (!isDead)
        {
              hp -= dmg;
            if (hp <= 0)
            {
                Dead();
                return;
            }
        
            PlaySE(audioPigHurt);
            anim.SetTrigger("Hurt");
            Run(targetPos);
        }
        
    }

    private void Dead()
    {
        PlaySE(audioPigDead);
        isWalking = false;
        isRunning = false;
        isDead = true;
        anim.SetTrigger("Dead");
    }

    private void RandomSound()
    {
        int random = Random.Range(0, 3);
        PlaySE(audioPigNormal[random]);
    }

    private void PlaySE(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}