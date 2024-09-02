// Decompiled with JetBrains decompiler
// Type: GearProfiencyIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GearProfiencyIcon : IconPrefabBase
{
  public UI2DSprite iconSprite;
  [SerializeField]
  private Sprite[] icons;
  private static GameObject self;

  public void Init(int level)
  {
    if (level < 1)
      level = 1;
    if (level > this.icons.Length)
      level = this.icons.Length;
    this.iconSprite.sprite2D = this.icons[level - 1];
  }

  public static GameObject GetPrefab()
  {
    if (Object.op_Equality((Object) GearProfiencyIcon.self, (Object) null))
      GearProfiencyIcon.self = Resources.Load<GameObject>("Icons/GearProfiencyIcon");
    return GearProfiencyIcon.self;
  }
}
