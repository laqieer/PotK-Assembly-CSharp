// Decompiled with JetBrains decompiler
// Type: Unit0046Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Unit0046Menu : BackButtonMenuBase
{
  protected const float LINK_HEIGHT = 100f;
  protected const float LINK_DEFHEIGHT = 136f;
  protected const float scale = 0.7352941f;
  private DateTime serverTime = DateTime.MinValue;
  [SerializeField]
  protected UILabel TxtTitle;
  public GameObject TopObject;
  public GameObject MiddleObject;
  public UILabel TxtCostValue;
  public UILabel TxtCombat;
  public UILabel TxtTeamNum;
  public NGHorizontalScrollParts indicator;
  private PlayerDeck[] playerDecks;
  private Promise<int?[]> player_unit_ids = new Promise<int?[]>();
  private GameObject prefabResult;
  private PlayerDeck SelectDeck;
  public GameObject[] playerItems;
  public UIButton[] buttons = new UIButton[5];
  public Transform[] ui3DModelTransfrom;
  public GameObject[] ui3DModelLoadDummy;
  public List<UI3DModel> ui3DModels;
  public List<GameObject> Models = new List<GameObject>();
  public GameObject ui3DModelPrefab;
  private int cost_max;
  public bool play;
  public bool coroutine;
  public bool stop;
  public int old_indicator_select = -1;
  public GameObject backButton;
  public CoroutineData<bool> modelChange;
  public bool fromVersus;
  public ColosseumUtility.Info info;
  private bool ChangeBackScene;

  public DateTime SevertTime
  {
    get => this.serverTime;
    set => this.serverTime = value;
  }

  [DebuggerHidden]
  private IEnumerator WaitScrollSe()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Menu.\u003CWaitScrollSe\u003Ec__Iterator2E4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShouldStop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Menu.\u003CShouldStop\u003Ec__Iterator2E5()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void SetTeamInfo(PlayerDeck deck)
  {
    this.TxtCostValue.SetTextLocalize(Consts.Format(Consts.GetInstance().UNIT_0046_COST, (IDictionary) new Hashtable()
    {
      {
        (object) "now",
        (object) deck.cost
      },
      {
        (object) "max",
        (object) this.cost_max
      }
    }));
    int combat = 0;
    ((IEnumerable<PlayerUnit>) deck.player_units).ForEach<PlayerUnit>((Action<PlayerUnit>) (x =>
    {
      if (!(x != (PlayerUnit) null))
        return;
      combat += Judgement.NonBattleParameter.FromPlayerUnit(x).Combat;
    }));
    this.TxtCombat.SetTextLocalize(combat.ToString());
    this.TxtTeamNum.SetTextLocalize(Consts.Format(Consts.GetInstance().UNIT_0046_MENU, (IDictionary) new Hashtable()
    {
      {
        (object) "num",
        (object) (this.indicator.selected + 1)
      }
    }));
  }

  protected override void Update()
  {
    if (this.playerDecks == null || this.indicator.selected >= this.playerDecks.Length || this.indicator.selected < 0)
      return;
    base.Update();
    if (this.SelectDeck != null && this.playerDecks[this.indicator.selected] == this.SelectDeck)
      return;
    this.SelectDeck = this.playerDecks[this.indicator.selected];
    this.charaActive(this.SelectDeck);
    if (this.old_indicator_select != this.indicator.selected)
    {
      this.StopCoroutine("ShouldStop");
      this.StartCoroutine("ShouldStop");
    }
    this.SetTeamInfo(this.SelectDeck);
  }

  [DebuggerHidden]
  public IEnumerator Init3DModelPrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Menu.\u003CInit3DModelPrefab\u003Ec__Iterator2E6()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ModelChange()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Menu.\u003CModelChange\u003Ec__Iterator2E7()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator OneProcessDestroy()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Menu.\u003COneProcessDestroy\u003Ec__Iterator2E8()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator StartDestroyPoolableObject(GameObject go)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Menu.\u003CStartDestroyPoolableObject\u003Ec__Iterator2E9()
    {
      go = go,
      \u003C\u0024\u003Ego = go
    };
  }

  [DebuggerHidden]
  public IEnumerator InitPlayerDecks(PlayerDeck[] _playerDecks)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Menu.\u003CInitPlayerDecks\u003Ec__Iterator2EA()
    {
      _playerDecks = _playerDecks,
      \u003C\u0024\u003E_playerDecks = _playerDecks,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator AddDeck(PlayerDeck playerDeck, GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Menu.\u003CAddDeck\u003Ec__Iterator2EB()
    {
      prefab = prefab,
      playerDeck = playerDeck,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003EplayerDeck = playerDeck,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator UpdateDeck(int index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Menu.\u003CUpdateDeck\u003Ec__Iterator2EC()
    {
      index = index,
      \u003C\u0024\u003Eindex = index,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitPlayerItems(PlayerItem[] items)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Menu.\u003CInitPlayerItems\u003Ec__Iterator2ED()
    {
      items = items,
      \u003C\u0024\u003Eitems = items,
      \u003C\u003Ef__this = this
    };
  }

  public void charaActive(PlayerDeck pDeck)
  {
    int index = 0;
    QuestScoreBonusTimetable[] array = ((IEnumerable<QuestScoreBonusTimetable>) SMManager.Get<QuestScoreBonusTimetable[]>()).Where<QuestScoreBonusTimetable>((Func<QuestScoreBonusTimetable, bool>) (x => x.start_at < this.SevertTime && x.end_at > this.SevertTime)).ToArray<QuestScoreBonusTimetable>();
    foreach (PlayerUnit playerUnit in pDeck.player_units)
    {
      if (playerUnit == (PlayerUnit) null)
        ((Component) this.buttons[index]).GetComponent<Unit0046Character>().CharaSetActive(false, false);
      else
        ((Component) this.buttons[index]).GetComponent<Unit0046Character>().CharaSetActive(true, playerUnit.IsSpecialEffectForRankingEvent(array));
      ++index;
    }
  }

  public void chara3DActive(int deck_index)
  {
  }

  public void CharacterChange(int num)
  {
    Unit0046Menu.OneFormationInfo info = new Unit0046Menu.OneFormationInfo();
    info.playerDeck = this.playerDecks[this.indicator.selected];
    this.player_unit_ids = new Promise<int?[]>();
    info.player_unit_ids = this.player_unit_ids;
    info.num = num;
    ModelUnits.Instance.DestroyModelUnits();
    Unit00468Scene.changeScene004682(true, info);
  }

  public void DetailSceneChange(int num)
  {
    if (this.playerDecks[this.indicator.selected].player_units[num] == (PlayerUnit) null)
      this.CharacterChange(num);
    else
      Unit0042Scene.changeScene(true, this.playerDecks[this.indicator.selected].player_units[num], this.playerDecks[this.indicator.selected].player_units);
  }

  public void OnEnable()
  {
  }

  public void OnDisable()
  {
    this.ui3DModels.ForEach((Action<UI3DModel>) (obj =>
    {
      if (!Object.op_Inequality((Object) obj, (Object) null) || !Object.op_Inequality((Object) obj.model_creater_, (Object) null))
        return;
      obj.DestroyModelCamera();
    }));
    this.ui3DModels.ForEach((Action<UI3DModel>) (obj =>
    {
      if (!Object.op_Inequality((Object) obj, (Object) null) || !Object.op_Inequality((Object) ((Component) obj).gameObject, (Object) null) || !(((Object) ((Component) obj).gameObject).name == "slc_3DModel(Clone)"))
        return;
      Object.Destroy((Object) ((Component) obj).gameObject);
    }));
    ModelUnits.Instance.DestroyModelUnits();
    this.ui3DModels.Clear();
    this.Models.Clear();
  }

  public void onEndScene()
  {
    if (Singleton<NGGameDataManager>.GetInstance().IsColosseum)
    {
      if (!this.ChangeBackScene)
      {
        Persist.colosseumDeckOrganized.Data.number = Mathf.Clamp(this.indicator.selected, 0, this.playerDecks.Length - 1);
        Persist.colosseumDeckOrganized.Flush();
      }
    }
    else if (this.fromVersus)
    {
      if (!this.ChangeBackScene)
      {
        Persist.versusDeckOrganized.Data.number = Mathf.Clamp(this.indicator.selected, 0, this.playerDecks.Length - 1);
        Persist.versusDeckOrganized.Flush();
      }
    }
    else
    {
      Persist.deckOrganized.Data.number = Mathf.Clamp(this.indicator.selected, 0, this.playerDecks.Length - 1);
      Persist.deckOrganized.Flush();
    }
    this.fromVersus = false;
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    if (Singleton<NGGameDataManager>.GetInstance().IsColosseum)
    {
      Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
      int num = !(((IEnumerable<PlayerUnit>) this.SelectDeck.player_units).FirstOrDefault<PlayerUnit>() != (PlayerUnit) null) ? 0 : Mathf.Clamp(this.indicator.selected, 0, this.playerDecks.Length - 1);
      Persist.colosseumDeckOrganized.Data.number = num;
      Persist.colosseumDeckOrganized.Flush();
      this.ChangeBackScene = true;
      Singleton<CommonRoot>.GetInstance().SetFooterEnable(true);
      Colosseum0234Scene.ChangeScene(this.info);
    }
    else if (this.fromVersus)
    {
      int num = !(((IEnumerable<PlayerUnit>) this.SelectDeck.player_units).FirstOrDefault<PlayerUnit>() != (PlayerUnit) null) ? 0 : Mathf.Clamp(this.indicator.selected, 0, this.playerDecks.Length - 1);
      Persist.versusDeckOrganized.Data.number = num;
      Persist.versusDeckOrganized.Flush();
      this.ChangeBackScene = true;
      this.backScene();
    }
    else
      this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnEquip()
  {
    if (this.IsPushAndSet())
      return;
    PlayerDeck playerDeck = this.playerDecks[this.indicator.selected];
    this.player_unit_ids = new Promise<int?[]>();
    Unit00468Scene.changeScene00468(true, playerDeck, this.player_unit_ids);
  }

  public virtual void IbtnItemedit()
  {
    if (this.IsPushAndSet())
      return;
    Quest00210Scene.changeScene(true);
  }

  public class OneFormationInfo
  {
    public Promise<int?[]> player_unit_ids;
    public int num;

    public PlayerDeck playerDeck { get; set; }
  }
}
