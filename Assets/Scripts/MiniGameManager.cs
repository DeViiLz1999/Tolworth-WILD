using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public GameObject yucca1;
    public GameObject yucca2;
    public GameObject yucca3;

    // Start is called before the first frame update
    void Start()
    {
        yucca1.SetActive(true);
        yucca2.SetActive(false);
        yucca3.SetActive(false);
    }

    public void OnSelectedBack()
    {
        SceneManager.LoadScene(1);
    }

    public void OnTapPhaseOne()
    {
        yucca1.SetActive(true);
        yucca2.SetActive(false);
        yucca3.SetActive(false);
    }

    public void OnTapPhaseTwo()
    {
        yucca1.SetActive(false);
        yucca2.SetActive(true);
        yucca3.SetActive(false);
    }

    public void OnTapPhaseThree()
    {
        yucca1.SetActive(false);
        yucca2.SetActive(false);
        yucca3.SetActive(true);
    }
}
