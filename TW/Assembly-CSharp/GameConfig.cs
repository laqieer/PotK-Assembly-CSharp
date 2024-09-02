// Decompiled with JetBrains decompiler
// Type: GameConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using PLitJson;
using System.IO;

#nullable disable
public class GameConfig
{
  private const string csDLCServer = "DLCServer";
  private const string csDLCPath = "DLCPath";
  private const string csGameServer = "GameServer";
  private const string csAccountServer = "AccountServer";
  private const string csUserName = "UserName";
  private const string csDLCVer = "DLCVer";
  private const string csApplicationVersion = "ApplicationVersion";
  private const string csMobageProduct = "IsProduction";
  private const string csTestPay = "IsTestPay";
  private const string csDLCVer_Value = "2017.02.28-03.55.02";
  private const string csApplicationVersion_Value = "2016.03.11-05.46.42";
  private const string csVersion = "4.0.0";
  public static GameConfig gGameConfig;
  private JsonData jd;
  public bool hasSerAdd;
  private string fGameServer;
  private string fDLCServer;
  private string fAccountServer;
  private string fLuaServer;

  public static GameConfig getInstance()
  {
    if (GameConfig.gGameConfig == null)
    {
      GameConfig.gGameConfig = new GameConfig();
      GameConfig.gGameConfig.initParam();
    }
    return GameConfig.gGameConfig;
  }

  public static string DLCServer => GameConfig.getInstance().getDLCServer();

  public static string DLCPath => GameConfig.getInstance().getDLCPath();

  public static string GameServer => GameConfig.getInstance().getGameServer();

  public static string AccountServer => GameConfig.getInstance().getAccountServer();

  public static string LuaServer => GameConfig.getInstance().getLuaServer();

  public static string UserName => GameConfig.getInstance().getUserName();

  public static string dlc_version => GameConfig.getInstance().getDlc_version();

  public static string ApplicationVersion => GameConfig.getInstance().getApplicationVersion();

  public static bool IsProduction => GameConfig.getInstance().IsMobageProduction();

  public static bool IsTestPay => GameConfig.getInstance().IsTestPayValue();

  public static string getOtherValue(string key) => GameConfig.getInstance().getKeyValue(key);

  public static bool IsHasServerAddress => GameConfig.getInstance().hasSerAdd;

  public static void setServerAddress(
    string pAccountSer,
    string pGameSer,
    string pDLCSer,
    string pLuaSer)
  {
    GameConfig.getInstance().setAllServer(pAccountSer, pGameSer, pDLCSer, pLuaSer);
  }

  public static string Client_Version => "4.0.0";

  public void initParam()
  {
    this.hasSerAdd = false;
    this.fGameServer = string.Empty;
    this.fDLCServer = string.Empty;
    this.fAccountServer = string.Empty;
    this.fLuaServer = string.Empty;
    string empty = string.Empty;
    string path = "/sdcard/denapunk/config.json";
    try
    {
      if (File.Exists(path))
      {
        StreamReader streamReader = new StreamReader(path);
        this.jd = JsonMapper.ToObject(streamReader.ReadToEnd());
        streamReader.Close();
      }
    }
    catch
    {
      this.jd = (JsonData) null;
      ModalWindow.Show(Consts.GetInstance().prompt, Consts.GetInstance().gameconfig_load_failure, (System.Action) (() => { }));
    }
    this.initDefine();
  }

  private void initDefine()
  {
  }

  public string getDLCServer()
  {
    string empty = string.Empty;
    return this.fDLCServer;
  }

  public string getDLCPath()
  {
    string empty = string.Empty;
    string dlcPath = GameConfig.getInstance().getKeyValue("DLCPath");
    if (dlcPath == string.Empty)
      dlcPath = string.Empty;
    return dlcPath;
  }

  public string getGameServer()
  {
    string empty = string.Empty;
    return this.fGameServer;
  }

  public string getAccountServer()
  {
    string empty = string.Empty;
    return this.fAccountServer;
  }

  public string getLuaServer() => this.fLuaServer;

  public void setAllServer(string pAccountSer, string pGameSer, string pDLCSer, string pLuaSer)
  {
    this.fAccountServer = pAccountSer;
    this.fGameServer = pGameSer;
    this.fDLCServer = pDLCSer;
    this.fLuaServer = pLuaSer;
  }

  public string getUserName()
  {
    string keyValue = GameConfig.getInstance().getKeyValue("UserName");
    if (!(keyValue == string.Empty))
      ;
    return keyValue;
  }

  public string getDlc_version()
  {
    string dlcVersion = GameConfig.getInstance().getKeyValue("DLCVer");
    if (dlcVersion == string.Empty)
      dlcVersion = "2017.02.28-03.55.02";
    return dlcVersion;
  }

  public string getApplicationVersion()
  {
    string applicationVersion = GameConfig.getInstance().getKeyValue("ApplicationVersion");
    if (applicationVersion == string.Empty)
      applicationVersion = "2016.03.11-05.46.42";
    return applicationVersion;
  }

  public bool IsMobageProduction() => this.IsKeyValue("IsProduction", true);

  public bool IsTestPayValue() => this.IsKeyValue("IsTestPay", false);

  private bool IsKeyValue(string key, bool def)
  {
    bool flag = def;
    switch (GameConfig.getInstance().getKeyValue(key))
    {
      case "0":
        flag = false;
        break;
      case "1":
        flag = true;
        break;
    }
    return flag;
  }

  private string getKeyValue(string key)
  {
    string empty = string.Empty;
    try
    {
      if (this.jd != null)
        empty = this.jd[key].ToString();
    }
    catch
    {
    }
    return empty;
  }
}
