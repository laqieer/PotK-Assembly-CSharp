// Decompiled with JetBrains decompiler
// Type: Shop00742Bugu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00742Bugu : MonoBehaviour
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
  [SerializeField]
  private UI2DSprite skillIcon;
  [SerializeField]
  private UI2DSprite weaponIcon;
  [SerializeField]
  private GameObject skillDescription;
  [SerializeField]
  private GameObject dirSpAttack;
  [SerializeField]
  private SPAtkTypeIcon WeaponSpAttack01;
  [SerializeField]
  private SPAtkTypeIcon WeaponSpAttack02;

  [DebuggerHidden]
  public IEnumerator Init(GearGear target)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00742Bugu.\u003CInit\u003Ec__Iterator48C()
    {
      target = target,
      \u003C\u0024\u003Etarget = target,
      \u003C\u003Ef__this = this
    };
  }

  protected void SetTitleText(GearGear gear)
  {
    ((Component) this.TxtName).gameObject.SetActive(true);
    this.TxtName.SetText(gear.name);
    if (gear.customize_flag != 1)
      return;
    this.TxtName.color = new Color(1f, 1f, 0.0f);
  }

  [DebuggerHidden]
  protected virtual IEnumerator BuguSpriteCreate(Future<Sprite> spriteF)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00742Bugu.\u003CBuguSpriteCreate\u003Ec__Iterator48D()
    {
      spriteF = spriteF,
      \u003C\u0024\u003EspriteF = spriteF,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected virtual IEnumerator RarityCreate(GearGear target)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00742Bugu.\u003CRarityCreate\u003Ec__Iterator48E()
    {
      target = target,
      \u003C\u0024\u003Etarget = target,
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
