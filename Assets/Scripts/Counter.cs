using System.Collections;
using UnityEngine;
using System;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private onButtonClikc _click;

    public event Action AccountChanges;

    public float Count { get; private set; }

    public void TimerControlButton()
    {
        if(_click.IsWork)
            StartCoroutine(ReadCounter(_click.IsWork));
        else
            StopAllCoroutines();
    }

    private IEnumerator ReadCounter( bool isWork)
    {
        var delay = new WaitForSeconds(_delay);

        while(isWork)
        {
            Count++;
            AccountChanges?.Invoke();

            yield return delay;
        }
    }

    private void OnEnable()
    {
        _click.AmoundButtonClick += TimerControlButton;
    }

    private void OnDisable()
    {
        _click.AmoundButtonClick -= TimerControlButton;
    }
}
