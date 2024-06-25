using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ativador : MonoBehaviour
{
    public GameObject obj;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        if (!Data_Controler.recepOK)
        {
            StartCoroutine(Ativa(time));

        }
        //   StartCoroutine(Ativa(time));


         Data_Controler.recepOK = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        if (!Data_Controler.recepOK)
        {
            StartCoroutine(Ativa(time));

        }
        //   StartCoroutine(Ativa(time));


        Data_Controler.recepOK = false;

    }
    public IEnumerator Ativa(float time)
    {
        yield return new WaitForSeconds(time);

        obj.SetActive(true);
    }
}
