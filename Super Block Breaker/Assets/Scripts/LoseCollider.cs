using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] string loseScene = "Lose";

    private void OnTriggerEnter2D()
    {
        SceneManager.LoadScene(loseScene);
    }
}
