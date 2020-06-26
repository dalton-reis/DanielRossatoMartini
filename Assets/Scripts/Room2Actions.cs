using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class Room2Actions : MonoBehaviour
{
    public TextMeshProUGUI instructions;
    public Text RTStatus;
    public Text LampSize;
    public Text denoiseStatus;
    public GameObject AreaLightRTOn;
    public GameObject AreaLightDenoiseOff;
    public GameObject AreaLightRTOff;
    public GameObject AreaLightBigRTOn;
    public GameObject AreaLightBigDenoiseOff;
    public GameObject AreaLightBigRTOff;
    public GameObject LampSmall;
    public GameObject LampBig;
    private bool rtShadow = true;
    private bool lampBig = false;
    private bool denoise = false;
    private bool graphy = false;

    public GameObject graphyGO;

    public GameObject extraInfo;
    private int countSteps = 0;
    
    public GameObject introduction;

    public GameObject controlCamera;
    public GameObject camera0Instructions;
    public GameObject camera1Instructions;
    public GameObject camera2Instructions;
    public GameObject camera3Instructions;
    public TextMeshProUGUI camera1Instruction2Text;
    public TextMeshProUGUI camera2Instruction1Text;
    public TextMeshProUGUI camera3Instruction1Text;
    public TextMeshProUGUI currentCameraText;

    public Camera camera0;
    private int camera0Index = 0;
    public Camera camera1;
    private int camera1Index = 1;
    public Camera camera2;
    private int camera2Index = 2;
    public Camera camera3;
    private int camera3Index = 3;
    public Camera camera4;
    private int camera4Index = 4;
    public Camera mainCamera;
    private int mainCameraIndex = 5;

    private int stepIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        changeCamera();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clickOk()
    {
        this.introduction.SetActive(false);
    }

    public void toggleRTShadow()
    {
        rtShadow = !rtShadow;
        AreaLightRTOn.SetActive(rtShadow && denoise);
        AreaLightDenoiseOff.SetActive(rtShadow && !denoise);
        AreaLightRTOff.SetActive(!rtShadow);
        AreaLightBigRTOn.SetActive(rtShadow && denoise);
        AreaLightBigDenoiseOff.SetActive(rtShadow && !denoise);
        AreaLightBigRTOff.SetActive(!rtShadow);

        if (rtShadow)
        {
            RTStatus.text = "Sombra RT: Ligada";
        }
        else
        {
            RTStatus.text = "Sombra RT: Desligada";
        }
    }

    public void toggleDenoise()
    {
        if (denoise)
        {
            instructions.text = "Com o 'denoiser' desligado, conseguimos ver o Ray Tracing em ação. A sombra é formada por vários pontinhos, cada um deles é um lugar onde o raio de luz não chegou.";
        }
        else
        {
            instructions.text = "Com o 'denoiser' ligado, os pontos do onde a luz não pegou são suavizados, tornando a sombra mais realista.";
        }

        denoise = !denoise;
        AreaLightRTOn.SetActive(rtShadow && denoise);
        AreaLightDenoiseOff.SetActive(rtShadow && !denoise);
        AreaLightRTOff.SetActive(!rtShadow);
        AreaLightBigRTOn.SetActive(rtShadow && denoise);
        AreaLightBigDenoiseOff.SetActive(rtShadow && !denoise);
        AreaLightBigRTOff.SetActive(!rtShadow);

        //DenoiseInstructionsOn.SetActive(denoise);
        //DenoiseInstructionsOff.SetActive(!denoise);

        if (denoise)
        {
            denoiseStatus.text = "Denoiser: Ligado";
        }
        else
        {
            denoiseStatus.text = "Denoiser: Desligado";
        }
    }

    public void toggleGraphy()
    {
        graphy = !graphy;
        graphyGO.SetActive(graphy);
    }

    public void toggleLampSize()
    {
        lampBig = !lampBig;
        LampSmall.SetActive(!lampBig);
        LampBig.SetActive(lampBig);

        if (lampBig)
        {
            LampSize.text = "Tamanho Luz: Grande";
            camera1Instruction2Text.text = "Como a fonte de luz é grande, três raios são refletidos para esse demonstração. embora na prática mais raios podem ser refletidos.";
            camera3Instruction1Text.text = "Uma fonte de luz grande resulta em uma sombra bem mais difusa, pois a luz vem de vários lugares e relativamente pouca luz é bloqueada.";
            camera2Instruction1Text.text = "Com a fonte de luz grande, maior parte da fonte de luz é visível a partir do ponto onde o raio é refletido, então o pixel fica bem bem claro.";
        }
        else
        {
            LampSize.text = "Tamanho Luz: Pequena";
            camera1Instruction2Text.text = "Como a fonte de luz é pequena, apenas dois raios são refletidos para o calculo.";
            camera3Instruction1Text.text = "Uma fonte de luz pequena resulta em uma sombra pouco difusa, apenas nas bordas da sombra é que há um ponto que parte dos raios atinge a luz e outra parte fica bloqueada.";
            camera1Instruction2Text.text = "Com a fonte de luz pequena, apenas parte da fonte de luz é visível a partir do ponto onde o raio é refletido, então o pixel fica um pouco no escuro.";
        }

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
        stepIndex = 5;
        changeCamera();
    }

    private void changeCamera()
    {
        if (stepIndex > 5)
        {
            stepIndex = 0;
        } 
        else if (stepIndex < 0)
        {
            stepIndex = 5;
        }
        camera0.enabled = camera0Index == stepIndex;
        camera1.enabled = camera1Index == stepIndex;
        camera2.enabled = camera2Index == stepIndex;
        camera3.enabled = camera3Index == stepIndex;
        camera4.enabled = camera4Index == stepIndex;
        mainCamera.enabled = mainCameraIndex == stepIndex;
        this.controlCamera.SetActive(mainCameraIndex == stepIndex);
        this.camera0Instructions.SetActive(camera0Index == stepIndex);
        this.camera1Instructions.SetActive(camera1Index == stepIndex);
        this.camera2Instructions.SetActive(camera2Index == stepIndex);
        this.camera3Instructions.SetActive(camera3Index == stepIndex);
        this.currentCameraText.text = (stepIndex + 1).ToString();
        countSteps++;
        if (countSteps > 3)
        {
            this.extraInfo.SetActive(false);
        }
    }
}
