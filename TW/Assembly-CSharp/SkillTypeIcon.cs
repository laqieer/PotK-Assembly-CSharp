// Decompiled with JetBrains decompiler
// Type: SkillTypeIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class SkillTypeIcon : IconPrefabBase
{
  public UI2DSprite iconSprite;
  [SerializeField]
  private Sprite[] icons;
  private static GameObject self;

  public void Init(BattleskillSkillType kind) => this.iconSprite.sprite2D = this.icons[(int) kind];

  public static GameObject GetPrefab()
  {
    if (Object.op_Equality((Object) SkillTypeIcon.self, (Object) null))
      SkillTypeIcon.self = Resources.Load<GameObject>("Icons/SkillTypeIcon");
    return SkillTypeIcon.self;
  }
}
