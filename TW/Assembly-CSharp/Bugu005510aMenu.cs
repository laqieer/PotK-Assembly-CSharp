// Decompiled with JetBrains decompiler
// Type: Bugu005510aMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu005510aMenu : BackButtonMenuBase
{
  [SerializeField]
  private GameObject[] LinkBugu;
  [SerializeField]
  public UIButton yesButton;
  [SerializeField]
  private UILabel TxtDescription;
  [SerializeField]
  private UILabel TxtPopuptitle;

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void Show(PlayerItem[] playerItems)
  {
    this.StartCoroutine(this.SetSelectedItemIcons(playerItems));
  }

  [DebuggerHidden]
  private IEnumerator SetSelectedItemIcons(PlayerItem[] playerItems)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005510aMenu.\u003CSetSelectedItemIcons\u003Ec__Iterator3DB()
    {
      playerItems = playerItems,
      \u003C\u0024\u003EplayerItems = playerItems,
      \u003C\u003Ef__this = this
    };
  }
}
