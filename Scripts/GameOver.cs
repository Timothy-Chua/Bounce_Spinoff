using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameOver("Victory!");
            GameManager.instance.score *= 200;
        }
    }
}
