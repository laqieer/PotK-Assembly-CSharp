// Decompiled with JetBrains decompiler
// Type: GuildYesNoPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GuildYesNoPopup : BackButtonMenuBase
{
  private System.Action yesCallback;
  private System.Action noCallback;
  [SerializeField]
  private UILabel popupTitle;
  [SerializeField]
  private UILabel desc1;
  [SerializeField]
  private UILabel desc2;
  [SerializeField]
  private UISprite slc_Popupbox;

  public void Initialize(string title, string message, Vector2 size, System.Action yes = null, System.Action no = null)
  {
    if (Object.op_Inequality((Object) ((Component) this).GetComponent<UIWidget>(), (Object) null))
      ((Component) this).GetComponent<UIWidget>().alpha = 0.0f;
    this.popupTitle.SetTextLocalize(title);
    this.desc1.SetTextLocalize(message);
    this.yesCallback = yes;
    this.noCallback = no;
    ((Component) this.desc2).gameObject.SetActive(false);
    this.slc_Popupbox.SetDimensions((int) size.x, (int) size.y);
  }

  public void onYesButton()
  {
    if (this.yesCallback == null)
      return;
    this.yesCallback();
  }

  public override void onBackButton()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    if (this.noCallback == null)
      return;
    this.noCallback();
  }
}
