// Decompiled with JetBrains decompiler
// Type: SprGearAttack
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SprGearAttack : MonoBehaviour
{
  public UI2DSprite iconSprite;
  private const int KIND_NONE = 1;
  [SerializeField]
  private UnityEngine.Sprite[] icons;

  public void InitGearAttackID(int index) => this.iconSprite.sprite2D = this.icons[index];

  public void InitGearAttackNone() => this.InitGearAttackID(1);
}
