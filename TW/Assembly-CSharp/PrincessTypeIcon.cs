// Decompiled with JetBrains decompiler
// Type: PrincessTypeIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class PrincessTypeIcon : MonoBehaviour
{
  [SerializeField]
  private UI2DSprite typeSprite;
  [SerializeField]
  private Sprite[] princessTypeIcons;

  public void SetPrincessType(PlayerUnit unit)
  {
    this.DispPrincessType(false);
    if (!unit.unit.IsNormalUnit)
      return;
    int index = unit.unit_type.ID - 1;
    if (this.princessTypeIcons.Length <= index || !Object.op_Inequality((Object) this.princessTypeIcons[index], (Object) null))
      return;
    this.DispPrincessType(true);
    this.typeSprite.sprite2D = this.princessTypeIcons[index];
  }

  public void DispPrincessType(bool canDisp)
  {
    ((Component) this.typeSprite).gameObject.SetActive(canDisp);
  }
}
