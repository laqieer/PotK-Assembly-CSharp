// Decompiled with JetBrains decompiler
// Type: Friend0088Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Friend0088Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtMessage;
  private System.Action callback;

  public virtual void IbtnOk()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    if (this.callback == null)
      return;
    this.callback();
  }

  public void SetMessage(string txt = null)
  {
    if (txt == null)
      return;
    this.txtMessage.SetTextLocalize(txt);
  }

  public void InitPopup(string txt = null, System.Action callback = null)
  {
    this.txtMessage.SetTextLocalize(txt);
    this.callback = callback;
  }

  public override void onBackButton() => this.IbtnOk();
}
