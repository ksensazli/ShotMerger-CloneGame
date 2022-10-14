using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static Action onStart;
    public static Action onEnd;
    private bool _isStart;
    private bool _isEnd;

    private void startLevel()
    {
        onStart?.Invoke();
        _isStart = true;
    }

    private void endLevel()
    {
        onEnd?.Invoke();
        _isEnd = true;
    }

    private void FixedUpdate() 
    {
        if (!_isStart && Input.GetMouseButtonDown(0))
        {
            startLevel();
            return;
        }

        if (!_isEnd)
        {
            return;
        }
    }
}
