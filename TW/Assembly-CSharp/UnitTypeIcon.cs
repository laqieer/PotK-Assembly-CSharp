// Decompiled with JetBrains decompiler
// Type: UnitTypeIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class UnitTypeIcon : MonoBehaviour
{
  public UI2DSprite iconSprite;
  [SerializeField]
  private Sprite[] icons;
  private static GameObject self;

  public void Init(UnitType type) => this.iconSprite.sprite2D = this.icons[type.ID - 1];

  public static GameObject GetPrefab()
  {
    if (Object.op_Equality((Object) UnitTypeIcon.self, (Object) null))
      UnitTypeIcon.self = Resources.Load<GameObject>("Icons/UnitTypeIcon");
    return UnitTypeIcon.self;
  }
}
