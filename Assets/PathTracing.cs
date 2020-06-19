using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class PathTracing : MonoBehaviour
{
    private bool graphy = false;


    private bool bpadrao = false;
    private bool bdirect = false;
    private bool bindirect2 = false;
    private bool bindirect3 = false;
    private bool bh512 = false;
    private bool bh1024 = false;
    private bool bh2048 = false;
    private bool bh4096 = false;
    private bool bl8 = false;

    public GameObject introduction;
    public GameObject graphyGO;

    public GameObject padrao;
    public GameObject direct;
    public GameObject indirect2;
    public GameObject indirect3;
    public GameObject h512;
    public GameObject h1024;
    public GameObject h2048;
    public GameObject h4096;
    public GameObject l8;


    // Start is called before the first frame update
    void Start()
    {
        //changeCamera();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clickOk()
    {
        this.introduction.SetActive(false);
    }

    public void toggleGraphy()
    {
        graphy = !graphy;
        graphyGO.SetActive(graphy);
    }

    private void setAllFalse()
    {
        bpadrao = false;
        bdirect = false;
        bindirect2 = false;
        bindirect3 = false;
        bh512 = false;
        bh1024 = false;
        bh2048 = false;
        bh4096 = false;
        bl8 = false;
    }

    private void setAllFogs()
    {
        padrao.SetActive(bpadrao);
        direct.SetActive(bdirect);
        indirect2.SetActive(bindirect2);
        indirect3.SetActive(bindirect3);
        h512.SetActive(bh512);
        h1024.SetActive(bh1024);
        h2048.SetActive(bh2048);
        h4096.SetActive(bh4096);
        l8.SetActive(bl8);
    }

    public void togglePadrao()
    {
        setAllFalse();
        bpadrao = true;
        setAllFogs();
    }
    public void toggleDirect()
    {
        setAllFalse();
        bdirect = true;
        setAllFogs();
    }
    public void toggleIndirect2()
    {
        setAllFalse();
        bindirect2 = true;
        setAllFogs();
    }
    public void toggleIndirect3()
    {
        setAllFalse();
        bindirect3 = true;
        setAllFogs();
    }
    public void toggleh512()
    {
        setAllFalse();
        bh512 = true;
        setAllFogs();
    }
    public void toggleh1024()
    {
        setAllFalse();
        bh1024 = true;
        setAllFogs();
    }
    public void toggleh2048()
    {
        setAllFalse();
        bh2048 = true;
        setAllFogs();
    }
    public void toggleh4096()
    {
        setAllFalse();
        bh4096 = true;
        setAllFogs();
    }
    public void toggleh8()
    {
        setAllFalse();
        bl8 = true;
        setAllFogs();
    }
}
