using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int berries = 0;
    public Text berriesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Berry"))
        {
            Destroy(collision.gameObject);
            berries++;
            Debug.Log("Berries: " + berries);
            berriesText.text = "Berries: " + berries;
        }
    }
}
