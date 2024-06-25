using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinhaRsp : MonoBehaviour
{
    public LineRenderer line;
    public Transform resp,inicioCabo;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(line.positionCount - 1, resp.localPosition);
        line.SetPosition(line.positionCount - 2, inicioCabo.localPosition);
    }
}
