// Decompiled with JetBrains decompiler
// Type: Unit0046Character
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Unit0046Character : MonoBehaviour
{
  public GameObject select;
  public GameObject Notselect;
  public int mynumber;
  [SerializeField]
  private UISprite specialIcon;
  [SerializeField]
  private UI2DSprite pieceIcon;
  private static readonly string specialIconSpriteName = "slc_icon_specific_effectiveness_{0}.png__GUI__004-6_sozai__004-6_sozai_prefab";
  private static readonly string specialIconSpriteNameSea = "slc_icon_specific_effectiveness_{0}.png__GUI__004-6_sozai_sea__004-6_sozai_sea_prefab";

  public void CharaSetActive(bool selectCondition, string SpecialType, bool getPiece)
  {
    this.Notselect.SetActive(!selectCondition);
    bool flag = !string.IsNullOrEmpty(SpecialType);
    this.specialIcon.gameObject.SetActive(flag);
    if (flag)
      this.specialIcon.spriteName = !Singleton<NGGameDataManager>.GetInstance().IsSea ? string.Format(Unit0046Character.specialIconSpriteName, (object) SpecialType) : string.Format(Unit0046Character.specialIconSpriteNameSea, (object) SpecialType);
    if ((Object) this.pieceIcon == (Object) null)
      return;
    this.pieceIcon.gameObject.SetActive(getPiece);
  }
}
