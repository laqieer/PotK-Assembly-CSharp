// Decompiled with JetBrains decompiler
// Type: SkillfullnessIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

public class SkillfullnessIcon : IconPrefabBase
{
  public UI2DSprite iconSprite;
  private const int KIND_NONE = 0;
  [SerializeField]
  private UnityEngine.Sprite[] icons;

  public UnityEngine.Sprite[] Icons => this.icons;

  private void InitKindId(int kind) => this.iconSprite.sprite2D = this.icons[kind];

  public void InitKindId(UnitFamily family) => this.InitKindId((int) family);

  public void InitKindNone() => this.InitKindId(0);
}
