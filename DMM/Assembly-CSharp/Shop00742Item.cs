// Decompiled with JetBrains decompiler
// Type: Shop00742Item
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using UnityEngine;

public class Shop00742Item : NGMenuBase
{
  [SerializeField]
  protected UILabel TxtAttack;
  [SerializeField]
  protected UILabel TxtCritical;
  [SerializeField]
  protected UILabel TxtDefense;
  [SerializeField]
  protected UILabel TxtDexterity;
  [SerializeField]
  protected UILabel TxtEvasion;
  [SerializeField]
  protected UILabel TxtFlavor;
  [SerializeField]
  protected UILabel TxtJobName;
  [SerializeField]
  protected UILabel TxtLeaderSkillname;
  [SerializeField]
  protected UILabel TxtMatk;
  [SerializeField]
  protected UILabel TxtMdef;
  [SerializeField]
  protected UILabel TxtMove;
  [SerializeField]
  protected UILabel TxtName;
  [SerializeField]
  protected UILabel TxtSkillexplanation;
  [SerializeField]
  protected UI2DSprite SlcTarget;
  [SerializeField]
  protected UI2DSprite rarityStarIcon;

  public IEnumerator Init(int entity_id)
  {
    SupplySupply supplySupply = MasterData.SupplySupply[entity_id];
    this.TxtFlavor.SetText(supplySupply.flavor);
    this.TxtName.SetText(supplySupply.name);
    this.TxtSkillexplanation.SetText(supplySupply.description);
    Future<UnityEngine.Sprite> spriteF = supplySupply.LoadSpriteBasic();
    IEnumerator e = spriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.SlcTarget.sprite2D = spriteF.Result;
    this.SlcTarget.width = Mathf.FloorToInt(spriteF.Result.textureRect.width);
    this.SlcTarget.height = Mathf.FloorToInt(spriteF.Result.textureRect.height);
    this.SlcTarget.transform.localScale = new Vector3(0.7f, 0.7f);
    spriteF = (Future<UnityEngine.Sprite>) null;
  }

  public virtual void IbtnPopupClose()
  {
  }

  public virtual void IbtnPopupClose2()
  {
  }

  public virtual void IbtnPopupClose3()
  {
  }
}
