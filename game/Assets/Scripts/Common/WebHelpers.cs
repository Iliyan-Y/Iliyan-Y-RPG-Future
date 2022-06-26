using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;


namespace RpgData
{
  public class WebHelpers
  {
    public static IEnumerator PostRequest(string url, string bodyJsonString)
    {
      var request = new UnityWebRequest(url, "POST");
      byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
      request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
      request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
      request.SetRequestHeader("Content-Type", "application/json");
      yield return request.SendWebRequest();
      Debug.Log("Status Code: " + request.responseCode);
    }
  }
}