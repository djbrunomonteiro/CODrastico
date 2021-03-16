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

    public Flowchart fungus;

    private string alternativaSelecionada;
 
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

    IEnumerator EsperaResultado(float tempo)
    {
        tempo = 2.0f;
        yield return new WaitForSeconds(tempo);
        ProximaPergunta();
    }
  
    public void resposta(string alternativa) {

        alternativaSelecionada = alternativa;
        Feed();

        if (alternativa == "A") {
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



        StartCoroutine(EsperaResultado(1.0f));

        
    }


    public void Feed()
    {
       switch (idTema)
        {

            case 1:
                if (alternativaSelecionada == "C" && idPergunta == 0)
                {
                    fungus.ExecuteBlock("feedCerto1");
                }
                else if (idPergunta == 0)
                {
                    fungus.ExecuteBlock("feedErro1");
                }

                if (alternativaSelecionada == "A" && idPergunta == 1)
                {
                    fungus.ExecuteBlock("feedCerto2");
                }
                else if (idPergunta == 1)
                {
                    fungus.ExecuteBlock("feedErro2");
                }

                if (alternativaSelecionada == "B" && idPergunta == 2)
                {
                    fungus.ExecuteBlock("feedCerto3");
                }
                else if (idPergunta == 2)
                {
                    fungus.ExecuteBlock("feedErro3");
                }

                if (alternativaSelecionada == "A" && idPergunta == 3)
                {
                    fungus.ExecuteBlock("feedCerto4");
                }
                else if (idPergunta == 3)
                {
                    fungus.ExecuteBlock("feedErro4");
                }

                break;


            case 2:
                if (alternativaSelecionada == "B" && idPergunta == 0)
                {
                    fungus.ExecuteBlock("feedCerto1");
                }
                else if (idPergunta == 0)
                {
                    fungus.ExecuteBlock("feedErro1");
                }

                if (alternativaSelecionada == "C" && idPergunta == 1)
                {
                    fungus.ExecuteBlock("feedCerto2");
                }
                else if (idPergunta == 1)
                {
                    fungus.ExecuteBlock("feedErro2");
                }

                if (alternativaSelecionada == "B" && idPergunta == 2)
                {
                    fungus.ExecuteBlock("feedCerto3");
                }
                else if (idPergunta == 2)
                {
                    fungus.ExecuteBlock("feedErro3");
                }

                if (alternativaSelecionada == "A" && idPergunta == 3)
                {
                    fungus.ExecuteBlock("feedCerto4");
                }
                else if (idPergunta == 3)
                {
                    fungus.ExecuteBlock("feedErro4");
                }

                break;

            default:
                break;

        }
        
        
        
    }
   

    void ProximaPergunta() {
        idPergunta++;
        

        if ( idPergunta <= questoes - 1) {
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

            StartCoroutine(EsperaResultado(4.0f));
            SceneManager.LoadScene("NOTAFINAL");
        }
        
    }
    
}
