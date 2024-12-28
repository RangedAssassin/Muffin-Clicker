using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent<int> OnTotalMuffinsChanged;
    public UnityEvent<int> MuffinsPerSecondChanged;

    [Range(0f, 1f)] [SerializeField] private float _critChance = 0.01f;

    private int _muffinsPerClick = 1;
    private int _muffinsPerSecond;
    private int _totalMuffins = 0;
    private  float _muffinsPerSecondTimer;

    public int TotalMuffins
    {
        get
        {
            return _totalMuffins;
        }
        set
        {
            _totalMuffins = value;

            OnTotalMuffinsChanged.Invoke(_totalMuffins);
            
        }
    }

    public int MuffinsPerSecond
    {
        get
        {
            return _muffinsPerSecond;
        }
        set
        {
            _muffinsPerSecond = value;
            MuffinsPerSecondChanged.Invoke(_muffinsPerSecond);

        }
    }

    public int AddMuffins()
    {
        int addedMuffins = 0;

        if (Random.value <= _critChance)
        {
            //Crit
            addedMuffins = _muffinsPerClick * 10;
        }
        else
        {
            //Normal
            addedMuffins = _muffinsPerClick;
        }
       
        TotalMuffins += addedMuffins;
                
        return addedMuffins;
    }
 
    public bool TryPurchaseUpgrade(int currentCost, int level, UpgradeType upgradeType)
    {
        if (TotalMuffins >= currentCost)
        {
            //Purchase
            TotalMuffins -= currentCost;
            level++;

            switch (upgradeType)
            {
                case UpgradeType.MuffinUpgrade:
                    _muffinsPerClick = 1 + level * 2;
                    break;
                case UpgradeType.SugarRush:
                    MuffinsPerSecond = level;
                    break;
                case UpgradeType.FancyMuffinUpgrade:
                    //Fancy Muffin Upgrade
                    break;

            }
            return true;
        }
        return false;
    }

    private void Start()
    {
        TotalMuffins = 0;
    }

    private void Update()
    {
        _muffinsPerSecondTimer += Time.deltaTime;
        
        if (_muffinsPerSecondTimer >= 1)
        {
            _muffinsPerSecondTimer--;
            TotalMuffins += _muffinsPerSecond;

        }
    }
}
