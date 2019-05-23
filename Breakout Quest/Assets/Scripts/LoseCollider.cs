using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    SceneLoader sceneLoader;

    void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    void OnTriggerEnter2D()
    {
        sceneLoader.LoadGameOverScene();
    }
}
