using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandonPositions : MonoBehaviour
{
    public Transform[] randonPositions, originalPosition;
    public Vector3[] vectorPositions;
    public TextMeshProUGUI guideText, timeConter, minTimeCont, gameOverText, winGameText;
  

    int min;
    public int randonIndice, len;
    public List<int> randonIndiceList;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spritePieces1, spritePieces2, spritePieces3, spriteFull;
    public static int okPieces;
    int index, pauseTime;
    public float time;
    bool  randomSprite, transprent, gameOver;
    public static bool startGame;

    bool sp1, sp2, sp3;
    int timeInt, randSprit;
  



    public bool repet;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (okPieces >= 6)
        {





            WinGame();

        }
        if (startGame)
        {
            ContTime();
        }

    }
    void Start()
    {
       
        okPieces = 0;
        randomSprite = true;
        transprent = true;
        winGameText.enabled = false;
        gameOverText.enabled = false;
        pauseTime = 1;
        sp1 = false;
        sp2 = false;
        sp3 = false;
        randomSprite = false;
        time = 0;
        timeInt = 0;
        if(!Data_Controler.ttDna)
        {
            startGame = true;
        }
        else
        {
            startGame = false;
        }
       
        StopPiece();


        // ContTime();



        // StartCoroutine(RandomSprite());






    }

    public void RandonPiece()
    {

        for (int j = 0; j < randonPositions.Length; j++)
        {
            vectorPositions[j] = randonPositions[randonIndiceList[j]].position;
        }




        for (int i = 0; i < randonPositions.Length; i++)
        {



            randonPositions[i].position = vectorPositions[i];


        }



    }
    void ContTime()
    {


        time += Time.deltaTime * pauseTime;
        timeInt = Mathf.FloorToInt(time);
        timeConter.text = timeInt.ToString();

        if (timeInt < 5 && transprent)
        {
            StopPiece();

        }
        if (timeInt == 5 && transprent)
        {
            ShowSprite();
            StartpPiece();
            RandonPiece();


            guideText.enabled = false;

        }
        if (timeInt >= 60)
        {
            time = 0;
            min++;
            minTimeCont.text = min.ToString();


        }
        if (min >= 2)
        {
            StopPiece();
            GameOver();


        }


    }
    void ShowSprite()
    {
        transprent = false;
        spriteRenderer.color = new Color(1, 1, 1, 0.2f);
        time = 0;


    }
    public void StopPiece()
    {
        for (int i = 0; i < randonPositions.Length; i++)
        {
            randonPositions[i].gameObject.GetComponent<DragEndDropQuebra>().blockMove = false;
        }
    }
    public void StartpPiece()
    {
        for (int j = 0; j < randonPositions.Length; j++)
        {
            randonPositions[j].gameObject.GetComponent<DragEndDropQuebra>().blockMove = true; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if ( goToMapOk)
        //{
        //   goToMapOk = false;
        //    StartCoroutine(UpDown());


        //}
    }
    public void RandSpriteButton()
    {
        randomSprite = false;
        time = 0;
        timeInt = 0;

    }
    void ChangePices(int selectPiece)
    {
        for (int i = 0; i < randonPositions.Length; i++)
        {
            if (selectPiece == 0)
            {
                randonPositions[i].GetComponent<SpriteRenderer>().sprite = spritePieces1[i];
            }
            if (selectPiece == 1)
            {
                randonPositions[i].GetComponent<SpriteRenderer>().sprite = spritePieces2[i];
            }
            if (selectPiece == 2)
            {
                randonPositions[i].GetComponent<SpriteRenderer>().sprite = spritePieces3[i];

            }
        }
        startGame = true;
        RandonPiece();



    }
    private IEnumerator RandomSprite()
    {
        while (randomSprite)
        {
            index++;


            if (index == spriteFull.Length)
            {
                index = 0;

            }
            spriteRenderer.sprite = spriteFull[index];
            yield return new WaitForSeconds(0.1f);





        }
        if (sp1 && index == 0)
        {
            index = 1;
            spriteRenderer.sprite = spriteFull[index];


        }
        if (sp2 && index == 1)
        {
            index = 2;
            spriteRenderer.sprite = spriteFull[index];

        }
        if (sp2 && index == 2)
        {
            index = 0;
            spriteRenderer.sprite = spriteFull[index];

        }
        if ((sp1 && sp2))
        {
            index = 2;
            spriteRenderer.sprite = spriteFull[index];

        }
        if (sp1 && sp3)
        {
            index = 1;
            spriteRenderer.sprite = spriteFull[index];

        }
        if (sp2 && sp3)
        {
            index = 0;
            spriteRenderer.sprite = spriteFull[index];

        }
        // if (sp1 && sp2 && sp3)
        //{
        //    sp1 = false;
        //    sp2 = false;
        //    sp3 = false;
        //}






        ChangePices(index);


    }
    void GameOver()
    {
        gameOverText.enabled = true;
        pauseTime = 0;
        Data_Controler.falasEnfermeira = 5;
        Restart();
      
        SceneManager.LoadScene("Triagem");

    }
    void WinGame()
    {
       

        winGameText.enabled = true;

        pauseTime = 0;
        Restart();
       
       
        Data_Controler.historicoOk = true;

        SceneManager.LoadScene("Triagem");

    }
   
    public void Restart()
    {
        min = 0;
        
        okPieces = 0;
        randomSprite = true;
        transprent = true;
        winGameText.enabled = false;
        gameOverText.enabled = false;
        pauseTime = 1;
        time = 0;
        timeInt = 0;
        pauseTime = 1;
        okPieces = 0;
       // startGame = false;
        minTimeCont.text = min.ToString();
        timeConter.text = timeInt.ToString();

        spriteRenderer.color = spriteRenderer.color + new Color(0, 0, 0, 1);
       // StartCoroutine(RandomSprite());
        for (int i = 0; i < randonPositions.Length; i++)
        {
            randonPositions[i].position = originalPosition[i].position;
        }
        SceneManager.LoadScene("Triagem");

    }
   
}
