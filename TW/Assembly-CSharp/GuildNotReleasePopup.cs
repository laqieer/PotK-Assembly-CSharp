// Decompiled with JetBrains decompiler
// Type: GuildNotReleasePopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class GuildNotReleasePopup : BackButtonMenuBase
{
  [SerializeField]
  private UILabel lblTitle;
  [SerializeField]
  private UILabel lblDesc;

  public void Initialize()
  {
    if (Object.op_Inequality((Object) ((Component) this).GetComponent<UIWidget>(), (Object) null))
      ((Component) this).GetComponent<UIWidget>().alpha = 0.0f;
    this.lblTitle.SetTextLocalize(Consts.Format(Consts.GetInstance().GUILD_COMING_SOON_TITLE));
    this.lblDesc.SetTextLocalize(Consts.Format(Consts.GetInstance().GUILD_COMING_SOON_DESC));
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();
}
