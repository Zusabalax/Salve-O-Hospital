using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class LimiteCollider : MonoBehaviour
{
    public GameObject obj1, obj2,obj3,obj4,obj5,luz,emissor,emissorposition;
    public Image botao;
    public SpriteRenderer render;
    public Sprite luzLiga, luzDesliga;
    public bool on;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "xray")
        {
            obj1.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(false);
            obj4.SetActive(false);
         
           // obj5.SetActive(false);

        }



    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "xray")
        {
            obj1.SetActive(true);
            obj2.SetActive(true);
            obj3.SetActive(true);
            obj4.SetActive(true);
          //  obj5.SetActive(true);

        }

    }

    public void LigaDesliga()
    {

       
        on = (on == true) ? false : true;
        if (on) 
        {
            render.sprite = luzLiga;
            obj1.SetActive(true);
            obj2.SetActive(true);
            obj3.SetActive(true);
            obj4.SetActive(true);
            obj5.SetActive(true);
            luz.SetActive(true);
            botao.color = Color.green;
          
            MoveXrayEmissor.podeclicar = true;


        }
        else
        {
            render.sprite = luzDesliga;
            obj1.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(false);
            obj4.SetActive(false);
            obj5.SetActive(true);
            luz.SetActive(false);
            botao.color = Color.red;
           
            

        }
    }
    private void OnDisable()
    {
        obj1.SetActive(false);
        obj2.SetActive(false);
        obj3.SetActive(false);
        obj4.SetActive(false);
      
        luz.SetActive(false);
        botao.color = Color.red;
       
        emissor.transform.position = emissorposition.transform.position;
        on = !on;
    }

}
