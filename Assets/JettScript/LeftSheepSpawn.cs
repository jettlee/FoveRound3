using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSheepSpawn : MonoBehaviour {

    public GameObject sheep;

    private float currentTime = 0.0f;
    private float spawnTime;

    // Use this for initialization
    void Start()
    {
        //sheep = SheepStatus.generateSheep();
        spawnTime = SheepStatus.generateSpawnTime();

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > spawnTime)
        {
            GameObject newSheep = Instantiate(sheep, transform);
            //newSheep.AddComponent<MoveRight>();
            currentTime = 0.0f;
            //sheep = SheepStatus.generateSheep();
            spawnTime = SheepStatus.generateSpawnTime();
        }
    }
}
