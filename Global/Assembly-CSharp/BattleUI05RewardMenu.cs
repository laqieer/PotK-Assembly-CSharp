// Decompiled with JetBrains decompiler
// Type: BattleUI05RewardMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI05RewardMenu : ResultMenuBase
{
  private const float LINK_WIDTH = 136f;
  private const float LINK_DEFWIDTH = 136f;
  private const float scale = 1f;
  [SerializeField]
  private GameObject mainObject;
  [SerializeField]
  private GameObject mainTitleObject;
  [SerializeField]
  private GameObject Title;
  [SerializeField]
  private GameObject Grid;
  [SerializeField]
  private GameObject ScrollView;
  [SerializeField]
  private GameObject NoneMessage;
  private GameObject mUnitPrefab;
  private GameObject mGearPrefab;
  private GameObject mSupplyPrefab;
  public GameObject Prefab;
  private NGSoundManager SM;
  private List<BattleUI05RewardMenu.Reward> PlayRewards = new List<BattleUI05RewardMenu.Reward>();

  public override void OnDestroy()
  {
    this.PlayRewards.Clear();
    base.OnDestroy();
  }

  private void Awake() => this.SM = Singleton<NGSoundManager>.GetInstance();

  [DebuggerHidden]
  public override IEnumerator Init(BattleInfo info, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05RewardMenu.\u003CInit\u003Ec__Iterator76C()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05RewardMenu.\u003CRun\u003Ec__Iterator76D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator OnFinish()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05RewardMenu.\u003COnFinish\u003Ec__Iterator76E()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void AddReward(
    object master,
    bool is_new,
    int quantity,
    int entity_id,
    int entity_type)
  {
    this.PlayRewards.Add(new BattleUI05RewardMenu.Reward()
    {
      master = master,
      is_new = is_new,
      quantity = quantity,
      entity_id = entity_id,
      entity_type = entity_type
    });
  }

  [DebuggerHidden]
  public IEnumerator SetReward()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05RewardMenu.\u003CSetReward\u003Ec__Iterator76F()
    {
      \u003C\u003Ef__this = this
    };
  }

  private GameObject CreateUnknownUnit(Transform parent = null)
  {
    GameObject unknownUnit = this.mUnitPrefab.Clone(parent);
    UnitIcon component = unknownUnit.GetComponent<UnitIcon>();
    component.BottomModeValue = UnitIcon.BottomMode.Nothing;
    component.BackgroundModeValue = UnitIcon.BackgroundMode.PlayerShadow;
    component.Unknown = true;
    component.NewUnit = false;
    ((Component) ((Component) component).transform.FindChild("icon")).gameObject.SetActive(false);
    Transform child = ((Component) component).transform.FindChild("back").FindChild("silhouette");
    child.localPosition = new Vector3()
    {
      x = child.localPosition.x,
      y = child.localPosition.y + 6f,
      z = child.localPosition.z
    };
    return unknownUnit;
  }

  private GameObject CreateUnknownItem(Transform parent = null)
  {
    GameObject unknownItem = this.mGearPrefab.Clone(parent);
    ItemIcon component = unknownItem.GetComponent<ItemIcon>();
    component.SetEmpty(true);
    component.gear.unknown.SetActive(true);
    component.BottomModeValue = ItemIcon.BottomMode.Nothing;
    return unknownItem;
  }

  private EventDelegate.Callback UnitClickEvent(PlayerUnit unit, bool isNew)
  {
    return (EventDelegate.Callback) (() => { });
  }

  private EventDelegate.Callback GearClickEvent(PlayerItem item, bool isNew)
  {
    return (EventDelegate.Callback) (() => { });
  }

  [DebuggerHidden]
  private IEnumerator InitPopup(GameObject popup, IEnumerator setter)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05RewardMenu.\u003CInitPopup\u003Ec__Iterator770()
    {
      popup = popup,
      setter = setter,
      \u003C\u0024\u003Epopup = popup,
      \u003C\u0024\u003Esetter = setter,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator OpenRewardIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05RewardMenu.\u003COpenRewardIcon\u003Ec__Iterator771()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void DisableReward()
  {
    this.mainObject.SetActive(false);
    this.mainTitleObject.SetActive(false);
  }

  private class Reward
  {
    public GameObject unknownObject;
    public GameObject gameObject;
    public object master;
    public bool is_new;
    public int quantity;
    public int entity_id;
    public int entity_type;
  }
}
