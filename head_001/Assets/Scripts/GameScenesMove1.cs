using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenesMove1 : MonoBehaviour
{
    

    public void GameScenesCtrl()
    {
        SceneManager.LoadScene("Game");   //어떤 씬 이름으로 이동할 건지
    }

    
}
