using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Static instance
    public static LevelManager levelManagerInstance;

    [SerializeField] List<LevelBlock> levelBlocks = new List<LevelBlock>(),
                                               currentLevelBlocks = new List<LevelBlock>();

    void Awake()
    {
        if (levelManagerInstance == null)
        {
            levelManagerInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    //
    void Start()
    {
        GenerateInitialBlocks();
    }

    void Update()
    {
        
    }



    // Block management methods
    //
    public void AddLevelBlock()
    {

    }
    //
    public void RemoveLevelBlock()
    {

    }
    //
    public void RemoveAllLevelBlocks()
    {

    }
    //
    public void GenerateInitialBlocks()
    {
        for (int i = 0; i < 2; i++)
        {

        }
    }
    //
    // Block management methods
}
