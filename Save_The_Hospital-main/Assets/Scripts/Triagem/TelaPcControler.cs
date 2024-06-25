using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TelaPcControler : MonoBehaviour
{
    public TextMeshProUGUI batimentosPc, temperaturaPc, precaoPc;
    public GameObject telaTemperatura, telaPressao, telaBatimentos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TriagemSistem.mouseclickTemperatura)
        {
            telaTemperatura.SetActive(true);
            telaPressao.SetActive(false);
            telaBatimentos.SetActive(false);
        }
        if (TriagemSistem.mouseclickPressao)
        {
            telaTemperatura.SetActive(false);
            telaPressao.SetActive(true);
            telaBatimentos.SetActive(false);
        }
        if (Estetoscopio.mouseclik)
        {
            telaTemperatura.SetActive(false);
            telaPressao.SetActive(false);
            telaBatimentos.SetActive(true);
        }
    }
}
