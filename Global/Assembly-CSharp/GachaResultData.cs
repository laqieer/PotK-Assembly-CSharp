// Decompiled with JetBrains decompiler
// Type: GachaResultData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GachaResultData : MonoBehaviour
{
  private static GachaResultData Instance;
  private GachaResultData.ResultData resultData;

  public void ChangeSceneOneShot()
  {
    GachaResultData instance = GachaResultData.GetInstance();
    bool is_new = instance.GetData().GetResultData()[0].is_new;
    CommonRewardType commonRewardType = new CommonRewardType(instance.GetData().GetResultData()[0].reward_type_id, instance.GetData().GetResultData()[0].reward_result_id, instance.GetData().GetResultData()[0].reward_result_quantity, instance.GetData().GetResultData()[0].is_new);
    commonRewardType.ThenUnit((Action<PlayerUnit>) (unit => this.ChangeSceneUnit(unit, is_new)));
    commonRewardType.ThenGear((Action<PlayerItem>) (gear => this.ChangeSceneGear(gear, is_new)));
  }

  private void ChangeSceneUnit(PlayerUnit PU, bool is_new)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_effect", true);
  }

  private void ChangeSceneGear(PlayerItem PI, bool is_new)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_effect", true);
  }

  public static GachaResultData GetInstance()
  {
    if (Object.op_Equality((Object) GachaResultData.Instance, (Object) null))
    {
      GameObject gameObject = GameObject.Find("Gacha Manager");
      if (Object.op_Equality((Object) gameObject, (Object) null))
      {
        gameObject = new GameObject("Gacha Manager");
        Object.DontDestroyOnLoad((Object) gameObject);
      }
      GachaResultData.Instance = gameObject.GetComponent<GachaResultData>();
      if (Object.op_Equality((Object) GachaResultData.Instance, (Object) null))
        GachaResultData.Instance = gameObject.AddComponent<GachaResultData>();
    }
    return GachaResultData.Instance;
  }

  public GachaResultData.ResultData GetData() => this.resultData;

  public void ResetData() => this.resultData = (GachaResultData.ResultData) null;

  public void SetData(WebAPI.Response.GachaG001ChargePay data)
  {
    this.resultData = (GachaResultData.ResultData) null;
    this.resultData = new GachaResultData.ResultData();
    this.resultData.resultList = new GachaResultData.Result[data.result.Length];
    this.resultData.patternID = data.animation_pattern;
    for (int index = 0; index < data.result.Length; ++index)
    {
      GachaResultData.Result result = new GachaResultData.Result();
      result.Set(data.result[index]);
      this.resultData.resultList[index] = result;
    }
    this.resultData.unlockQuests = data.unlock_quests;
  }

  public void SetData(WebAPI.Response.GachaG001ChargeMultiPay data)
  {
    this.resultData = (GachaResultData.ResultData) null;
    this.resultData = new GachaResultData.ResultData();
    this.resultData.resultList = new GachaResultData.Result[data.result.Length];
    this.resultData.patternID = data.animation_pattern;
    this.resultData.patternGems = data.animation_pattern_gems;
    for (int index = 0; index < data.result.Length; ++index)
    {
      GachaResultData.Result result = new GachaResultData.Result();
      result.Set(data.result[index]);
      this.resultData.resultList[index] = result;
    }
    this.resultData.unlockQuests = data.unlock_quests;
  }

  public void SetData(WebAPI.Response.GachaG002FriendpointPay data)
  {
    this.resultData = (GachaResultData.ResultData) null;
    this.resultData = new GachaResultData.ResultData();
    this.resultData.resultList = new GachaResultData.Result[data.result.Length];
    this.resultData.patternID = (string[]) null;
    for (int index = 0; index < data.result.Length; ++index)
    {
      GachaResultData.Result result = new GachaResultData.Result();
      result.Set(data.result[index]);
      this.resultData.resultList[index] = result;
    }
  }

  public void SetData(WebAPI.Response.GachaG004TicketPay data)
  {
    this.resultData = new GachaResultData.ResultData();
    this.resultData.resultList = new GachaResultData.Result[data.result.Length];
    this.resultData.patternID = (string[]) null;
    for (int index = 0; index < data.result.Length; ++index)
    {
      GachaResultData.Result result = new GachaResultData.Result();
      result.Set(data.result[index]);
      this.resultData.resultList[index] = result;
    }
  }

  public void SetData(WebAPI.Response.GachaG007PanelPay data)
  {
    this.resultData = (GachaResultData.ResultData) null;
    this.resultData = new GachaResultData.ResultData();
    this.resultData.resultList = new GachaResultData.Result[data.result.Length];
    this.resultData.patternID = data.animation_pattern;
    this.resultData.gachaType = Consts.GachaType.SHEET;
    this.resultData.openPanelResult = data.open_panel_result;
    for (int index = 0; index < data.result.Length; ++index)
    {
      GachaResultData.Result result = new GachaResultData.Result();
      result.Set(data.result[index]);
      this.resultData.resultList[index] = result;
    }
    this.resultData.unlockQuests = data.unlock_quests;
  }

  public void SetData(WebAPI.Response.GachaG007PanelMultiPay data)
  {
    this.resultData = (GachaResultData.ResultData) null;
    this.resultData = new GachaResultData.ResultData();
    this.resultData.resultList = new GachaResultData.Result[data.result.Length];
    this.resultData.patternID = data.animation_pattern;
    this.resultData.patternGems = data.animation_pattern_gems;
    this.resultData.gachaType = Consts.GachaType.SHEET;
    this.resultData.openPanelResult = data.open_panel_result;
    for (int index = 0; index < data.result.Length; ++index)
    {
      GachaResultData.Result result = new GachaResultData.Result();
      result.Set(data.result[index]);
      this.resultData.resultList[index] = result;
    }
    this.resultData.unlockQuests = data.unlock_quests;
  }

  public bool IsPopupEffect()
  {
    bool flag = true;
    if ((this.resultData.unlockQuests == null || this.resultData.unlockQuests.Length == 0) && this.resultData.openPanelResult == null)
      flag = false;
    return flag;
  }

  [DebuggerHidden]
  public IEnumerator CharacterStoryPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GachaResultData.\u003CCharacterStoryPopup\u003Ec__Iterator391()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SheetGachaResultPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GachaResultData.\u003CSheetGachaResultPopup\u003Ec__Iterator392()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator StartSheetEffect()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GachaResultData.\u003CStartSheetEffect\u003Ec__Iterator393()
    {
      \u003C\u003Ef__this = this
    };
  }

  public GameObject OpenPopup(GameObject original)
  {
    GameObject gameObject = Singleton<PopupManager>.GetInstance().open(original);
    ((Component) gameObject.transform.parent.Find("Popup Mask")).gameObject.GetComponent<TweenAlpha>().to = 0.75f;
    return gameObject;
  }

  public class Result
  {
    public bool is_new;
    public int reward_result_id;
    public int reward_result_quantity;
    public int reward_type_id;

    public UnlockQuest unlock_quest { get; set; }

    public void Set(
      WebAPI.Response.GachaG001ChargeMultiPayResult result)
    {
      this.is_new = result.is_new;
      this.reward_result_id = result.reward_result_id;
      this.reward_result_quantity = result.reward_result_quantity;
      this.reward_type_id = result.reward_type_id;
    }

    public void Set(WebAPI.Response.GachaG001ChargePayResult result)
    {
      this.is_new = result.is_new;
      this.reward_result_id = result.reward_result_id;
      this.reward_result_quantity = result.reward_result_quantity;
      this.reward_type_id = result.reward_type_id;
    }

    public void Set(
      WebAPI.Response.GachaG002FriendpointPayResult result)
    {
      this.is_new = result.is_new;
      this.reward_result_id = result.reward_result_id;
      this.reward_result_quantity = result.reward_result_quantity;
      this.reward_type_id = result.reward_type_id;
    }

    public void Set(WebAPI.Response.GachaG004TicketPayResult result)
    {
      this.is_new = result.is_new;
      this.reward_result_id = result.reward_result_id;
      this.reward_result_quantity = result.reward_result_quantity;
      this.reward_type_id = result.reward_type_id;
    }

    public void Set(WebAPI.Response.GachaG007PanelPayResult result)
    {
      this.is_new = result.is_new;
      this.reward_result_id = result.reward_result_id;
      this.reward_result_quantity = result.reward_result_quantity;
      this.reward_type_id = result.reward_type_id;
    }

    public void Set(
      WebAPI.Response.GachaG007PanelMultiPayResult result)
    {
      this.is_new = result.is_new;
      this.reward_result_id = result.reward_result_id;
      this.reward_result_quantity = result.reward_result_quantity;
      this.reward_type_id = result.reward_type_id;
    }
  }

  public class ResultData
  {
    public Consts.GachaType gachaType;
    public GachaResultData.Result[] resultList;
    public string[] patternID;

    public AnimationPatternMultiAfter[] patternGems { get; set; }

    public UnlockQuest[] unlockQuests { get; set; }

    public GachaG007OpenPanelResult openPanelResult { get; set; }

    public GachaResultData.Result[] GetResultData() => this.resultList;

    public string[] GetPatternData() => this.patternID;

    public UnlockQuest[] GetUnlockQuestData() => this.unlockQuests;
  }
}
