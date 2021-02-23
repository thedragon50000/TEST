using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_SC : MonoBehaviour
{
    public GameObject target;
    public Vector2 position0; //按下去的位置
    public Vector2 position1; //拖到新的位置

    public float dist; //兩點之間的距離
    public bool isDragging;

    public bool first_position_Get; //是否已經決定抓到按下去的那點

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform); //攝影機隨時照著角色
        CameraRotate(Input.mousePosition.x, Input.mousePosition.y);

    }

    public void CameraRotate(float _mouseX, float _mouseY)
    {
        float rotateSpeed = 0.005f;
        //注意!!! 此處是 GetMouseButton() 表示一直長按滑鼠左鍵；不是 GetMouseButtonDown()
        if (Input.GetMouseButtonDown(0))
        {
            position0 = Input.mousePosition;

            isDragging = true;

        }

        if (Input.GetMouseButton(0))
        {
            if (isDragging == true)
            {
                position1 = Input.mousePosition;
                dist = position1.x - position0.x;
                this.transform.RotateAround(target.transform.position, Vector3.up,
                    dist * rotateSpeed);
            }
        }

        //控制相機繞中心點(centerPoint)水平旋轉
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                position0 = new Vector2(0,0);
                position1 = new Vector2(0,0);
                dist = 0;
            }

    }
}
