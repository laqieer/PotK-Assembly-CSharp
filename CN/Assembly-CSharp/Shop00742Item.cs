// Decompiled with JetBrains decompiler
// Type: Shop00742Item
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00742Item : NGMenuBase
{
  [SerializeField]
  protected UILabel TxtAttack;
  [SerializeField]
  protected UILabel TxtCritical;
  [SerializeField]
  protected UILabel TxtDefense;
  [SerializeField]
  protected UILabel TxtDexterity;
  [SerializeField]
  protected UILabel TxtEvasion;
  [SerializeField]
  protected UILabel TxtFlavor;
  [SerializeField]
  protected UILabel TxtJobName;
  [SerializeField]
  protected UILabel TxtLeaderSkillname;
  [SerializeField]
  protected UILabel TxtMatk;
  [SerializeField]
  protected UILabel TxtMdef;
  [SerializeField]
  protected UILabel TxtMove;
  [SerializeField]
  protected UILabel TxtName;
  [SerializeField]
  protected UILabel TxtSkillexplanation;
  [SerializeField]
  protected UI2DSprite SlcTarget;
  [SerializeField]
  protected UI2DSprite rarityStarIcon;

  [DebuggerHidden]
  public IEnumerator Init(int entity_id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00742Item.\u003CInit\u003Ec__Iterator490()
    {
      entity_id = entity_id,
      \u003C\u0024\u003Eentity_id = entity_id,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnPopupClose()
  {
  }

  public virtual void IbtnPopupClose2()
  {
  }

  public virtual void IbtnPopupClose3()
  {
  }
}
