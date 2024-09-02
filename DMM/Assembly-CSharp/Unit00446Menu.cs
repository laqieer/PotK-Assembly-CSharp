// Decompiled with JetBrains decompiler
// Type: Unit00446Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using UnityEngine;

public class Unit00446Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtBattleTitle;
  public UI2DSprite GearSpriteObject;
  public UI2DSprite rarityStars;
  public UILabel TxtTitle;

  public IEnumerator SetSprite(GearGear targetgear)
  {
    Future<UnityEngine.Sprite> spriteF = targetgear.LoadSpriteBasic();
    IEnumerator e = spriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.GearSpriteObject.sprite2D = spriteF.Result;
    this.GearSpriteObject.width = Mathf.FloorToInt(spriteF.Result.textureRect.width);
    this.GearSpriteObject.height = Mathf.FloorToInt(spriteF.Result.textureRect.height);
    RarityIcon.SetRarity(targetgear, this.rarityStars);
    this.TxtTitle.SetTextLocalize(targetgear.name);
  }

  public void changeScene()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public virtual void IbtnBattleBack()
  {
  }

  public override void onBackButton() => this.changeScene();
}
