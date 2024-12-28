using TMPro;
using UnityEngine;

/// <summary>
/// Updates the header children UI elements
/// </summary>

public class Header : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _totalMuffinsText;
    [SerializeField] private TextMeshProUGUI _muffinsPerSecondText;


    /// <summary>
    /// Updates total muffins text header.
    /// </summary>
    /// <param name="counter">The total Muffins</param>
    public void UpdateTotalMuffins(int counter)
    {
        //if (counter == 1)
        //{
        //    //_totalMuffinsText.text = counter.ToString() + " Muffin!";
        //    _totalMuffinsText.text = $"{counter} muffin";
        //}
        //else if (counter == -1)
        //{
        //    _totalMuffinsText.text = $"{counter} muffin";
        //}
        //else
        //{
        //    _totalMuffinsText.text = $"{counter} muffins";
        //}

        _totalMuffinsText.text = counter == 1 ? "1 muffin" : $"{counter} muffins";
    }

    public void UpdateMuffinsPerSecond(int muffinsPerSecond)
    {
        if (muffinsPerSecond == 0)
        {
            _muffinsPerSecondText.text = muffinsPerSecond.ToString() + " Muffins / Second";
        }
        else if (muffinsPerSecond == 1)
        {
            _muffinsPerSecondText.text = muffinsPerSecond.ToString() + " Muffin / Second";
        }
        else
        {
            _muffinsPerSecondText.text = muffinsPerSecond.ToString() + " Muffins / Second";
        }


    }

}
 