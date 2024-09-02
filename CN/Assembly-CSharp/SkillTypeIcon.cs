// Decompiled with JetBrains decompiler
// Type: SkillTypeIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
