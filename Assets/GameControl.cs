using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    private int idTema;

    public static GameControl instance;

    public Text pergunta;
    public Text txtRespostaA;
    public Text txtRespostaB;
    public Text txtRespostaC;
    public Text infoRespostas;


    public string[] perguntas;
    public string[] alternativaA;
    public string[] alternativaB;
    public string[] alternativaC;
    public string[] alternativaCorreta;

    public int idPergunta;

    private float acertos;
    private float media;
    private float questoes;
    private int notaFinal;

    //void Awake() {
    //    if(instance == null) {
    //        instance = this;
    //        DontDestroyOnLoad(this.gameObject);
    //    } else {
    //        Destroy(gameObject);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema");

        idPergunta = 0;
        questoes = perguntas.Length;
        PlayerPrefs.SetInt("questoes", (int)questoes);

        pergunta.text = perguntas[idPergunta];
        txtRespostaA.text = alternativaA[idPergunta];
        txtRespostaB.text = alternativaB[idPergunta];
        txtRespostaC.text = alternativaC[idPergunta];
        infoRespostas.text = $"<-- Respondendo {idPergunta + 1} de {questoes}-->";
    }

    // Update is called once per frame
    void Update()
    {

        //if (!fungus.HasExecutingBlocks()) {

        //    StartCoroutine(TempoCoroutine());

        //} else {
        //    StopCoroutine(TempoCoroutine());
        //}

        
        
    }



    public void resposta(string alternativa) {

               
        if(alternativa == "A") {
            if( alternativaA[idPergunta] == alternativaCorreta[idPergunta]) {
                acertos += 1;
            }
        }
        else if (alternativa == "B") {
            if (alternativaB[idPergunta] == alternativaCorreta[idPergunta]) {
                acertos += 1;
            }
        }
        else if(alternativa == "C") {
            if (alternativaC[idPergunta] == alternativaCorreta[idPergunta]) {
                acertos += 1;
            }
        }
        ProximaPergunta();

    }

    void ProximaPergunta() {
        idPergunta++;

        if( idPergunta <= questoes - 1) {
            pergunta.text = perguntas[idPergunta];
            txtRespostaA.text = alternativaA[idPergunta];
            txtRespostaB.text = alternativaB[idPergunta];
            txtRespostaC.text = alternativaC[idPergunta];
            infoRespostas.text = $"<-- Respondendo {idPergunta + 1} de {questoes}-->";
        } else {

            media = 10 * (acertos / questoes);
            notaFinal = Mathf.RoundToInt(media);

            if( notaFinal> PlayerPrefs.GetInt("notaFinal"+idTema.ToString())) {
                PlayerPrefs.SetInt("notaFinal"+idTema.ToString(), notaFinal);
                PlayerPrefs.SetInt("acertos"+idTema.ToString(),(int)acertos);
            }

            PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
            PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);
            SceneManager.LoadScene("NOTAFINAL");
        }
        
    }
    
}
