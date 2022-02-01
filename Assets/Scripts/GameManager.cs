using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    [SerializeField] public GameState currentGameState = GameState.Menu;



    void Awake()
    {
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    //
    void Start()
    {
        
    }

    void Update()
    {
        
    }



    // Game state methods
    //
    public void StartGame()
    { 
        
    }
    //
    public void GameOver()
    { 
        
    }
    //
    public void BackToMenu()
    { 
        
    }
    //
    // Game state methods



    private void SetGameState(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.Menu:

                break;
            
            case GameState.InGame:
                
                break;
            
            case GameState.GameOver:
                
                break;
            
            default:
                
                break;
        }

        currentGameState = newGameState;
    }

}
