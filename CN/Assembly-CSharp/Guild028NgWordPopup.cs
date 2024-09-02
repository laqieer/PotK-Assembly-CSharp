// Decompiled with JetBrains decompiler
// Type: Guild028NgWordPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Guild028NgWordPopup : BackButtonMenuBase
{
  private System.Action callback;
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtDesc;

  public void Initialize(System.Action ok = null)
  {
    if (Object.op_Inequality((Object) ((Component) this).GetComponent<UIWidget>(), (Object) null))
      ((Component) this).GetComponent<UIWidget>().alpha = 0.0f;
    this.txtTitle.SetTextLocalize(Consts.GetInstance().GUILD_COMMON_NG_WORD_TITLE);
    this.txtDesc.SetTextLocalize(Consts.GetInstance().GUILD_COMMON_NG_WORD);
    this.callback = ok;
  }

  public override void onBackButton()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    if (this.callback == null)
      return;
    this.callback();
  }
}
