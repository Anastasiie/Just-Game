using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // обертати об`єкти
    [SerializeField] private float speed = 2f;
   
    private void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime); // x, y, z
    }
}
