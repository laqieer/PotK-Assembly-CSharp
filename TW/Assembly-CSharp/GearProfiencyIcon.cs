// Decompiled with JetBrains decompiler
// Type: GearProfiencyIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
