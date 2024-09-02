// Decompiled with JetBrains decompiler
// Type: Popup00631Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup00631Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScrollMasonry Scroll;

  [DebuggerHidden]
  public IEnumerator InitGachaDetail(string title, GachaDescriptionBodies[] bodys)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup00631Menu.\u003CInitGachaDetail\u003Ec__Iterator9FF()
    {
      title = title,
      bodys = bodys,
      \u003C\u0024\u003Etitle = title,
      \u003C\u0024\u003Ebodys = bodys,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    DetailController.Release();
  }

  public override void onBackButton() => this.IbtnNo();
}
