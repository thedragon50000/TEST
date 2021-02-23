using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TopNBottom_SC : MonoBehaviour
{
    // 是否達到頂或到底
    public bool GetTop;
    public bool GetBottom;
    public GameObject MyCamera;
    float Uptime =0;
    float Downtime =0;
    float Lefttime =0;
    float Righttime =0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetTopOrBottom();
        CameraMove();
    }

    void GetTopOrBottom()
    {
        if (MyCamera.transform.position.y>=7)
        {
            GetTop = true;
        }
        else
        {
            GetTop = false;
        }

        if (MyCamera.transform.position.y<=0)
        {
            GetBottom = true;
        }
        else
        {
            GetBottom = false;
        }
    }

    void CameraMove()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (GetTop ==false)
            {
                Uptime+= Time.deltaTime;
                MyCamera.transform.position += new Vector3(0,0.1f,0);
            }
        }

        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Uptime = 0;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (GetBottom == false)
            {
                Downtime+= Time.deltaTime;
                MyCamera.transform.position -= new Vector3(0, 0.1f, 0);
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Downtime = 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Lefttime+= Time.deltaTime;
            MyCamera.transform.position -= new Vector3(0.1f,0,0);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Lefttime = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Righttime+= Time.deltaTime;
            MyCamera.transform.position += new Vector3(0.1f,0,0);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Righttime = 0;
        }
    }
}
