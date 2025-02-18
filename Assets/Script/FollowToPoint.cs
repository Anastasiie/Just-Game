using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowToPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] points; // ����� ��� ����� �� ����� ���������� ��� (unity)
    private int CurrentPointIndex = 0;

    [SerializeField] private float speed = 2f;

    // ������� ���������
    private void Update()
    {
        if (Vector2.Distance(points[CurrentPointIndex].transform.position, transform.position) < .1f) //��������� �� ������ �� ����������
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
