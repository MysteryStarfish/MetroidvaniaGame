using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public bool isPlayerAround = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerAround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerAround = false;
        }
    }
}
