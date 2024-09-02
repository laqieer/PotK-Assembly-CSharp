// Decompiled with JetBrains decompiler
// Type: ResultMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class ResultMenuBase : NGMenuBase
{
  protected GameObject DirUnitPrefab;
  protected int mvp_index = -1;
  protected int questSID = -1;
  protected CommonQuestType questType = CommonQuestType.Story;
  protected Dictionary<int, PlayerUnit> beforeUnits;
  protected Dictionary<int, PlayerUnit> afterUnits;
  protected Dictionary<int, PlayerItem> beforeGears;
  protected Dictionary<int, PlayerItem> afterGears;
  protected List<BattleEndPlayer_character_intimates_in_battle> characterIntimates = new List<BattleEndPlayer_character_intimates_in_battle>();
  protected List<UnlockIntimateSkill> unlockIntimateSkills;
  protected List<int> unlockCharacterQuestIDS = new List<int>();
  protected List<int> unlockHarmonyQuestIDS = new List<int>();
  protected List<PlayerItem> disappearedPlayerGears = new List<PlayerItem>();
  [SerializeField]
  protected GameObject DirUnitExp;
  [SerializeField]
  protected GameObject[] DirUnit;
  protected string CharacterIntimateUpPrefabName = "Prefabs/battle/popup_020_22_1__anim_popup01";

  public virtual void OnDestroy()
  {
    this.DirUnitPrefab = (GameObject) null;
    if (this.beforeUnits != null)
      this.beforeUnits.Clear();
    if (this.afterUnits != null)
      this.afterUnits.Clear();
    if (this.beforeGears != null)
      this.beforeGears.Clear();
    if (this.afterGears != null)
      this.afterGears.Clear();
    if (this.characterIntimates != null)
      this.characterIntimates.Clear();
    if (this.unlockCharacterQuestIDS != null)
      this.unlockCharacterQuestIDS.Clear();
    if (this.unlockHarmonyQuestIDS != null)
      this.unlockHarmonyQuestIDS.Clear();
    if (this.disappearedPlayerGears == null)
      return;
    this.disappearedPlayerGears.Clear();
  }

  [DebuggerHidden]
  private IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResultMenuBase.\u003CInit\u003Ec__Iterator606()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator Init(GameCore.BattleInfo info, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResultMenuBase.\u003CInit\u003Ec__Iterator607()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator Init(GameCore.BattleInfo info, BattleEnd result, int index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResultMenuBase.\u003CInit\u003Ec__Iterator608()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator Init(WebAPI.Response.GvgBattleFinish battleResultData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResultMenuBase.\u003CInit\u003Ec__Iterator609()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator Init(
    ColosseumUtility.Info info,
    ResultMenuBase.Param param,
    Gladiator gladiator)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResultMenuBase.\u003CInit\u003Ec__Iterator60A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator Init(WebAPI.Response.PvpPlayerFinish info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResultMenuBase.\u003CInit\u003Ec__Iterator60B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator Init(WebAPI.Response.EventTop eventTopInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResultMenuBase.\u003CInit\u003Ec__Iterator60C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator Init(int a)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResultMenuBase.\u003CInit\u003Ec__Iterator60D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ResultMenuBase.\u003CRun\u003Ec__Iterator60E runCIterator60E = new ResultMenuBase.\u003CRun\u003Ec__Iterator60E();
    return (IEnumerator) runCIterator60E;
  }

  [DebuggerHidden]
  public virtual IEnumerator OnFinish()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ResultMenuBase.\u003COnFinish\u003Ec__Iterator60F finishCIterator60F = new ResultMenuBase.\u003COnFinish\u003Ec__Iterator60F();
    return (IEnumerator) finishCIterator60F;
  }

  public GameObject OpenPopup(GameObject original)
  {
    GameObject gameObject = Singleton<PopupManager>.GetInstance().open(original);
    ((Component) gameObject.transform.parent.Find("Popup Mask")).gameObject.GetComponent<TweenAlpha>().to = 0.75f;
    return gameObject;
  }

  public virtual GameObject CreateTouchObject(EventDelegate.Callback callback, Transform parent = null)
  {
    Resolution currentResolution = Screen.currentResolution;
    GameObject touchObject = new GameObject("touch object");
    touchObject.transform.parent = parent ?? ((Component) this).transform;
    UIWidget uiWidget = touchObject.AddComponent<UIWidget>();
    uiWidget.depth = 1000;
    uiWidget.width = ((Resolution) ref currentResolution).height;
    uiWidget.height = ((Resolution) ref currentResolution).width;
    BoxCollider boxCollider = touchObject.AddComponent<BoxCollider>();
    ((Collider) boxCollider).isTrigger = true;
    boxCollider.size = new Vector3()
    {
      x = (float) ((Resolution) ref currentResolution).height,
      y = (float) ((Resolution) ref currentResolution).width,
      z = 1f
    };
    UIButton uiButton = touchObject.AddComponent<UIButton>();
    uiButton.tweenTarget = (GameObject) null;
    EventDelegate.Add(uiButton.onClick, callback);
    return touchObject;
  }

  public void PlayTween(GameObject o)
  {
    o.SetActive(true);
    ((IEnumerable<UITweener>) o.GetComponentsInChildren<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      if (x.tweenGroup != 0)
        return;
      x.ResetToBeginning();
      x.PlayForward();
    }));
  }

  [DebuggerHidden]
  protected IEnumerator ShowUnitEXP()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResultMenuBase.\u003CShowUnitEXP\u003Ec__Iterator610()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator CharacterIntimatesPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResultMenuBase.\u003CCharacterIntimatesPopup\u003Ec__Iterator611()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator CharacterStoryPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResultMenuBase.\u003CCharacterStoryPopup\u003Ec__Iterator612()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator HarmonyStoryPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResultMenuBase.\u003CHarmonyStoryPopup\u003Ec__Iterator613()
    {
      \u003C\u003Ef__this = this
    };
  }

  private enum EffectTYpe
  {
    NONE,
    SKILL_EVOLUTION,
    NEW_SKILL,
    LEADER_SKILL_EVOLUTION,
  }

  public class BonusReward
  {
    public int reward_quantity;
    public int reward_type_id;
    public int reward_id;

    public BonusReward(
      WebAPI.Response.ColosseumFinishBonus_rewards reward)
    {
      this.SetInfo(reward);
    }

    public BonusReward(
      WebAPI.Response.ColosseumTutorialFinishBonus_rewards reward)
    {
      this.SetInfo(reward);
    }

    public void SetInfo(
      WebAPI.Response.ColosseumFinishBonus_rewards reward)
    {
      this.reward_quantity = reward.reward_quantity;
      this.reward_type_id = reward.reward_type_id;
      this.reward_id = reward.reward_id;
    }

    public void SetInfo(
      WebAPI.Response.ColosseumTutorialFinishBonus_rewards reward)
    {
      this.reward_quantity = reward.reward_quantity;
      this.reward_type_id = reward.reward_type_id;
      this.reward_id = reward.reward_id;
    }
  }

  public class CampaignReward
  {
    public int reward_quantity;
    public string show_text2;
    public int reward_type_id;
    public int campaign_id;
    public string show_title;
    public string show_text;
    public int reward_id;

    public CampaignReward()
    {
    }

    public CampaignReward(
      WebAPI.Response.ColosseumFinishCampaign_rewards reward)
    {
      this.SetInfo(reward);
    }

    public CampaignReward(
      WebAPI.Response.ColosseumTutorialFinishCampaign_rewards reward)
    {
      this.SetInfo(reward);
    }

    public void SetInfo(
      WebAPI.Response.ColosseumFinishCampaign_rewards reward)
    {
      this.reward_quantity = reward.reward_quantity;
      this.show_text2 = reward.show_text2;
      this.reward_type_id = reward.reward_type_id;
      this.campaign_id = reward.campaign_id;
      this.show_title = reward.show_title;
      this.show_text = reward.show_text;
      this.reward_id = reward.reward_id;
    }

    public void SetInfo(
      WebAPI.Response.ColosseumTutorialFinishCampaign_rewards reward)
    {
      this.reward_quantity = reward.reward_quantity;
      this.show_text2 = reward.show_text2;
      this.reward_type_id = reward.reward_type_id;
      this.campaign_id = reward.campaign_id;
      this.show_title = reward.show_title;
      this.show_text = reward.show_text;
      this.reward_id = reward.reward_id;
    }
  }

  public class CampaignNextReward
  {
    public string next_reward_title;
    public int campaign_id;
    public string next_reward_text;

    public CampaignNextReward(
      WebAPI.Response.ColosseumFinishCampaign_next_rewards reward)
    {
      this.SetInfo(reward);
    }

    public CampaignNextReward(
      WebAPI.Response.ColosseumTutorialFinishCampaign_next_rewards reward)
    {
      this.SetInfo(reward);
    }

    public void SetInfo(
      WebAPI.Response.ColosseumFinishCampaign_next_rewards reward)
    {
      this.next_reward_title = reward.next_reward_title;
      this.campaign_id = reward.campaign_id;
      this.next_reward_text = reward.next_reward_text;
    }

    public void SetInfo(
      WebAPI.Response.ColosseumTutorialFinishCampaign_next_rewards reward)
    {
      this.next_reward_title = reward.next_reward_title;
      this.campaign_id = reward.campaign_id;
      this.next_reward_text = reward.next_reward_text;
    }
  }

  public class Param
  {
    public ResultMenuBase.BonusReward[] bonus_rewards;
    public bool is_battle;
    public int next_battle_type;
    public Bonus[] bonus;
    public Gladiator[] gladiators;
    public ColosseumRecord colosseum_record;
    public PvPRecord pvp_record;
    public Player player;
    public bool target_player_is_friend;
    public bool is_tutorial;
    public int battle_type;
    public RankUpInfo colosseum_result_rank_up;
    public ColosseumEnd colosseum_finish;
    public PlayerPresent[] player_presents;
    public ResultMenuBase.CampaignReward[] campaign_rewards;
    public ResultMenuBase.CampaignNextReward[] campaign_next_rewards;

    public Param(WebAPI.Response.ColosseumFinish finish)
    {
      int length1 = finish.bonus_rewards.Length;
      this.bonus_rewards = new ResultMenuBase.BonusReward[length1];
      for (int index = 0; index < length1; ++index)
      {
        if (this.bonus_rewards[index] == null)
          this.bonus_rewards[index] = new ResultMenuBase.BonusReward(finish.bonus_rewards[index]);
        else
          this.bonus_rewards[index].SetInfo(finish.bonus_rewards[index]);
      }
      int length2 = finish.campaign_rewards.Length;
      this.campaign_rewards = new ResultMenuBase.CampaignReward[length2];
      for (int index = 0; index < length2; ++index)
        this.campaign_rewards[index] = new ResultMenuBase.CampaignReward(finish.campaign_rewards[index]);
      int length3 = finish.campaign_next_rewards.Length;
      this.campaign_next_rewards = new ResultMenuBase.CampaignNextReward[length3];
      for (int index = 0; index < length3; ++index)
        this.campaign_next_rewards[index] = new ResultMenuBase.CampaignNextReward(finish.campaign_next_rewards[index]);
      this.is_battle = finish.is_battle;
      this.next_battle_type = finish.next_battle_type;
      this.bonus = finish.bonus;
      this.gladiators = finish.gladiators;
      this.colosseum_record = finish.colosseum_record;
      this.player = finish.player;
      this.target_player_is_friend = finish.target_player_is_friend;
      this.is_tutorial = finish.is_tutorial;
      this.battle_type = finish.battle_type;
      this.colosseum_result_rank_up = finish.colosseum_result_rank_up;
      this.colosseum_finish = finish.colosseum_finish;
      this.player_presents = finish.player_presents;
    }

    public Param(WebAPI.Response.ColosseumTutorialFinish finish)
    {
      int length1 = finish.bonus_rewards.Length;
      this.bonus_rewards = new ResultMenuBase.BonusReward[length1];
      for (int index = 0; index < length1; ++index)
      {
        if (this.bonus_rewards[index] == null)
          this.bonus_rewards[index] = new ResultMenuBase.BonusReward(finish.bonus_rewards[index]);
        else
          this.bonus_rewards[index].SetInfo(finish.bonus_rewards[index]);
      }
      int length2 = finish.campaign_rewards.Length;
      this.campaign_rewards = new ResultMenuBase.CampaignReward[length2];
      for (int index = 0; index < length2; ++index)
        this.campaign_rewards[index] = new ResultMenuBase.CampaignReward(finish.campaign_rewards[index]);
      int length3 = finish.campaign_next_rewards.Length;
      this.campaign_next_rewards = new ResultMenuBase.CampaignNextReward[length3];
      for (int index = 0; index < length3; ++index)
        this.campaign_next_rewards[index] = new ResultMenuBase.CampaignNextReward(finish.campaign_next_rewards[index]);
      this.is_battle = finish.is_battle;
      this.next_battle_type = finish.next_battle_type;
      this.bonus = finish.bonus;
      this.gladiators = finish.gladiators;
      this.colosseum_record = finish.colosseum_record;
      this.player = finish.player;
      this.target_player_is_friend = finish.target_player_is_friend;
      this.is_tutorial = finish.is_tutorial;
      this.battle_type = finish.battle_type;
      this.colosseum_result_rank_up = finish.colosseum_result_rank_up;
      this.colosseum_finish = finish.colosseum_finish;
      this.player_presents = finish.player_presents;
    }
  }
}
