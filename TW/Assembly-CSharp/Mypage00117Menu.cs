// Decompiled with JetBrains decompiler
// Type: Mypage00117Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Mypage00117Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtPopuptitle;
  [SerializeField]
  protected UILabel TxtREADME;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private UITextList textList;
  private string text;

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public virtual void IbtnPopupOk() => Debug.Log((object) "click default event IbtnPopupOk");

  [DebuggerHidden]
  public IEnumerator InitSceneAsync(string text)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage00117Menu.\u003CInitSceneAsync\u003Ec__Iterator1BF()
    {
      text = text,
      \u003C\u0024\u003Etext = text,
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => this.IbtnBack();
}
