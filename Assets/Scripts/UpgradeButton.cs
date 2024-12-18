using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private TextMeshProUGUI _levelText;

    [SerializeField]
    private TextMeshProUGUI _costText;

    [SerializeField]
    private float _costPowerScale = 1.5f;

    private int _level;

    private int CurrentCost
    {
        get
        {
            return 5 + Mathf.RoundToInt(Mathf.Pow(_level, _costPowerScale));
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    public void TotalMuffinsChanged(int totalMuffins)
    {
        bool canAfford = totalMuffins >= CurrentCost;

        _costText.color = canAfford ? Color.green : Color.red;
    }

    public void OnUpgradeClicked()
    {
        int currentCost = CurrentCost;

        bool purchasedUpgrade = _gameManager.TryPurchaseUpgrade(currentCost, _level);
        
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
