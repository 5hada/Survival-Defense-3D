using UnityEngine;

public class PIg : MonoBehaviour
{
    [SerializeField]
    private string amimalName;
    [SerializeField]
    private int hp;

    [SerializeField]
    private float walkSpeed;

    private Vector3 direction;

    private bool isAction;
    private bool isWalking;

    [SerializeField]
    private float walkTime;
    [SerializeField]
    private float waitTime;
    private float currentTime;

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private BoxCollider boxCollider;

    void Start()
    {
        currentTime = waitTime;
        isAction = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotation();
        ElapseTime();
    }

    private void Move()
    {
        if (isWalking)
        {
            rb.MovePosition(transform.position + transform.forward * walkSpeed * Time.deltaTime);
        }
    }

    private void Rotation()
    {
        if (isWalking)
        {
            Vector3 rotation = Vector3.Lerp(transform.eulerAngles, direction, 0.01f);
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
        isAction = true;

        anim.SetBool("Walking", isWalking);
        direction.Set(0f, Random.Range(0f,360f), 0f);
        RandomAction();
    }

    private void RandomAction()
    {
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
        anim.SetBool("Walking", isWalking);
    }
}