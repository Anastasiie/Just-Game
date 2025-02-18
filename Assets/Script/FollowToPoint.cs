using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowToPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] points; // масив для точок між якими відбувається рух (unity)
    private int CurrentPointIndex = 0;

    [SerializeField] private float speed = 2f;

    // Рухаючі Платформи
    private void Update()
    {
        if (Vector2.Distance(points[CurrentPointIndex].transform.position, transform.position) < .1f) //дистанція між точкою та платформою
        {
            CurrentPointIndex++;
            if (CurrentPointIndex >= points.Length)
            {
                CurrentPointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[CurrentPointIndex].transform.position, Time.deltaTime * speed);
    }
}
