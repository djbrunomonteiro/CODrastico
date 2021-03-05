using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotaFinal : MonoBehaviour
{

    private int idTema;
    //public Text txtnota;
    public Text txtInfo;

    private int notaF;
    private int acertos;


    public float porcentagem;

    private string txtDotema;
    private int questoes;

    public Image porcNotaFinal;
    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema");
        questoes = PlayerPrefs.GetInt("questoes");
        VerificaTema();
        
        //notaF = PlayerPrefs.GetInt("notaFinalTemp" + idTema.ToString());
        acertos = PlayerPrefs.GetInt("acertosTemp" + idTema.ToString());
        //txtnota.text = "Nota final "+notaF.ToString();
        txtInfo.text = "Você conseguiu desativar " + acertos.ToString() + " de " + questoes.ToString() + " componentes do codigo "+txtDotema;
        PorcentagemNotafinal();
              


    }

   public void PorcentagemNotafinal() {

        porcentagem = acertos * 100 / questoes;        

        porcNotaFinal.fillAmount = porcentagem / 100;
        
    }

    public void VerificaTema() {
        switch (idTema) {
            case 1:
                txtDotema = "HTML";
                break;
            case 2:
                txtDotema = "CSS";
                break;
            default:
                break;
        }
    }

   
}
