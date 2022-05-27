using System;
using UnityEngine;
using Utils;

public class MainMenuButtons : MonoBehaviour
{
    private INavigator _navigator;

    private bool isNavigated;

    private void Start()
    {
        _navigator = FindObjectOfType<GameNavigator>();
    }


    private void Update()
    {
        if (Input.anyKey && !isNavigated)
        {
            isNavigated = true;
            _navigator.NavigateToGame();
        }
    }
}