// Decompiled with JetBrains decompiler
// Type: PrincessTypeIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using UnityEngine;

public class PrincessTypeIcon : MonoBehaviour
{
  [SerializeField]
  private UI2DSprite typeSprite;
  [SerializeField]
  private UnityEngine.Sprite[] princessTypeIcons;
  [Space(8f)]
  [SerializeField]
  private UISprite typeSpriteAtlas;
  private readonly string[] TYPE_STR = new string[8]
  {
    "",
    "king",
    "life",
    "atk",
    "mag",
    "def",
    "tech",
    ""
  };

  public void SetPrincessType(UnitTypeEnum unitType) => this.ChangeSpriteIcon(unitType);

  public void SetPrincessType(PlayerUnit unit)
  {
    if (!unit.unit.IsNormalUnit)
    {
      this.DispPrincessType(false);
    }
    else
    {
      this.DispPrincessType(true);
      this.SetPrincessType(unit.unit_type.Enum);
    }
  }

  private void ChangeSpriteIcon(UnitTypeEnum unitType)
  {
    if ((Object) this.typeSprite != (Object) null)
    {
      int index = (int) (unitType - 1);
      if (index >= this.princessTypeIcons.Length || (Object) this.princessTypeIcons[index] == (Object) null)
        this.DispPrincessType(false);
      else
        this.typeSprite.sprite2D = this.princessTypeIcons[index];
    }
    else
    {
      if (!((Object) this.typeSpriteAtlas != (Object) null))
        return;
      if (unitType == UnitTypeEnum.random)
        this.DispPrincessType(false);
      else
        this.typeSpriteAtlas.spriteName = string.Format("slc_princess_{0}", (object) this.TYPE_STR[(int) unitType]);
    }
  }

  public void DispPrincessType(bool canDisp)
  {
    if ((Object) this.typeSprite != (Object) null)
    {
      this.typeSprite.gameObject.SetActive(canDisp);
    }
    else
    {
      if (!((Object) this.typeSpriteAtlas != (Object) null))
        return;
      this.typeSpriteAtlas.gameObject.SetActive(canDisp);
    }
  }
}
