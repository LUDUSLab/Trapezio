using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class touch : MonoBehaviour {

	public GameObject VaiEVem, RegiaoAlvo, BamBamObject;
    public Slider EnergyBar;
	public float CountToPowerUp;
    private float newY;
    private Vector3 newScale;
    public int maxEnergy = 4;
    private bool CanStop = true;
    public float ScaleSpeed = 0.2f;
    public float ReferencePosition;
    private float lerpTime = 3f;
    private float currentLerpTime = 0f;
    private float perc;
    private float xPosition;
    private bool DelayPowerUp = false;
    public float DelayPowerUpTime = 1.5f;
    public float AddVaiEVemSpeed;
    private Color InitialColor;
    public Color ClickColor;
    private Color ClickColor2;
    private float aux;
    //public GameObject FeedbackAcerto;
    public Animator mainCamera;
    public GameObject FeedbackPowerUp;
    public float MinRotation;
    public float MaxRotation;
    public Transform Roleta;
    private float zRotation;
    private bool canLostLife = true;

    public void Start()
    {
        InitialColor = RegiaoAlvo.GetComponent<SpriteRenderer>().color;
        ClickColor2 = new Color(ClickColor.r, ClickColor.g, ClickColor.b);
    }
    public void CanLostLife()
    {
        canLostLife = true;
    }
	public void Stop()
    {
        ///*
        if(Time.timeScale == 0)
        {
            return;
        }
        if (DelayPowerUp)
        {
            return;
        }
        else if (CanStop)
        {
            if(VaiEVem != null) //se for vai e vem
            {
                xPosition = VaiEVem.transform.position.x;
                if (xPosition >= -ReferencePosition && xPosition <= ReferencePosition)
                {
                    EnergyBar.value += 1 / CountToPowerUp;                        
                    mainCamera.SetBool("CanShake", true);   //feedback de acerto
                    RegiaoAlvo.GetComponent<SpriteRenderer>().color = ClickColor2;
                    Invoke("ChangeColor", 0.2f);
                    GetComponent<ScoreManager>().AddScore(1);
                    BamBamObject.GetComponent<Animator>().SetBool("WantMore", true);
                }
                else
                {
                    if(canLostLife)
                    {
                        canLostLife = false;
                        Handheld.Vibrate();
                        GetComponent<LifeBarManager>().ReduceLife(1);
                        Invoke("CanLostLife", 0.2f);
                    }
                }
            }
            else //se for roleta
            {
                zRotation = Roleta.eulerAngles.z;
                if (zRotation >= MinRotation && zRotation <= MaxRotation)
                {
                    EnergyBar.value += 1 / CountToPowerUp;  // aumenta a barra de energia
                    GetComponent<ScoreManager>().AddScore(1);   // aumenta a pontuação
                    
                    BamBamObject.GetComponent<Animator>().SetBool("WantMore", true);    // animação do bambam
                    mainCamera.SetBool("CanShake", true);   // feedback de acerto
                }
                else
                {
                    if (canLostLife)
                    {
                        canLostLife = false;
                        Handheld.Vibrate();
                        GetComponent<LifeBarManager>().ReduceLife(1);
                        GetComponent<PlayOneSound>().PlaySound(GetComponent<PlayOneSound>().Erro);
                        Invoke("CanLostLife", 0.2f);
                    }
                }
            }
        }
        //*/
    }
    private void SetFeedBackInactive()
    {
        //FeedbackAcerto.SetActive(false);
    }
    private void ChangeColor()
    {
        RegiaoAlvo.GetComponent<SpriteRenderer>().color = InitialColor;
    }
    public void PowerUpTouch()
    {
        if (!CanStop)
        {
            GetComponent<ScoreManager>().AddScore(1);
        }
    }

    public void Update()
    {
        ///*
        if(Input.GetMouseButtonDown(0) && Camera.main.ScreenToWorldPoint(Input.mousePosition).y <= 3)
        {
            Stop();
            PowerUpTouch();
        }
        //*/
        //<!-- consume energy
        if(EnergyBar.value == 1)    // power up ativou aqui!!1
        {
            CountToPowerUp++;   //aumenta a quantidade pra liberar o power up
            BamBamObject.GetComponent<Animator>().SetBool("IsPowerUpActive", true); //ativa o power up
            mainCamera.SetBool("PowerUp", true);
            FeedbackPowerUp.SetActive(true);
            if(VaiEVem != null) //se for vai e vem
            {
                aux = VaiEVem.GetComponent<Animator>().GetFloat("AnimationSpeed");  //aumenta a velocidade do vai e vem
                VaiEVem.GetComponent<Animator>().SetFloat("AnimationSpeed", aux + AddVaiEVemSpeed);
            }
            else    //se for roleta
            {
                Roleta.GetComponent<RotationOscilator>().AddSpeed(1);
            }
            DelayPowerUp = true;    //controla o tempo de atraso do power up
            CanStop = false;    //controla o toque durante o power up
        }
        if(!CanStop)
        {
            //Debug.Log("hello2");
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            perc = currentLerpTime / lerpTime;
            EnergyBar.value = Mathf.Lerp(1, 0, perc);
            if(EnergyBar.value == 0)
            {
                CanStop = true;
                currentLerpTime = 0;
                BamBamObject.GetComponent<Animator>().SetBool("IsPowerUpActive", false);
                mainCamera.SetBool("PowerUp", false);
                FeedbackPowerUp.SetActive(false);

                Invoke("SetDelayPowerUpFalse", DelayPowerUpTime);
            }
        }
        // -->
    } 
    private void SetDelayPowerUpFalse()
    {
        DelayPowerUp = false;
    }
}