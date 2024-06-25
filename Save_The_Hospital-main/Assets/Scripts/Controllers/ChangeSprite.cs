using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class ChangeSprite : MonoBehaviour
{

   
    public RuntimeAnimatorController aniCurado;
    public GameObject feliz, triste;

    // Start is called before the first frame update
   

   
   public  void TrocaSprite()
    {

        // this.gameObject.GetComponent<SpriteRenderer>().sprite = curado;
        this.gameObject.GetComponent<Animator>().runtimeAnimatorController = aniCurado;



    }
}
