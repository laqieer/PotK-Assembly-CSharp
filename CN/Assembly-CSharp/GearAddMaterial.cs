﻿// Decompiled with JetBrains decompiler
// Type: GearAddMaterial
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GearAddMaterial : MonoBehaviour
{
  [SerializeField]
  private GameObject materialAddImg;
  [SerializeField]
  private GameObject rateBaseImg;
  [SerializeField]
  private UILabel lblAddStatus;
  [SerializeField]
  private UILabel lblAddPercent;
  private ItemIcon itemIcon;

  public void Init()
  {
    this.materialAddImg.SetActive(true);
    this.rateBaseImg.SetActive(false);
    if (Object.op_Equality((Object) this.itemIcon, (Object) null))
      return;
    Object.Destroy((Object) ((Component) this.itemIcon).gameObject);
    this.itemIcon = (ItemIcon) null;
  }

  [DebuggerHidden]
  public IEnumerator Set(PlayerItem baseGear, PlayerItem materialGear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GearAddMaterial.\u003CSet\u003Ec__Iterator3C7()
    {
      materialGear = materialGear,
      baseGear = baseGear,
      \u003C\u0024\u003EmaterialGear = materialGear,
      \u003C\u0024\u003EbaseGear = baseGear,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateIcon(PlayerItem gear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GearAddMaterial.\u003CCreateIcon\u003Ec__Iterator3C8()
    {
      gear = gear,
      \u003C\u0024\u003Egear = gear,
      \u003C\u003Ef__this = this
    };
  }
}
