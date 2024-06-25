using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacientMove : MonoBehaviour
{
    public Transform pascientPosition;
    public  List<GameObject> pacientList;


  
    

    // Start is called before the first frame update
    void Start()
    {
       
        Data_Controler.pacientID = PlayerPrefs.GetInt("PacientID");

        Data_Controler.pressao = PlayerPrefs.GetString("Pressao");
        Data_Controler.temperatura = PlayerPrefs.GetInt("Temperatura");
       

        Instantiate(pacientList[Data_Controler.pacientID], pascientPosition);
      
        if (Data_Controler.Atendimentook)
        {
            if(Falas.indexFala==0)
            {
                pascientPosition.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ChangeSprite>().TrocaSprite();
                pascientPosition.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ChangeSprite>().feliz.SetActive(true);
            }
          

        }
        else
        {
            Debug.Log("cara Triste11111");
            Debug.Log(Data_Controler.contaErro);
            if ( Data_Controler.contaErro>=3)
            {
                pascientPosition.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ChangeSprite>().triste.SetActive(true);
                Debug.Log("cara Triste22222");
            }
             

        }



    }

    // Update is called once per frame
   
}
