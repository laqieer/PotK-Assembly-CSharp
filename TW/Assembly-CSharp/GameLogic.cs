// Decompiled with JetBrains decompiler
// Type: GameLogic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using DenaLib;
using System.IO;
using UnityEngine;

#nullable disable
public class GameLogic : DenaLib.Singleton<GameLogic>, IGameLogic
{
  public EGameState m_GameState;
  private HotUpdate m_HotUpdate;
  private LuaManager m_LuaManager;
  private CallbackCenter m_CallbackCenter;
  private HFResourceManager m_ResourceManager;
  private WindowStackManager m_WindowStackManager;
  private Utlity m_Utlity;
  public int m_iTouchTimes;
  public string strLuaVersion = "0101";

  public GameLogic()
  {
    this.m_HotUpdate = new HotUpdate();
    this.m_CallbackCenter = new CallbackCenter();
    this.m_ResourceManager = new HFResourceManager();
    this.m_WindowStackManager = new WindowStackManager();
    this.m_LuaManager = new LuaManager(this.m_ResourceManager);
    this.m_Utlity = new Utlity();
  }

  public EGameState GameState => this.m_GameState;

  public CallbackCenter GetCallbackCenter() => this.m_CallbackCenter;

  public HFResourceManager GetResourceManager() => this.m_ResourceManager;

  public LuaManager GetLuaManager() => this.m_LuaManager;

  public WindowStackManager GetWindowStackManager() => this.m_WindowStackManager;

  public void Init()
  {
    this.m_iTouchTimes = 0;
    PathManager.Init();
    this.m_HotUpdate.AddRemoteServer(GameConfig.LuaServer);
    this.m_HotUpdate.OnDownloadFinish += new UpdateManager.DownloadFinishEvent(this.OnEndUpdate);
    this.m_CallbackCenter.InitCallbackList(8);
  }

  public void Update()
  {
    if (this.m_GameState == EGameState.ERunGame)
      return;
    if (this.m_ResourceManager != null)
      this.m_ResourceManager.Update();
    if (this.m_GameState != EGameState.EMobageLogin)
      ;
    if (this.m_GameState == EGameState.EHotUpdate && this.m_HotUpdate != null)
    {
      this.m_HotUpdate.Update();
      this.m_CallbackCenter.Call(4, (object) this.m_HotUpdate.GetUpdateProgress());
      this.m_HotUpdate.PostUpdate();
    }
    if (this.m_GameState == EGameState.EHotFixInit)
    {
      string luaDir = this.m_HotUpdate.GetLuaDir();
      DirectoryInfo directoryInfo = new DirectoryInfo(luaDir);
      if (directoryInfo.Exists)
      {
        foreach (FileSystemInfo file in directoryInfo.GetFiles("*.*", SearchOption.AllDirectories))
          this.m_LuaManager.LoadPackLua(file.FullName);
      }
      else
        Debug.LogError((object) (luaDir + "not exists."));
      this.m_GameState = EGameState.ESelectServer;
    }
    if (this.m_GameState == EGameState.ESelectServer)
      this.m_GameState = EGameState.EStartGame;
    if (this.m_GameState != EGameState.EStartGame)
      return;
    this.m_CallbackCenter.Call(7);
    this.m_GameState = EGameState.ERunGame;
  }

  public void Login(string username, string password)
  {
    this.m_GameState = EGameState.EHotUpdate;
    this.OnBeginUpdate();
  }

  private void OnLoginSuccess()
  {
  }

  private void OnLoginFail() => this.m_CallbackCenter.Call(1);

  private void OnBeginUpdate()
  {
    if (this.m_HotUpdate == null)
      return;
    this.m_CallbackCenter.Call(0);
    this.m_CallbackCenter.Call(2);
    this.m_HotUpdate.SetVersion(1);
    this.m_HotUpdate.CheckUpdate();
    this.m_GameState = EGameState.EHotUpdate;
  }

  private void OnEndUpdate(bool success)
  {
    this.m_CallbackCenter.Call(3);
    this.m_GameState = EGameState.EHotFixInit;
  }
}
