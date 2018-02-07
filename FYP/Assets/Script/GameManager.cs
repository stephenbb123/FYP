using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public void OnStartGame(string SceneName)
    {
        SceneManager.LoadScene(SceneName); //場景名稱,選取場景
    }
}
