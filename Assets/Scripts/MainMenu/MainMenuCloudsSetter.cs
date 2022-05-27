using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainMenuCloudsSetter : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private MainMenuCloud cloudPrefab;

    private float nextCloud;

    private void Start()
    {
        nextCloud = Time.time + 1;
    }

    private void Update()
    {
        if (nextCloud - Time.time < 0)
        {
            nextCloud = Time.time + Random.Range(5, 15);
            var rect = ((RectTransform) transform).rect;
            var cloud = Instantiate(cloudPrefab, new Vector3(0, Random.Range(transform.position.y - rect.height / 2, rect.height / 2)), Quaternion.identity);
            cloud.transform.SetParent(transform, false);
        }
    }
}