using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using RpgData;

public class StartGame : MonoBehaviour
{
  string backendUr = RpgData.WebHelpers.backendUrl;
  public Image loadingProgressBar;
  public GameObject home;
  public GameObject loadingInterface;



  List<AsyncOperation> sceneToLoad = new List<AsyncOperation>();


  public async void SignUp()
  {
    //var data =  StartCoroutine(WebHelpers.PostRequest("", ""));

    Player p = new Player("", "kiro@bg.com");
    Debug.Log(p.toJson());
    var data = await WebHelpers.PostRequestAsync(backendUr + "user", p.toJson());
    Debug.Log("data");
    Debug.Log(data);



    // StartNewGame();  
  }

  public void LogIn()
  {
    StartNewGame();
  }




  void StartNewGame()
  {
    //SocketIoController.InitializeConnection();
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



}

