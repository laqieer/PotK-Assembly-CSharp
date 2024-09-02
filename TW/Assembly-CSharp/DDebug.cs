// Decompiled with JetBrains decompiler
// Type: DDebug
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using PLitJson;
using System;
using System.IO;
using UnityEngine;

#nullable disable
public class DDebug
{
  private const int csAll = 0;
  private const int csLog = 1;
  private const int csWarning = 2;
  private const int csError = 3;
  private const int csExcept = 4;
  private const int csPCVal = 0;
  private const string csDebugKey = "debuglev";
  private const string csFileName = "debugcon.json";
  private const string csTag = "91Dena:";
  public static DDebug gDenaDebug;
  private JsonData jd;
  private int debugLevel;

  public static DDebug getInstance()
  {
    if (DDebug.gDenaDebug == null)
    {
      DDebug.gDenaDebug = new DDebug();
      DDebug.gDenaDebug.initParam();
    }
    return DDebug.gDenaDebug;
  }

  public static void Log(string msg) => DDebug.getInstance().msgLog(msg);

  public static void LogWarning(string msg) => DDebug.getInstance().msgLogWarning(msg);

  public static void LogError(string msg) => DDebug.getInstance().msgLogError(msg);

  public static void LogErrorUpload(string msg) => DDebug.getInstance().msgLogErrorUpload(msg);

  public static void LogException(Exception ex) => DDebug.getInstance().msgLogException(ex);

  public void initParam()
  {
    this.debugLevel = 0;
    string empty = string.Empty;
    string path = "/sdcard/denapunk/debugcon.json";
    try
    {
      if (!File.Exists(path))
        return;
      StreamReader streamReader = new StreamReader(path);
      this.jd = JsonMapper.ToObject(streamReader.ReadToEnd());
      this.debugLevel = int.Parse(this.jd["debuglev"].ToString());
      streamReader.Close();
    }
    catch
    {
      ModalWindow.Show("提示", "DenaDebug加载失败", (System.Action) (() => { }));
    }
  }

  public void msgLog(string msg)
  {
    if (this.debugLevel >= 1)
      return;
    Debug.Log((object) ("91Dena:" + msg));
  }

  public void msgLogWarning(string msg)
  {
    if (this.debugLevel >= 2)
      return;
    Debug.LogWarning((object) ("91Dena:" + msg));
  }

  public void msgLogError(string msg)
  {
    if (this.debugLevel >= 3)
      return;
    Debug.LogError((object) ("91Dena:" + msg));
  }

  public void msgLogErrorUpload(string msg) => Debug.LogError((object) ("91Dena:" + msg));

  public void msgLogException(Exception ex)
  {
    if (this.debugLevel >= 4)
      return;
    Debug.LogException(ex);
  }
}
