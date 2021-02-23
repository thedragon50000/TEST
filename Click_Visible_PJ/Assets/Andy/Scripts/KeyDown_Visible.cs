using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDown_Visible : MonoBehaviour
{
    // Start is called before the first frame update
    public Renderer Camera_renderer;
    public GameObject IamCamera;
    void Start()
    {
        Camera_renderer = IamCamera.GetComponent<Renderer>();
        Camera_renderer.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Camera_renderer.enabled = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Camera_renderer.enabled = false;
        }
    }
}
