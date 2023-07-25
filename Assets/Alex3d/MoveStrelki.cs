using System;
using UnityEngine;

// Press the space key in Play Mode to switch to the Bounce state.   _FresnelStrength

public class MoveStrelki : MonoBehaviour
{
    private Animator anim;
    public Material matGlass;
    void Start()
    {
        anim = GetComponent<Animator>();
        matGlass.shader = Shader.Find("Shader Graphs/Ice");
    }
    public string AnimName = "DvornikiAnimation";
    bool onOff = true; bool onOffFara = true;
    public GameObject FaraA, FaraB;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
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
}