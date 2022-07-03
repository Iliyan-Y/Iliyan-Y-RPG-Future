using System;
using System.Collections.Generic;
using SocketIOClient;
using SocketIOClient.Newtonsoft.Json;
using UnityEngine;


namespace RpgData
{
  public class SocketIoController
  {
    public static SocketIOUnity socket { get; set; }

    public static void InitializeConnection()
    {

      var uri = new Uri("http://localhost:3000/");

      socket = new SocketIOUnity(uri, new SocketIOOptions
      {
        Query = new Dictionary<string, string>
                {
                    {"token", "UNITY" }
                }
                 ,
        EIO = 4
                 ,
        Transport = SocketIOClient.Transport.TransportProtocol.WebSocket
      });
      socket.JsonSerializer = new NewtonsoftJsonSerializer();

      // not mutable ! 
      socket.OnConnected += (sender, e) =>
         {
           socket.Emit("hello", "TEXT FROM CLIENT");
           Debug.Log("socket.OnConnected");
         };
      socket.OnPing += (sender, e) =>
      {
        Debug.Log("Ping");
      };
      socket.OnPong += (sender, e) =>
      {
        Debug.Log("Pong: " + e.TotalMilliseconds);
      };
      socket.OnDisconnected += (sender, e) =>
      {
        Debug.Log("disconnect: " + e);
      };
      socket.OnReconnectAttempt += (sender, e) =>
      {
        Debug.Log($"{DateTime.Now} Reconnecting: attempt = {e}");
      };
      Debug.Log("Connecting...");
      socket.Connect();

    }

    //  public void EmitTest()
    // {
    //     string eventName = EventNameTxt.text.Trim().Length < 1 ? "hello" : EventNameTxt.text;
    //     string txt = DataTxt.text;
    //     if (!IsJSON(txt))
    //     {
    //         socket.Emit(eventName, txt);
    //     }
    //     else
    //     {
    //         socket.EmitStringAsJSON(eventName, txt);
    //     }
    // }

    // Update is called once per frame
    public static void Test()
    {

      if (Input.GetKeyDown(KeyCode.W))
      {
        socket.Emit("hello", "TEXT FROM CLIENT by W");
      }
    }

  }
}