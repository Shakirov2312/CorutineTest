using System.Collections;
using UnityEngine;
using TMPro;

public class CountTimer : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _count;
    [SerializeField] private bool _isWork = false;
    [SerializeField] private TextMeshProUGUI _text;

    public void TimerControl()
    {
        _isWork = !_isWork;

        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        var delay = new WaitForSeconds(_delay);

        while (_isWork)
        {
            CounterOperation();
            CounterDisplay();

            yield return delay;
        }
    }

    private void CounterDisplay()
    {
        _text.text = _count.ToString();
    }
    
    private void CounterOperation()
    {
        _count++;
    }
}
