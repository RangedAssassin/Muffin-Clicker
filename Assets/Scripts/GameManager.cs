using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent<int> OnTotalMuffinsChanged;

    [Range(0f, 1f)] [SerializeField] private float _critChance = 0.01f;

    private int _muffinsPerClick = 1;
    private int _totalMuffins = 0;

    private int TotalMuffins
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

    public int AddMuffins()
    {
        int addedMuffins = 0;

        if (Random.value <= _critChance)
        {
            addedMuffins = _muffinsPerClick * 10;
        }
        else
        {
            addedMuffins = _muffinsPerClick;
        }
       
        TotalMuffins += addedMuffins;
                
        return addedMuffins;
    }
 
    public bool TryPurchaseUpgrade(int currentCost, int level)
    {
        if (TotalMuffins >= currentCost)
        {
            TotalMuffins -= currentCost;
            level++;
            _muffinsPerClick = 1 + level * 2;
           return true;
        }
        return false;
    }

    public bool TryPurchaseSugarRushUpgrade(int currentCost)
    {
        if (TotalMuffins >= currentCost)
        {
            TotalMuffins -= currentCost;

            return true;
        }
        return false;
    }


    private void Start()
    {
        TotalMuffins = 0;
    }

    //private void Update()
    //{

    //    if (_muffinsPerSecond > 0)
    //    {
    //        _timer += Time.deltaTime;

    //        if (_timer >= 1f)
    //        {
    //            TotalMuffins += Mathf.RoundToInt(_muffinsPerSecond);
    //            _timer = 0;
    //        }
    //    }
    //}
    //public float GetMuffinsPerSecond()
    //{
    //    return _muffinsPerSecond;
    //}

}
