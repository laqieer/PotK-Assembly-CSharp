// Decompiled with JetBrains decompiler
// Type: Friend008161Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend008161Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtDescription;

  [DebuggerHidden]
  public IEnumerator Init(string title = "", string description = "")
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend008161Menu.\u003CInit\u003Ec__Iterator4C3()
    {
      title = title,
      description = description,
      \u003C\u0024\u003Etitle = title,
      \u003C\u0024\u003Edescription = description,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnOk()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public void IbtnNo() => this.IbtnOk();

  public override void onBackButton() => this.IbtnNo();
}
