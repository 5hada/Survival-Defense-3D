using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    [SerializeField]
    private int hp;
    private int currentHp;

    [SerializeField]
    private int sp;
    private int currentSp;

    [SerializeField]
    private int spIncreaseSpeed;

    [SerializeField]
    private int spRechargeTIme;
    private int currentSpRechargeTime;

    private bool spUsed;

    [SerializeField]
    private int dp;
    private int currentDp;

    [SerializeField]
    private int hungry;
    private int currentHungry;

    [SerializeField]
    private int hungryDecreaseTime;
    private int currentHungryDecreaseTime;

    [SerializeField]
    private int thirsty;
    private int currentThirsty;

    [SerializeField]
    private int thirstyDecreaseTime;
    private int currentThirstyDecreaseTime;

    [SerializeField]
    private int satisfy;
    private int currentSatisfy;

    [SerializeField]
    private Image[] images_Gauge;

    private const int HP = 0, DP = 1, SP = 2, HUNGRY = 3, THIRSTY = 4, SATISFY = 5;

    private void Start()
    {
        currentHp = hp;
        currentSp = sp;
        currentDp = dp;
        currentHungry = hungry;
        currentThirsty = thirsty;
        currentSatisfy = satisfy;
    }

    private void Update()
    {
        Hungry();
        Thirsty();
        SpRechargeTime();
        SpRecover();
        GaugeUpdate();
    }

    private void SpRechargeTime()
    {
        if (spUsed)
        {
            if (currentSpRechargeTime < spRechargeTIme)
                currentSpRechargeTime++;
            else
                spUsed = false;
        }
    }

    private void SpRecover()
    {
        if (!spUsed && currentSp < sp)
        {
            currentSp += spIncreaseSpeed;
        }
    }

    private void Hungry()
    {
        if ( currentHungry > 0)
        {
            if (currentHungryDecreaseTime <= hungryDecreaseTime)
                currentHungryDecreaseTime++;
            else
            {
                currentHungry--;
                currentHungryDecreaseTime = 0;
            }
        }
        else
            Debug.Log("배고픔 0");
    }

    private void Thirsty()
    {
        if (currentThirsty > 0)
        {
            if (currentThirstyDecreaseTime <= thirstyDecreaseTime)
                currentThirstyDecreaseTime++;
            else
            {
                currentThirsty--;
                currentThirstyDecreaseTime = 0;
            }
        }
        else
            Debug.Log("목마름 0");
    }

    private void GaugeUpdate()
    {
        images_Gauge[HP].fillAmount = (float)currentHp / hp;
        images_Gauge[DP].fillAmount = (float)currentDp / dp;
        images_Gauge[SP].fillAmount = (float)currentSp / sp;
        images_Gauge[HUNGRY].fillAmount = (float)currentHungry / hungry;
        images_Gauge[THIRSTY].fillAmount = (float)currentThirsty / thirsty;
        images_Gauge[SATISFY].fillAmount = (float)currentSatisfy / satisfy;
    }

    public void IncreaseHp(int count)
    {
        if (currentHp + count <= hp)
            currentHp += count;
        else
            currentHp = hp;
    }

    public void DecreaseHp(int count)
    {
        if (currentDp >0)
        {
            DecreaseDp(count);
            return;
        }
        currentHp -= count;

        if (currentHp <= 0)
        { 
            currentHp = 0;
            Debug.Log("HP 0");
        }
    }

    public void IncreaseDp(int count)
    {
        if (currentDp + count <= dp)
            currentDp += count;
        else
            currentDp = dp;
    }

    public void DecreaseDp(int count)
    {
        currentDp -= count;
        if (currentDp <= 0)
        {
            currentDp = 0;
            Debug.Log("DP 0");
        }
    }

    public void IncreaseHungry(int count)
    {
        if (currentHungry + count <= hungry)
            currentHungry += count;
        else
            currentHungry = hungry;
    }

    public void DecreaseHungry(int count)
    {
        if (currentHungry - count < 0)
            currentHungry = 0;
        else
            currentHungry -= count;
    }

    public void IncreaseThirsty(int count)
    {
        if (currentThirsty + count <= thirsty)
            currentThirsty += count;
        else
            currentThirsty = thirsty;
    }

    public void DecreaseThirsty(int count)
    {
        if (currentThirsty - count < 0)
            currentThirsty = 0;
        else
            currentThirsty -= count;
    }

    public void IncreaseSp(int count)
    {
        if (currentSp + count <= sp)
            currentSp += count;
        else
            currentSp = sp;
    }

    public void DecreaseStamina(int count)
    {
        spUsed = true;
        currentSpRechargeTime = 0;
        
        if (currentSp - count>0)
            currentSp -= count;
        else
            currentSp = 0;
    }

    public int GetCurrentSp()
    {
        return currentSp;
    }
}
