using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estetoscopio : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;
    [SerializeField] private AudioSource somPegar;
    [SerializeField] private Transform estetoMesa;
    public static bool  mouseOnEsteto, mouseclik;
    bool clickMouse;
    // Start is called before the first frame update
    void Start()
    {
        rb.position=estetoMesa.position;

    }

    // Update is called once per frame
    void Update()
    {
        Arrasta();

    }
    private void OnMouseOver()
    {
        if(TriagemSistem.block)
        {

            mouseOnEsteto = true;
            if (Input.GetMouseButtonDown(0))
            {
                if (mouseOnEsteto)
                {
                    clickMouse = true;
                    mouseclik = true;

                    TriagemSistem.mouseclickPressao = false;
                    TriagemSistem.mouseclickTemperatura = false;

                }
            }
            else if (Input.GetMouseButtonUp(0))
            {

                if (mouseOnEsteto)
                {
                    clickMouse = false;
                    mouseclik = false;

                }
            }



        }

    }
    private void OnMouseExit()
    {
        mouseOnEsteto= false;
    }
    //private void OnMouseDown()
    //{
    //    if (mouseOnEsteto) 
    //    {
    //        clickMouse = true;
    //        mouseclik = true;
          
    //        TriagemSistem.mouseclickPressao = false;
    //        TriagemSistem.mouseclickTemperatura = false;

    //    }

    //}
    //private void OnMouseUp()
    //{
    //    if (mouseOnEsteto)
    //    {
    //        clickMouse= false;
    //        mouseclik= false;
            
    //    }
        
    //}
   
    void Arrasta()
    {
        if (clickMouse)
        {
            rb.MovePosition(cam.ScreenToWorldPoint(Input.mousePosition));

        }

    }
    //private void OnMouseOver()
    //{
       
    //        //  mouseOnTermometro = true;
           
    //        somPegar.Play();
    //    if(Input.GetMouseButtonDown(0)) 
    //    {
    //        mouseOnEsteto = true;
    //    }
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        mouseOnEsteto = false;
    //    }

       
       

    //}
   
    private void OnTriggerEnter2D(Collider2D collision)
    {



        Debug.Log("");
        if (collision.gameObject.tag == "Estetoscopio")
        {


            BatimentosCardiacos.stopCorrotine = true;
            TriagemSistem.block = false;
            clickMouse = false;
            mouseclik = false;
            if (!BatimentosCardiacos.flag2)
            {
                StartCoroutine(BatimentosCardiacos.Instance.GeradorBatimentos());
            }
            if (!BatimentosCardiacos.flag3)
            {
                StartCoroutine(BatimentosCardiacos.Instance.Batimentos());
            }


        }
       

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        BatimentosCardiacos.stopCorrotine = false;
    }
}
