using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartCena : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
