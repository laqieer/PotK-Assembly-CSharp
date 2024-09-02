// Decompiled with JetBrains decompiler
// Type: SkillTypeIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

public class SkillTypeIcon : IconPrefabBase
{
  public UI2DSprite iconSprite;
  [SerializeField]
  private UnityEngine.Sprite[] icons;
  private static GameObject self;

  public void Init(BattleskillSkillType kind) => this.iconSprite.sprite2D = this.icons[(int) kind];

  public static GameObject GetPrefab()
  {
    if ((Object) SkillTypeIcon.self == (Object) null)
      SkillTypeIcon.self = Resources.Load<GameObject>("Icons/SkillTypeIcon");
    return SkillTypeIcon.self;
  }
}
