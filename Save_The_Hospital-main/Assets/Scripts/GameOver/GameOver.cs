using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class GameOver : MonoBehaviour
{
    public static bool startGame;
    // Start is called before the first frame update
    private void Awake()
    {
        startGame = false;
    }
    void Start()
    {

        DeleteData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeleteData()
    {
         PlayerPrefs.DeleteAll();
        if (File.Exists(FilaControler.SavePath))
        {
          
            File.Delete(FilaControler.SavePath);
        }
    }

}
