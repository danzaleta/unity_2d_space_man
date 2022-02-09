using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.gameManagerInstance.currentGameState != GameState.GameOver)
        {
            if (collision.CompareTag("Player"))
            {
                PlayerDinoController controller = collision.GetComponent<PlayerDinoController>();
                controller.Die();
            }
        }
        else
        {
            if (collision.CompareTag("Player"))
            {
                PlayerDinoController controller = collision.GetComponent<PlayerDinoController>();
                controller.RestartPosition();
            }
            //Destroy(collision.gameObject);
            //GameManager.gameManagerInstance.RestartGame();

        }
    }
}