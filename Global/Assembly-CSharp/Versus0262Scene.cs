// Decompiled with JetBrains decompiler
// Type: Versus0262Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus0262Scene : NGSceneBase
{
  [SerializeField]
  private Versus0262Menu menu;
  private static bool is_loading_draw;
  private WebAPI.Response.PvpBoot pvpInfo;

  public static void ChangeScene0262(bool stack, PvpMatchingTypeEnum type, bool loading_draw = false)
  {
    Versus0262Scene.is_loading_draw = loading_draw;
    Singleton<NGSceneManager>.GetInstance().changeScene("versus026_2", (stack ? 1 : 0) != 0, (object) type);
  }

  public static void ChangeScene0262(
    bool stack,
    PvpMatchingTypeEnum type,
    WebAPI.Response.PvpBoot pvpInfo)
  {
    Versus0262Scene.is_loading_draw = false;
    Singleton<NGSceneManager>.GetInstance().changeScene("versus026_2", (stack ? 1 : 0) != 0, (object) type, (object) pvpInfo);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0262Scene.\u003ConInitSceneAsync\u003Ec__Iterator599()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PvpMatchingTypeEnum type)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0262Scene.\u003ConStartSceneAsync\u003Ec__Iterator59A()
    {
      type = type,
      \u003C\u0024\u003Etype = type,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PvpMatchingTypeEnum type, WebAPI.Response.PvpBoot pvpInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0262Scene.\u003ConStartSceneAsync\u003Ec__Iterator59B()
    {
      type = type,
      pvpInfo = pvpInfo,
      \u003C\u0024\u003Etype = type,
      \u003C\u0024\u003EpvpInfo = pvpInfo,
      \u003C\u003Ef__this = this
    };
  }
}
