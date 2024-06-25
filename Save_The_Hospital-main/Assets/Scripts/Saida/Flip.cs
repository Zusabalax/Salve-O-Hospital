using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public SpriteRenderer enfermeira;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlipSprite());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator FlipSprite()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 6));


            enfermeira.flipX = (enfermeira.flipX == true) ? false : true;

        }

    }
}
