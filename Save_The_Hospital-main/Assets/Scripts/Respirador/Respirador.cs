using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Respirador : DragEndDrop
{
    [SerializeField] private Transform rosto,respirador;
    [SerializeField] private Collider2D col;
    public static bool on;
    [SerializeField] private Image botao;
    [SerializeField] private ParticleSystem ar;
    [SerializeField] string seneName;
    public  bool respDna;

    // Start is called before the first frame update
    void Start()
    {
        mouseClick = false;


        if(respDna)
        {
            if (!Data_Controler.respOK && Falas.indexFala > 2)
            {
                Falas.indexFala = 4;
            }
            else if (Data_Controler.respOK && Falas.indexFala > 2)
            {
                Falas.indexFala = 3;
            }
        }
     
       



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == col)
        {
            mouseClick = false;
            respirador.position = rosto.position;
            ar.Play();
            StartCoroutine(GamePulmao());

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == col)
        {
           
            ar.Stop();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(on)
        {
            MoveObj();
        }
       
    }
    public void LigaDesliga()
    {


        on = (on == true) ? false : true;
        if (on)
        {
           
            botao.color = Color.green;

          


        }
        else
        {
           
            botao.color = Color.red;



        }
    }

    public IEnumerator GamePulmao()
    {
        

            yield return new WaitForSeconds(2);
             SceneManager.LoadScene(seneName);
    }
       

}

