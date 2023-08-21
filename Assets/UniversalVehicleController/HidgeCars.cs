using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidgeCars : MonoBehaviour
{
    bool onOff;
    public GameObject HandBrake;
    public void HandBrakeFunc()
    {
        if (onOff == true)
        { HandBrake.SetActive(true); onOff = false; }
        else { HandBrake.SetActive(false); onOff = true; }
    }
    public My m_Controls;
    public void Awake()
    {
        m_Controls = new My();
    }
    public void OnEnable()
    {
        m_Controls.Enable();
    }

    public void OnDisable()
    {
        m_Controls.Disable();
    }
    public GameObject carsObj;
    void Update()
    {
        float HandB = m_Controls.GraphicsSett.HandB.ReadValue<float>();
        if (HandB > 0.5f)
        {
            carsObj.SetActive(true);
        }
    }
}
