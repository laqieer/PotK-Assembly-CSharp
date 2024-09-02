// Decompiled with JetBrains decompiler
// Type: Unit00484Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit00484Menu : Unit00483Menu
{
  public GameObject ibtnCombine;
  public GameObject ibtnReinforce;
  protected Unit00468Scene.Mode _mode;

  protected override void SetPrice(PlayerUnit basePlayerUnit, PlayerUnit[] select)
  {
    this.TxtZeny.SetTextLocalize((this._mode != Unit00468Scene.Mode.Unit0048 ? CalcUnitCompose.priceStringth(basePlayerUnit, select) : CalcUnitCompose.priceCompose(basePlayerUnit, select)).ToString());
  }

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerUnit basePlayerUnit,
    PlayerUnit[] materialPlayerUnits,
    Unit00468Scene.Mode mode)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00484Menu.\u003CInit\u003Ec__Iterator343()
    {
      mode = mode,
      basePlayerUnit = basePlayerUnit,
      materialPlayerUnits = materialPlayerUnits,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EmaterialPlayerUnits = materialPlayerUnits,
      \u003C\u003Ef__this = this
    };
  }

  protected override void setEnterBtnStatus(PlayerUnit[] _selectUnit)
  {
    UIButton uiButton = (UIButton) null;
    switch (this._mode)
    {
      case Unit00468Scene.Mode.Unit0048:
        this.ibtnCombine.SetActive(true);
        this.ibtnReinforce.SetActive(false);
        uiButton = this.ibtnCombine.GetComponent<UIButton>();
        this.TxtTitle.SetText(Consts.GetInstance().unit_004_8_4_combine_title);
        break;
      case Unit00468Scene.Mode.Unit00481:
        this.ibtnCombine.SetActive(false);
        this.ibtnReinforce.SetActive(true);
        uiButton = this.ibtnReinforce.GetComponent<UIButton>();
        this.TxtTitle.SetText(Consts.GetInstance().unit_004_8_4_reinforce_title);
        break;
    }
    if (!Object.op_Implicit((Object) uiButton))
      return;
    uiButton.isEnabled = true;
    if (_selectUnit.Length != 0)
      return;
    uiButton.isEnabled = false;
  }

  protected override void ChangeSozaiSelect(PlayerUnit _baseUnit, PlayerUnit[] _selectUnit)
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    if (this._mode == Unit00468Scene.Mode.Unit0048)
      Unit00486Scene.changeScene(false, _baseUnit, _selectUnit);
    else
      Debug.LogError((object) "無い画面モードが設定されてます");
  }

  protected override void changeSceneForCombine(
    List<PlayerUnit> materialList,
    List<PlayerUnit> resultList,
    List<int> otherList,
    Dictionary<string, object> showPopupData)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_8_12", false, (object) materialList, (object) resultList, (object) otherList, (object) showPopupData, (object) this._mode);
  }

  protected override void changeSceneForPopup(
    Unit004832Menu popupMenu,
    List<PlayerUnit> rarityList,
    PlayerUnit baseUnit,
    PlayerUnit[] selectUnit)
  {
    popupMenu.mode = this._mode;
    this.StartCoroutine(popupMenu.SetSelectedUnitIcons(new Func<List<PlayerUnit>, WebAPI.Response.UnitCompose, Dictionary<string, object>>(((Unit00483Menu) this).setShowPopupData), rarityList.ToArray(), baseUnit, selectUnit));
  }
}
