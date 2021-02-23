using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public LayerMask _CardLayerMask;
    public LayerMask _DisLayerMask;
    public GameObject obj;
    public Vector3 v3Org;
    public bool isToDis;

    // Use this for initialization
    void Start () {
        isToDis = false;
    }
	
	// Update is called once per frame
	void Update () {
        Raycast_Ray2();
        if (obj != null && Input.GetMouseButton(0))
        {
            Vector3 v3stw =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 300));
            obj.transform.position = new Vector3(v3stw.x, v3stw.y, obj.transform.position.z);
        }
        if (obj != null && Input.GetMouseButtonUp(0))
        {
            isToDis = true;
        }
    }

    //Raycast (ray : Ray,                               out hitInfo : RaycastHit, distance : float = Mathf.Infinity, layerMask : int = kDefaultRaycastLayers) : bool
    //         ray包辦(原始座標、從原始座標建立方向).   碰撞資訊                  射線距離(長度)                     遮罩(限定碰撞)
    //多了一个out hitInfo: RaycastHit, 如果碰撞到物体，具体碰撞数据和被碰撞体都会被记录在RaycastHit上，包括碰撞位置，碰撞位置法线，被碰撞体的Transform节点等信息。其他一样。
    void Raycast_Ray2()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        Ray ray1 = new Ray(origin, direction);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);//滑鼠位置
            if (Physics.Raycast(ray2, out hit, Mathf.Infinity, _CardLayerMask))
            {
                //Debug.Log(string.Format("Touch - Name:{0}, Position:{1}", hit.transform.name, hit.transform.position));
                if (obj == null && hit.transform.tag == "Card")
                {
                    obj = hit.transform.gameObject;
                    v3Org = obj.transform.position;
                }
            }
        }
        else if (isToDis)
        {
            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);//滑鼠位置
            if (Physics.Raycast(ray2, out hit, Mathf.Infinity, _DisLayerMask))
            {
                //Debug.Log(string.Format("Touch - Name:{0}, Position:{1}", hit.transform.name, hit.transform.position));
                if (obj != null && hit.transform.tag == "DisPlay")
                {
                    Debug.Log("DisPlay");
                    //obj.transform.position = hit.transform.position;//移至指定位置上
                    obj.SetActive(false);
                    Sprite sprChar = obj.GetComponent<CardScript>().sprChar;
                    string nameChar = obj.GetComponent<CardScript>().nameChar;
                    StartCoroutine(hit.transform.GetComponent<DisPlayScript>().CoDisPlayEvent(sprChar, nameChar));
                }
                else
                {
                    obj.transform.position = v3Org;
                    obj = null;
                }
            }
            else
            {
                obj.transform.position = v3Org;
                obj = null;
            }

            isToDis = false;
        }
    }
}

