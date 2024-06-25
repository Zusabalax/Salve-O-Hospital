using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalizaSutura : MonoBehaviour
{
    public Transform pacientePosition;
    bool flag;

    // Start is called before the first frame update
    void Start()
    {
        Data_Controler.gessoOk = false;
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Data_Controler.gessoOk && flag)
        {
            Destroy(pacientePosition.GetChild(0).gameObject);
            SceneManager.LoadScene("Triagem");
            flag = false;
        }

    }
    private void OnEnable()
    {
        Data_Controler.gessoOk = false;
        flag = true;

    }

}
