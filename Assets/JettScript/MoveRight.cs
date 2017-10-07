using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour {

    private Vector3 move;
    private Vector3 rotate;
    public GameObject spwanSheep;
	// Use this for initialization
	void Start () {
        move = SheepStatus.rightGenerateMove();
        rotate = SheepStatus.rightGenerateRotate();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(move * Time.deltaTime);
        spwanSheep.transform.Rotate(rotate * Time.deltaTime * 3);
        
    }
}
