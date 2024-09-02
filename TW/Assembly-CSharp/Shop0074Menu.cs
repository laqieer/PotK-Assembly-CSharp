// Decompiled with JetBrains decompiler
// Type: Shop0074Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop0074Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtOwnnumber;
  [SerializeField]
  protected UILabel TxtTitle30;
  public Modified<Shop[]> shopModify;
  public NGxScroll scroll;
  public GameObject detailPopupF;
  private List<Shop0074Scroll> products;

  public Player _player { get; set; }

  [DebuggerHidden]
  public IEnumerator Init(Player player, bool isUpdate = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0074Menu.\u003CInit\u003Ec__Iterator4D0()
    {
      player = player,
      isUpdate = isUpdate,
      \u003C\u0024\u003Eplayer = player,
      \u003C\u0024\u003EisUpdate = isUpdate,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator updateScroll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0074Menu.\u003CupdateScroll\u003Ec__Iterator4D1()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void updateText(string money) => this.TxtOwnnumber.SetTextLocalize(money);

  [DebuggerHidden]
  private IEnumerator DetailPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0074Menu.\u003CDetailPopup\u003Ec__Iterator4D2()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void Foreground()
  {
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void VScrollBar()
  {
  }
}
