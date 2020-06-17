using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;


public class TransparencyRoom : MonoBehaviour
{

    public TextMeshProUGUI instructions;
    public Text metalicStatus;
    public Text ssrStatus;
    public Text sphereStatus;
    public Text giStatus;
    private bool ssr = true;
    private bool metalic = true;
    private bool lowRefraction = true;
    private bool gi = true;

    public GameObject metalicos;
    public GameObject difusos;

    public GameObject lowSphere;
    public GameObject highSphere;

    public GameObject extraInfo;
    private int countSteps = 0;

    public GameObject introduction;

    public GameObject controlCameraInstructions;
    public GameObject camera0Instructions;
    public GameObject camera01Instructions;
    public GameObject camera1Instructions;
    public GameObject camera1Instruction14;
    public GameObject camera2Instructions;
    public GameObject camera21Instructions;
    public GameObject camera3Instructions;
    public GameObject camera4Instructions;
    public GameObject camera5Instructions;
    public TextMeshProUGUI camera0Instruction2Text;
    public TextMeshProUGUI camera01Instruction1Text;
    public TextMeshProUGUI camera01Instruction2Text;
    public TextMeshProUGUI camera1Instruction2Text;
    public TextMeshProUGUI camera2Instruction1Text;
    public TextMeshProUGUI camera3Instruction3Text;
    public TextMeshProUGUI currentCameraText;

    public Camera mainCamera;
    private int mainCameraIndex = 0;
    public Camera camera0;
    private int camera0Index = 1;
    public Camera camera1;
    private int camera01Index = 2;
    public Camera camera01;
    private int camera1Index = 3;
    public Camera camera2;
    private int camera2Index = 4;
    public Camera camera21;
    private int camera21Index = 5;
    public Camera camera3;
    private int camera3Index = 6;
    public Camera camera4;
    private int camera4Index = 7;
    public Camera camera5;
    private int camera5Index = 8;

    public GameObject VolumeSSROnGIOn;
    public GameObject VolumeSSROffGIOn;
    public GameObject VolumeSSROnGIOff;
    public GameObject VolumeSSROffGIOff;

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

    public void toggleSSR()
    {
        if (ssr)
        {
            instructions.text = "Com o 'denoiser' desligado, conseguimos ver o Ray Tracing em ação. A sombra é formada por vários pontinhos, cada um deles é um lugar onde o raio de luz não chegou.";
        }
        else
        {
            instructions.text = "Com o 'denoiser' ligado, os pontos do onde a luz não pegou são suavizados, tornando a sombra mais realista.";
        }

        ssr = !ssr;

        VolumeSSROnGIOn.SetActive(ssr && gi);
        VolumeSSROffGIOn.SetActive(!ssr && gi);
        VolumeSSROnGIOff.SetActive(ssr && !gi);
        VolumeSSROffGIOff.SetActive(!ssr && !gi);

        camera1Instruction14.SetActive(!ssr && stepIndex == camera2Index);

        //DenoiseInstructionsOn.SetActive(denoise);
        //DenoiseInstructionsOff.SetActive(!denoise);

        if (ssr)
        {
            ssrStatus.text = "SSR: On";
        }
        else
        {
            ssrStatus.text = "SSR: Off";
        }
    }

    public void toggleGI()
    {

        gi = !gi;

        VolumeSSROnGIOn.SetActive(ssr && gi);
        VolumeSSROffGIOn.SetActive(!ssr && gi);
        VolumeSSROnGIOff.SetActive(ssr && !gi);
        VolumeSSROffGIOff.SetActive(!ssr && !gi);

        camera1Instruction14.SetActive(!ssr && stepIndex == camera2Index);

        if (gi)
        {
            giStatus.text = "GI Denoiser: On";
        }
        else
        {
            giStatus.text = "GI Denoiser: Off";
        }
    }

    public void toggleMetalic()
    {
        metalic = !metalic;

        metalicos.SetActive(metalic);
        difusos.SetActive(!metalic);

        if (metalic)
        {
            metalicStatus.text = "Metálico";
            camera0Instruction2Text.text = "Quando a textura é metálica, há pouca dispersão de luz nos objetos próximos, pois a luz é refletida de forma mais direta, gerando pouca interação com outros objetos.";
            camera01Instruction1Text.text = "Aqui temos um objeto metálico refletindo a luz de forma mais direta.";
            camera01Instruction2Text.text = "Quando um raio de luz atinge um objeto metálico, ele é refletido com o mesmo ângulo de entrada, ou seja, se o raio chegar ao objeto com um ângulo de entrada de 30°, o ângulo de saída será de 30° também.";
        }
        else
        {
            metalicStatus.text = "Difuso";
            camera0Instruction2Text.text = "Quando a textura é difusa, o objeto dispersa a luz que cai sobre ele para outros objetos ao redor, fazendo com que sua cor apareça em outros objetos.";
            camera01Instruction1Text.text = "Aqui temos um objeto difuso refletindo a luz para todos os lados.";
            camera01Instruction2Text.text = "Quando um raio de luz atinge um objeto difuso, ele é refletido para todos os lados, pois não há nenhuma ordenação nesse sentido. O algoritmo gera então vários outros raios para direções diversas para simular um objeto difuso.";
        }
    }

    public void toggleSphere()
    {
        lowRefraction = !lowRefraction;

        lowSphere.SetActive(lowRefraction);
        highSphere.SetActive(!lowRefraction);

        if (lowRefraction)
        {
            sphereStatus.text = "Refração Baixa";
            camera3Instruction3Text.text = "Com refração baixa, há apenas pequenas distorções nas bordas do objeto.";
        }
        else
        {
            sphereStatus.text = "Refração Alta";
            camera3Instruction3Text.text = "Com uma refração alta, as distorções se tornam mais pronunciadas. ";
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
        if (stepIndex > 8)
        {
            stepIndex = 0;
        }
        else if (stepIndex < 0)
        {
            stepIndex = 8;
        }
        camera0.enabled = camera0Index == stepIndex;
        camera01.enabled = camera01Index == stepIndex;
        camera1.enabled = camera1Index == stepIndex;
        camera2.enabled = camera2Index == stepIndex;
        camera21.enabled = camera21Index == stepIndex;
        camera3.enabled = camera3Index == stepIndex;
        camera4.enabled = camera4Index == stepIndex;
        camera5.enabled = camera5Index == stepIndex;
        mainCamera.enabled = mainCameraIndex == stepIndex;
        this.controlCameraInstructions.SetActive(mainCameraIndex == stepIndex);
        this.camera0Instructions.SetActive(camera0Index == stepIndex);
        this.camera01Instructions.SetActive(camera01Index == stepIndex);
        this.camera1Instructions.SetActive(camera1Index == stepIndex || camera2Index == stepIndex);
        //this.camera2Instructions.SetActive(camera2Index == stepIndex);
        this.camera21Instructions.SetActive(camera21Index == stepIndex);
        this.camera3Instructions.SetActive(camera3Index == stepIndex);
        this.camera4Instructions.SetActive(camera4Index == stepIndex);
        this.camera5Instructions.SetActive(camera5Index == stepIndex);
        this.currentCameraText.text = (stepIndex + 1).ToString();
        camera1Instruction14.SetActive(!ssr && stepIndex == camera2Index);
        countSteps++;
        if (countSteps > 5)
        {
            this.extraInfo.SetActive(false);
        }
    }
}
