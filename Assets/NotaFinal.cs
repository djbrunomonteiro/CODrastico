using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using UnityEngine.SceneManagement;
public class NotaFinal : MonoBehaviour
{

    private int idTema;
    public Text txtInfo;

    private int notaFHtml, notaFCss;
    private int acertos;


    public float porcentagem;

    private string txtDotema;
    private int questoes;

    public Button porcUm;
    public Button porcDois;
    public Button porcTres;

 
    public GameObject gameOver, painelBtns, audioController;

    public Image porcNotaFinalHtml;
    public Image porcNotaFinalCss;

    public Flowchart flowCGameOver;
    internal bool activeSelf;


    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema");
        questoes = PlayerPrefs.GetInt("questoes");
        notaFHtml = PlayerPrefs.GetInt("notaFinal1");
        notaFCss = PlayerPrefs.GetInt("notaFinal2");


        audioController = GameObject.Find("AudioControl");
        gameOver = GameObject.Find("gameover");
        gameOver.SetActive(false);

        VerificaTema();
        
        acertos = PlayerPrefs.GetInt("acertosTemp" + idTema.ToString());
        txtInfo.text = "Você conseguiu desativar " + acertos.ToString() + " de " + questoes.ToString() + " componentes do codigo "+txtDotema;
        
    
        PorcentagemNotafinal();
        RegraDoJogo();
        FeedbackFinal();
    }
   void Update()
    {
        idTema = PlayerPrefs.GetInt("idTema");
       
    }

    public void PorcentagemNotafinal() {

        porcentagem = acertos * 100 / questoes;        


            porcNotaFinalHtml.fillAmount = porcentagem / 100;
            porcNotaFinalCss.fillAmount = porcentagem / 100; ;

        
    }

    public void VerificaTema() {
        switch (idTema) {
            case 1:
                txtDotema = "HTML";
                txtInfo.color = new Color(1, 0.92f, 0.16f, 1);
                break;
            case 2:
                txtDotema = "CSS";
                txtInfo.color = new Color(0, 1, 0, 1);
                break;
            default:
                break;
        }
    }

    public void RegraDoJogo()
    {
        switch (porcentagem)
        {
            case 0:
                gameOver.SetActive(true);
                porcUm.GetComponent<Button>().interactable = false;
                porcDois.GetComponent<Button>().interactable = false;
                porcTres.GetComponent<Button>().interactable = false;
                painelBtns.SetActive(false);
                flowCGameOver.ExecuteBlock("feedGameover");
                GameOverAudio();
                break;
            case 25:
                gameOver.SetActive(true);
                porcUm.GetComponent<Button>().interactable = false;
                porcDois.GetComponent<Button>().interactable = false;
                porcTres.GetComponent<Button>().interactable = false;
                painelBtns.SetActive(false);
                flowCGameOver.ExecuteBlock("feedGameover");
                GameOverAudio();
                break;

            case 50:
                gameOver.SetActive(false);
                porcUm.GetComponent<Button>().interactable = true;
                porcDois.GetComponent<Button>().interactable = false;
                porcTres.GetComponent<Button>().interactable = false;
                flowCGameOver.ExecuteBlock("feedback50");
                break;
            case 75:
                porcUm.GetComponent<Button>().interactable = true;
                porcDois.GetComponent<Button>().interactable = true;
                porcTres.GetComponent<Button>().interactable = false;
                flowCGameOver.ExecuteBlock("feedback75");
                break;
            case 100:
                porcUm.GetComponent<Button>().interactable = false;
                porcDois.GetComponent<Button>().interactable = true;
                flowCGameOver.ExecuteBlock("feedback100");
                break;

            default:               
                break;
        }
    }

    public void FeedbackFinal()
    {
        if(notaFHtml == notaFCss)
        {
            porcTres.GetComponent<Button>().interactable = true;
            porcDois.GetComponent<Button>().interactable = false;
        }
        else
        {
            porcTres.GetComponent<Button>().interactable = false;            
        }
        
    }


    public void GameOverAudio()
    {

        if (gameOver.activeSelf)
        {

            audioController.GetComponent<AudioController>();
            audioController.GetComponent<AudioSource>().Pause();
            audioController.GetComponent<AudioSource>().clip = audioController.GetComponent<AudioController>().clips[3];
            audioController.GetComponent<AudioSource>().Play();
            audioController.GetComponent<AudioSource>().loop = false;

        }
    }

    public void Congratulations()
    {
       SceneManager.LoadScene("CONGRATULATIONS");
    }
}
