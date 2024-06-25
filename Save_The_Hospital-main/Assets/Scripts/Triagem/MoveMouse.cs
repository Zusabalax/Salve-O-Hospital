using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MoveMouse : MonoBehaviour
{
    public static bool mouseOncollisor, solta,click;
    
  
    public Rigidbody2D rb;
    public Camera cam;

    private void Awake()
    {
        solta = true;
    }
    void Update()
    {
        Arrasta();
    }
  

    private void OnMouseOver()
    {
      
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
            //  mouseOnTermometro = true;
                 mouseOncollisor = true; 
                 click = true;
                    


            }
             if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                 mouseOncollisor = false;
                click = false;
            }
        
           


    }
    void Arrasta()
    {
        if (mouseOncollisor)
        {
            rb.MovePosition(cam.ScreenToWorldPoint(Input.mousePosition));

        }

    }
}
