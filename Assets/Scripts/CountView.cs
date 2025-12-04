using TMPro;
using UnityEngine;

public class CountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private Counter _counter;
    
    private void OnEnable()
    {
        _counter.ValueChanges += CountDisplay;
    }

    private void OnDisable()
    {
        _counter.ValueChanges -= CountDisplay;
    }

    private void CountDisplay()
    {
        _textMeshPro.text = _counter.Count.ToString();
    }
}
