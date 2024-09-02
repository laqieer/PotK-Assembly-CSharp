// Decompiled with JetBrains decompiler
// Type: Quest002152popup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Quest002152popup : BackButtonMenuBase
{
  [SerializeField]
  private UI2DSprite LeftChara;
  [SerializeField]
  private UI2DSprite RightChara;
  [SerializeField]
  private UILabel TxtDescription;
  [SerializeField]
  private UILabel TxtLiberation;
  public int lvv;

  public void PopupSetiing()
  {
    this.TxtDescription.SetTextLocalize(Consts.GetInstance().quest_002152_text + "[ffff00]" + Consts.GetInstance().close + "Lv" + this.lvv.ToString() + "[-]" + Consts.GetInstance().OVER);
    this.TxtLiberation.SetTextLocalize(Consts.GetInstance().episode_unlock_conditions);
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
