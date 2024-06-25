using UnityEngine;

public class AmpliaVacina : MonoBehaviour
{
    public static bool jafoi,jafoi2;
   
    public SpriteRenderer vacina, letra, foco,fundo;
    public GameObject mascara,armario;
    Color corOriginal;
      Vector3 escalaVacina;
    private void Awake()
    {
        escalaVacina=this.gameObject.transform.localScale;
    }
    private void Start()
    {
        jafoi = true;
        jafoi2 = false;
        corOriginal = fundo.color;
    }
    private void OnMouseOver()
    {
      
        if (jafoi)
        {
            jafoi = false;
            jafoi2 = true;
            vacina.sortingOrder = 31;
            letra.sortingOrder = 31;
            fundo.sortingOrder = 30;
            mascara.SetActive(true);
            // fundo.gameObject.SetActive (true);
            foco.gameObject.SetActive(true);
            fundo.color = Color.white;
            this.gameObject.transform.localScale = this.gameObject.transform.localScale * 2;
            
        }
        

    }
    private void OnMouseExit()
    {
        if (jafoi2)
        {
            jafoi2 = false;
            jafoi = true;
            vacina.sortingOrder = 12;
            letra.sortingOrder = 12;
            fundo.sortingOrder = 11;
            fundo.color = corOriginal;
            mascara.SetActive(false);
            //  fundo.gameObject.SetActive(false);
            foco.gameObject.SetActive(false);
            this.gameObject.transform.localScale = escalaVacina;
        }
       
    }


}
