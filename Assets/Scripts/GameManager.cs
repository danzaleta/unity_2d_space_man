using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Static instance
    public static GameManager gameManagerInstance;

    public GameState currentGameState = GameState.Menu;



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
        if (currentGameState != GameState.InGame)
        {
            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
            {
                StartGame();
            }
        }
        
    }



    // Game state methods
    //
    public void StartGame()
    { 
        SetGameState(GameState.InGame);
    }
    //
    public void GameOver()
    {
        SetGameState(GameState.GameOver);
    }
    //
    public void BackToMenu()
    {
        SetGameState(GameState.Menu);
    }
    //
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
                //LevelManager.levelManagerInstance.RemoveAllLevelBlocks();
                //Invoke("ReloadLevel", 0.1f);
                //ReloadLevel();

                break;
            
            case GameState.GameOver:
                
                break;
            
            default:
                
                break;
        }

        currentGameState = newGameState;
    }

    private void ReloadLevel()
    {
        LevelManager.levelManagerInstance.RemoveAllLevelBlocks();
        LevelManager.levelManagerInstance.GenerateInitialBlocks();
    }

}
