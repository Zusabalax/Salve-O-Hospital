using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMouse : MonoBehaviour
{
    public Collider2D mouse;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == mouse) 
        { 
                 MoveMouse.mouseOncollisor = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
