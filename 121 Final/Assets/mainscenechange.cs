using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainscenechange : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.CompareTag("Player")))
        {
            return;
        }

        Debug.Log("change scene");
        PlayGame();

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("mainGame");
    }
}

