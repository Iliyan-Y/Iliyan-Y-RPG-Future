using SocketIOClient.Newtonsoft;

namespace RpgData
{
  public class Player
  {
    public string id { get; }
    public string email { get; }



    public Player(string id, string email)
    {
      this.id = id;
      this.email = email;
    }
    //add
    //second constructor from json

    public static Player fromJson(string json)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(json);
    }

    public string toJson()
    {

      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

  }
}