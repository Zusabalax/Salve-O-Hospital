using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacinaUsada : MonoBehaviour
{
   
    public Rigidbody2D rb;
    public Camera cam;
    bool mouseEnter,mouseClick;
    // Start is called before the first frame update
    void Start()
    {
        mouseClick = false;
        mouseEnter = false;
        
    }
    private void OnMouseEnter()
    {
        mouseEnter = true;
    }
    private void OnMouseExit()
    {
        mouseEnter = false;
    }
    private void OnMouseDown()
    {
        if(mouseEnter) 
        {
            mouseClick = true;
        }
    }
    private void OnMouseUp() 
    {
        if (mouseEnter)
        {
            mouseClick = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (mouseClick)
        {
            rb.MovePosition(cam.ScreenToWorldPoint(Input.mousePosition));

        }
      

    }
    private void OnEnable()
    {
        mouseClick = false;
        mouseEnter = false;
    }
}
