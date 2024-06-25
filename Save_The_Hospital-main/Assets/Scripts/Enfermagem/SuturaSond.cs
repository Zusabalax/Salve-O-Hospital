using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuturaSond : MonoBehaviour
{
    public bool onMouse;
  
    public AudioSource tone;
    public Collider2D agulha;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == agulha)
        {
            onMouse = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == agulha)
        {
            onMouse = false;
        }
    }
    //private void OnMouseDown()
    //{
    //    if (onMouse) 
    //    {
    //        tone.Play();
        
    //    }
    //}
    private void Update()
    {

        if (Input.GetMouseButtonUp(0)&& onMouse )
        {
            tone.Play();
            if(!Sutura.vitoria)
            {
                StartCoroutine(CorChange());
            }
            

        }

    }
    private IEnumerator CorChange()
    {

            this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color=Color.green;
            yield return new WaitForSeconds(0.2f);
            this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>()
               .color = new Color(0.09433961f, 0.01637593f, 0.01637593f, 0.5607843f);





    }



    // Update is called once per frame


}
