using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class PegaCor : MonoBehaviour
{
    public Transform target;
    public Image sprite;
    
    public int x, y;
    // Start is called before the first frame update
    void Start()
    {
        if (Data_Controler.pacientID == 3|| Data_Controler.pacientID==17)
        {
            y = 30;
        }
        else if (Data_Controler.pacientID == 9)
        {
            y = 34;
        }
        else if (Data_Controler.pacientID == 7|| Data_Controler.pacientID==16)
        {
            y = 35;
        }
        else if (Data_Controler.pacientID == 4 || Data_Controler.pacientID == 6 || Data_Controler.pacientID == 18)
        {
            y = 31;
            x = 30;
        }
        else if (Data_Controler.pacientID == 8)
        {
            y = 32;
        }

        else
        {
            y = 33;
        }


        sprite.color = target.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite.texture.GetPixel(x, y);

    }

    private void Update()
    {
       // sprite.color = target.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite.texture.GetPixel(x, y);
    }

    private void OnEnable()
    {
    //    if (Data_Controler.pacientID == 3 || Data_Controler.pacientID == 4)
    //    {
    //        y = 30;
    //    }
    //    else if (Data_Controler.pacientID == 9 )
    //    {
    //        y = 34;
    //    }
    //    else if (Data_Controler.pacientID == 7)
    //    {
    //        y = 35;
    //    }
    //    else if (Data_Controler.pacientID == 4)
    //    {
    //        y = 30;
    //        x = 30;
    //    }

    //    else
    //    {
    //        y = 33;
    //    }


    //    sprite.color = target.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite.texture.GetPixel(x, y);

    //
    }

    // Update is called once per frame


}
