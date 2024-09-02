// Decompiled with JetBrains decompiler
// Type: Unit00493Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit00493Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtDetaildescription;
  [SerializeField]
  protected UILabel TxtOwnednumber;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UILabel TxtDropQuestName;
  [SerializeField]
  protected UISprite IconEvolution;
  [SerializeField]
  protected UISprite IconUnification;
  [SerializeField]
  protected UISprite IconRevival;
  [SerializeField]
  private UI2DSprite mainSprite;
  [SerializeField]
  private GameObject newflagSprite;
  [SerializeField]
  private GameObject btnBG;

  [DebuggerHidden]
  public IEnumerator Init(UnitUnit MaterialEvolution, bool NewFlag, bool isGacha)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00493Menu.\u003CInit\u003Ec__Iterator390()
    {
      MaterialEvolution = MaterialEvolution,
      NewFlag = NewFlag,
      isGacha = isGacha,
      \u003C\u0024\u003EMaterialEvolution = MaterialEvolution,
      \u003C\u0024\u003ENewFlag = NewFlag,
      \u003C\u0024\u003EisGacha = isGacha,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
