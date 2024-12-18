using UnityEngine;
using TMPro;
public class MuffinClicker : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private TextMeshProUGUI _textRewardPrefab;

    [SerializeField] private float minX;

    [SerializeField] private float maxX;

    [SerializeField] private float minY;

    [SerializeField] private float maxY;


    //Creates random floating number showing how many muffins per click.
    public void OnMuffinClicked()
    {
        int addedMuffins = _gameManager.AddMuffins();

        CreateTextRewardPrefab(addedMuffins);
    }

    private void CreateTextRewardPrefab(int addedMuffins)
    {
        //Clone
        TextMeshProUGUI textRewardClone = Instantiate(_textRewardPrefab, transform);

        //Random Position.
        Vector2 randomVector = MyToolbox.GetRandomVector2(minX, maxX, minY, maxY);
        textRewardClone.transform.localPosition = randomVector;

        //Set the text.
        textRewardClone.text = $"+ {addedMuffins}";
    }
}
