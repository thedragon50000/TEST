using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWorldViewScript : MonoBehaviour {
    public Vector3 v3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*從世界轉螢幕*/
            Debug.Log("從世界轉螢幕 - " + Camera.main.WorldToScreenPoint(v3));
            /*從世界到視窗*/
            Debug.Log("從世界到視窗 - " + Camera.main.WorldToViewportPoint(v3));

            /*從螢幕到世界*/
            Debug.Log("從螢幕到世界 - " + Camera.main.ScreenToWorldPoint(v3));
            /*從螢幕到視窗*/
            Debug.Log("從螢幕到視窗 - " + Camera.main.ScreenToViewportPoint(v3));

            /*從視窗到螢幕*/
            Debug.Log("從視窗到螢幕 - " + Camera.main.ViewportToScreenPoint(v3));
            /*從視窗到世界*/
            Debug.Log("從視窗到世界 - " + Camera.main.ViewportToWorldPoint(v3));
        }
    }
}
