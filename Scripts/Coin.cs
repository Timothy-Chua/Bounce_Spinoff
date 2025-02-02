using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CoinCollected();
            gameObject.SetActive(false);
        }
    }
}
