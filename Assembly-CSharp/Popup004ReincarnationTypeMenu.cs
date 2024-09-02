// Decompiled with JetBrains decompiler
// Type: Popup004ReincarnationTypeMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Popup004ReincarnationTypeMenu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel TxtHimeTypeLeft;
  [SerializeField]
  private UILabel TxtHimeTypeRight;
  private System.Action onDecide;

  public void Init(string unitTypeTextBefore, string unitTypeTextAfter, System.Action onDecide)
  {
    this.onDecide = onDecide;
    this.TxtHimeTypeLeft.SetTextLocalize(unitTypeTextBefore);
    this.TxtHimeTypeRight.SetTextLocalize(unitTypeTextAfter);
  }

  public void IbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    if (this.onDecide == null)
      return;
    this.onDecide();
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
