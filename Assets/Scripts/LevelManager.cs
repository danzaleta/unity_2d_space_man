using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Static instance
    public static LevelManager levelManagerInstance;

    [SerializeField] List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>(),
                                               currentLevelBlocks = new List<LevelBlock>();
    
    [SerializeField] Transform levelStartPosition;



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
        int randomIndex = Random.Range(0, allTheLevelBlocks.Count);

        LevelBlock block;
        Vector3 spawnPosition = Vector3.zero;

        if (currentLevelBlocks.Count == 0)
        {
            block = Instantiate(allTheLevelBlocks[0]);
            spawnPosition = levelStartPosition.position;
        }
        else
        {
            block = Instantiate(allTheLevelBlocks[randomIndex]);
            spawnPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].endPoint.position;
        }

        block.transform.SetParent(this.transform, false);
        block.transform.position = spawnPosition;

        Vector3 correction = new Vector3(
            block.transform.position.x + (block.transform.position.x - block.startPoint.position.x), 
            block.transform.position.y + (block.transform.position.y - block.startPoint.position.y),
            0
        );

        Debug.Log("posicion del start point del bloque: " + block.startPoint.position);

        block.transform.position = correction;

        currentLevelBlocks.Add(block);
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
            AddLevelBlock();    
        }
    }
    //
    // Block management methods
}
