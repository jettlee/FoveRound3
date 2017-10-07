using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sheepScript : MonoBehaviour {

    public GameObject initPos;
    public GameObject targetPos;
    public FoveInterface fove;
    
    bool setDestroy= false;
    bool isComplete = false;
    bool gazeStart = false;
    bool blinkEnable = false;
    Image loader;
    Image loaderImage;

    void Start () {
        initPos = GameObject.Find("SpawnInitPos");
        fove = GameObject.Find("Fove Interface").GetComponent<FoveInterface>();        
        transform.position = initPos.transform.position;
        targetPos = GameObject.Find("SpawnTargetPos");
        
        GetComponentInChildren<Image>().enabled = false; ;
        loaderImage = GetComponentInChildren<Image>();
        loader = loaderImage;
        Debug.Log(loaderImage.name);        
        StartCoroutine(MoveSheep());
    }
	
    IEnumerator MoveSheep()
    {        
        Vector3 currentVelocity = Vector3.zero;
        float smoothTime = 2.0f;
        for (;;)
        {
            yield return new WaitForSeconds(0.2f);
            float dist = Vector3.Magnitude(transform.position - targetPos.transform.position);
            if (dist > 0.1)
            {
                transform.position = Vector3.SmoothDamp(transform.position, targetPos.transform.position, ref currentVelocity, smoothTime);
            }
            else
            {                
                setDestroy = true;                
                break;
            }
        }
    }

    IEnumerator LoadingBar()
    {
        loader.GetComponent<Image>().enabled = true;
        loader.enabled = true;
        loaderImage.fillAmount = 0.0f;
        blinkEnable = false;
        if (!isComplete)
        {
            for (;;) { 
                yield return new WaitForSeconds(0.15f);                
                loaderImage.fillAmount += 0.05f;
                loader.transform.position = transform.position;
                Debug.Log("Fill amount=" + loaderImage.fillAmount);
                if(loaderImage.fillAmount >= 1.0f)
                {
                    isComplete = true;
                    blinkEnable = true;
                    break;
                }
            }
        }
    }

	void Update () {
        if (setDestroy)
        {
            Destroy(this.gameObject);
        }
        

        if (fove.Gazecast(GetComponent<Collider>()))
        {
            if (!gazeStart)
            {
                gazeStart = true;
                StartCoroutine(LoadingBar());
            }
        }
        else
        {
            gazeStart = false;
            loader.enabled = false;
            isComplete = false;           
        }

        if (FoveInterface.CheckEyesClosed() == Fove.Managed.EFVR_Eye.Both && blinkEnable)
        {
            Destroy(this.gameObject);
            blinkEnable = false;
        }
    }
}
