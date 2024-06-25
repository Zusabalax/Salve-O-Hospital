using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ApagaLtreiro());
        
    }
    private void OnEnable()
    {
        StartCoroutine(ApagaLtreiro());
    }

    // Update is called once per frame
    public IEnumerator ApagaLtreiro()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }

 }
