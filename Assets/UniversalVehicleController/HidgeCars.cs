using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidgeCars : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject carsObj;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            carsObj.SetActive(true);
        }
    }
}
