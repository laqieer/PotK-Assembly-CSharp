// Decompiled with JetBrains decompiler
// Type: Transfer01272Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using UnityEngine;

#nullable disable
public class Transfer01272Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtID;
  [SerializeField]
  protected UIInput InputPassword;
  [SerializeField]
  protected UILabel TxtDescription;
  [SerializeField]
  protected UIButton BtnDecide;

  public void InitTransfer()
  {
    this.TxtID.SetTextLocalize(SMManager.Get<Player>().short_id);
    this.TxtDescription.SetTextLocalize(Consts.GetInstance().TRANSFER01271_DESCRIPTION);
    this.BtnDecide.isEnabled = false;
  }

  public void OnChange()
  {
    if (!this.BtnDecide.isEnabled && this.InputPassword.value.Length >= 8)
    {
      this.BtnDecide.isEnabled = true;
    }
    else
    {
      if (!this.BtnDecide.isEnabled || this.InputPassword.value.Length >= 8)
        return;
      this.BtnDecide.isEnabled = false;
    }
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public void IbtnCopy()
  {
    if (this.IsPushAndSet())
      return;
    Clipboard.setText(SMManager.Get<Player>().short_id.ToString());
    Consts instance = Consts.GetInstance();
    ModalWindow.Show(instance.USERCODE_COPY_TITLE, instance.USERCODE_COPY, (System.Action) (() => this.IsPush = false));
  }
}
