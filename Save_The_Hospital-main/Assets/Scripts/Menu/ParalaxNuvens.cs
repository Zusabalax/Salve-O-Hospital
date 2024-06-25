using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxNuvens : MonoBehaviour
{
    
    [SerializeField] Transform pontI,pontF;
    [SerializeField] float vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(vel, 0,0);

        if(this.transform.position.x>= pontF.position.x)
        {
            this.transform.position=pontI.position;
        }
    }
}
