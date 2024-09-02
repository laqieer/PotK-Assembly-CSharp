// Decompiled with JetBrains decompiler
// Type: Unit00493Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  public GameObject newflagSprite;

  [DebuggerHidden]
  public IEnumerator Init(UnitUnit MaterialEvolution, bool NewFlag)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00493Menu.\u003CInit\u003Ec__Iterator2E3()
    {
      MaterialEvolution = MaterialEvolution,
      NewFlag = NewFlag,
      \u003C\u0024\u003EMaterialEvolution = MaterialEvolution,
      \u003C\u0024\u003ENewFlag = NewFlag,
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
