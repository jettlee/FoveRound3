//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Fove.Managed;

//public class SheepBehavior : MonoBehaviour {

//    [SerializeField] private GameObject m_sheep;

//	// Use this for initialization
//	void Start () {
//        m_sheep = GetComponent<Renderer>().material.color;
//	}
	
//	// Update is called once per frame
//	void Update () {
//        if (fove.Gazecast(m_item.GetComponent<BoxCollider>()))
//        {
//            if (!gazeStart)
//            {
//                currTime += Time.deltaTime;
//                if (currTime > gazeTimeThreashold)
//                {
//                    m_item.GetComponent<Renderer>().material.color = Color.black;
//                    itemDestroy(FoveInterface.CheckEyesClosed());
//                }
//            }
//        }
//        else
//        {
//            m_item.GetComponent<Renderer>().material.color = m_defaultColor;
//        }
//    }

//    public void itemDestroy(EFVR_Eye eyes)
//    {
//        switch (eyes)
//        {
//            case EFVR_Eye.Both:
//                Destroy(m_item);
//                currTime = 0.0f;
//                break;
//            case EFVR_Eye.Left:
//                currTime = 0.0f;
//                Destroy(m_item);
//                break;
//            case EFVR_Eye.Right:
//                currTime = 0.0f;
//                Destroy(m_item);
//                break;
//            case EFVR_Eye.Neither:
//                break;
//        }
//    }
//}
