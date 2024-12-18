using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class SugarRushUpgrade : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _costText;

    [SerializeField] private int[] _costPerLevel;
    
    private int _level;

    private void Start()
    {
        UpdateSugarRushUI();
    }
    public void OnSugarRushUpgradeClicked()
    {
        int currentCost = _costPerLevel[_level];
        bool purchasedUpgrade = _gameManager.TryPurchaseSugarRushUpgrade(currentCost);

        if (purchasedUpgrade)
        {
            _level++;
            UpdateSugarRushUI();
        }
    }

    private void UpdateSugarRushUI()
    {
        _levelText.text = _level.ToString();
        _costText.text = _costPerLevel[_level].ToString();
    }
}