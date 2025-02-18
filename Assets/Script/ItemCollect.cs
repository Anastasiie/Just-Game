using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    private int CollectItems = 0;                       //зміна для count items
    [SerializeField] private Text ItemText;
    [SerializeField] private AudioSource CollectingSoundEffect; //collect item sound

    //знищення апельсинів + текст апельсинів
    private void OnTriggerEnter2D(Collider2D collision) //player -> boxcollider triger
    {
        if (collision.gameObject.CompareTag("Collect")) //orange - > tag Collect
        {
            CollectingSoundEffect.Play();               // sound play
            Destroy(collision.gameObject);
            CollectItems++;                             //+ 1 item
            ItemText.text = "Oranges: " + CollectItems; // текст = кількість знищенн апельсинів 
        }
    }
}
