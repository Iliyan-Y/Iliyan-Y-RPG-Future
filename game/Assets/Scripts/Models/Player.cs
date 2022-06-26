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


    public string toJson()
    {

      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

  }
}