// Decompiled with JetBrains decompiler
// Type: Unit004813Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit004813Scene : NGSceneBase
{
  [SerializeField]
  private Unit004813Menu menu;

  public static void changeScene(
    bool stack,
    PlayerUnit basePlayerUnit,
    PlayerUnit resultPlayerUnit,
    List<int> otherData,
    Dictionary<string, object> showPopupData)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_8_13", (stack ? 1 : 0) != 0, (object) basePlayerUnit, (object) resultPlayerUnit, (object) otherData, (object) showPopupData);
  }

  public static void changeScene(
    bool stack,
    PlayerUnit basePlayerUnit,
    PlayerUnit resultPlayerUnit,
    List<int> otherData,
    Dictionary<string, object> showPopupData,
    Unit00468Scene.Mode mode)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_8_13", (stack ? 1 : 0) != 0, (object) basePlayerUnit, (object) resultPlayerUnit, (object) otherData, (object) showPopupData, (object) mode);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004813Scene.\u003ConInitSceneAsync\u003Ec__Iterator2CB()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    PlayerUnit basePlayerUnit,
    PlayerUnit resultPlayerUnit,
    List<int> otherData,
    Dictionary<string, object> showPopupData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004813Scene.\u003ConStartSceneAsync\u003Ec__Iterator2CC()
    {
      showPopupData = showPopupData,
      basePlayerUnit = basePlayerUnit,
      resultPlayerUnit = resultPlayerUnit,
      otherData = otherData,
      \u003C\u0024\u003EshowPopupData = showPopupData,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EresultPlayerUnit = resultPlayerUnit,
      \u003C\u0024\u003EotherData = otherData,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    PlayerUnit basePlayerUnit,
    PlayerUnit resultPlayerUnit,
    List<int> otherData,
    Dictionary<string, object> showPopupData,
    Unit00468Scene.Mode mode)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004813Scene.\u003ConStartSceneAsync\u003Ec__Iterator2CD()
    {
      mode = mode,
      basePlayerUnit = basePlayerUnit,
      resultPlayerUnit = resultPlayerUnit,
      otherData = otherData,
      showPopupData = showPopupData,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EresultPlayerUnit = resultPlayerUnit,
      \u003C\u0024\u003EotherData = otherData,
      \u003C\u0024\u003EshowPopupData = showPopupData,
      \u003C\u003Ef__this = this
    };
  }
}
