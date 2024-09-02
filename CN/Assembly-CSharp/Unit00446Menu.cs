// Decompiled with JetBrains decompiler
// Type: Unit00446Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit00446Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtBattleTitle;
  public UI2DSprite GearSpriteObject;
  public UI2DSprite rarityStars;
  public UILabel TxtTitle;

  [DebuggerHidden]
  public IEnumerator SetSprite(GearGear targetgear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00446Menu.\u003CSetSprite\u003Ec__Iterator2DD()
    {
      targetgear = targetgear,
      \u003C\u0024\u003Etargetgear = targetgear,
      \u003C\u003Ef__this = this
    };
  }

  public void changeScene()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public virtual void IbtnBattleBack()
  {
  }

  public override void onBackButton() => this.changeScene();
}
