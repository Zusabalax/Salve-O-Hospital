using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveiraSprites : MonoBehaviour
{
    public Sprite[] caveiras;
    public GameObject caveira,caveiratv;
    public GameObject collider1, collider2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpriteChange();

    }
    public void SpriteChange()
    {
        if (Data_Controler.pacinetGotratament == 0)
        {
            caveira.GetComponent<SpriteRenderer>().sprite = caveiras[0];
            caveiratv.GetComponent<SpriteRenderer>().sprite = caveiras[0];
            collider1.SetActive(true);
            collider2.SetActive(false);
        }
        else if (Data_Controler.pacinetGotratament == 3)
        {
            caveira.GetComponent<SpriteRenderer>().sprite = caveiras[1];
            caveiratv.GetComponent<SpriteRenderer>().sprite = caveiras[1];
            collider2.SetActive(true);
            collider1.SetActive(false);
        }
        else
        {
            caveira.GetComponent<SpriteRenderer>().sprite = caveiras[2];
            caveiratv.GetComponent<SpriteRenderer>().sprite = caveiras[2];
            collider1.SetActive(true);
            collider2.SetActive(false);
        }
    }
}
   
