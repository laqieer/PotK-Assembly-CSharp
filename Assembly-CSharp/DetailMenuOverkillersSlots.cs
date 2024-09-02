// Decompiled with JetBrains decompiler
// Type: DetailMenuOverkillersSlots
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
using UnitDetails;
using UnityEngine;

public class DetailMenuOverkillersSlots : MonoBehaviour
{
  [SerializeField]
  [Tooltip("未設定|未開錠時表示")]
  private GameObject[] notsets_;
  [SerializeField]
  [Tooltip("空設定")]
  private GameObject[] spaces_;
  [SerializeField]
  private UIButton[] buttons_;
  [SerializeField]
  [Tooltip("設定したユニットアイコンの親")]
  private GameObject[] links_;
  [SerializeField]
  [Tooltip("未開錠表示オリジナル")]
  private EffectOverkillersSlotLock effectLock_;
  [SerializeField]
  [Tooltip("本表示を隠す際にOFFにする")]
  private GameObject[] objHide_;
  private GameObject popupReleasePrefab_;
  private PlayerUnit playerUnit_;
  private OverkillersSlotRelease.Conditions[] conditions_;
  private bool activeEdit_;
  private bool activeMove_;
  private EffectOverkillersSlotLock[] effects_;
  private bool[] effectRunnings_;
  private UnitIcon[] icons_;
  private bool getSEASkill_;

  public bool isHide
  {
    get => !this.objHide_[0].activeSelf;
    set
    {
      if (this.isHide == value)
        return;
      bool flag = !value;
      for (int index = 0; index < this.objHide_.Length; ++index)
        this.objHide_[index].SetActive(flag);
    }
  }

  private void Awake() => this.effectLock_.gameObject.SetActive(false);

  public IEnumerator initialize(
    GameObject popupReleasePrefab,
    GameObject unitPrefab,
    PlayerUnit playerUnit,
    OverkillersSlotRelease.Conditions[] releaseConditions,
    Control controlFlags)
  {
    this.popupReleasePrefab_ = popupReleasePrefab;
    this.playerUnit_ = playerUnit;
    this.conditions_ = releaseConditions;
    this.activeEdit_ = (controlFlags & (Control.OverkillersEdit | Control.CustomDeck)) == Control.OverkillersEdit;
    this.activeMove_ = controlFlags.IsOn(Control.OverkillersMove);
    bool bInfoEquipStatus = controlFlags.IsOff(Control.SelfAbility);
    if (!bInfoEquipStatus)
    {
      this.activeEdit_ = false;
      this.activeMove_ = false;
    }
    if (this.effects_ == null)
    {
      this.effects_ = new EffectOverkillersSlotLock[this.links_.Length];
      this.effectRunnings_ = new bool[this.links_.Length];
      this.icons_ = new UnitIcon[this.links_.Length];
    }
    for (int n = 0; n < this.effects_.Length; ++n)
    {
      if (this.effectRunnings_[n])
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this.effects_[n].gameObject);
        this.effects_[n] = (EffectOverkillersSlotLock) null;
        this.effectRunnings_[n] = false;
      }
      if (releaseConditions == null || releaseConditions.Length <= n)
      {
        if ((UnityEngine.Object) this.effects_[n] != (UnityEngine.Object) null)
          this.effects_[n].gameObject.SetActive(false);
        this.notsets_[n].SetActive(false);
        this.spaces_[n].SetActive(true);
        this.buttons_[n].isEnabled = false;
        if ((UnityEngine.Object) this.icons_[n] != (UnityEngine.Object) null)
          this.icons_[n].gameObject.SetActive(false);
      }
      else
      {
        this.spaces_[n].SetActive(false);
        bool flag = true;
        this.buttons_[n].isEnabled = this.activeEdit_ || this.activeMove_;
        if (playerUnit.isReleasedOverkillersSlot(n))
        {
          if ((UnityEngine.Object) this.effects_[n] != (UnityEngine.Object) null)
            this.effects_[n].gameObject.SetActive(false);
          PlayerUnit[] overkillersUnits = playerUnit.cache_overkillers_units;
          int num = overkillersUnits != null ? overkillersUnits.Length : 0;
          PlayerUnit playerUnit1 = !bInfoEquipStatus || num <= n ? (PlayerUnit) null : playerUnit.cache_overkillers_units[n];
          if (playerUnit1 != (PlayerUnit) null)
          {
            if ((UnityEngine.Object) this.icons_[n] == (UnityEngine.Object) null)
            {
              this.icons_[n] = unitPrefab.Clone(this.links_[n].transform).GetComponent<UnitIcon>();
              this.icons_[n].buttonBoxCollider.enabled = false;
            }
            this.icons_[n].gameObject.SetActive(true);
            UnitIcon icon = this.icons_[n];
            yield return (object) icon.SetUnit(playerUnit1, playerUnit1.GetElement(), false);
            icon.ShowBottomInfo(UnitSortAndFilter.SORT_TYPES.Level);
            flag = false;
            icon = (UnitIcon) null;
          }
          else if ((UnityEngine.Object) this.icons_[n] != (UnityEngine.Object) null)
            this.icons_[n].gameObject.SetActive(false);
        }
        else
        {
          if ((UnityEngine.Object) this.icons_[n] != (UnityEngine.Object) null)
            this.icons_[n].gameObject.SetActive(false);
          if ((UnityEngine.Object) this.effects_[n] == (UnityEngine.Object) null)
            this.effects_[n] = this.effectLock_.gameObject.Clone(this.links_[n].transform.parent).GetComponent<EffectOverkillersSlotLock>();
          this.effects_[n].initialize(releaseConditions[n].unity_value, this.activeEdit_);
        }
        this.notsets_[n].SetActive(flag);
      }
    }
  }

  public void onClickedSlot0() => this.onClickedSlot(0);

  public void onLongPressedSlot0() => this.onLongPressedSlot(0);

  public void onClickedSlot1() => this.onClickedSlot(1);

  public void onLongPressedSlot1() => this.onLongPressedSlot(1);

  public void onClickedSlot2() => this.onClickedSlot(2);

  public void onLongPressedSlot2() => this.onLongPressedSlot(2);

  public void onClickedSlot3() => this.onClickedSlot(3);

  public void onLongPressedSlot3() => this.onLongPressedSlot(3);

  private void onClickedSlot(int no)
  {
    if (!this.activeEdit_ || this.getSEASkill_)
      return;
    if (this.playerUnit_.isReleasedOverkillersSlot(no))
    {
      Unit004OverkillersSlotUnitSelectScene.changeScene(this.playerUnit_, no, this.playerUnit_.cache_overkillers_units[no], new System.Action<PlayerUnit>(this.onSelectedUnit));
    }
    else
    {
      if ((UnityEngine.Object) this.effects_[no] == (UnityEngine.Object) null || this.effectRunnings_[no] || !((UnityEngine.Object) this.popupReleasePrefab_ != (UnityEngine.Object) null))
        return;
      bool[] slot_locks = new bool[this.conditions_.Length];
      for (int slot_no = 0; slot_no < slot_locks.Length; ++slot_no)
        slot_locks[slot_no] = !this.playerUnit_.isReleasedOverkillersSlot(slot_no);
      PopupOverkillersSlotRelease.show(this.popupReleasePrefab_, this.playerUnit_, no, slot_locks, this.conditions_[no], (System.Action) (() => this.StartCoroutine(this.doOverkillersSlotRelease(no))));
    }
  }

  private IEnumerator doOverkillersSlotRelease(int no)
  {
    DetailMenuOverkillersSlots overkillersSlots = this;
    Singleton<CommonRoot>.GetInstance().ShowLoadingLayer(1);
    Unit0042Menu inParents = NGUITools.FindInParents<Unit0042Menu>(overkillersSlots.gameObject);
    if ((UnityEngine.Object) inParents != (UnityEngine.Object) null)
    {
      bool bWait = true;
      inParents.UploadFavorites((System.Action) (() => bWait = false));
      while (bWait)
        yield return (object) null;
    }
    IEnumerator e = overkillersSlots.doUnlockSlot(no);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  private void onLongPressedSlot(int no)
  {
    if (!this.activeMove_ || !this.playerUnit_.isReleasedOverkillersSlot(no) || this.playerUnit_.cache_overkillers_units[no] == (PlayerUnit) null)
      return;
    Unit0042Menu inParents = NGUITools.FindInParents<Unit0042Menu>(this.gameObject);
    if (!((UnityEngine.Object) inParents != (UnityEngine.Object) null))
      return;
    inParents.moveUnitPage(this.playerUnit_.cache_overkillers_units[no].id, this.buttons_[no].gameObject);
  }

  private void onSelectedUnit(PlayerUnit unit)
  {
  }

  private IEnumerator doUnlockSlot(int no)
  {
    this.getSEASkill_ = false;
    Future<WebAPI.Response.UnitReleaseFrameOverKillers> future = WebAPI.UnitReleaseFrameOverKillers(this.playerUnit_.id, this.getConditionsMaterialIds(no), no, (System.Action<WebAPI.Response.UserError>) (e =>
    {
      WebAPI.DefaultUserErrorCallback(e);
      MypageScene.ChangeSceneOnError();
    }));
    yield return (object) future.Wait();
    if (future.Result != null)
    {
      if (GuildUtil.gvgPopupState != GuildUtil.GvGPopupState.None)
        yield return (object) GuildUtil.UpdateGuildDeck();
      Singleton<CommonRoot>.GetInstance().HideLoadingLayer();
      Singleton<PopupManager>.GetInstance().open((GameObject) null, isViewBack: false);
      yield return (object) new WaitForSeconds(0.5f);
      if (no == PlayerUnit.SEASkillUnlockConditions - 1)
      {
        UnitSEASkill unitSkill = ((IEnumerable<UnitSEASkill>) MasterData.UnitSEASkillList).FirstOrDefault<UnitSEASkill>((Func<UnitSEASkill, bool>) (x => x.ID == this.playerUnit_.unit.same_character_id));
        IEnumerator e = MasterData.LoadScriptScript(unitSkill.script_id);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        if (MasterData.ScriptScript != null && MasterData.ScriptScript.ContainsKey(unitSkill.script_id) || unitSkill.skill_1_BattleskillSkill.HasValue)
          this.getSEASkill_ = true;
        unitSkill = (UnitSEASkill) null;
      }
      this.effectRunnings_[no] = true;
      this.effects_[no].startUnlock((System.Action) (() => this.onFinishedEffectUnlock(no)));
    }
  }

  private int[] getConditionsMaterialIds(int no)
  {
    PlayerMaterialUnit[] playerMaterials = this.conditions_[no].getPlayerMaterials();
    int[] numArray = new int[playerMaterials.Length];
    for (int index = 0; index < playerMaterials.Length; ++index)
      numArray[index] = playerMaterials[index].id;
    return numArray;
  }

  private void onFinishedEffectUnlock(int no)
  {
    UnityEngine.Object.Destroy((UnityEngine.Object) this.effects_[no].gameObject);
    this.effects_[no] = (EffectOverkillersSlotLock) null;
    this.effectRunnings_[no] = false;
    if (no == PlayerUnit.SEASkillUnlockConditions - 1 && this.getSEASkill_)
    {
      Unit0042SEASkillReleaseScene.changeScene(true, this.playerUnit_.unit.ID, this.playerUnit_.unit.same_character_id);
    }
    else
    {
      Singleton<PopupManager>.GetInstance().dismiss();
      Singleton<PopupManager>.GetInstance().monitorCoroutine(this.doUpdateUnits());
    }
  }

  private IEnumerator doUpdateUnits()
  {
    Unit0042Menu menu = NGUITools.FindInParents<Unit0042Menu>(this.gameObject);
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      Singleton<PopupManager>.GetInstance().open((GameObject) null, isViewBack: false);
      yield return (object) null;
      PlayerUnit[] array = SMManager.Get<PlayerUnit[]>();
      PlayerUnit[] playerUnits = new PlayerUnit[menu.UnitList.Length];
      for (int index = 0; index < menu.UnitList.Length; ++index)
      {
        int tid = menu.UnitList[index].id;
        playerUnits[index] = Array.Find<PlayerUnit>(array, (Predicate<PlayerUnit>) (x => x.id == tid));
      }
      yield return (object) menu.UpdateAllPage(playerUnits);
      yield return (object) null;
      Singleton<PopupManager>.GetInstance().dismiss();
    }
  }
}
