// Decompiled with JetBrains decompiler
// Type: Unit004_RentalUnit_Edit_Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Unit004_RentalUnit_Edit_Menu : UnitMenuBase
{
  public UIButton allDeleteBtn;
  public UIButton okBtn;
  public TweenPosition tp;
  private const int maxUnitNum = 7;
  private UnitSortAndFilter filter;
  [SerializeField]
  protected GameObject[] rentalCharacters;
  private Dictionary<CommonElement, int> lastSelectUnitDic;
  private Dictionary<CommonElement, UnitIcon> rentalCharatersDic = new Dictionary<CommonElement, UnitIcon>();
  private CommonElement currentSelectElement = CommonElement.none;
  private readonly List<CommonElement> rentalElementList = new List<CommonElement>()
  {
    CommonElement.none,
    CommonElement.fire,
    CommonElement.wind,
    CommonElement.thunder,
    CommonElement.ice,
    CommonElement.light,
    CommonElement.dark
  };

  private IEnumerator SendRentalUnitID()
  {
    Unit004_RentalUnit_Edit_Menu rentalUnitEditMenu = this;
    int?[] player_unit_ids = new int?[7];
    int index = 0;
    foreach (KeyValuePair<CommonElement, UnitIcon> keyValuePair in rentalUnitEditMenu.rentalCharatersDic)
    {
      player_unit_ids[index] = keyValuePair.Value.unit == null ? new int?(0) : new int?(keyValuePair.Value.PlayerUnit.id);
      ++index;
    }
    IEnumerator e1 = WebAPI.RentalunitEditRentalUnit(player_unit_ids, (System.Action<WebAPI.Response.UserError>) (e => WebAPI.DefaultUserErrorCallback(e))).Wait();
    while (e1.MoveNext())
      yield return e1.Current;
    e1 = (IEnumerator) null;
    rentalUnitEditMenu.IbtnBack();
  }

  protected override IEnumerator CreateUnitIcon(
    int info_index,
    int unit_index,
    PlayerUnit baseUnit = null)
  {
    IEnumerator e = base.CreateUnitIcon(info_index, unit_index, baseUnit);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.CreateUnitIconAction(info_index, unit_index);
  }

  public IEnumerator Initalize(
    PlayerDeck playerDeck,
    PlayerUnit[] playerUnits,
    int max_cost,
    bool isEquip)
  {
    Unit004_RentalUnit_Edit_Menu rentalUnitEditMenu1 = this;
    IEnumerator e = ServerTime.WaitSync();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    rentalUnitEditMenu1.serverTime = ServerTime.NowAppTime();
    ((IEnumerable<GameObject>) rentalUnitEditMenu1.rentalCharacters).ForEach<GameObject>((System.Action<GameObject>) (v => v.transform.Clear()));
    playerUnits = ((IEnumerable<PlayerUnit>) playerUnits).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x.unit.IsNormalUnit)).ToArray<PlayerUnit>();
    rentalUnitEditMenu1.InitializeInfo((IEnumerable<PlayerUnit>) playerUnits, (IEnumerable<PlayerMaterialUnit>) null, Persist.friendSupportSortAndFilter, isEquip, true, false, true, true);
    e = rentalUnitEditMenu1.CreateUnitIcon();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    rentalUnitEditMenu1.InitializeEnd();
    List<UnitIcon> unitIconList = new List<UnitIcon>();
    foreach (GameObject rentalCharacter in rentalUnitEditMenu1.rentalCharacters)
    {
      UnitIcon unitObject = rentalUnitEditMenu1.CreateUnitObject(rentalCharacter);
      unitObject.SetEmpty();
      unitIconList.Add(unitObject);
    }
    rentalUnitEditMenu1.rentalCharatersDic.Clear();
    for (int index = 0; index < rentalUnitEditMenu1.rentalElementList.Count; ++index)
      rentalUnitEditMenu1.rentalCharatersDic.Add(rentalUnitEditMenu1.rentalElementList[index], unitIconList[index]);
    int num1 = 0;
    foreach (KeyValuePair<CommonElement, UnitIcon> keyValuePair in rentalUnitEditMenu1.rentalCharatersDic)
    {
      Unit004_RentalUnit_Edit_Menu rentalUnitEditMenu = rentalUnitEditMenu1;
      KeyValuePair<CommonElement, UnitIcon> chara = keyValuePair;
      int num = num1;
      chara.Value.onClick = (System.Action<UnitIconBase>) (x =>
      {
        if (closure_0.currentSelectElement == chara.Key)
          return;
        closure_0.tp.from.x = closure_0.rentalCharacters[num].transform.localPosition.x - 270f;
        closure_0.tp.to.x = closure_0.rentalCharacters[num].transform.localPosition.x - 270f;
        closure_0.currentSelectElement = chara.Key;
        closure_0.StartCoroutine(closure_0.FilterList(closure_0.CommonElementToFilterTypes(chara.Key)));
      });
      ++num1;
    }
    if (rentalUnitEditMenu1.lastSelectUnitDic == null)
      rentalUnitEditMenu1.lastSelectUnitDic = new Dictionary<CommonElement, int>();
    yield return (object) rentalUnitEditMenu1.StartCoroutine(rentalUnitEditMenu1.FilterList(UnitSortAndFilter.FILTER_TYPES.ElementNone));
    rentalUnitEditMenu1.currentSelectElement = CommonElement.none;
    rentalUnitEditMenu1.tp.from.x = rentalUnitEditMenu1.rentalCharacters[0].transform.localPosition.x - 270f;
    rentalUnitEditMenu1.tp.to.x = rentalUnitEditMenu1.rentalCharacters[0].transform.localPosition.x - 270f;
    rentalUnitEditMenu1.tp.PlayForward();
    PlayerRentalPlayerUnitIds rentalPlayerUnitIds = SMManager.Get<PlayerRentalPlayerUnitIds>();
    if (rentalPlayerUnitIds != null && rentalPlayerUnitIds.rental_player_unit_ids != null)
    {
      for (int index = 0; index < rentalUnitEditMenu1.rentalElementList.Count; ++index)
      {
        if (!rentalUnitEditMenu1.lastSelectUnitDic.ContainsKey(rentalUnitEditMenu1.rentalElementList[index]))
          rentalUnitEditMenu1.lastSelectUnitDic.Add(rentalUnitEditMenu1.rentalElementList[index], rentalPlayerUnitIds.rental_player_unit_ids[index].Value);
      }
    }
    PlayerUnit[] playerUnitArray = SMManager.Get<PlayerUnit[]>();
    foreach (KeyValuePair<CommonElement, int> keyValuePair in rentalUnitEditMenu1.lastSelectUnitDic)
    {
      KeyValuePair<CommonElement, int> unit = keyValuePair;
      if (unit.Value != 0)
      {
        PlayerUnit playerUnit = ((IEnumerable<PlayerUnit>) playerUnitArray).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x.id == unit.Value)).FirstOrDefault<PlayerUnit>();
        rentalUnitEditMenu1.rentalCharatersDic[unit.Key].unit = playerUnit.unit;
        rentalUnitEditMenu1.StartCoroutine(rentalUnitEditMenu1.rentalCharatersDic[unit.Key].SetUnit(playerUnit, playerUnit.GetElement(), false));
        rentalUnitEditMenu1.rentalCharatersDic[unit.Key].BottomModeValue = UnitIconBase.BottomMode.Level;
        rentalUnitEditMenu1.rentalCharatersDic[unit.Key].setLevelText(playerUnit);
      }
    }
    rentalUnitEditMenu1.allDeleteBtn.onClick.Clear();
    // ISSUE: reference to a compiler-generated method
    rentalUnitEditMenu1.allDeleteBtn.onClick.Add(new EventDelegate(new EventDelegate.Callback(rentalUnitEditMenu1.\u003CInitalize\u003Eb__12_2)));
    rentalUnitEditMenu1.okBtn.onClick.Clear();
    // ISSUE: reference to a compiler-generated method
    rentalUnitEditMenu1.okBtn.onClick.Add(new EventDelegate(new EventDelegate.Callback(rentalUnitEditMenu1.\u003CInitalize\u003Eb__12_3)));
    if (!rentalUnitEditMenu1.lastSelectUnitDic.ContainsKey(CommonElement.none) || rentalUnitEditMenu1.lastSelectUnitDic[CommonElement.none] == 0)
    {
      PlayerUnit[] playerUnits1 = playerDeck.player_units;
      if (playerUnits1[0] != (PlayerUnit) null)
      {
        foreach (UnitIconInfo allUnitInfo in rentalUnitEditMenu1.allUnitInfos)
        {
          if (!allUnitInfo.removeButton && allUnitInfo.playerUnit.id == playerUnits1[0].id)
          {
            allUnitInfo.icon.onClick(allUnitInfo.icon);
            break;
          }
        }
      }
    }
    // ISSUE: reference to a compiler-generated method
    rentalUnitEditMenu1.scroll.scrollView.onDragFinished = new UIScrollView.OnDragFinished(rentalUnitEditMenu1.\u003CInitalize\u003Eb__12_4);
    rentalUnitEditMenu1.SetIconState();
  }

  private UnitSortAndFilter.FILTER_TYPES CommonElementToFilterTypes(
    CommonElement type)
  {
    switch (type)
    {
      case CommonElement.none:
        return UnitSortAndFilter.FILTER_TYPES.ElementNone;
      case CommonElement.fire:
        return UnitSortAndFilter.FILTER_TYPES.ElementFire;
      case CommonElement.wind:
        return UnitSortAndFilter.FILTER_TYPES.ElementWind;
      case CommonElement.thunder:
        return UnitSortAndFilter.FILTER_TYPES.ElementThunder;
      case CommonElement.ice:
        return UnitSortAndFilter.FILTER_TYPES.ElementIce;
      case CommonElement.light:
        return UnitSortAndFilter.FILTER_TYPES.ElementLight;
      case CommonElement.dark:
        return UnitSortAndFilter.FILTER_TYPES.ElementDark;
      default:
        return UnitSortAndFilter.FILTER_TYPES.ElementNone;
    }
  }

  private IEnumerator FilterList(UnitSortAndFilter.FILTER_TYPES fliterType)
  {
    Unit004_RentalUnit_Edit_Menu rentalUnitEditMenu1 = this;
    if (!Singleton<PopupManager>.GetInstance().isOpen)
    {
      if ((UnityEngine.Object) rentalUnitEditMenu1.filter == (UnityEngine.Object) null)
      {
        Unit004_RentalUnit_Edit_Menu rentalUnitEditMenu = rentalUnitEditMenu1;
        IEnumerator coroutine = rentalUnitEditMenu1.CreateUnitSortAndFilterPrefab();
        yield return (object) rentalUnitEditMenu1.StartCoroutine(coroutine);
        UnitSortAndFilter filter = (UnitSortAndFilter) coroutine.Current;
        IEnumerator e = filter.Initialize(new System.Action<SortInfo>(((UnitMenuBase) rentalUnitEditMenu1).Sort), rentalUnitEditMenu1.persist, (UnitMenuBase) rentalUnitEditMenu1, rentalUnitEditMenu1.isDispOnlyNormalUnit);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        filter.SortFilterUnitNum = (System.Action<SortInfo>) (x => filter.SetUnitNum(rentalUnitEditMenu.FilterBy(x.filters, x.groupIDs).ToList<UnitIconInfo>(), rentalUnitEditMenu.allUnitInfos));
        coroutine = (IEnumerator) null;
      }
      rentalUnitEditMenu1.filter.SetUnitNum(rentalUnitEditMenu1.displayUnitInfos, rentalUnitEditMenu1.allUnitInfos);
      rentalUnitEditMenu1.filter.gameObject.SetActive(false);
      if (fliterType == UnitSortAndFilter.FILTER_TYPES.ElementNone)
        rentalUnitEditMenu1.filter.SetElementType(true);
      else
        rentalUnitEditMenu1.filter.SetElementType(false);
      rentalUnitEditMenu1.filter.SetFilterType(fliterType, true);
      rentalUnitEditMenu1.filter.IbtnDicision();
    }
  }

  protected override void Sort(SortInfo info)
  {
    base.Sort(info);
    this.SetIconState();
  }

  private IEnumerator CreateUnitSortAndFilterPrefab()
  {
    if ((UnityEngine.Object) this.filter == (UnityEngine.Object) null)
    {
      Future<GameObject> sortPopupPrefabF = Res.Prefabs.popup.popup_Unit_Sort__anim_popup01.Load<GameObject>();
      IEnumerator e = sortPopupPrefabF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.filter = sortPopupPrefabF.Result.Clone(Singleton<CommonRoot>.GetInstance().LoadTmpObj.transform).GetComponent<UnitSortAndFilter>();
      sortPopupPrefabF = (Future<GameObject>) null;
    }
    yield return (object) this.filter;
  }

  protected override void CreateUnitIconCache(int info_index, int unit_index, PlayerUnit baseUnit = null)
  {
    base.CreateUnitIconCache(info_index, unit_index);
    this.SetIconState();
    this.CreateUnitIconAction(info_index, unit_index);
  }

  private void CreateUnitIconAction(int info_index, int unit_index)
  {
    UnitIconBase allUnitIcon = this.allUnitIcons[unit_index];
    if (this.displayUnitInfos[info_index].removeButton)
    {
      allUnitIcon.gameObject.GetComponent<UnitIcon>().SetIconBackColor(this.currentSelectElement == CommonElement.none ? Color.gray : Color.white);
      allUnitIcon.gameObject.GetComponent<UnitIcon>().SetIconBoxCollider(this.currentSelectElement != CommonElement.none);
      allUnitIcon.onClick = (System.Action<UnitIconBase>) (ui =>
      {
        if (this.currentSelectElement == CommonElement.none || !this.lastSelectUnitDic.ContainsKey(this.currentSelectElement) || this.lastSelectUnitDic[this.currentSelectElement] == 0)
          return;
        for (int index = 0; index < this.displayUnitInfos.Count; ++index)
        {
          if (!this.displayUnitInfos[index].removeButton && this.displayUnitInfos[index].playerUnit.id == this.lastSelectUnitDic[this.currentSelectElement])
          {
            this.rentalCharatersDic[this.currentSelectElement].SetEmpty();
            this.rentalCharatersDic[this.currentSelectElement].unit = (UnitUnit) null;
            this.lastSelectUnitDic[this.currentSelectElement] = 0;
            break;
          }
        }
        this.SetIconState();
      });
    }
    else
    {
      allUnitIcon.gameObject.GetComponent<UnitIcon>().SetIconBoxCollider(true);
      allUnitIcon.onClick = (System.Action<UnitIconBase>) (ui =>
      {
        if (!ui.Selected)
        {
          this.rentalCharatersDic[this.currentSelectElement].unit = ui.PlayerUnit.unit;
          this.StartCoroutine(this.rentalCharatersDic[this.currentSelectElement].SetUnit(ui.PlayerUnit, ui.PlayerUnit.GetElement(), false));
          this.rentalCharatersDic[this.currentSelectElement].BottomModeValue = UnitIconBase.BottomMode.Level;
          this.rentalCharatersDic[this.currentSelectElement].setLevelText(ui.PlayerUnit);
          if (!this.lastSelectUnitDic.ContainsKey(this.currentSelectElement))
            this.lastSelectUnitDic.Add(this.currentSelectElement, ui.PlayerUnit.id);
          else
            this.lastSelectUnitDic[this.currentSelectElement] = ui.PlayerUnit.id;
        }
        else
        {
          if (this.currentSelectElement == CommonElement.none || this.lastSelectUnitDic.ContainsKey(CommonElement.none) && this.lastSelectUnitDic[CommonElement.none] == ui.PlayerUnit.id)
            return;
          this.rentalCharatersDic[this.currentSelectElement].SetEmpty();
          this.rentalCharatersDic[this.currentSelectElement].unit = (UnitUnit) null;
          this.lastSelectUnitDic[this.currentSelectElement] = 0;
        }
        this.SetIconState();
      });
    }
  }

  private void ClearRentalCharacters()
  {
    foreach (KeyValuePair<CommonElement, UnitIcon> keyValuePair in this.rentalCharatersDic)
    {
      if (keyValuePair.Key != CommonElement.none)
      {
        keyValuePair.Value.SetEmpty();
        keyValuePair.Value.unit = (UnitUnit) null;
      }
    }
    for (int index = 1; index < this.rentalElementList.Count; ++index)
    {
      if (this.lastSelectUnitDic.ContainsKey(this.rentalElementList[index]))
        this.lastSelectUnitDic[this.rentalElementList[index]] = 0;
    }
    this.SetIconState();
  }

  protected override IEnumerator ShowSortAndFilterPopup()
  {
    Unit004_RentalUnit_Edit_Menu rentalUnitEditMenu = this;
    if (!Singleton<PopupManager>.GetInstance().isOpen)
    {
      if ((UnityEngine.Object) rentalUnitEditMenu.filter == (UnityEngine.Object) null)
      {
        IEnumerator coroutine = rentalUnitEditMenu.CreateUnitSortAndFilterPrefab();
        yield return (object) rentalUnitEditMenu.StartCoroutine(coroutine);
        rentalUnitEditMenu.filter = (UnitSortAndFilter) coroutine.Current;
        IEnumerator e = rentalUnitEditMenu.filter.GetComponent<UnitSortAndFilter>().Initialize(new System.Action<SortInfo>(((UnitMenuBase) rentalUnitEditMenu).Sort), rentalUnitEditMenu.persist, (UnitMenuBase) rentalUnitEditMenu, rentalUnitEditMenu.isDispOnlyNormalUnit, rentalUnitEditMenu.isFriendSupport);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        // ISSUE: reference to a compiler-generated method
        rentalUnitEditMenu.filter.SortFilterUnitNum = new System.Action<SortInfo>(rentalUnitEditMenu.\u003CShowSortAndFilterPopup\u003Eb__20_0);
        coroutine = (IEnumerator) null;
      }
      rentalUnitEditMenu.filter.SetUnitNum(rentalUnitEditMenu.displayUnitInfos, rentalUnitEditMenu.allUnitInfos);
      rentalUnitEditMenu.filter.gameObject.SetActive(false);
      Singleton<PopupManager>.GetInstance().open(rentalUnitEditMenu.filter.gameObject, isCloned: true);
      rentalUnitEditMenu.filter.SetFriendSupportCurrentElement(rentalUnitEditMenu.currentSelectElement, true);
      rentalUnitEditMenu.filter.gameObject.SetActive(true);
    }
    else
      rentalUnitEditMenu.IsPush = false;
  }

  private UnitIcon CreateUnitObject(GameObject parent)
  {
    UnitIcon component = UnityEngine.Object.Instantiate<GameObject>(this.unitPrefab, new Vector3(10000f, 0.0f, 0.0f), new Quaternion()).GetComponent<UnitIcon>();
    GameObject gameObject = component.gameObject;
    gameObject.SetActive(true);
    parent.transform.Clear();
    gameObject.transform.parent = parent.transform;
    gameObject.transform.localPosition = Vector3.zero;
    UIWidget componentInChildren = parent.GetComponentInChildren<UIWidget>();
    gameObject.GetComponentInChildren<UnitIcon>().SetSize(componentInChildren.width, componentInChildren.height);
    return component;
  }

  public override void onBackButton() => this.onClickedClose();

  public void onClickedClose()
  {
    if (Singleton<CommonRoot>.GetInstance().isLoading || this.IsPushAndSet())
      return;
    this.backScene();
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
    if (!this.scroll.scrollView.isDragging)
      return;
    this.SetIconState();
  }

  private void SetIconState()
  {
    this.lastSelectUnitDic.Values.ToArray<int>();
    for (int index = 0; index < this.displayUnitInfos.Count; ++index)
    {
      if (this.displayUnitInfos[index].removeButton)
      {
        if (this.allUnitIcons[0].unit == null)
          this.allUnitIcons[0].BottomBaseObject = false;
      }
      else if ((UnityEngine.Object) this.displayUnitInfos[index].icon != (UnityEngine.Object) null)
      {
        this.displayUnitInfos[index].icon.CanAwake = false;
        if (this.GetIconState(this.displayUnitInfos[index], this.currentSelectElement))
        {
          this.displayUnitInfos[index].icon.UnitRental = true;
          this.displayUnitInfos[index].icon.Select(0);
          this.displayUnitInfos[index].icon.HideCheckIcon();
          this.displayUnitInfos[index].icon.blinkDeckStatus.gameObject.SetActive(true);
        }
        else
        {
          this.displayUnitInfos[index].icon.UnitRental = false;
          this.displayUnitInfos[index].icon.blinkDeckStatus.gameObject.SetActive(false);
          this.displayUnitInfos[index].icon.Deselect();
        }
      }
    }
  }

  private bool GetIconState(UnitIconInfo info, CommonElement element) => this.lastSelectUnitDic.ContainsKey(element) && info.playerUnit.id == this.lastSelectUnitDic[element];
}
