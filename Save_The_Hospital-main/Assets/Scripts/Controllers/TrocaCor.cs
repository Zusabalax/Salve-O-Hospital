using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrocaCor : MonoBehaviour
{
    // Start is called before the first frame update
    public bool imageSprite;
    public Image image;
    public SpriteRenderer sprite;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if(imageSprite)
        {
            sprite.color = Color.green;

        }

        else
        {
            image.color = Color.green;
        }
       
    }
    private void OnMouseExit()
    {
        if (imageSprite)
        {
            sprite.color = Color.white;

        }
        else
        {
            image.color = Color.white;
        }
    }
}
