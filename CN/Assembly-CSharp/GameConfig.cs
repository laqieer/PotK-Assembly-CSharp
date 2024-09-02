// Decompiled with JetBrains decompiler
// Type: GameConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using PLitJson;
using System.IO;

#nullable disable
public class GameConfig
{
  private const string csUserName = "UserName";
  private const string csTestPay = "IsTestPay";
  private const string csVerAddress = "VerAddress";
  private const string csIsChannel = "IsChannel";
  private const string csDLCVer_Value = "2016.03.11-06.32.34";
  private const string csApplicationVersion_Value = "2016.03.11-05.46.42";
  private const string csVersion = "3.0.0";
  public static GameConfig gGameConfig;
  private JsonData jd;
  private bool fIsChanelPackage;
  private string fSerVersion = string.Empty;
  private string fGameServer;
  private string fDLCServer;
  private string fAccountServer;
  private string fLuaServer;
  private bool fIsPCLogin;

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

  public static string GameServer => GameConfig.getInstance().getGameServer();

  public static string AccountServer => GameConfig.getInstance().getAccountServer();

  public static string LuaServer => GameConfig.getInstance().getLuaServer();

  public static string UserName => GameConfig.getInstance().getUserName();

  public static string dlc_version => GameConfig.getInstance().getDlc_version();

  public static string ApplicationVersion => GameConfig.getInstance().getApplicationVersion();

  public static bool IsTestPay => GameConfig.getInstance().IsTestPayValue();

  public static string getOtherValue(string key) => GameConfig.getInstance().getKeyValue(key);

  public static void setServerAddress(
    string pAccountSer,
    string pGameSer,
    string pDLCSer,
    string pLuaSer)
  {
    GameConfig.getInstance().setAllServer(pAccountSer, pGameSer, pDLCSer, pLuaSer);
  }

  public static string getClientVer => GameConfig.getInstance().getVerAddress();

  public static void setClientVer(string val) => GameConfig.getInstance().setVerAddress(val);

  public static bool IsChanelPackage => GameConfig.getInstance().IsChannelPkg();

  public static void setChanelPackage(bool val) => GameConfig.getInstance().SetIsChannelPkg(val);

  public static bool getIsPCLogin => GameConfig.getInstance().IsPCLogin();

  public void initParam()
  {
    this.fIsChanelPackage = true;
    this.fSerVersion = "3.0.0";
    this.fIsPCLogin = false;
    this.fGameServer = string.Empty;
    this.fDLCServer = string.Empty;
    this.fAccountServer = string.Empty;
    this.fLuaServer = string.Empty;
    string empty = string.Empty;
    string path = "/sdcard/denapunk/debugconfig.json";
    try
    {
      if (File.Exists(path))
      {
        DDebug.Log("find files:" + path);
        StreamReader streamReader = new StreamReader(path);
        this.jd = JsonMapper.ToObject(streamReader.ReadToEnd());
        streamReader.Close();
      }
      else
        DDebug.Log("no find files:" + path);
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

  public string getVerAddress()
  {
    DDebug.Log("verAddress:" + this.fSerVersion);
    return this.fSerVersion;
  }

  public void setVerAddress(string value) => this.fSerVersion = value;

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

  public string getDlc_version() => "2016.03.11-06.32.34";

  public string getApplicationVersion() => "2016.03.11-05.46.42";

  public bool IsChannelPkg() => this.fIsChanelPackage;

  public void SetIsChannelPkg(bool val) => this.fIsChanelPackage = val;

  public bool IsPCLogin() => this.fIsPCLogin;

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
