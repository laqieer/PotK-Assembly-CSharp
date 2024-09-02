// Decompiled with JetBrains decompiler
// Type: CommonElementIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class CommonElementIcon : MonoBehaviour
{
  private const int DEPTH = 10000;
  public UI2DSprite iconSprite;
  [SerializeField]
  private Sprite[] icons;
  [SerializeField]
  private UI2DSprite iconEffectSprite;

  public void Init(CommonElement element, bool resize = false, float elementAttackRate = 1f)
  {
    bool flag = this.GetElementAdvantage(elementAttackRate) == CommonElementIcon.Advantage.HIGHER;
    this.iconSprite.sprite2D = this.icons[(int) (element - 1)];
    if (Object.op_Equality((Object) this.iconEffectSprite, (Object) null))
      return;
    ((Component) this.iconEffectSprite).gameObject.SetActive(flag);
    if (flag)
      this.iconEffectSprite.sprite2D = this.icons[(int) (element - 1)];
    if (resize)
    {
      this.iconSprite.SetDimensions(((Texture) this.iconSprite.sprite2D.texture).width, ((Texture) this.iconSprite.sprite2D.texture).height);
      if (flag)
        this.iconEffectSprite.SetDimensions(((Texture) this.iconEffectSprite.sprite2D.texture).width, ((Texture) this.iconEffectSprite.sprite2D.texture).height);
    }
    this.iconSprite.depth = 10000;
    this.iconEffectSprite.depth = 10001;
  }

  public void FixPosition()
  {
    this.iconSprite.UpdateAnchors();
    if (!Object.op_Inequality((Object) this.iconEffectSprite, (Object) null))
      return;
    this.iconEffectSprite.UpdateAnchors();
  }

  private CommonElementIcon.Advantage GetElementAdvantage(float elementAttackRate)
  {
    CommonElementIcon.Advantage elementAdvantage = CommonElementIcon.Advantage.NONE;
    if ((double) elementAttackRate > 1.0)
      elementAdvantage = CommonElementIcon.Advantage.HIGHER;
    if ((double) elementAttackRate < 1.0)
      elementAdvantage = CommonElementIcon.Advantage.LOWER;
    return elementAdvantage;
  }

  private enum Advantage
  {
    NONE,
    HIGHER,
    LOWER,
  }
}
