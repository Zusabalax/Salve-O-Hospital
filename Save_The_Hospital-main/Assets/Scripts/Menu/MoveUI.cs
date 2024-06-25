using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject destino;
    public float time, espera;
   
    public string obj;
   
    Transform destinoClone;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Espera());


    }
    public IEnumerator Espera()
    {



        yield return new WaitForSeconds(espera);

        destino = GameObject.Find(obj);
        destinoClone = destino.transform;
        this.gameObject.transform.DOMove(destinoClone.position, time).SetEase(Ease.Linear);
       

    }






    // Update is called once per frame
    
}
