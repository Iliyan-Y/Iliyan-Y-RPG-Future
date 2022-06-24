using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogIn : MonoBehaviour
{

  public void GameLogIn()
  {
    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Space");

    // Wait until the asynchronous scene fully loads
    while (!asyncLoad.isDone)
    {
      Debug.Log("Loading...");
      //  yield return null;
    }
  }

}
