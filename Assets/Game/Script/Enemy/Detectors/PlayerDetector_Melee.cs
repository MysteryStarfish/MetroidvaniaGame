using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector_Melee : MonoBehaviour
{
    public bool isMeleeTrigger = false;
    public PlayerHandler player = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isMeleeTrigger = true;
            player = collision.gameObject.GetComponent<PlayerHandler>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isMeleeTrigger = false;
            player = null;
        }
    }
}
