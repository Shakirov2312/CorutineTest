using System.Collections;
using UnityEngine;
using System;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private InputReader _click;
    [SerializeField] private bool _isWork;

    public event Action ValueChanges;

    private Coroutine _coroutine;

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
            _coroutine = StartCoroutine("ReadCounter");
        else
            StopCoroutine(_coroutine);
    }

    private IEnumerator ReadCounter()
    {
        var delay = new WaitForSeconds(_delay);

        while(_isWork)
        {
            Count++;
            ValueChanges?.Invoke();

            yield return delay;
        }
    }
}
