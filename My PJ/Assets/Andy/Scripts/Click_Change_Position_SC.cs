using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Change_Position_SC : MonoBehaviour
{
    public GameObject target;
    public Vector2 position0; //按下去的位置
    public Vector2 position1; //拖到新的位置

    public float horizon_dist; //兩點之間的水平距離
    public float vertical_dist; //兩點之間的垂直距離

    public bool isDragging;

    public bool first_position_Get; //是否已經決定抓到按下去的那點

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MousePosition(position0.x, position0.y);
    }

    public void MousePosition(float _mouseX, float _mouseY)
    {

        if (Input.GetMouseButtonDown(0))
        {
            target.transform.position = Input.mousePosition;

            isDragging = true;

        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging == true)
            {
                target.transform.position = new Vector3(0,0,0);
            }
        }



    }

    // private float _maxy;
    // public float max_y
    // {
    //     get { return this.transform.position.y; }
    //     set {
    //         if (this.transform.position.y>=7)
    //         {
    //             _maxy = Mathf.Min(7, this.transform.position.y);
    //         }
    //     }
    // }
}
