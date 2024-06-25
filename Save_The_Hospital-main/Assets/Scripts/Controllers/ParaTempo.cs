using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaTempo : MonoBehaviour
{
    // Start is called before the first frame update
  public void StopTime()
    {
        Time.timeScale = 0.0f;

    }
    public void StartTime()
    {
        Time.timeScale = 1.0f;
    }
}
