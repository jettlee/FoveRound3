using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SheepStatus {

    public static GameObject[] sheeps;
    private static float[] spawnTimeArray = new float[] { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f};
    private static Vector3[] rightMoveBehavior = new Vector3[] { new Vector3(3.0f, 0.0f, 2.0f), new Vector3(1.0f, 0.0f, -2.5f), new Vector3(5.0f, 0.0f, 5.0f) };
    private static Vector3[] rightRotateBehavior = new Vector3[] { new Vector3(5.0f, 0.0f, 2.0f), new Vector3(3.0f, 0.0f, -3.0f), new Vector3(2.0f, 0.0f, 5.0f) };

    private static Vector3[] leftMoveBehavior = new Vector3[] { new Vector3(-3.0f, 0.0f, 5.0f), new Vector3(-1.0f, 0.0f, 3.0f), new Vector3(-5.0f, 0.0f, -3.0f) };
    private static Vector3[] leftRotateBehavior = new Vector3[] { new Vector3(-5.0f, 0.0f, -3.0f), new Vector3(-3.0f, 0.0f, -3.0f), new Vector3(-2.0f, 0.0f, -4.0f) };

    public static GameObject generateSheep()
    {
        return sheeps[Random.Range(0, sheeps.Length - 1)];
    }
    public static float generateSpawnTime()
    {
        return spawnTimeArray[Random.Range(0, spawnTimeArray.Length - 1)];
    }

    public static Vector3 rightGenerateMove()
    {
        return rightMoveBehavior[Random.Range(0, rightMoveBehavior.Length - 1)];
    }

    public static Vector3 rightGenerateRotate()
    {
        return rightRotateBehavior[Random.Range(0, rightRotateBehavior.Length - 1)];
    }

    public static Vector3 leftGenerateMove()
    {
        return leftMoveBehavior[Random.Range(0, leftMoveBehavior.Length - 1)];
    }

    public static Vector3 leftGenerateRotate()
    {
        return leftRotateBehavior[Random.Range(0, leftRotateBehavior.Length - 1)];
    }
}
