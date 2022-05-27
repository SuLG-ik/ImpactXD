using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MainMenuCloud : MonoBehaviour

{
    private float _speed;

    private void Start()
    {
        _speed = Random.Range(0.25f, 0.7f);
        var scale = Random.Range(2f, 3f);
        transform.localScale = new Vector3(scale, scale);
    }

    private void Update()
    {
        transform.position += new Vector3(Time.deltaTime * _speed, 0);
        if (transform.position.x >= 5)
        {
            Destroy(gameObject);
        }
    }
}