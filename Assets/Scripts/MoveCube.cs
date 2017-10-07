using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour {

    public GameObject init;
    public GameObject target;

    Rigidbody rigidBody;
    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        StartCoroutine(moveBody());
    }
	
    IEnumerator moveBody()
    {
        Vector3 velocity = Vector3.zero;
        float smoothTime = 0.1f;
        for (;;)
        {
            yield return new WaitForSeconds(0.3f);
            float targetDist = Mathf.Abs( Vector3.Magnitude(transform.position) - Vector3.Magnitude(target.transform.position));
            float initDist = Mathf.Abs(Vector3.Magnitude(transform.position) - Vector3.Magnitude(init.transform.position));

            if (targetDist > 0.01)
            {
                transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, smoothTime);
            }
            else
            { 
                transform.position = Vector3.SmoothDamp(transform.position, init.transform.position, ref velocity, smoothTime);
            }

            //if (distTarget < 0.01f)
            //    break;
            
        }
    }

	// Update is called once per frame
	void Update () {        
	}
}
