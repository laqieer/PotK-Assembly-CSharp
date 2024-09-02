// Decompiled with JetBrains decompiler
// Type: SPAtkTypeIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class SPAtkTypeIcon : MonoBehaviour
{
  private const int KIND_NONE = 0;
  public UI2DSprite iconSprite;
  [SerializeField]
  private Sprite[] icons;

  private void InitKindId(int index) => this.iconSprite.sprite2D = this.icons[index];

  public void InitKindId(UnitFamily family) => this.InitKindId((int) family);

  public void InitKindNone() => this.InitKindId(0);
}
