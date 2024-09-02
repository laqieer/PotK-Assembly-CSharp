// Decompiled with JetBrains decompiler
// Type: Unit00443indicatorDirection
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using UnityEngine;

public class Unit00443indicatorDirection : MonoBehaviour
{
  [SerializeField]
  protected UILabel TxtIntroduction;

  public IEnumerator Init(ItemInfo targetGear)
  {
    this.Init(targetGear.gear);
    yield break;
  }

  public void Init(GearGear gear) => this.TxtIntroduction.SetTextLocalize(gear.description);
}
