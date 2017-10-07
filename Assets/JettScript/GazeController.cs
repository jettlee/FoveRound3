using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeController : MonoBehaviour {

    public FoveInterface fove;
    public float correctFactor = 0.9f;

    private Vector3 lastOrigin, lastDirection;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (FoveInterface.CheckEyesClosed() == Fove.Managed.EFVR_Eye.Neither)
        {
            FoveInterface.EyeRays rays = FoveInterface.GetEyeRays();
            Vector3 origin = (rays.left.origin + rays.right.origin) * 0.5f;
            Vector3 direction = (rays.left.direction + rays.left.direction) * 0.5f;

            if (Vector3.Dot(lastOrigin.normalized, origin.normalized) < correctFactor || Vector3.Dot(lastDirection.normalized, direction.normalized) < correctFactor)
            {
                origin = lastOrigin;
                direction = lastDirection;
            }

            RaycastHit hit;
            if (Physics.Raycast(origin, direction, out hit, Mathf.Infinity))
            {
                transform.position = hit.point;
            }
            else
            {
                transform.position = (rays.left.GetPoint(10.0f) + rays.right.GetPoint(10.0f));
            }

            lastOrigin = origin;
            lastDirection = direction;
        }
    }
}
