using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragEndDropQuebra : MonoBehaviour
{
    public Camera cam;
   
    public Rigidbody2D rb;
    public bool inPart,arrast ,blockMove;
    public Transform originalPosition;
    public float distance;
    public static DragEndDropQuebra Instance;

    private void Awake()
    {
        Instance = this;    
        blockMove = true;
    }

    void OnMouseOver()
    {
        inPart = true;
        if (Input.GetMouseButtonDown(0))
        {
            if (inPart)
                arrast = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (inPart)
                arrast = false;

        }

    }
    private void OnMouseExit()
    {
        inPart = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();   
        arrast = false;

        
    }
    //private void OnMouseDown()
    //{
    //    if (inPart)
    //        arrast = true;
        
    //}
    //private void OnMouseUp()
    //{
    //    if(inPart)
    //        arrast = false;
    //}

    // Update is called once per frame
    void Update()
    {
        //if(inPart)
        //{
        //    if(Input.GetMouseButtonDown(0))
        //    {
        //        arrast=(arrast) ? false : true;
        //        Debug.Log(arrast);

        //    }
        //}
        if (blockMove)
        {
            ArrastPart();

        }


    }

    public void ArrastPart()
    {
        if(arrast)
        {
            this.transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 40;
            rb.MovePosition(cam.ScreenToWorldPoint(Input.mousePosition));
        }
        else
        {
            this.transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 30;
            if (Vector2.Distance(rb.transform.position,originalPosition.position)<=distance)
            {
                rb.transform.position = originalPosition.position;
                RandonPositions.okPieces++;
                blockMove = false;
            }
        }
       
    }

}
