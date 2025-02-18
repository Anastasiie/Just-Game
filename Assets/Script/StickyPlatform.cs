using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    // гравець прилипає до платформи лише зверху, (trigger)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Kunoichi") //player name
        {
            collision.gameObject.transform.SetParent(transform);    //player as clild, to stick at platform + (in unity add new box colider for dn`t stick near platform) 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Kunoichi")
        {
            collision.gameObject.transform.SetParent(null);         //null to leave platform
        }
    }
}
