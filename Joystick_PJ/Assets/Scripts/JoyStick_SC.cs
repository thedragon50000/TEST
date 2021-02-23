using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick_SC : MonoBehaviour
{public RectTransform rtrsRect;
    public RectTransform rtrsHandle;
    public float limitMaxHandle;
    public bool isDragging;     //判斷有無在拖曳

    public Transform trsPlayer;
    public float speed;

    // Update is called once per frame
    void Update () {
        Drag();
    }

    public void StartDrag()
    {
        isDragging = true;
    }
    public void Drag()
    {
        if (!isDragging)
            return;
        Vector2 mPos = Input.mousePosition;
        Vector2 newPos = mPos - rtrsRect.anchoredPosition;
        Vector2 newPos2 = Vector2.ClampMagnitude(newPos, limitMaxHandle);   //newPos最大值無法超過limitMaxHandle

        rtrsHandle.anchoredPosition = newPos2;

        //物件移動
        //Vector2 dir = newPos2.normalized * speed * Time.deltaTime;
        Vector2 dir = (newPos2/ limitMaxHandle) * speed * Time.deltaTime;
        trsPlayer.Translate(dir);
    }
    public void StopDrag()
    {
        isDragging = false;
        rtrsHandle.anchoredPosition = Vector2.zero; //手柄歸位
    }
}
