using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action AmoundButtonClick;

    public void ClickButton()
    {
        AmoundButtonClick?.Invoke();
    }
}
