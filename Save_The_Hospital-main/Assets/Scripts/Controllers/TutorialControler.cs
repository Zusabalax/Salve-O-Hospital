using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TutorialControler : MonoBehaviour
{
    public  List<Sprite> sprites;
    [TextArea]
    public List<string> textos;
    public TextMeshProUGUI textMeshPro;
    public SpriteRenderer render;
    public int indexSprite;
    public GameObject tutorial;
    public  List<GameObject> luzPopup;
    

    public int activeIndex;

    // Start is called before the first frame update
    void Start()
    {

        indexSprite = 0;
        render.sprite = sprites[indexSprite];
        textMeshPro.text = textos[indexSprite];
        TrocaSprite(indexSprite);
        switch (activeIndex) 
       {
            case 1:
                if(Data_Controler.ttTriagem)
                {
                    tutorial.SetActive(false);
                }
                break;

            case 2:
                if (Data_Controler.ttDna)
                {
                    tutorial.SetActive(false);
                }

                break;

            case 3:
                if (Data_Controler.ttRaiox)
                {
                    tutorial.SetActive(false);
                }
                break;
            case 4 :
                if (Data_Controler.ttEnfermagem)
                {
                    tutorial.SetActive(false);
                }
                break;
            case 5 :
                if (Data_Controler.ttVacina)
                {
                    tutorial.SetActive(false);
                }

                break;
        case 6 :
            
                if (Data_Controler.ttRespirador)
                {
                    tutorial.SetActive(false);
                }

                break;

        }



    }

    // Update is called once per frame
   

    public void Next()
    {
        indexSprite++;
        if(indexSprite >= sprites.Count) 
        {
            indexSprite = 0;
            switch (activeIndex)
            {
                case 1:
                    Data_Controler.ttTriagem = true;
                   
                    break;

                case 2:
                    Data_Controler.ttDna= true;
                    RandonPositions.startGame = true;

                   

                    break;

                case 3:
                    Data_Controler.ttRaiox= true;
                   
                    break;
                case 4:
                    Data_Controler.ttEnfermagem= true;
                    
                    break;
                case 5:
                    Data_Controler.ttVacina=true;
                    

                    break;
                case 6:
                    Data_Controler.ttRespirador = true;


                    break;

            }
            Time.timeScale = 1.0f;
            tutorial.SetActive(false);
            
        }
        render.sprite = sprites[indexSprite];
        TrocaSprite(indexSprite);

        textMeshPro.text = textos[indexSprite];
    }
    public void Previous() 
    {
        indexSprite--;
        if (indexSprite <= 0)
        {
            indexSprite = 0;
        }
        render.sprite = sprites[indexSprite];
        textMeshPro.text = textos[indexSprite];
        TrocaSprite(indexSprite);

    }

    void TrocaSprite(int index)
    {
        foreach (GameObject sprite in luzPopup)
        {
            sprite.SetActive(false);

        }
        luzPopup[index].SetActive(true);

    }

}
