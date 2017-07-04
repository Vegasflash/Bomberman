using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnButtonClick()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("TP2");
        SceneManager.UnloadSceneAsync(y);
    }
}
