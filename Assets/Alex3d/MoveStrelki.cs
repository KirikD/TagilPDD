using System;
using UnityEngine;

// Press the space key in Play Mode to switch to the Bounce state.   _FresnelStrength

public class MoveStrelki : MonoBehaviour
{
    private Animator anim;
    public Material matGlass;
    [Header("Поворотики")]
    public GameObject PovL, PovR;
        
    void Start()
    {
        anim = GetComponent<Animator>();
        matGlass.shader = Shader.Find("Shader Graphs/Ice");

        PovR.SetActive(false); PovL.SetActive(false); FaraA.SetActive(false); FaraB.SetActive(false);
        matGlass.SetFloat("_RefractStrength", 0.0f);
    }
    public string AnimName = "DvornikiAnimation";
    bool onOff = true; bool onOffFara = true; bool onOffPowRL = true;
    [Header("Фары")]
    public GameObject FaraA, FaraB;
    void Update()
    {

      /*  if (Input.GetKeyDown(KeyCode.K))
        {
           
            if (onOff == true)
            { InvokeRepeating("StartStrelki", 2.0f, 5.0f); matGlass.SetFloat("_RefractStrength", 0.0f);  onOff = false; }
            else { CancelInvoke("StartStrelki"); matGlass.SetFloat("_RefractStrength", 0.2f);  onOff = true; }
        }        
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (onOffFara == true)
            { FaraA.SetActive(true); FaraB.SetActive(true); onOffFara = false; }
            else { FaraA.SetActive(false); FaraB.SetActive(false); onOffFara = true; }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (onOffPowRL == true)
            { Pov_L_OnOff(); PovR.SetActive(false); onOffPowRL = false; }
            else {  PovL.SetActive(false); PovR.SetActive(false); onOffPowRL = true; }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (onOffPowRL == true)
            { Pov_R_OnOff(); PovL.SetActive(false);  onOffPowRL = false; }
            else {  PovR.SetActive(false); PovL.SetActive(false); onOffPowRL = true; }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {

            if (onOffPowRL == true)
            { Pov_L_OnOff(); Pov_R_OnOff(); onOffPowRL = false; }
            else { PovR.SetActive(false); PovL.SetActive(false); onOffPowRL = true; }
        }*/

    }
    public void InputGetKeyDownKeyCodeK ()
     {
           
            if (onOff == true)
            { InvokeRepeating("StartStrelki", 2.0f, 5.0f); matGlass.SetFloat("_RefractStrength", 0.0f);  onOff = false; }
            else { CancelInvoke("StartStrelki"); matGlass.SetFloat("_RefractStrength", 0.2f); onOff = true; }
        }
    public void  InputGetKeyDownKeyCodeM ()
{
    if (onOffFara == true)
    { FaraA.SetActive(true); FaraB.SetActive(true); onOffFara = false; }
    else { FaraA.SetActive(false); FaraB.SetActive(false); onOffFara = true; }
}

 public void InputGetKeyDownKeyCodeQ ()
{

   if (onOffPowRL == true)
    { Pov_L_OnOff(); PovR.SetActive(false); onOffPowRL = false; }
    else { PovL.SetActive(false); PovR.SetActive(false); onOffPowRL = true; }
}
 public void InputGetKeyDownKeyCodeE()
{

    if (onOffPowRL == true)
    { Pov_R_OnOff(); PovL.SetActive(false); onOffPowRL = false; }
    else { PovR.SetActive(false); PovL.SetActive(false); onOffPowRL = true; }
}
public void InputGetKeyDownKeyCodeX ()
{

    if (onOffPowRL == true)
    { Pov_L_OnOff(); Pov_R_OnOff(); onOffPowRL = false; }
    else { PovR.SetActive(false); PovL.SetActive(false); onOffPowRL = true; }
}






public void SetKapliNaStekle()
    {
        matGlass.SetFloat("_RefractStrength", 0.4f);
    }
    public void FaraOnOff()
    {
        if (onOffFara == true)
        { FaraA.SetActive(true); FaraB.SetActive(true); onOffFara = false; }
        else { FaraA.SetActive(false); FaraB.SetActive(false); onOffFara = true; }
    }
    public void StrelkiOnOff()
    {
        if (onOff == true)
        { InvokeRepeating("StartStrelki", 2.0f, 5.0f); matGlass.SetFloat("_RefractStrength", 0.0f); onOff = false; }
        else { CancelInvoke("StartStrelki"); matGlass.SetFloat("_RefractStrength", 0.5f); onOff = true; }
    }
    void StartStrelki() 
    {
        anim.Play(AnimName, 0, 0.0f);
        
    }


    public void Pov_L_OnOff()
    {
       PovL.SetActive(true);
    }
    public void Pov_R_OnOff()
    {
        PovR.SetActive(true); 
    }
    public void Avariika_OnOff()
    {
        PovR.SetActive(true); PovL.SetActive(true);
        PovR.GetComponent<Animator>().Play(AnimName, 0, 0.0f); PovL.GetComponent<Animator>().Play(AnimName, 0, 0.0f);
    }

    }