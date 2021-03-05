using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TemaJogo : MonoBehaviour
{
    public Button btnPlay;
    //public Text txtNomeTema;

    public string[] nomeTema;

    public GameObject infoTema;
    public Text txtInfoTema;

    public int idTema;
    // Start is called before the first frame update
    void Start()
    {
        idTema = 0;
        //txtNomeTema.text = nomeTema[idTema];  
 
        btnPlay.interactable = false;
        txtInfoTema.text = "";

        
    }

    public void SelecioneTema(int i) {
        idTema = i;
        PlayerPrefs.SetInt("idTema", idTema);
        txtInfoTema.text = nomeTema[idTema];
        infoTema.SetActive(true);
        btnPlay.interactable = true;
    }

    public void Jogar() {

        SceneManager.LoadScene("T"+idTema.ToString());
    }
}
