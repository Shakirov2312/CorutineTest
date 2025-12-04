using System.Collections;
using UnityEngine;
using System;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private InputReader _click;
    [SerializeField] private bool _isWork;

    public event Action ValueChanges;

    public float Count { get; private set; }

    private void OnEnable()
    {
        _click.AmoundButtonClick += TrakTimer;
    }

    private void OnDisable()
    {
        _click.AmoundButtonClick -= TrakTimer;
    }

    public void TrakTimer()
    {
        _isWork = !_isWork;

        if (_isWork)
            StartCoroutine("ReadCounter");
        else
            StopCoroutine("ReadCounter");
    }

    private IEnumerator ReadCounter()
    {
        var delay = new WaitForSeconds(_delay);

        for(; ; )
        {
            Count++;
            ValueChanges?.Invoke();

            yield return delay;
        }
    }
}
