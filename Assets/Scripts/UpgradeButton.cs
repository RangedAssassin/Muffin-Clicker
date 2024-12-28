using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] protected GameManager _gameManager;

    [SerializeField] protected TextMeshProUGUI _levelText;

    [SerializeField] protected TextMeshProUGUI _costText;



    [SerializeField] private float _costPowerScale = 1.5f;

    [SerializeField] private bool _isMuffinUpgrade;

    [SerializeField] private UpgradeType _upgradeType;

    protected int _level;

    private int Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
            _levelText.text = _level.ToString();
            _costText.text = CurrentCost.ToString();
        }
    }

    protected virtual int CurrentCost
    {
        get
        {
            return 5 + Mathf.RoundToInt(Mathf.Pow(_level, _costPowerScale));
        }
    }

    private void Start()
    {
        Level = 0;
        UpdateUI();
        GetComponent<Button>().onClick.AddListener(OnUpgradeClicked);
        _gameManager.OnTotalMuffinsChanged.AddListener(TotalMuffinsChanged);
    }

    public void TotalMuffinsChanged(int totalMuffins)
    {
        bool canAfford = totalMuffins >= CurrentCost;

        _costText.color = canAfford ? Color.green : Color.red;
    }

    public void OnUpgradeClicked()
    {
        int currentCost = CurrentCost;
  
        bool purchasedUpgrade = _gameManager.TryPurchaseUpgrade(currentCost, _level, _upgradeType);
        
        if (purchasedUpgrade)
        {
            _level++;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        _levelText.text = _level.ToString();
        _costText.text = CurrentCost.ToString();
    }
}
