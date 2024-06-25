using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXrayEmissor : MonoBehaviour
{
    public static bool mouseOncollisor,podeclicar;
    public Rigidbody2D rb;
    public Camera cam;


    void Update()
    {
        Arrasta();
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && podeclicar)
        {
            //  mouseOnTermometro = true;
            mouseOncollisor = (mouseOncollisor == true) ? false : true;
           

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
