using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject InventoryCanvas;
    public GameObject GameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        InventoryCanvas.SetActive(false);
    }

    public void OnSelected()
    {
        GameCanvas.SetActive(false);
        InventoryCanvas.SetActive(true);
    }

    public void OnSelectedBack()
    {
        GameCanvas.SetActive(true);
        InventoryCanvas.SetActive(false);
    }

    public void OnNext()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuiz()
    {
        SceneManager.LoadScene(2);
    }

    public void OnMiniGameSeleted()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
