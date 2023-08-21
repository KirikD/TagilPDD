using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class QualSettingsSett : MonoBehaviour
{
    public My m_Controls;
    public void Awake()
    {
        m_Controls = new My();
    }
    public void ReloadAllScene()
    {
        SceneManager.UnloadScene("Tagil_Ways");
        SceneManager.UnloadScene("Tagil_Buildnings");
        Invoke("ReloadthisScene",2);
    }
    public void ReloadthisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
    }
public void OnEnable()
    {
        m_Controls.Enable();
    }

    public void OnDisable()
    {
        m_Controls.Disable();
    }
    void Update()
    {
        float Graf1 = m_Controls.GraphicsSett.Graphics1.ReadValue<float>();
        float Graf2 = m_Controls.GraphicsSett.Graphics2.ReadValue<float>();
        float Graf3 = m_Controls.GraphicsSett.Graphics3.ReadValue<float>();
        float Graf4 = m_Controls.GraphicsSett.Graphics4.ReadValue<float>();
        float Graf5 = m_Controls.GraphicsSett.Graphics5.ReadValue<float>();
        float Graf6 = m_Controls.GraphicsSett.Graphics6.ReadValue<float>();


        if (Graf1 > 0.5f)
           {  Debug.Log( "1_" + Graf1);
               QualitySettings.SetQualityLevel(0, false);
           }
        if (Graf2 > 0.5f)
        {
            Debug.Log("2_" + Graf2);
            QualitySettings.SetQualityLevel(1, false);
           }
        if (Graf3 > 0.5f)
        {
            Debug.Log("3_" + Graf3);
            QualitySettings.SetQualityLevel(2, false);
           }
        if (Graf4 > 0.5f)
        {
            Debug.Log("4_" + Graf4);
            QualitySettings.SetQualityLevel(3, false);
           }
        if (Graf5 > 0.5f)
        {
            Debug.Log("5_" + Graf5);
            QualitySettings.SetQualityLevel(4, false);
           }
        if (Graf6 > 0.5f)
        {
            Debug.Log("6_" + Graf6);
            QualitySettings.SetQualityLevel(5, true);
           }
    }
}
