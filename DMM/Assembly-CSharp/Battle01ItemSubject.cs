// Decompiled with JetBrains decompiler
// Type: Battle01ItemSubject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle01ItemSubject : NGBattleMenuBase
{
  [SerializeField]
  private UI2DSprite icon;
  [SerializeField]
  private UILabel txt_name;
  [SerializeField]
  private UILabel txt_description;
  [SerializeField]
  private UILabel txt_amount;
  private ItemIcon itemIcon;
  private BL.Item item;
  public NGHorizontalScrollParts _scroll;

  private void Awake() => this.icon.enabled = false;

  public override IEnumerator onInitAsync()
  {
    Battle01ItemSubject battle01ItemSubject = this;
    Future<GameObject> f = !battle01ItemSubject.battleManager.isSea ? Res.Prefabs.ItemIcon.prefab.Load<GameObject>() : Res.Prefabs.Sea.ItemIcon.prefab_sea.Load<GameObject>();
    IEnumerator e = f.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject result = f.Result;
    battle01ItemSubject.itemIcon = result.CloneAndGetComponent<ItemIcon>(battle01ItemSubject.icon.gameObject.transform);
    NGUITools.AdjustDepth(battle01ItemSubject.itemIcon.gameObject, battle01ItemSubject.icon.depth);
    battle01ItemSubject.itemIcon.SetBasedOnHeight(battle01ItemSubject.icon.height);
  }

  private IEnumerator doSetIcon(SupplySupply supply)
  {
    IEnumerator e = this.itemIcon.InitBySupply(supply);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.itemIcon.isButtonActive = false;
    this.itemIcon.QuantitySupply = false;
  }

  public void setItemTargets(BL.Item item, List<BL.Unit> targets)
  {
    this.item = item;
    this.StartCoroutine(this.doSetIcon(item.item));
    this.setText(this.txt_name, item.item.name);
    this.setText(this.txt_description, item.item.description);
    this.setText(this.txt_amount, item.amount);
    Battle01ItemUseSelect[] componentsInChildren = this.GetComponentsInChildren<Battle01ItemUseSelect>(true);
    if (componentsInChildren.Length == 0)
      return;
    componentsInChildren[0].setTargets(targets, true);
  }

  public void resetScrollView()
  {
    if ((Object) this._scroll == (Object) null)
    {
      NGHorizontalScrollParts[] componentsInChildren = this.GetComponentsInChildren<NGHorizontalScrollParts>(true);
      if (componentsInChildren.Length != 0)
        this._scroll = componentsInChildren[0];
    }
    this._scroll.resetScrollView();
  }

  public void useUnit(BL.Unit unit)
  {
    if (this.item == null)
      return;
    this.env.useItem(this.item, unit, this.battleManager.getManager<BattleTimeManager>());
    NGUITools.FindInParents<Battle01SelectNode>(this.transform).backToTop();
  }
}
