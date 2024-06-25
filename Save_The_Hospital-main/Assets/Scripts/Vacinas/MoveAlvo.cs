using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveAlvo : MonoBehaviour
{
    public GameObject alvo, fim,inicio;
    public float tempo;
    // Start is called before the first frame update
    void Start()

    {
      
        alvo.transform.position = inicio.transform.position;
     

    }
    private void OnEnable()
    {
        EnfermagemSistem.moveAlvo = true;
        alvo.transform.position = inicio.transform.position;
        alvo.transform.DOMoveY(fim.transform.position.y, tempo).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        if (!EnfermagemSistem.moveAlvo)
        {
            alvo.transform.DOPause();
            
        }
    }
}
