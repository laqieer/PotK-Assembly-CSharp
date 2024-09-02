﻿// Decompiled with JetBrains decompiler
// Type: BattlePvpFinalize
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattlePvpFinalize : BattleMonoBehaviour
{
  private PVPManager _pvpManager;

  private PVPManager pvpManager
  {
    get
    {
      if (Object.op_Equality((Object) this._pvpManager, (Object) null))
        this._pvpManager = Singleton<PVPManager>.GetInstance();
      return this._pvpManager;
    }
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattlePvpFinalize.\u003CStart_Battle\u003Ec__Iterator9DA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ForceClose()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BattlePvpFinalize.\u003CForceClose\u003Ec__Iterator9DB closeCIterator9Db = new BattlePvpFinalize.\u003CForceClose\u003Ec__Iterator9DB();
    return (IEnumerator) closeCIterator9Db;
  }

  private void errorCallback(WebAPI.Response.UserError error)
  {
    Singleton<NGSceneManager>.GetInstance().StartCoroutine(PopupCommon.Show(error.Code, error.Reason, (System.Action) (() =>
    {
      NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
      instance.clearStack();
      instance.destroyCurrentScene();
      instance.changeScene(Singleton<CommonRoot>.GetInstance().startScene);
    })));
  }
}
