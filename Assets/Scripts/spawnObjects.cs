using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObjects : MonoBehaviour {

    public GameObject initPos;
    public GameObject targetPos;
    public GameObject sheepPrefab;

    GameObject sheep;

    IEnumerator spawnPrefab()
    {
        for (;;)
        {             
            sheep = Instantiate(sheepPrefab);
            yield return new WaitForSeconds(12.0f);
        }
    }

	void Start ()
    {
        StartCoroutine(spawnPrefab());
	}

    // Update is called once per frame
    void Update () {       
		
	}
}
