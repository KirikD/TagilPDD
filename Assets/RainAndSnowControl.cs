using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RainAndSnowControl : MonoBehaviour
{
    public Toggle m_ToggleRain, m_ToggleSnow;
    public Text m_TextRain, m_TextSnow;

    void Start()
    {
        //Fetch the Toggle GameObject
        //m_ToggleRain = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, and output the state
        m_ToggleRain.onValueChanged.AddListener(delegate {
            ToggleValueChangedRain(m_ToggleRain);
        });
        m_ToggleRain.onValueChanged.AddListener(delegate {
            ToggleValueChangedSnow(m_ToggleSnow);
        });

        //Initialize the Text to say whether the Toggle is in a positive or negative state
       // m_Text.text = "Toggle is : " + m_ToggleRain.isOn;
    }

    public GameObject Rain, Snow;
    void ToggleValueChangedRain(Toggle change)
    {
        m_TextRain.text = "Дождь " + m_ToggleRain.isOn;
        if (m_ToggleRain.isOn)
        { Rain.SetActive(true); }
        if (m_ToggleRain.isOn == false)
        { Rain.SetActive(false); }
    }
    void ToggleValueChangedSnow(Toggle change)
    {
        m_TextSnow.text = "Снег is : " + m_ToggleSnow.isOn;
        if (m_ToggleSnow.isOn)
        { Snow.SetActive(true); }
        if (m_ToggleSnow.isOn == false)
        { Snow.SetActive(true); }
    }
    void Update()
    {
        
    }

    public Transform StartP_A, StartP_B, StartP_C, StartP_D, StartP_E, StartP_F;
    Vector3 PointStart;
    public GameObject PlayerCam, Car;

    public void CoordSetointStart_A()
    { PointStart = StartP_A.position; }
    public void CoordSetointStart_B()
    { PointStart = StartP_B.position; }
    public void CoordSetointStart_C()
    { PointStart = StartP_C.position; }


    public void CoordSetointStart_D()
    { PointStart = StartP_D.position; }
    public void CoordSetointStart_E()
    { PointStart = StartP_E.position; }
    public void CoordSetointStart_F()
    { PointStart = StartP_F.position; }
    public void SetPointStart() 
    {
        PlayerCam.transform.position = PointStart + new Vector3(0, 4, 0);
        Car.transform.position = PointStart + new Vector3(2,3,2);


    }
        

}
