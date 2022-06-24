using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogIn : MonoBehaviour
{
  public Image loadingProgressBar;
  public GameObject home;
  public GameObject loadingInterface;

  List<AsyncOperation> sceneToLoad = new List<AsyncOperation>();
  public void StartGame()
  {
    HideHome();
    ShowLoading();
    sceneToLoad.Add(SceneManager.LoadSceneAsync("Space"));
    StartCoroutine(LoadingScreen());
  }

  void HideHome()
  {
    home.SetActive(false);
  }

  void ShowLoading()
  {
    loadingInterface.SetActive(true);
  }

  IEnumerator LoadingScreen()
  {
    float totalProgress = 0;

    for (int i = 0; i < sceneToLoad.Count; i++)
    {
      while (!sceneToLoad[i].isDone)
      {
        totalProgress += sceneToLoad[i].progress;
        loadingProgressBar.fillAmount = totalProgress / sceneToLoad.Count;
        yield return null;
      }
    }

  }

  // public void GameLogIn()
  // {
  //   AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Space");

  //   // Wait until the asynchronous scene fully loads
  //   while (!asyncLoad.isDone)
  //   {
  //     Debug.Log("Loading...");
  //     //  yield return null;
  //   }
  // }

}
