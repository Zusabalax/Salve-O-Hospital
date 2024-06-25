using System.Collections;

using UnityEngine;

public class SpotClick : MonoBehaviour
{
   
    public bool esquerdaDireita;
    public LineRenderer render;
    public AudioSource click;
    public Collider2D faixa;

    // Start is called before the first frame update

    
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision==faixa)
        {
            click.Play();
        }
       
    }

    private void Update()
    {
            if (render.positionCount%2==0 && esquerdaDireita)
            {
                 this.gameObject.GetComponent<Collider2D>().enabled =false;
                
            }
            else if (render.positionCount % 2 != 0 && !esquerdaDireita)
            {
                this.gameObject.GetComponent<Collider2D>().enabled = false;

            }
            else
            {
            this.gameObject.GetComponent<Collider2D>().enabled = true;

        }

    }



    // Update is called once per frame
    void Start()
    {
        
            StartCoroutine(Destaque());
          

       

    }
    public  IEnumerator Destaque()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (!esquerdaDireita && render.positionCount%2==0)
            {
                this.transform.localScale = this.transform.localScale*1.1f;
                yield return new WaitForSeconds(0.1f);
                this.transform.localScale = this.transform.localScale /1.1f;

            }
            if (esquerdaDireita && render.positionCount % 2 != 0)
            {
                this.transform.localScale = this.transform.localScale * 1.1f;
                yield return new WaitForSeconds(0.1f);
                this.transform.localScale = this.transform.localScale / 1.1f;

            }



        }
       
    }
    private void OnEnable()
    {
        StartCoroutine(Destaque());
    }

}
