using System;
using UnityEngine;

public class onButtonClikc : MonoBehaviour
{
    public event Action AmoundButtonClick;

    [SerializeField] public bool IsWork {  get; private set; }

    public void ClickButton()
    {
        IsWork = !IsWork;
        AmoundButtonClick?.Invoke();
    }
}
