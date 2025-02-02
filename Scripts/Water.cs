using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnCollisionEnter(Collision actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            actor.gameObject.SetActive(false);
            GameManager.instance.GameOver("Defeat");
        }
    }
}
