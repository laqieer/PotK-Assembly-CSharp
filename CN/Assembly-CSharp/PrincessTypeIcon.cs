// Decompiled with JetBrains decompiler
// Type: PrincessTypeIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
