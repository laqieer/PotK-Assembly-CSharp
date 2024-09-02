// Decompiled with JetBrains decompiler
// Type: Activity00418DetailPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Activity00418DetailPopup : BackButtonMonoBehaiviour
{
  [SerializeField]
  private UILabel titleLabel;
  [SerializeField]
  private UILabel detailLabel;
  [SerializeField]
  private UISprite pic;

  [DebuggerHidden]
  public IEnumerator Init(string title, string detail, string picName)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Activity00418DetailPopup.\u003CInit\u003Ec__Iterator295()
    {
      title = title,
      detail = detail,
      picName = picName,
      \u003C\u0024\u003Etitle = title,
      \u003C\u0024\u003Edetail = detail,
      \u003C\u0024\u003EpicName = picName,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();
}
