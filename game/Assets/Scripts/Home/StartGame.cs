using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using RpgData;
using TMPro;

public class StartGame : MonoBehaviour
{

  public Image loadingProgressBar;
  public GameObject home;
  public GameObject loadingInterface;


  // private variables
  TMP_InputField userName;
  string backendUr = RpgData.WebHelpers.backendUrl;
  List<AsyncOperation> sceneToLoad = new List<AsyncOperation>();

  void Start()
  {
    userName = GameObject.Find("UserNameInput").GetComponent<TMP_InputField>();
  }


  public async void SignUp()
  {
    //var data =  StartCoroutine(WebHelpers.PostRequest("", ""));
    Player p = new Player("", userName.text);
    string data = await WebHelpers.PostRequestAsync(backendUr + "user", p.toJson());
    if (data == "") return;

    CurrentState.player = Player.fromJson(data);
    StartNewGame();
  }

  public void LogIn()
  {
    StartNewGame();
  }


  void StartNewGame()
  {
    SocketIoController.InitializeConnection();
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

