using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorScript : MonoBehaviour {

	public FoveInterface fove;

    public GameObject cursor;

    public Light light;

    Rigidbody rigid;

    Vector3 velocity = Vector3.zero;

    float smoothTime = 0.1f;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        FoveInterface.EyeRays rays = FoveInterface.GetEyeRays();
        //GazeConvergenceData convergencePoint = FoveInterface.GetGazeConvergence();
        //RaycastHit hit;
        //Physics.Raycast(convergencePoint.ray, out hit, Mathf.Infinity);
        //if (hit.point != Vector3.zero) // Vector3 is non-nullable; comparing to null is always false
        //{
        //    cursor.transform.position = hit.point;
        //}
        //else
        //{
        //    cursor.transform.position = convergencePoint.ray.GetPoint(3.0f);
        //}


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
            cursor.transform.position = Vector3.SmoothDamp(cursor.transform.position, (position + direction), ref velocity, smoothTime);          
        }
        
    }
}
