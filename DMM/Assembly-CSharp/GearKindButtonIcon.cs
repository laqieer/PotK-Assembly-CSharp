// Decompiled with JetBrains decompiler
// Type: GearKindButtonIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

public class GearKindButtonIcon : MonoBehaviour
{
  public void Init(GearKindEnum kind) => this.GetComponent<UI2DSprite>().sprite2D = this.GetIdle(kind);

  public UnityEngine.Sprite GetIdle(GearKind kind) => this.GetIdle(kind.Enum);

  public UnityEngine.Sprite GetPress(GearKind kind) => this.GetPress(kind.Enum);

  public UnityEngine.Sprite GetIdle(GearKindEnum kind) => Resources.Load<UnityEngine.Sprite>(string.Format("Icons/Materials/GuideWeaponBtn/slc_{0}_idle", (object) kind.ToString()));

  public UnityEngine.Sprite GetPress(GearKindEnum kind) => Resources.Load<UnityEngine.Sprite>(string.Format("Icons/Materials/GuideWeaponBtn/slc_{0}_pressed", (object) kind.ToString()));
}
