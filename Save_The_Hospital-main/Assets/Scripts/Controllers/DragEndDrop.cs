using System;
using System.Collections;

using UnityEngine;


public class DragEndDrop : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public static bool mouseEnter, mouseClick;
    // Start is called before the first frame update
    void Start()
    {
        mouseClick = false;
        mouseEnter = false;

    }
    private void OnMouseOver()
    {
        mouseEnter = true;
        if (Input.GetMouseButtonDown(0))
        {
            if (mouseEnter)
            {
                mouseClick = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (mouseEnter)
            {
                mouseClick = false;
            }

        }


    }
    private void OnMouseExit()
    {
        mouseEnter = false;
    }
    //private void OnMouseDown()
    //{
    //    if (mouseEnter)
    //    {
    //        mouseClick = true;
    //    }
    //}
    //private void OnMouseUp()
    //{
    //    if (mouseEnter)
    //    {
    //        mouseClick = false;
    //    }
    //}


    // Update is called once per frame
    void Update()
    {
       


    }
    
    private void OnEnable()
    {
        mouseClick = false;
        mouseEnter = false;
    }
    public void MoveObj()
    {
        if (mouseClick)
        {
            rb.MovePosition(cam.ScreenToWorldPoint(Input.mousePosition));

        }
    }
}
