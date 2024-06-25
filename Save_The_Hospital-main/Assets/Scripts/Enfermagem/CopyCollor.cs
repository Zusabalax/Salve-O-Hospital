using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyCollor : MonoBehaviour
{
    public Image imageA, ImageB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ColorCopy();
        
    }
    public void ColorCopy()
    {
        imageA.color = ImageB.color;

    }
}
