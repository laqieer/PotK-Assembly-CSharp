// Decompiled with JetBrains decompiler
// Type: CreateIconObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class CreateIconObject : MonoBehaviour
{
  private UniqueIcons uniqueIcon;
  private GameObject objIcon;

  public GameObject GetIcon() => this.objIcon;

  [DebuggerHidden]
  public IEnumerator CreateThumbnail(
    MasterDataTable.CommonRewardType rewardType,
    int rewardID,
    int quantity = 0,
    bool visibleBottom = true,
    bool isButton = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CreateIconObject.\u003CCreateThumbnail\u003Ec__IteratorA9A()
    {
      quantity = quantity,
      rewardType = rewardType,
      rewardID = rewardID,
      visibleBottom = visibleBottom,
      isButton = isButton,
      \u003C\u0024\u003Equantity = quantity,
      \u003C\u0024\u003ErewardType = rewardType,
      \u003C\u0024\u003ErewardID = rewardID,
      \u003C\u0024\u003EvisibleBottom = visibleBottom,
      \u003C\u0024\u003EisButton = isButton,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetUniqueIcon(Func<IEnumerator> f, Transform t, bool vB)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CreateIconObject.\u003CSetUniqueIcon\u003Ec__IteratorA9B()
    {
      t = t,
      f = f,
      vB = vB,
      \u003C\u0024\u003Et = t,
      \u003C\u0024\u003Ef = f,
      \u003C\u0024\u003EvB = vB,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateUniqueIcon(Transform linktarget)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CreateIconObject.\u003CCreateUniqueIcon\u003Ec__IteratorA9C()
    {
      linktarget = linktarget,
      \u003C\u0024\u003Elinktarget = linktarget,
      \u003C\u003Ef__this = this
    };
  }
}
