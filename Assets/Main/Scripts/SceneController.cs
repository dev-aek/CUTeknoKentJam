using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    enum SceneType { Forest,Hospital,Gameplay, None}
    [SerializeField] SceneType sceneType = SceneType.None;

    void Start()
    {
        if (sceneType == SceneType.Hospital)
        {
            SceneManager.LoadScene("Hospt");
        }
        else if (sceneType == SceneType.Gameplay)
        {
            SceneManager.LoadScene("Forest Scene");
        }
    }

    void Update()
    {
        
    }

    public void ForestScene()
    {
        SceneManager.LoadScene("Forest");
    }
}
