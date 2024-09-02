// Decompiled with JetBrains decompiler
// Type: Unit00443Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit00443Menu : EquipmentDetailMenuBase
{
  [SerializeField]
  public UI2DSprite DynWeaponIll;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected Transform DynWeaponModel;
  [SerializeField]
  protected GameObject charaThum;
  [SerializeField]
  protected GameObject DirAddStauts;
  public UIButton nowFavorite;
  public UIButton yetFavorite;
  public Transform TopStarPos;
  public NGHorizontalScrollParts indicator;
  public Unit00443indicator indicatorPage1;
  public Unit00443indicatorDirection indicatorPage2;
  public UIGrid grid;
  public PlayerItem RetentionGear;
  public UIWidget ZoomBuguSprite;
  protected Unit004431Menu.Param sendParam = new Unit004431Menu.Param();
  [SerializeField]
  public UI2DSprite rarityStarsIcon;

  protected void SetTitleText(string gearName, int customizeFlag)
  {
    ((Component) this.TxtTitle).gameObject.SetActive(true);
    this.TxtTitle.SetText(gearName);
    if (customizeFlag != 1)
      return;
    this.TxtTitle.color = Color.yellow;
  }

  [DebuggerHidden]
  public IEnumerator Init(PlayerItem targetGear, bool limited = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00443Menu.\u003CInit\u003Ec__Iterator2D6()
    {
      targetGear = targetGear,
      limited = limited,
      \u003C\u0024\u003EtargetGear = targetGear,
      \u003C\u0024\u003Elimited = limited,
      \u003C\u003Ef__this = this
    };
  }

  protected IEnumerator setTexture(Future<Sprite> src, UI2DSprite to)
  {
    return src.Then<Sprite>((Func<Sprite, Sprite>) (sprite =>
    {
      Sprite sprite1 = sprite;
      to.sprite2D = sprite1;
      return sprite1;
    })).Wait();
  }

  public void changeFavorite()
  {
    ((Component) this.yetFavorite).gameObject.SetActive(((Component) this.nowFavorite).gameObject.activeSelf);
    ((Component) this.nowFavorite).gameObject.SetActive(!((Component) this.yetFavorite).gameObject.activeSelf);
  }

  [DebuggerHidden]
  public virtual IEnumerator FavoriteAPI()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00443Menu.\u003CFavoriteAPI\u003Ec__Iterator2D7()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void choiceUnitChangeScene()
  {
    Unit00468Scene.changeScene004431(true, this.sendParam);
  }

  [DebuggerHidden]
  protected IEnumerator WaitScrollSe()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00443Menu.\u003CWaitScrollSe\u003Ec__Iterator2D8()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void EndScene()
  {
    foreach (Component component in this.charaThum.transform)
      Object.Destroy((Object) component.gameObject);
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnFavoriteOff()
  {
  }

  public virtual void IbtnFavoriteOn()
  {
  }

  public virtual void IbtnZoom() => Unit00446Scene.changeScene(true, this.RetentionGear);
}
