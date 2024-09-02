// Decompiled with JetBrains decompiler
// Type: SkillGenreIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class SkillGenreIcon : IconPrefabBase
{
  public UI2DSprite iconSprite;
  [SerializeField]
  private Sprite[] icons;
  private static GameObject self;

  public void Init(BattleskillGenre? genre)
  {
    if (genre.HasValue)
      this.iconSprite.sprite2D = this.icons[(int) (genre.Value - 1)];
    else
      this.iconSprite.sprite2D = (Sprite) null;
  }

  public static GameObject GetPrefab()
  {
    if (Object.op_Equality((Object) SkillGenreIcon.self, (Object) null))
      SkillGenreIcon.self = Resources.Load<GameObject>("Icons/SkillGenreIcon");
    return SkillGenreIcon.self;
  }
}
