using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovePaciente : MonoBehaviour
{
    [SerializeField] private Vector3 destino;
    [SerializeField] private float speed;
    [SerializeField] private Transform destinoT,inicio;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private AudioSource win,loose;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(MovePersonagem());
        if(Falas.indexFala==0 )
        {
            text.text = "Tratamento Concluído.";
            win.Play();

        }
        else 
        {
            text.text = "Paciente perdido";
            loose.Play();

        }


    }
    public IEnumerator MovePersonagem()
    {
     
        yield return new WaitForSeconds(1);
        destino = destinoT.position;

        inicio.GetChild(0).gameObject.transform.DOMove(destino, speed).OnComplete(() => {

            inicio.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Anda", false);
            SceneManager.LoadScene("Recepção");
        });
        inicio.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Anda", true);




       


    }
    public IEnumerator ScalePersonagem()
    {
        while (true) 
        {
            inicio.GetChild(0).gameObject.transform.localScale=new Vector3(5,5,5);
            yield return new WaitForSeconds(0.5f);
            inicio.GetChild(0).gameObject.transform.localScale = new Vector3(5, 5, 5);



        }
       



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
