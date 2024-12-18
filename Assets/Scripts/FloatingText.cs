using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    
    [SerializeField] private TextMeshProUGUI _text;

    private float _timer;
    private Color _startColor;
    
    void Start()
    {
        _startColor = _text.color;
    }

    //Moves floating numbers, fades their color, and destroys them. 
    void Update()
    {
        transform.Translate(0, _moveSpeed * Time.deltaTime, 0);
        
        _timer = _timer + Time.deltaTime;
        _text.color = Color.Lerp(_startColor, Color.clear, _timer);

        if (_text.color.a <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
