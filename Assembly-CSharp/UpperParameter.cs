// Decompiled with JetBrains decompiler
// Type: UpperParameter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections.Generic;
using UnityEngine;

public class UpperParameter : MonoBehaviour
{
  public UnityEngine.Sprite upiconSpriteAtk;
  public UnityEngine.Sprite upiconSpriteDef;
  public UnityEngine.Sprite upiconSpriteHp;
  public UnityEngine.Sprite upiconSpriteMatk;
  public UnityEngine.Sprite upiconSpriteMtl;
  public UnityEngine.Sprite upiconSpriteSpe;
  public UnityEngine.Sprite upiconSpriteTec;
  public UnityEngine.Sprite upiconSpriteLuck;
  public UI2DSprite[] upiconSprites;
  public GameObject[] upiconEffect;

  private void SetSprite(UnitUnit unit)
  {
    ((IEnumerable<UI2DSprite>) this.upiconSprites).ForEach<UI2DSprite>((System.Action<UI2DSprite>) (x => x.gameObject.SetActive(true)));
    ((IEnumerable<GameObject>) this.upiconEffect).ForEach<GameObject>((System.Action<GameObject>) (x => x.SetActive(false)));
    int num = 0;
    if (!unit.IsBuildup)
    {
      if (num < 4 && unit.hp_compose != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteHp;
      if (num < 4 && unit.strength_compose != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteAtk;
      if (num < 4 && unit.vitality_compose != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteDef;
      if (num < 4 && unit.intelligence_compose != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteMatk;
      if (num < 4 && unit.mind_compose != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteMtl;
      if (num < 4 && unit.agility_compose != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteSpe;
      if (num < 4 && unit.dexterity_compose != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteTec;
      if (num < 4 && unit.lucky_compose != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteLuck;
    }
    else
    {
      if (num < 4 && unit.hp_buildup != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteHp;
      if (num < 4 && unit.strength_buildup != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteAtk;
      if (num < 4 && unit.vitality_buildup != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteDef;
      if (num < 4 && unit.intelligence_buildup != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteMatk;
      if (num < 4 && unit.mind_buildup != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteMtl;
      if (num < 4 && unit.agility_buildup != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteSpe;
      if (num < 4 && unit.dexterity_buildup != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteTec;
      if (num < 4 && unit.lucky_buildup != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteLuck;
      for (int index = 0; index < num; ++index)
      {
        this.upiconEffect[index].SetActive(true);
        TweenColor component = this.upiconEffect[index].GetComponent<TweenColor>();
        component.ResetToBeginning();
        component.PlayForward();
      }
    }
    while (num < 4)
      this.upiconSprites[num++].gameObject.SetActive(false);
  }

  public void Init(PlayerUnit materialUnit) => this.SetSprite(materialUnit.unit);
}
