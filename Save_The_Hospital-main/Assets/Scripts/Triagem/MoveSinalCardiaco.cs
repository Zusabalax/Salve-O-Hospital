using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveSinalCardiaco : MonoBehaviour
{
    public  GameObject destino;
    public float time;
    Mouse mouse;
    Transform destinoClone;
    // Start is called before the first frame update
    void Start()
    {
        destino = GameObject.Find("p2");
        destinoClone = destino.transform;
        this.gameObject.transform.DOMove(destinoClone.position, time).SetEase(Ease.Linear);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
