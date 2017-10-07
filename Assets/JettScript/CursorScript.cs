using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour {

    public FoveInterface fove;

    public GameObject cursor;

    Vector3 velocity = Vector3.zero;

    float smoothTime = 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        FoveInterface.EyeRays rays = FoveInterface.GetEyeRays();
        FoveInterface.GazeConvergenceData convergencePoint = FoveInterface.GetGazeConvergence();

        Vector3 position = rays.left.origin * 0.5f + rays.right.origin * 0.5f;
        Vector3 direction = rays.left.direction * 0.5f + rays.right.direction * 0.5f;


        RaycastHit hit;
        if (Physics.Raycast(position, direction, out hit))
        {
            //cursor.transform.position = hit.point;
            cursor.transform.position = Vector3.SmoothDamp(cursor.transform.position, hit.point, ref velocity, smoothTime);
        }
        else
        {
            //cursor.transform.position = position + direction * 3f;
            cursor.transform.position = Vector3.SmoothDamp(cursor.transform.position, (5* position + direction), ref velocity, smoothTime);
        }
    }
}
