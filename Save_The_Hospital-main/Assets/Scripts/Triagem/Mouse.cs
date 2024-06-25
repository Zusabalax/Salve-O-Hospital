using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Mouse : MonoBehaviour
{
    [SerializeField] private Transform mousePad, mousePosition, setaP;
    [SerializeField] private Rigidbody2D mouse, seta;
    private Vector3 mouseVetor;
    private float modulo;
    public float sensibilidade;
    public static bool clickB;


    // Start is called before the first frame update
    void Start()
    {

        
    }
    private void OnMouseEnter()
    {
        clickB = true;
    }
    private void OnMouseExit()
    {
        clickB = false;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickB = true;
            Debug.Log("clicou no mouse");
        }
        else if (Input.GetMouseButtonUp(0))
        {
            clickB = false;
            mousePosition.position = mousePad.position;


        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }
    void MouseVetor()
    {
         mouseVetor = mousePad.position - mousePosition.position;
         modulo = mouseVetor.magnitude;
        mouseVetor = new Vector3(mouseVetor.x, mouseVetor.y, 0);
        MoveSeta();

    }

    void MoveSeta()
    {


        if (MoveMouse.mouseOncollisor)
        {
            seta.bodyType = RigidbodyType2D.Dynamic;
            //seta.AddForce(-mouseVetor*5);
            setaP.position+= -mouseVetor * sensibilidade;
            clickB = true;
        }
        else
        {
            if (clickB)
            {
                seta.bodyType = RigidbodyType2D.Static;
                clickB = false;
               
               
            }
        }





    }

    // Update is called once per frame
    void Update()
    {
        MouseVetor();

    }
}
