using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private int idTema;
    public void LoadCena(string cena) {

        SceneManager.LoadScene($"{cena}");

    }


    void Update()
    {
        
    }

    public void LoadCenaAuto()
    {
        idTema = PlayerPrefs.GetInt("idTema");

        if(idTema == 1)
        {
            SceneManager.LoadScene("T2");
            idTema = 2;
            PlayerPrefs.SetInt("idTema".ToString(), idTema);
        }
        else { SceneManager.LoadScene("T1");
            idTema = 1;
            PlayerPrefs.SetInt("idTema".ToString(), idTema);
        }
    }

    public void ReLoadCena()
    {
        idTema = PlayerPrefs.GetInt("idTema");

        if (idTema == 1)
        {
            idTema = 1;
            PlayerPrefs.SetInt("idTema".ToString(), idTema);
            SceneManager.LoadScene("T1");
        }
        else         {
            idTema = 2;
            PlayerPrefs.SetInt("idTema".ToString(), idTema);
            SceneManager.LoadScene("T2");
        }

        }


}
