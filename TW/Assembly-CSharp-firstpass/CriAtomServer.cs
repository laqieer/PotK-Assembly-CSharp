// Decompiled with JetBrains decompiler
// Type: CriAtomServer
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

#nullable disable
public class CriAtomServer : MonoBehaviour
{
  private static CriAtomServer _instance;
  private int pauseCallCount;
  private int onApplicationPauseCallCount;
  public Action<bool> onApplicationPausePreProcess;
  public Action<bool> onApplicationPausePostProcess;

  public static CriAtomServer instance
  {
    get
    {
      CriAtomServer.CreateInstance();
      return CriAtomServer._instance;
    }
  }

  public static void CreateInstance()
  {
    if (!Object.op_Equality((Object) CriAtomServer._instance, (Object) null))
      return;
    CriWare.managerObject.AddComponent<CriAtomServer>();
  }

  public static void DestroyInstance()
  {
    if (!Object.op_Inequality((Object) CriAtomServer._instance, (Object) null))
      return;
    Object.Destroy((Object) CriAtomServer._instance);
  }

  private void Awake()
  {
    if (Object.op_Equality((Object) CriAtomServer._instance, (Object) null))
      CriAtomServer._instance = this;
    else
      Object.Destroy((Object) this);
  }

  private void OnEnable()
  {
  }

  private void OnDisable()
  {
    if (!Object.op_Equality((Object) CriAtomServer._instance, (Object) this))
      return;
    CriAtomServer._instance = (CriAtomServer) null;
  }

  private bool CheckPauseCount(ref int currentCount, bool pause)
  {
    currentCount = !pause ? currentCount - 1 : currentCount + 1;
    if (pause && currentCount > 1)
      return false;
    if (pause || currentCount == 0)
      return true;
    currentCount = currentCount <= 0 ? 0 : currentCount;
    return false;
  }

  private void OnApplicationPause(bool appPause)
  {
    if (!this.CheckPauseCount(ref this.onApplicationPauseCallCount, appPause))
      return;
    this.ProcessApplicationPause(appPause);
  }

  private void ProcessApplicationPause(bool appPause)
  {
    if (!this.CheckPauseCount(ref this.pauseCallCount, appPause))
      return;
    if (this.onApplicationPausePreProcess != null)
      this.onApplicationPausePreProcess(appPause);
    CriAtomPlugin.Pause(appPause);
    if (this.onApplicationPausePostProcess == null)
      return;
    this.onApplicationPausePostProcess(appPause);
  }
}
