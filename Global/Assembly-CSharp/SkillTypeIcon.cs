// Decompiled with JetBrains decompiler
// Type: SkillTypeIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
