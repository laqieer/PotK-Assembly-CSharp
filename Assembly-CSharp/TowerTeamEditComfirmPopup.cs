// Decompiled with JetBrains decompiler
// Type: TowerTeamEditComfirmPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTeamEditComfirmPopup : BackButtonMonoBehaiviour
{
  private const float LINK_WIDTH = 92f;
  private const float LINK_HEIGHT = 110f;
  private const float scale = 0.8363636f;
  [SerializeField]
  private UILabel lblPopupTitle;
  [SerializeField]
  private UILabel lblPopupDesc;
  private System.Action actionEditTeam;
  private GameObject iconPrefab;
  private GameObject hpGaugePrefab;
  [SerializeField]
  protected GameObject[] linkCharacters;

  private IEnumerator SetTeamUnits(List<UnitIconInfo> selectedUnitIcons)
  {
    if (selectedUnitIcons != null)
    {
      for (int i = 0; i < selectedUnitIcons.Count; ++i)
      {
        IEnumerator e = this.LoadUnitPrefab(i, selectedUnitIcons[i].playerUnit);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
    }
  }

  private IEnumerator LoadUnitPrefab(int index, PlayerUnit unit)
  {
    GameObject gameObject = this.iconPrefab.Clone(this.linkCharacters[index].transform);
    gameObject.transform.localScale = new Vector3(0.8363636f, 0.8363636f);
    UnitIcon unitScript = gameObject.GetComponent<UnitIcon>();
    IEnumerator e;
    if ((UnityEngine.Object) this.hpGaugePrefab == (UnityEngine.Object) null)
    {
      Future<GameObject> f = Res.Prefabs.tower.dir_hp_gauge.Load<GameObject>();
      e = f.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.hpGaugePrefab = f.Result;
      f = (Future<GameObject>) null;
    }
    if ((UnityEngine.Object) this.hpGaugePrefab != (UnityEngine.Object) null)
      this.hpGaugePrefab.Clone(unitScript.hp_gauge.transform);
    e = unitScript.setSimpleUnit(unit);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    unitScript.setLevelText(unit);
    unitScript.ShowBottomInfo(UnitSortAndFilter.SORT_TYPES.Level);
    if (unit != (PlayerUnit) null)
    {
      unitScript.BreakWeapon = unit.IsBrokenEquippedGear;
      unitScript.SpecialIcon = false;
      unitScript.HpGauge.TweenHpGauge.setValue(unit.TowerHp, unit.total_hp, false);
    }
    else
      unitScript.SetEmpty();
    unitScript.Favorite = false;
    unitScript.Gray = false;
  }

  public IEnumerator InitializeAsync(
    List<UnitIconInfo> selectedUnitIcons,
    GameObject unitIconPrefab,
    GameObject hpGaugePrefab,
    System.Action action)
  {
    TowerTeamEditComfirmPopup editComfirmPopup = this;
    if ((UnityEngine.Object) editComfirmPopup.GetComponent<UIWidget>() != (UnityEngine.Object) null)
      editComfirmPopup.GetComponent<UIWidget>().alpha = 0.0f;
    editComfirmPopup.actionEditTeam = action;
    editComfirmPopup.lblPopupTitle.SetTextLocalize(Consts.GetInstance().POPUP_TOWER_TEAM_EDIT_COMFIRM_TITLE);
    editComfirmPopup.lblPopupDesc.SetTextLocalize(Consts.GetInstance().POPUP_TOWER_TEAM_EDIT_COMFIRM_DESC);
    editComfirmPopup.iconPrefab = unitIconPrefab;
    editComfirmPopup.hpGaugePrefab = hpGaugePrefab;
    IEnumerator e = editComfirmPopup.SetTeamUnits(selectedUnitIcons);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public void onYesButton()
  {
    if (this.actionEditTeam == null)
      return;
    this.actionEditTeam();
  }

  public void onNoButton() => Singleton<PopupManager>.GetInstance().dismiss();

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();
}
