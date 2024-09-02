// Decompiled with JetBrains decompiler
// Type: GearKindIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class GearKindIcon : IconPrefabBase
{
  public UI2DSprite iconSprite;
  [SerializeField]
  protected Sprite none_icon;
  private static GameObject self;

  public void Init(GearKind kind, CommonElement element = CommonElement.none)
  {
    this.iconSprite.sprite2D = GearKindIcon.LoadSprite(kind.Enum, element);
  }

  public void Init(int ID, CommonElement element = CommonElement.none)
  {
    this.iconSprite.sprite2D = GearKindIcon.LoadSprite((GearKindEnum) ID, element);
  }

  public static Sprite LoadSprite(GearKindEnum kind, CommonElement element)
  {
    return Resources.Load<Sprite>(string.Format("Icons/Materials/GearKind_Element_Icon/slc_{0}_{1}_34_30", (object) kind.ToString(), (object) element.ToString()));
  }

  public void None() => this.iconSprite.sprite2D = this.none_icon;

  public static GameObject GetPrefab()
  {
    if (Object.op_Equality((Object) GearKindIcon.self, (Object) null))
      GearKindIcon.self = Resources.Load<GameObject>("Icons/GearKindIcon");
    return GearKindIcon.self;
  }
}
