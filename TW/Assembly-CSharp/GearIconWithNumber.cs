﻿// Decompiled with JetBrains decompiler
// Type: GearIconWithNumber
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GearIconWithNumber : MonoBehaviour
{
  public GameObject gearIconPrefab;
  public GameObject gearIconParent;
  public UILabel numberLabel;
  private ItemIcon itemIcon;
  private GearGear gearData;

  public ItemIcon ItemIcon => this.itemIcon;

  private void onClickButton()
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("guide011_4_1", true, (object) this.gearData);
  }

  [DebuggerHidden]
  public IEnumerator SetGear(GearGear gear, bool contains)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GearIconWithNumber.\u003CSetGear\u003Ec__IteratorB7F()
    {
      gear = gear,
      contains = contains,
      \u003C\u0024\u003Egear = gear,
      \u003C\u0024\u003Econtains = contains,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetGear(PlayerItem gear, bool contains)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GearIconWithNumber.\u003CSetGear\u003Ec__IteratorB80()
    {
      gear = gear,
      contains = contains,
      \u003C\u0024\u003Egear = gear,
      \u003C\u0024\u003Econtains = contains,
      \u003C\u003Ef__this = this
    };
  }
}
