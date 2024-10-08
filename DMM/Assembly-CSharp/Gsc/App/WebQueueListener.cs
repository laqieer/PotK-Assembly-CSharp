﻿// Decompiled with JetBrains decompiler
// Type: Gsc.App.WebQueueListener
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using Gsc.App.NetworkHelper;
using Gsc.Core;
using Gsc.Network;
using UnityEngine;

namespace Gsc.App
{
  public class WebQueueListener : IWebQueueObserver
  {
    public void OnStart()
    {
      if (!((Object) Singleton<CommonRoot>.GetInstanceOrNull() != (Object) null))
        return;
      Singleton<CommonRoot>.GetInstance().isWebRunning = true;
    }

    public void OnFinish()
    {
      if (!((Object) Singleton<CommonRoot>.GetInstanceOrNull() != (Object) null))
        return;
      Singleton<CommonRoot>.GetInstance().isWebRunning = false;
    }

    public void OnAuthFailed(WebTaskResult result) => ImmortalObject.Instance.StartCoroutine(GsccBridge.OnFailed(result, (IWebTask) null));

    public void OnResults(WebTaskBundle taskBundle)
    {
      foreach (IWebTask task in taskBundle)
        ImmortalObject.Instance.StartCoroutine(GsccBridge.OnFailed(task.Result, task));
    }
  }
}
