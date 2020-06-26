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
    private bool bbounces = false;
    private bool bdayNight = true;
    private bool bAllLights = true;

    public GameObject defaultInstructions;
    public GameObject directInstructions;
    public GameObject indirect2Instructions;
    public GameObject indirect3Instructions;
    public GameObject sample8Instructions;
    public GameObject sample512Instructions;
    public GameObject sample2048Instructions;
    public GameObject sample4096Instructions;
    public GameObject bouncesInstructions;
    public GameObject allOffInstructions;
    public GameObject LightsInstructions;
    public GameObject SunInstructions;

    public GameObject introduction;
    public GameObject graphyGO;


    public GameObject AllLights;
    public GameObject Sun;
    public Text SunTextText;
    public Text AllLightsTextText;


    public TextMeshProUGUI diaNoiteInstructions;
    public TextMeshProUGUI allLightsInstructions;

    public GameObject padrao;
    public GameObject direct;
    public GameObject indirect2;
    public GameObject indirect3;
    public GameObject h512;
    public GameObject h1024;
    public GameObject h2048;
    public GameObject h4096;
    public GameObject l8;
    public GameObject bounces;

    private int stepIndex = 0;
    public Camera currentCamera;
    public GameObject mainCamera;
    private int mainCameraIndex = 0;
    public GameObject CameraSphere;
    private int cameraSphereIndex = 1;
    public GameObject CameraRedGreen;
    private int cameraRedGreenIndex = 2;
    public GameObject CameraMirrors;
    private int cameraMirrorsIndex = 3;
    public GameObject CameraSign;
    private int cameraSignIndex = 4;

    private int countSteps = 0;

    public GameObject f2;
    private int f2i = 2;
    public GameObject f3;
    private int f3i = 3;
    public GameObject f4;
    private int f4i = 4;
    public GameObject f5;
    private int f5i = 5;
    public GameObject f6;
    private int f6i = 6;
    public GameObject f7;
    private int f7i = 7;
    public GameObject f8;
    private int f8i = 8;
    public GameObject f9;
    private int f9i = 9;
    public GameObject f10;
    private int f10i = 10;
    private int indexFs = 2;
    public TextMeshProUGUI BouncesTextText;


    // Start is called before the first frame update
    void Start()
    {
        goToMainCamera();
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
        bbounces = false;
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
        bounces.SetActive(bbounces);

        defaultInstructions.SetActive(bpadrao);
        directInstructions.SetActive(bdirect);
        indirect2Instructions.SetActive(bindirect2);
        indirect3Instructions.SetActive(bindirect3);
        sample8Instructions.SetActive(bl8);
        sample512Instructions.SetActive(bh512);
        sample2048Instructions.SetActive(bh2048);
        sample4096Instructions.SetActive(bh4096);
        bouncesInstructions.SetActive(bbounces);

        //Vector3 temp = new Vector3(100f, 100, 100);
        //currentCamera.transform.position += temp;
    }

    public void toggleDayNight()
    {
        bdayNight = !bdayNight;
        Sun.SetActive(bdayNight); 

        allOffInstructions.SetActive(!bAllLights && !bdayNight);
        LightsInstructions.SetActive(bAllLights || bdayNight);
        SunInstructions.SetActive(bAllLights || bdayNight);

        if (bdayNight)
        {
            SunTextText.text = "Dia";
            diaNoiteInstructions.text = "Durante o dia, podemos ver que as outras luzes tem um efeito pequeno na imagem, devido ao sol ser muito mais brilhante.";
        } else
        {
            SunTextText.text = "Noite";
            diaNoiteInstructions.text = "Durante a noite conseguimos ver com clareza as outras luzes e como elas afetam a cena.";
        }
    }

    public void toggleAllLights()
    {
        bAllLights = !bAllLights;
        AllLights.SetActive(bAllLights);

        allOffInstructions.SetActive(!bAllLights && !bdayNight);
        LightsInstructions.SetActive(bAllLights || bdayNight);
        SunInstructions.SetActive(bAllLights || bdayNight);

        if (bAllLights)
        {
            AllLightsTextText.text = "Luzes: Ligadas";
            allLightsInstructions.text = "Com as luzes ligadas, podemos ver como elas geram outras sombras e até como elas fazem com que a cor de um objeto passe para outro com os reflexos difusos.";
        }
        else
        {
            AllLightsTextText.text = "Luzes: Desligadas";
            allLightsInstructions.text = "Com as luzes desligadas, apenas o Sol está iluminando a cena, dessa forma tudo está sendo iluminado por ele, mesmo em locais onde não há só diretamente.";
        }
    }

    public void plus()
    {

        setAllFalse();
        bbounces = true;
        changeBounces(1);
        setAllFogs();
    }
    public void minus()
    {
        changeBounces(-1);
    }

    private void changeBounces(int amount)
    {
        if ((indexFs == 10 && amount > 0) || (indexFs == 2 && amount < 0))
        {
            return;
        }

        indexFs = indexFs + amount;

        f2.SetActive(f2i == indexFs);
        f3.SetActive(f3i == indexFs);
        f4.SetActive(f4i == indexFs);
        f5.SetActive(f5i == indexFs);
        f6.SetActive(f6i == indexFs);
        f7.SetActive(f7i == indexFs);
        f8.SetActive(f8i == indexFs);
        f9.SetActive(f9i == indexFs);
        f10.SetActive(f10i == indexFs);

        BouncesTextText.text = indexFs + "";

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

    public void next()
    {
        stepIndex++;
        changeCamera();

    }
    public void previous()
    {
        stepIndex--;
        changeCamera();
    }
    public void goToMainCamera()
    {
        stepIndex = 0;
        changeCamera();
    }

    private void changeCamera()
    {
        if (stepIndex > 4)
        {
            stepIndex = 0;
        }
        else if (stepIndex < 0)
        {
            stepIndex = 4;
        }

        mainCamera.SetActive(mainCameraIndex == stepIndex);
        CameraSphere.SetActive(cameraSphereIndex == stepIndex);
        CameraRedGreen.SetActive(cameraRedGreenIndex == stepIndex);
        CameraMirrors.SetActive(cameraMirrorsIndex == stepIndex);
        CameraSign.SetActive(cameraSignIndex == stepIndex);
        //currentCamera = getCurrentCamera();
        //camera21.enabled = camera21Index == stepIndex;
        //this.controlCameraInstructions.SetActive(mainCameraIndex == stepIndex);
        //this.camera0Instructions.SetActive(camera0Index == stepIndex);
        //this.camera01Instructions.SetActive(camera01Index == stepIndex);
        //this.camera1Instructions.SetActive(camera1Index == stepIndex || camera2Index == stepIndex);
        //this.camera2Instructions.SetActive(camera2Index == stepIndex);
        //this.camera21Instructions.SetActive(camera21Index == stepIndex);
        //this.camera3Instructions.SetActive(camera3Index == stepIndex);
        //this.camera4Instructions.SetActive(camera4Index == stepIndex);
        //this.camera5Instructions.SetActive(camera5Index == stepIndex);
        //this.currentCameraText.text = (stepIndex + 1).ToString();
        //camera1Instruction14.SetActive(!ssr && stepIndex == camera2Index);
        countSteps++;
        if (countSteps > 10)
        {
            //this.extraInfo.SetActive(false);
        }
    }

    /*private Camera getCurrentCamera()
    {

        if (mainCameraIndex == stepIndex)
        {
            return mainCamera;
        } 
        else if (cameraSphereIndex == stepIndex)
        {
            return CameraSphere;
        }
        else if (cameraRedGreenIndex == stepIndex)
        {
            return CameraRedGreen;
        }
        else if (cameraMirrorsIndex == stepIndex)
        {
            return CameraMirrors;
        }
        else if (cameraSignIndex == stepIndex)
        {
            return CameraSign;
        }
        return mainCamera;
    }*/
}
