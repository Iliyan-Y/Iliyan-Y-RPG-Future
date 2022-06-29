using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System.Threading.Tasks;



namespace RpgData
{
  public class WebHelpers
  {
    public static string backendUrl = "http://localhost:3000/";
    public static IEnumerator PostRequest(string url, string bodyJsonString)
    {
      var request = new UnityWebRequest("http://localhost:3000/user", "POST");
      byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
      request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
      request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
      request.SetRequestHeader("Content-Type", "application/json");
      yield return request.SendWebRequest();
      Debug.Log("Status Code: " + request.responseCode);

    }



    public static async Task<string> PostRequestAsync(string url, string bodyJsonString)
    {

      using (UnityWebRequest www = UnityWebRequest.Post(url, bodyJsonString))
      {
        UnityWebRequestAsyncOperation operation = www.SendWebRequest();
        while (!operation.isDone)
          await Task.Yield();

        var data = www.downloadHandler.text; //You can process text - bytes - etc...

        if (www.responseCode == 200)
        {
          Debug.Log("Player created");
          return data;
        }
        else
        {
          Debug.Log("Error creating new player");
          Debug.Log(data);
          return "";
        }

      }
    }
  }


}