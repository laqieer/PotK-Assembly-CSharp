// Decompiled with JetBrains decompiler
// Type: GuildOkPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GuildOkPopup : BackButtonMenuBase
{
  private const int CommonDlgSizeX = 532;
  private const int CommonDlgSizeY = 345;
  private System.Action okCallback;
  [SerializeField]
  private UILabel popupTitle;
  [SerializeField]
  private UILabel desc;
  [SerializeField]
  private UISprite slc_Popupbox;

  public void Initialize(string title, string message, Vector2? size = null, System.Action ok = null)
  {
    if (Object.op_Inequality((Object) ((Component) this).GetComponent<UIWidget>(), (Object) null))
      ((Component) this).GetComponent<UIWidget>().alpha = 0.0f;
    this.popupTitle.SetTextLocalize(title);
    this.desc.SetTextLocalize(message);
    this.okCallback = ok;
    this.slc_Popupbox.SetDimensions(!size.HasValue ? 532 : (int) size.Value.x, !size.HasValue ? 345 : (int) size.Value.y);
  }

  public override void onBackButton()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    if (this.okCallback == null)
      return;
    this.okCallback();
  }
}
