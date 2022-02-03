using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.gameManagerInstance.currentGameState != GameState.GameOver)
        {
            if (collision.tag == "Player")
            {
                PlayerDinoController controller = collision.GetComponent<PlayerDinoController>();
                controller.Die();
            }
        }
    }
}