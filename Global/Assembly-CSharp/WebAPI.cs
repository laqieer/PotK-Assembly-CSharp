// Decompiled with JetBrains decompiler
// Type: WebAPI
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Earth;
using GameCore;
using gu3.Device;
using HTTP;
using MasterDataTable;
using MiniJSON;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UniLinq;
using UnityEngine;

#nullable disable
public static class WebAPI
{
  private static readonly string errorUnknown = "原因不明のエラー";
  private static readonly Dictionary<string, string> commonErrorDict = new Dictionary<string, string>()
  {
    {
      "VLD000",
      "意図しないパラメータがある"
    },
    {
      "VLD011",
      "secret_key が存在しない "
    },
    {
      "VLD012",
      "secret_key が文字列に変換できない"
    },
    {
      "VLD013",
      "secret_key が空文字列"
    },
    {
      "VLD014",
      "secret_key が 65 文字以上"
    },
    {
      "VLD031",
      "device_id が存在しない"
    },
    {
      "VLD032",
      "device_id が文字列に変換できない"
    },
    {
      "VLD033",
      "device_id が空文字列 "
    },
    {
      "VLD034",
      "device_id が 35 文字以下"
    },
    {
      "VLD035",
      "device_id が 37 文字以上"
    }
  };
  private static readonly Dictionary<string, string> passcodeErrorDict = WebAPI.commonErrorDict;
  private static readonly Dictionary<string, string> migrateErrorDict = ((IEnumerable<Dictionary<string, string>>) new Dictionary<string, string>[2]
  {
    WebAPI.commonErrorDict,
    new Dictionary<string, string>()
    {
      {
        "Locked PASSCODE",
        "入力誤り回数が三回を超えている"
      },
      {
        "Missing PASSCODE",
        "パスコードが誤っている"
      },
      {
        "Missing DEVICE_ID",
        "移行元と移行先が同一端末"
      }
    }
  }).SelectMany<Dictionary<string, string>, KeyValuePair<string, string>>((Func<Dictionary<string, string>, IEnumerable<KeyValuePair<string, string>>>) (x => (IEnumerable<KeyValuePair<string, string>>) x)).ToDictionary<KeyValuePair<string, string>, string, string>((Func<KeyValuePair<string, string>, string>) (x => x.Key), (Func<KeyValuePair<string, string>, string>) (x => x.Value));
  private static readonly Dictionary<string, string> facebookSSOError = ((IEnumerable<Dictionary<string, string>>) new Dictionary<string, string>[2]
  {
    WebAPI.commonErrorDict,
    new Dictionary<string, string>()
    {
      {
        "missing_device_id",
        "移行元と移行先が同一端末"
      },
      {
        "missing_related_id",
        "FBと連携なし"
      }
    }
  }).SelectMany<Dictionary<string, string>, KeyValuePair<string, string>>((Func<Dictionary<string, string>, IEnumerable<KeyValuePair<string, string>>>) (x => (IEnumerable<KeyValuePair<string, string>>) x)).ToDictionary<KeyValuePair<string, string>, string, string>((Func<KeyValuePair<string, string>, string>) (x => x.Key), (Func<KeyValuePair<string, string>, string>) (x => x.Value));
  private static Dictionary<string, DateTime> latestResponsedAt = new Dictionary<string, DateTime>();
  private static readonly string[] SENTRY_MESSAGE_DELIMITERS = new string[1]
  {
    " ::: "
  };
  public static Action<WebAPI.Response.UserError> DefaultUserErrorCallback = new Action<WebAPI.Response.UserError>(WebAPI.defaultUserErrorCallback);

  public static void AuthPasscode(Action<string, int> successCallback, Action<string> failCallback)
  {
    WebAPI.AuthPasscode(successCallback, (Func<string, IEnumerator>) (message =>
    {
      failCallback(message);
      return new object[0].GetEnumerator();
    }));
  }

  public static void AuthPasscode(
    Action<string, int> successCallback,
    Func<string, IEnumerator> failCallback)
  {
    WebQueue.EnqueueAuthPasscode(successCallback, (Func<WebError, IEnumerator>) (error =>
    {
      if (error.Status == 400)
      {
        string[] keys = new string[4]
        {
          "reason.secret_key",
          "reason.device_id",
          "reason.passcode",
          "reason"
        };
        string jsonStringOrNull = error.Response.getJsonStringOrNull(keys);
        string str;
        if (WebAPI.passcodeErrorDict.TryGetValue(jsonStringOrNull, out str))
          return failCallback(str);
      }
      return failCallback(WebAPI.errorUnknown);
    }));
  }

  public static void AuthMigrate(
    string passcode,
    System.Action successCallback,
    Action<string, int> failCallback)
  {
    WebAPI.AuthMigrate(passcode, successCallback, (Func<string, int, IEnumerator>) ((message, seconds) =>
    {
      failCallback(message, seconds);
      return new object[0].GetEnumerator();
    }));
  }

  public static void AuthMigrate(
    string passcode,
    System.Action successCallback,
    Func<string, int, IEnumerator> failCallback)
  {
    WebQueue.EnqueueAuthMigrate(passcode, successCallback, (Func<WebError, IEnumerator>) (error =>
    {
      if (error.Status == 400)
      {
        string[] keys = new string[4]
        {
          "reason.secret_key",
          "reason.device_id",
          "reason.passcode",
          "reason"
        };
        string jsonStringOrNull = error.Response.getJsonStringOrNull(keys);
        string str1;
        if (WebAPI.migrateErrorDict.TryGetValue(jsonStringOrNull, out str1))
        {
          if (jsonStringOrNull == "Locked PASSCODE")
          {
            string str2 = str1;
            int? jsonIntOrNull1 = error.Response.getJsonIntOrNull("trial_counter");
            // ISSUE: variable of a boxed type
            __Boxed<int> local = (ValueType) (!jsonIntOrNull1.HasValue ? 0 : jsonIntOrNull1.Value);
            int? jsonIntOrNull2 = error.Response.getJsonIntOrNull("expires_in");
            string time = WebAPI.secondsToTime(!jsonIntOrNull2.HasValue ? 0 : jsonIntOrNull2.Value);
            string str3 = string.Format("\n{0}回入力が正しく受付できなかったため{1}間は移行コードの入力ができません。", (object) local, (object) time);
            str1 = str2 + str3;
          }
          Func<string, int, IEnumerator> func = failCallback;
          string str4 = str1;
          int? jsonIntOrNull = error.Response.getJsonIntOrNull("expires_in");
          int num = !jsonIntOrNull.HasValue ? 0 : jsonIntOrNull.Value;
          return func(str4, num);
        }
      }
      return failCallback(WebAPI.errorUnknown, 0);
    }));
  }

  public static void AccountRelateFacebookSSO(System.Action successCallback, Action<string> failCallback)
  {
    WebAPI.AccountRelateFacebookSSO(successCallback, (Func<string, IEnumerator>) (message =>
    {
      failCallback(message);
      return new object[0].GetEnumerator();
    }));
  }

  public static void AccountRelateFacebookSSO(
    System.Action successCallback,
    Func<string, IEnumerator> failCallback)
  {
    WebQueue.EnqueueAuthFacebookSSORelateAccount(successCallback, (Func<WebError, IEnumerator>) (error =>
    {
      if (error.Status == 409)
        return failCallback("409");
      if (error.Status == 400)
      {
        string[] keys = new string[4]
        {
          "reason.device_id",
          "reason.secret_key",
          "reason.access_token",
          "reason"
        };
        string jsonStringOrNull = error.Response.getJsonStringOrNull(keys);
        string str;
        if (WebAPI.facebookSSOError.TryGetValue(jsonStringOrNull, out str))
          return failCallback(str);
      }
      return failCallback(WebAPI.errorUnknown);
    }));
  }

  public static void AuthMigrateFacebookSSO(System.Action successCallback, Action<string> failCallback)
  {
    WebAPI.AuthMigrateFacebookSSO(successCallback, (Func<string, IEnumerator>) (message =>
    {
      failCallback(message);
      return new object[0].GetEnumerator();
    }));
  }

  public static void AuthMigrateFacebookSSO(
    System.Action successCallback,
    Func<string, IEnumerator> failCallback)
  {
    WebQueue.EnqueueAuthFacebookSSOMigrate(successCallback, (Func<WebError, IEnumerator>) (error =>
    {
      if (error.Status == 400)
      {
        string[] keys = new string[4]
        {
          "reason.device_id",
          "reason.secret_key",
          "reason.access_token",
          "reason"
        };
        string jsonStringOrNull = error.Response.getJsonStringOrNull(keys);
        string str;
        if (WebAPI.facebookSSOError.TryGetValue(jsonStringOrNull, out str))
          return failCallback(str);
      }
      return failCallback(WebAPI.errorUnknown);
    }));
  }

  public static void AuthDeviceFacebookSSO(
    Action<string, string> successCallback,
    Action<string> failCallback)
  {
    WebAPI.AuthDeviceFacebookSSO(successCallback, (Func<string, IEnumerator>) (message =>
    {
      failCallback(message);
      return new object[0].GetEnumerator();
    }));
  }

  public static void AuthDeviceFacebookSSO(
    Action<string, string> successCallback,
    Func<string, IEnumerator> failCallback)
  {
    WebQueue.EnqueueAuthFacebookSSODevice(successCallback, (Func<WebError, IEnumerator>) (error =>
    {
      if (error.Status == 400)
      {
        string[] keys = new string[3]
        {
          "reason.missing_related_id",
          "reason.access_token",
          "reason"
        };
        string jsonStringOrNull = error.Response.getJsonStringOrNull(keys);
        string str;
        if (WebAPI.facebookSSOError.TryGetValue(jsonStringOrNull, out str))
          return failCallback(str);
      }
      return failCallback(WebAPI.errorUnknown);
    }));
  }

  public static void AuthIsRelatedFacebookSSO(
    Action<bool> successCallback,
    Action<string> failCallback)
  {
    WebAPI.AuthIsRelatedFacebookSSO(successCallback, (Func<string, IEnumerator>) (message =>
    {
      failCallback(message);
      return new object[0].GetEnumerator();
    }));
  }

  public static void AuthIsRelatedFacebookSSO(
    Action<bool> successCallback,
    Func<string, IEnumerator> failCallback)
  {
    WebQueue.EnqueueAuthFacebookSSOIsRelated(successCallback, (Func<WebError, IEnumerator>) (error => failCallback(WebAPI.errorUnknown)));
  }

  public static void AuthDeviceInfo(System.Action authCallback)
  {
    WebAPI.AuthDeviceInfo(authCallback, (Func<IEnumerator>) (() =>
    {
      authCallback();
      return new object[0].GetEnumerator();
    }));
  }

  public static void AuthDeviceInfo(System.Action successCallback, Func<IEnumerator> failCallback)
  {
    WebQueue.EnqueueAuthDeviceInfo(successCallback, (Func<WebError, IEnumerator>) (error =>
    {
      if (error.HasResponse())
      {
        if (error.IsClientError())
        {
          error.Request.RestRetryCount = 0;
          return failCallback();
        }
      }
      else if (Persist.auth.Exists)
        return new object[0].GetEnumerator();
      return WebQueue.FailCallback(error);
    }));
  }

  private static string secondsToTime(int n)
  {
    if (n < 60)
      return n.ToString() + "秒";
    if (n < 3600)
      return (n / 60).ToString() + "分";
    return n < 86400 ? (n / 60 / 60).ToString() + "時" : (n / 60 / 60 / 24).ToString() + "日";
  }

  public static Future<BattleEnd> BattleFinish(
    WebAPI.Request.BattleFinish request,
    BE be,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    if (request.quest_type == CommonQuestType.Story)
      return WebAPI.BattleStoryFinish(request.battle_turn, request.battle_uuid, request.continue_count, request.drop_entity_ids.ToArray(), request.duels_critical_count.ToArray(), request.duels_damage.ToArray(), request.duels_hit_damage.ToArray(), request.duels_max_damage.ToArray(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.dead_count)).ToArray<int>(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.enemy_id)).ToArray<int>(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.kill_count)).ToArray<int>(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.level_difference)).ToArray<int>(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.overkill_damage)).ToArray<int>(), request.gears.Select<WebAPI.Request.BattleFinish.GearResult, int>((Func<WebAPI.Request.BattleFinish.GearResult, int>) (x => x.damage_count)).ToArray<int>(), request.gears.Select<WebAPI.Request.BattleFinish.GearResult, int>((Func<WebAPI.Request.BattleFinish.GearResult, int>) (x => x.kill_count)).ToArray<int>(), request.gears.Select<WebAPI.Request.BattleFinish.GearResult, int>((Func<WebAPI.Request.BattleFinish.GearResult, int>) (x => x.player_gear_id)).ToArray<int>(), request.intimates.Select<WebAPI.Request.BattleFinish.IntimateResult, int>((Func<WebAPI.Request.BattleFinish.IntimateResult, int>) (x => x.target_character_id)).ToArray<int>(), request.intimates.Select<WebAPI.Request.BattleFinish.IntimateResult, int>((Func<WebAPI.Request.BattleFinish.IntimateResult, int>) (x => x.exp)).ToArray<int>(), request.intimates.Select<WebAPI.Request.BattleFinish.IntimateResult, int>((Func<WebAPI.Request.BattleFinish.IntimateResult, int>) (x => x.character_id)).ToArray<int>(), request.is_game_over, request.panel_entity_ids.ToArray(), request.supplies.Select<WebAPI.Request.BattleFinish.SupplyResult, int>((Func<WebAPI.Request.BattleFinish.SupplyResult, int>) (x => x.supply_id)).ToArray<int>(), request.supplies.Select<WebAPI.Request.BattleFinish.SupplyResult, int>((Func<WebAPI.Request.BattleFinish.SupplyResult, int>) (x => x.use_quantity)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.player_unit_id)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.received_damage)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.remaining_hp)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.rental)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.total_damage)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.total_damage_count)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.total_kill_count)).ToArray<int>(), request.week_element_attack_count, request.week_kind_attack_count, !request.win ? 0 : 1, userErrorCallback).Then<BattleEnd>((Func<WebAPI.Response.BattleStoryFinish, BattleEnd>) (x => x.battle_finish));
    if (request.quest_type == CommonQuestType.Extra)
      return WebAPI.BattleExtraFinish(request.battle_turn, request.battle_uuid, request.continue_count, request.drop_entity_ids.ToArray(), request.duels_critical_count.ToArray(), request.duels_damage.ToArray(), request.duels_hit_damage.ToArray(), request.duels_max_damage.ToArray(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.dead_count)).ToArray<int>(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.enemy_id)).ToArray<int>(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.kill_count)).ToArray<int>(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.level_difference)).ToArray<int>(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.overkill_damage)).ToArray<int>(), request.gears.Select<WebAPI.Request.BattleFinish.GearResult, int>((Func<WebAPI.Request.BattleFinish.GearResult, int>) (x => x.damage_count)).ToArray<int>(), request.gears.Select<WebAPI.Request.BattleFinish.GearResult, int>((Func<WebAPI.Request.BattleFinish.GearResult, int>) (x => x.kill_count)).ToArray<int>(), request.gears.Select<WebAPI.Request.BattleFinish.GearResult, int>((Func<WebAPI.Request.BattleFinish.GearResult, int>) (x => x.player_gear_id)).ToArray<int>(), request.intimates.Select<WebAPI.Request.BattleFinish.IntimateResult, int>((Func<WebAPI.Request.BattleFinish.IntimateResult, int>) (x => x.target_character_id)).ToArray<int>(), request.intimates.Select<WebAPI.Request.BattleFinish.IntimateResult, int>((Func<WebAPI.Request.BattleFinish.IntimateResult, int>) (x => x.exp)).ToArray<int>(), request.intimates.Select<WebAPI.Request.BattleFinish.IntimateResult, int>((Func<WebAPI.Request.BattleFinish.IntimateResult, int>) (x => x.character_id)).ToArray<int>(), request.is_game_over, request.panel_entity_ids.ToArray(), request.supplies.Select<WebAPI.Request.BattleFinish.SupplyResult, int>((Func<WebAPI.Request.BattleFinish.SupplyResult, int>) (x => x.supply_id)).ToArray<int>(), request.supplies.Select<WebAPI.Request.BattleFinish.SupplyResult, int>((Func<WebAPI.Request.BattleFinish.SupplyResult, int>) (x => x.use_quantity)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.player_unit_id)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.received_damage)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.remaining_hp)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.rental)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.total_damage)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.total_damage_count)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.total_kill_count)).ToArray<int>(), request.week_element_attack_count, request.week_kind_attack_count, !request.win ? 0 : 1, userErrorCallback).Then<BattleEnd>((Func<WebAPI.Response.BattleExtraFinish, BattleEnd>) (x => x.battle_finish));
    if (request.quest_type == CommonQuestType.Character)
      return WebAPI.BattleCharacterFinish(request.battle_turn, request.battle_uuid, request.continue_count, request.drop_entity_ids.ToArray(), request.duels_critical_count.ToArray(), request.duels_damage.ToArray(), request.duels_hit_damage.ToArray(), request.duels_max_damage.ToArray(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.dead_count)).ToArray<int>(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.enemy_id)).ToArray<int>(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.kill_count)).ToArray<int>(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.level_difference)).ToArray<int>(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.overkill_damage)).ToArray<int>(), request.gears.Select<WebAPI.Request.BattleFinish.GearResult, int>((Func<WebAPI.Request.BattleFinish.GearResult, int>) (x => x.damage_count)).ToArray<int>(), request.gears.Select<WebAPI.Request.BattleFinish.GearResult, int>((Func<WebAPI.Request.BattleFinish.GearResult, int>) (x => x.kill_count)).ToArray<int>(), request.gears.Select<WebAPI.Request.BattleFinish.GearResult, int>((Func<WebAPI.Request.BattleFinish.GearResult, int>) (x => x.player_gear_id)).ToArray<int>(), request.intimates.Select<WebAPI.Request.BattleFinish.IntimateResult, int>((Func<WebAPI.Request.BattleFinish.IntimateResult, int>) (x => x.target_character_id)).ToArray<int>(), request.intimates.Select<WebAPI.Request.BattleFinish.IntimateResult, int>((Func<WebAPI.Request.BattleFinish.IntimateResult, int>) (x => x.exp)).ToArray<int>(), request.intimates.Select<WebAPI.Request.BattleFinish.IntimateResult, int>((Func<WebAPI.Request.BattleFinish.IntimateResult, int>) (x => x.character_id)).ToArray<int>(), request.is_game_over, request.panel_entity_ids.ToArray(), request.supplies.Select<WebAPI.Request.BattleFinish.SupplyResult, int>((Func<WebAPI.Request.BattleFinish.SupplyResult, int>) (x => x.supply_id)).ToArray<int>(), request.supplies.Select<WebAPI.Request.BattleFinish.SupplyResult, int>((Func<WebAPI.Request.BattleFinish.SupplyResult, int>) (x => x.use_quantity)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.player_unit_id)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.received_damage)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.remaining_hp)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.rental)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.total_damage)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.total_damage_count)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.total_kill_count)).ToArray<int>(), request.week_element_attack_count, request.week_kind_attack_count, !request.win ? 0 : 1, userErrorCallback).Then<BattleEnd>((Func<WebAPI.Response.BattleCharacterFinish, BattleEnd>) (x => x.battle_finish));
    if (request.quest_type == CommonQuestType.Harmony)
      return WebAPI.BattleHarmonyFinish(request.battle_turn, request.battle_uuid, request.continue_count, request.drop_entity_ids.ToArray(), request.duels_critical_count.ToArray(), request.duels_damage.ToArray(), request.duels_hit_damage.ToArray(), request.duels_max_damage.ToArray(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.dead_count)).ToArray<int>(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.enemy_id)).ToArray<int>(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.kill_count)).ToArray<int>(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.level_difference)).ToArray<int>(), request.enemies.Select<WebAPI.Request.BattleFinish.EnemyResult, int>((Func<WebAPI.Request.BattleFinish.EnemyResult, int>) (x => x.overkill_damage)).ToArray<int>(), request.gears.Select<WebAPI.Request.BattleFinish.GearResult, int>((Func<WebAPI.Request.BattleFinish.GearResult, int>) (x => x.damage_count)).ToArray<int>(), request.gears.Select<WebAPI.Request.BattleFinish.GearResult, int>((Func<WebAPI.Request.BattleFinish.GearResult, int>) (x => x.kill_count)).ToArray<int>(), request.gears.Select<WebAPI.Request.BattleFinish.GearResult, int>((Func<WebAPI.Request.BattleFinish.GearResult, int>) (x => x.player_gear_id)).ToArray<int>(), request.intimates.Select<WebAPI.Request.BattleFinish.IntimateResult, int>((Func<WebAPI.Request.BattleFinish.IntimateResult, int>) (x => x.target_character_id)).ToArray<int>(), request.intimates.Select<WebAPI.Request.BattleFinish.IntimateResult, int>((Func<WebAPI.Request.BattleFinish.IntimateResult, int>) (x => x.exp)).ToArray<int>(), request.intimates.Select<WebAPI.Request.BattleFinish.IntimateResult, int>((Func<WebAPI.Request.BattleFinish.IntimateResult, int>) (x => x.character_id)).ToArray<int>(), request.is_game_over, request.panel_entity_ids.ToArray(), request.supplies.Select<WebAPI.Request.BattleFinish.SupplyResult, int>((Func<WebAPI.Request.BattleFinish.SupplyResult, int>) (x => x.supply_id)).ToArray<int>(), request.supplies.Select<WebAPI.Request.BattleFinish.SupplyResult, int>((Func<WebAPI.Request.BattleFinish.SupplyResult, int>) (x => x.use_quantity)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.player_unit_id)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.received_damage)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.remaining_hp)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.rental)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.total_damage)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.total_damage_count)).ToArray<int>(), request.units.Select<WebAPI.Request.BattleFinish.UnitResult, int>((Func<WebAPI.Request.BattleFinish.UnitResult, int>) (x => x.total_kill_count)).ToArray<int>(), request.week_element_attack_count, request.week_kind_attack_count, !request.win ? 0 : 1, userErrorCallback).Then<BattleEnd>((Func<WebAPI.Response.BattleHarmonyFinish, BattleEnd>) (x => x.battle_finish));
    return request.quest_type == CommonQuestType.Earth ? Singleton<EarthDataManager>.GetInstance().BattleFinish(request, be) : (Future<BattleEnd>) null;
  }

  public static Future<T> GachaChargePay<T>(
    string name,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<T>((Func<Promise<T>, IEnumerator>) (promise => WebAPI.LoadGachaChargePay<T>(promise, name, execute_count, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaChargePay<T>(
    Promise<T> promise,
    string name,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaChargePay\u003Ec__Iterator43<T>()
    {
      name = name,
      execute_count = execute_count,
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ename = name,
      \u003C\u0024\u003Eexecute_count = execute_count,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaChargePay<T>(
    string name,
    int execute_count,
    int gacha_id,
    Action<T> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/{0}/pay".F((object) name), new Dictionary<string, object>()
    {
      [nameof (execute_count)] = (object) execute_count,
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
      }
      else
        ((Action<T>) callback)((T) typeof (T).GetConstructor(new System.Type[1]
        {
          typeof (Dictionary<string, object>)
        }).Invoke(new object[1]{ (object) json.Json }));
    }));
  }

  public static Future<T> GachaChargeMultiPay<T>(
    string name,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<T>((Func<Promise<T>, IEnumerator>) (promise => WebAPI.LoadGachaChargeMultiPay<T>(promise, name, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaChargeMultiPay<T>(
    Promise<T> promise,
    string name,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaChargeMultiPay\u003Ec__Iterator44<T>()
    {
      name = name,
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ename = name,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaChargeMultiPay<T>(
    string name,
    int gacha_id,
    Action<T> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/{0}/multi/pay".F((object) name), new Dictionary<string, object>()
    {
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
      }
      else
        ((Action<T>) callback)((T) typeof (T).GetConstructor(new System.Type[1]
        {
          typeof (Dictionary<string, object>)
        }).Invoke(new object[1]{ (object) json.Json }));
    }));
  }

  public static Future<WebAPI.Response.GachaG002FriendpointPay> GachaFriendPointPay(
    string name,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG002FriendpointPay>((Func<Promise<WebAPI.Response.GachaG002FriendpointPay>, IEnumerator>) (promise => WebAPI.LoadGachaG002FriendpointPay(promise, name, execute_count, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG002FriendpointPay(
    Promise<WebAPI.Response.GachaG002FriendpointPay> promise,
    string name,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG002FriendpointPay\u003Ec__Iterator45()
    {
      name = name,
      execute_count = execute_count,
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ename = name,
      \u003C\u0024\u003Eexecute_count = execute_count,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaFriendpointPay(
    string name,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.GachaG002FriendpointPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/{0}/pay".F((object) name), new Dictionary<string, object>()
    {
      [nameof (execute_count)] = (object) execute_count,
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG002FriendpointPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG002FriendpointPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.AchievementApiAuth> AchievementApiAuth(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.AchievementApiAuth>((Func<Promise<WebAPI.Response.AchievementApiAuth>, IEnumerator>) (promise => WebAPI.LoadAchievementApiAuth(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadAchievementApiAuth(
    Promise<WebAPI.Response.AchievementApiAuth> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadAchievementApiAuth\u003Ec__Iterator46()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalAchievementApiAuth(
    Action<WebAPI.Response.AchievementApiAuth> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/achievement/api/auth", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.AchievementApiAuth) null);
      }
      else
        callback(new WebAPI.Response.AchievementApiAuth(json.Json));
    }));
  }

  public static Future<WebAPI.Response.Agreement> Agreement(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.Agreement>((Func<Promise<WebAPI.Response.Agreement>, IEnumerator>) (promise => WebAPI.LoadAgreement(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadAgreement(
    Promise<WebAPI.Response.Agreement> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadAgreement\u003Ec__Iterator47()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalAgreement(
    Action<WebAPI.Response.Agreement> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/agreement", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.Agreement) null);
      }
      else
        callback(new WebAPI.Response.Agreement(json.Json));
    }));
  }

  public static Future<WebAPI.Response.BattleCharacterFinish> BattleCharacterFinish(
    int battle_turn,
    string battle_uuid,
    int continue_count,
    int[] drop_entity_ids,
    int[] duels_critical_count,
    int[] duels_damage,
    int[] duels_hit_damage,
    int[] duels_max_damage,
    int[] enemy_results_dead_count,
    int[] enemy_results_enemy_id,
    int[] enemy_results_kill_count,
    int[] enemy_results_level_difference,
    int[] enemy_results_overkill_damage,
    int[] gear_results_damage_count,
    int[] gear_results_kill_count,
    int[] gear_results_player_gear_id,
    int[] intimate_result_target_player_character_id,
    int[] intimate_results_exp,
    int[] intimate_results_player_character_id,
    bool is_game_over,
    int[] panel_entity_ids,
    int[] supply_results_supply_id,
    int[] supply_results_use_quantity,
    int[] unit_results_player_unit_id,
    int[] unit_results_received_damage,
    int[] unit_results_remaining_hp,
    int[] unit_results_rental,
    int[] unit_results_total_damage,
    int[] unit_results_total_damage_count,
    int[] unit_results_total_kill_count,
    int weak_element_attack_count,
    int weak_kind_attack_count,
    int win,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.BattleCharacterFinish>((Func<Promise<WebAPI.Response.BattleCharacterFinish>, IEnumerator>) (promise => WebAPI.LoadBattleCharacterFinish(promise, battle_turn, battle_uuid, continue_count, drop_entity_ids, duels_critical_count, duels_damage, duels_hit_damage, duels_max_damage, enemy_results_dead_count, enemy_results_enemy_id, enemy_results_kill_count, enemy_results_level_difference, enemy_results_overkill_damage, gear_results_damage_count, gear_results_kill_count, gear_results_player_gear_id, intimate_result_target_player_character_id, intimate_results_exp, intimate_results_player_character_id, is_game_over, panel_entity_ids, supply_results_supply_id, supply_results_use_quantity, unit_results_player_unit_id, unit_results_received_damage, unit_results_remaining_hp, unit_results_rental, unit_results_total_damage, unit_results_total_damage_count, unit_results_total_kill_count, weak_element_attack_count, weak_kind_attack_count, win, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBattleCharacterFinish(
    Promise<WebAPI.Response.BattleCharacterFinish> promise,
    int battle_turn,
    string battle_uuid,
    int continue_count,
    int[] drop_entity_ids,
    int[] duels_critical_count,
    int[] duels_damage,
    int[] duels_hit_damage,
    int[] duels_max_damage,
    int[] enemy_results_dead_count,
    int[] enemy_results_enemy_id,
    int[] enemy_results_kill_count,
    int[] enemy_results_level_difference,
    int[] enemy_results_overkill_damage,
    int[] gear_results_damage_count,
    int[] gear_results_kill_count,
    int[] gear_results_player_gear_id,
    int[] intimate_result_target_player_character_id,
    int[] intimate_results_exp,
    int[] intimate_results_player_character_id,
    bool is_game_over,
    int[] panel_entity_ids,
    int[] supply_results_supply_id,
    int[] supply_results_use_quantity,
    int[] unit_results_player_unit_id,
    int[] unit_results_received_damage,
    int[] unit_results_remaining_hp,
    int[] unit_results_rental,
    int[] unit_results_total_damage,
    int[] unit_results_total_damage_count,
    int[] unit_results_total_kill_count,
    int weak_element_attack_count,
    int weak_kind_attack_count,
    int win,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBattleCharacterFinish\u003Ec__Iterator48()
    {
      battle_turn = battle_turn,
      battle_uuid = battle_uuid,
      continue_count = continue_count,
      drop_entity_ids = drop_entity_ids,
      duels_critical_count = duels_critical_count,
      duels_damage = duels_damage,
      duels_hit_damage = duels_hit_damage,
      duels_max_damage = duels_max_damage,
      enemy_results_dead_count = enemy_results_dead_count,
      enemy_results_enemy_id = enemy_results_enemy_id,
      enemy_results_kill_count = enemy_results_kill_count,
      enemy_results_level_difference = enemy_results_level_difference,
      enemy_results_overkill_damage = enemy_results_overkill_damage,
      gear_results_damage_count = gear_results_damage_count,
      gear_results_kill_count = gear_results_kill_count,
      gear_results_player_gear_id = gear_results_player_gear_id,
      intimate_result_target_player_character_id = intimate_result_target_player_character_id,
      intimate_results_exp = intimate_results_exp,
      intimate_results_player_character_id = intimate_results_player_character_id,
      is_game_over = is_game_over,
      panel_entity_ids = panel_entity_ids,
      supply_results_supply_id = supply_results_supply_id,
      supply_results_use_quantity = supply_results_use_quantity,
      unit_results_player_unit_id = unit_results_player_unit_id,
      unit_results_received_damage = unit_results_received_damage,
      unit_results_remaining_hp = unit_results_remaining_hp,
      unit_results_rental = unit_results_rental,
      unit_results_total_damage = unit_results_total_damage,
      unit_results_total_damage_count = unit_results_total_damage_count,
      unit_results_total_kill_count = unit_results_total_kill_count,
      weak_element_attack_count = weak_element_attack_count,
      weak_kind_attack_count = weak_kind_attack_count,
      win = win,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebattle_turn = battle_turn,
      \u003C\u0024\u003Ebattle_uuid = battle_uuid,
      \u003C\u0024\u003Econtinue_count = continue_count,
      \u003C\u0024\u003Edrop_entity_ids = drop_entity_ids,
      \u003C\u0024\u003Eduels_critical_count = duels_critical_count,
      \u003C\u0024\u003Eduels_damage = duels_damage,
      \u003C\u0024\u003Eduels_hit_damage = duels_hit_damage,
      \u003C\u0024\u003Eduels_max_damage = duels_max_damage,
      \u003C\u0024\u003Eenemy_results_dead_count = enemy_results_dead_count,
      \u003C\u0024\u003Eenemy_results_enemy_id = enemy_results_enemy_id,
      \u003C\u0024\u003Eenemy_results_kill_count = enemy_results_kill_count,
      \u003C\u0024\u003Eenemy_results_level_difference = enemy_results_level_difference,
      \u003C\u0024\u003Eenemy_results_overkill_damage = enemy_results_overkill_damage,
      \u003C\u0024\u003Egear_results_damage_count = gear_results_damage_count,
      \u003C\u0024\u003Egear_results_kill_count = gear_results_kill_count,
      \u003C\u0024\u003Egear_results_player_gear_id = gear_results_player_gear_id,
      \u003C\u0024\u003Eintimate_result_target_player_character_id = intimate_result_target_player_character_id,
      \u003C\u0024\u003Eintimate_results_exp = intimate_results_exp,
      \u003C\u0024\u003Eintimate_results_player_character_id = intimate_results_player_character_id,
      \u003C\u0024\u003Eis_game_over = is_game_over,
      \u003C\u0024\u003Epanel_entity_ids = panel_entity_ids,
      \u003C\u0024\u003Esupply_results_supply_id = supply_results_supply_id,
      \u003C\u0024\u003Esupply_results_use_quantity = supply_results_use_quantity,
      \u003C\u0024\u003Eunit_results_player_unit_id = unit_results_player_unit_id,
      \u003C\u0024\u003Eunit_results_received_damage = unit_results_received_damage,
      \u003C\u0024\u003Eunit_results_remaining_hp = unit_results_remaining_hp,
      \u003C\u0024\u003Eunit_results_rental = unit_results_rental,
      \u003C\u0024\u003Eunit_results_total_damage = unit_results_total_damage,
      \u003C\u0024\u003Eunit_results_total_damage_count = unit_results_total_damage_count,
      \u003C\u0024\u003Eunit_results_total_kill_count = unit_results_total_kill_count,
      \u003C\u0024\u003Eweak_element_attack_count = weak_element_attack_count,
      \u003C\u0024\u003Eweak_kind_attack_count = weak_kind_attack_count,
      \u003C\u0024\u003Ewin = win,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBattleCharacterFinish(
    int battle_turn,
    string battle_uuid,
    int continue_count,
    int[] drop_entity_ids,
    int[] duels_critical_count,
    int[] duels_damage,
    int[] duels_hit_damage,
    int[] duels_max_damage,
    int[] enemy_results_dead_count,
    int[] enemy_results_enemy_id,
    int[] enemy_results_kill_count,
    int[] enemy_results_level_difference,
    int[] enemy_results_overkill_damage,
    int[] gear_results_damage_count,
    int[] gear_results_kill_count,
    int[] gear_results_player_gear_id,
    int[] intimate_result_target_player_character_id,
    int[] intimate_results_exp,
    int[] intimate_results_player_character_id,
    bool is_game_over,
    int[] panel_entity_ids,
    int[] supply_results_supply_id,
    int[] supply_results_use_quantity,
    int[] unit_results_player_unit_id,
    int[] unit_results_received_damage,
    int[] unit_results_remaining_hp,
    int[] unit_results_rental,
    int[] unit_results_total_damage,
    int[] unit_results_total_damage_count,
    int[] unit_results_total_kill_count,
    int weak_element_attack_count,
    int weak_kind_attack_count,
    int win,
    Action<WebAPI.Response.BattleCharacterFinish> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/battle/character/finish", new Dictionary<string, object>()
    {
      [nameof (battle_turn)] = (object) battle_turn,
      [nameof (battle_uuid)] = (object) battle_uuid,
      [nameof (continue_count)] = (object) continue_count,
      [nameof (drop_entity_ids)] = (object) drop_entity_ids,
      [nameof (duels_critical_count)] = (object) duels_critical_count,
      [nameof (duels_damage)] = (object) duels_damage,
      [nameof (duels_hit_damage)] = (object) duels_hit_damage,
      [nameof (duels_max_damage)] = (object) duels_max_damage,
      [nameof (enemy_results_dead_count)] = (object) enemy_results_dead_count,
      [nameof (enemy_results_enemy_id)] = (object) enemy_results_enemy_id,
      [nameof (enemy_results_kill_count)] = (object) enemy_results_kill_count,
      [nameof (enemy_results_level_difference)] = (object) enemy_results_level_difference,
      [nameof (enemy_results_overkill_damage)] = (object) enemy_results_overkill_damage,
      [nameof (gear_results_damage_count)] = (object) gear_results_damage_count,
      [nameof (gear_results_kill_count)] = (object) gear_results_kill_count,
      [nameof (gear_results_player_gear_id)] = (object) gear_results_player_gear_id,
      [nameof (intimate_result_target_player_character_id)] = (object) intimate_result_target_player_character_id,
      [nameof (intimate_results_exp)] = (object) intimate_results_exp,
      [nameof (intimate_results_player_character_id)] = (object) intimate_results_player_character_id,
      [nameof (is_game_over)] = (object) is_game_over,
      [nameof (panel_entity_ids)] = (object) panel_entity_ids,
      [nameof (supply_results_supply_id)] = (object) supply_results_supply_id,
      [nameof (supply_results_use_quantity)] = (object) supply_results_use_quantity,
      [nameof (unit_results_player_unit_id)] = (object) unit_results_player_unit_id,
      [nameof (unit_results_received_damage)] = (object) unit_results_received_damage,
      [nameof (unit_results_remaining_hp)] = (object) unit_results_remaining_hp,
      [nameof (unit_results_rental)] = (object) unit_results_rental,
      [nameof (unit_results_total_damage)] = (object) unit_results_total_damage,
      [nameof (unit_results_total_damage_count)] = (object) unit_results_total_damage_count,
      [nameof (unit_results_total_kill_count)] = (object) unit_results_total_kill_count,
      [nameof (weak_element_attack_count)] = (object) weak_element_attack_count,
      [nameof (weak_kind_attack_count)] = (object) weak_kind_attack_count,
      [nameof (win)] = (object) win
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.BattleCharacterFinish) null);
      }
      else
        callback(new WebAPI.Response.BattleCharacterFinish(json.Json));
    }));
  }

  public static Future<WebAPI.Response.BattleCharacterStart> BattleCharacterStart(
    int deck_number,
    int deck_type_id,
    int quest_s_id,
    string support_player_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.BattleCharacterStart>((Func<Promise<WebAPI.Response.BattleCharacterStart>, IEnumerator>) (promise => WebAPI.LoadBattleCharacterStart(promise, deck_number, deck_type_id, quest_s_id, support_player_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBattleCharacterStart(
    Promise<WebAPI.Response.BattleCharacterStart> promise,
    int deck_number,
    int deck_type_id,
    int quest_s_id,
    string support_player_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBattleCharacterStart\u003Ec__Iterator49()
    {
      deck_number = deck_number,
      deck_type_id = deck_type_id,
      quest_s_id = quest_s_id,
      support_player_id = support_player_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Edeck_number = deck_number,
      \u003C\u0024\u003Edeck_type_id = deck_type_id,
      \u003C\u0024\u003Equest_s_id = quest_s_id,
      \u003C\u0024\u003Esupport_player_id = support_player_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBattleCharacterStart(
    int deck_number,
    int deck_type_id,
    int quest_s_id,
    string support_player_id,
    Action<WebAPI.Response.BattleCharacterStart> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/battle/character/start", new Dictionary<string, object>()
    {
      [nameof (deck_number)] = (object) deck_number,
      [nameof (deck_type_id)] = (object) deck_type_id,
      [nameof (quest_s_id)] = (object) quest_s_id,
      [nameof (support_player_id)] = (object) support_player_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.BattleCharacterStart) null);
      }
      else
        callback(new WebAPI.Response.BattleCharacterStart(json.Json));
    }));
  }

  public static Future<WebAPI.Response.BattleExtraFinish> BattleExtraFinish(
    int battle_turn,
    string battle_uuid,
    int continue_count,
    int[] drop_entity_ids,
    int[] duels_critical_count,
    int[] duels_damage,
    int[] duels_hit_damage,
    int[] duels_max_damage,
    int[] enemy_results_dead_count,
    int[] enemy_results_enemy_id,
    int[] enemy_results_kill_count,
    int[] enemy_results_level_difference,
    int[] enemy_results_overkill_damage,
    int[] gear_results_damage_count,
    int[] gear_results_kill_count,
    int[] gear_results_player_gear_id,
    int[] intimate_result_target_player_character_id,
    int[] intimate_results_exp,
    int[] intimate_results_player_character_id,
    bool is_game_over,
    int[] panel_entity_ids,
    int[] supply_results_supply_id,
    int[] supply_results_use_quantity,
    int[] unit_results_player_unit_id,
    int[] unit_results_received_damage,
    int[] unit_results_remaining_hp,
    int[] unit_results_rental,
    int[] unit_results_total_damage,
    int[] unit_results_total_damage_count,
    int[] unit_results_total_kill_count,
    int weak_element_attack_count,
    int weak_kind_attack_count,
    int win,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.BattleExtraFinish>((Func<Promise<WebAPI.Response.BattleExtraFinish>, IEnumerator>) (promise => WebAPI.LoadBattleExtraFinish(promise, battle_turn, battle_uuid, continue_count, drop_entity_ids, duels_critical_count, duels_damage, duels_hit_damage, duels_max_damage, enemy_results_dead_count, enemy_results_enemy_id, enemy_results_kill_count, enemy_results_level_difference, enemy_results_overkill_damage, gear_results_damage_count, gear_results_kill_count, gear_results_player_gear_id, intimate_result_target_player_character_id, intimate_results_exp, intimate_results_player_character_id, is_game_over, panel_entity_ids, supply_results_supply_id, supply_results_use_quantity, unit_results_player_unit_id, unit_results_received_damage, unit_results_remaining_hp, unit_results_rental, unit_results_total_damage, unit_results_total_damage_count, unit_results_total_kill_count, weak_element_attack_count, weak_kind_attack_count, win, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBattleExtraFinish(
    Promise<WebAPI.Response.BattleExtraFinish> promise,
    int battle_turn,
    string battle_uuid,
    int continue_count,
    int[] drop_entity_ids,
    int[] duels_critical_count,
    int[] duels_damage,
    int[] duels_hit_damage,
    int[] duels_max_damage,
    int[] enemy_results_dead_count,
    int[] enemy_results_enemy_id,
    int[] enemy_results_kill_count,
    int[] enemy_results_level_difference,
    int[] enemy_results_overkill_damage,
    int[] gear_results_damage_count,
    int[] gear_results_kill_count,
    int[] gear_results_player_gear_id,
    int[] intimate_result_target_player_character_id,
    int[] intimate_results_exp,
    int[] intimate_results_player_character_id,
    bool is_game_over,
    int[] panel_entity_ids,
    int[] supply_results_supply_id,
    int[] supply_results_use_quantity,
    int[] unit_results_player_unit_id,
    int[] unit_results_received_damage,
    int[] unit_results_remaining_hp,
    int[] unit_results_rental,
    int[] unit_results_total_damage,
    int[] unit_results_total_damage_count,
    int[] unit_results_total_kill_count,
    int weak_element_attack_count,
    int weak_kind_attack_count,
    int win,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBattleExtraFinish\u003Ec__Iterator4A()
    {
      battle_turn = battle_turn,
      battle_uuid = battle_uuid,
      continue_count = continue_count,
      drop_entity_ids = drop_entity_ids,
      duels_critical_count = duels_critical_count,
      duels_damage = duels_damage,
      duels_hit_damage = duels_hit_damage,
      duels_max_damage = duels_max_damage,
      enemy_results_dead_count = enemy_results_dead_count,
      enemy_results_enemy_id = enemy_results_enemy_id,
      enemy_results_kill_count = enemy_results_kill_count,
      enemy_results_level_difference = enemy_results_level_difference,
      enemy_results_overkill_damage = enemy_results_overkill_damage,
      gear_results_damage_count = gear_results_damage_count,
      gear_results_kill_count = gear_results_kill_count,
      gear_results_player_gear_id = gear_results_player_gear_id,
      intimate_result_target_player_character_id = intimate_result_target_player_character_id,
      intimate_results_exp = intimate_results_exp,
      intimate_results_player_character_id = intimate_results_player_character_id,
      is_game_over = is_game_over,
      panel_entity_ids = panel_entity_ids,
      supply_results_supply_id = supply_results_supply_id,
      supply_results_use_quantity = supply_results_use_quantity,
      unit_results_player_unit_id = unit_results_player_unit_id,
      unit_results_received_damage = unit_results_received_damage,
      unit_results_remaining_hp = unit_results_remaining_hp,
      unit_results_rental = unit_results_rental,
      unit_results_total_damage = unit_results_total_damage,
      unit_results_total_damage_count = unit_results_total_damage_count,
      unit_results_total_kill_count = unit_results_total_kill_count,
      weak_element_attack_count = weak_element_attack_count,
      weak_kind_attack_count = weak_kind_attack_count,
      win = win,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebattle_turn = battle_turn,
      \u003C\u0024\u003Ebattle_uuid = battle_uuid,
      \u003C\u0024\u003Econtinue_count = continue_count,
      \u003C\u0024\u003Edrop_entity_ids = drop_entity_ids,
      \u003C\u0024\u003Eduels_critical_count = duels_critical_count,
      \u003C\u0024\u003Eduels_damage = duels_damage,
      \u003C\u0024\u003Eduels_hit_damage = duels_hit_damage,
      \u003C\u0024\u003Eduels_max_damage = duels_max_damage,
      \u003C\u0024\u003Eenemy_results_dead_count = enemy_results_dead_count,
      \u003C\u0024\u003Eenemy_results_enemy_id = enemy_results_enemy_id,
      \u003C\u0024\u003Eenemy_results_kill_count = enemy_results_kill_count,
      \u003C\u0024\u003Eenemy_results_level_difference = enemy_results_level_difference,
      \u003C\u0024\u003Eenemy_results_overkill_damage = enemy_results_overkill_damage,
      \u003C\u0024\u003Egear_results_damage_count = gear_results_damage_count,
      \u003C\u0024\u003Egear_results_kill_count = gear_results_kill_count,
      \u003C\u0024\u003Egear_results_player_gear_id = gear_results_player_gear_id,
      \u003C\u0024\u003Eintimate_result_target_player_character_id = intimate_result_target_player_character_id,
      \u003C\u0024\u003Eintimate_results_exp = intimate_results_exp,
      \u003C\u0024\u003Eintimate_results_player_character_id = intimate_results_player_character_id,
      \u003C\u0024\u003Eis_game_over = is_game_over,
      \u003C\u0024\u003Epanel_entity_ids = panel_entity_ids,
      \u003C\u0024\u003Esupply_results_supply_id = supply_results_supply_id,
      \u003C\u0024\u003Esupply_results_use_quantity = supply_results_use_quantity,
      \u003C\u0024\u003Eunit_results_player_unit_id = unit_results_player_unit_id,
      \u003C\u0024\u003Eunit_results_received_damage = unit_results_received_damage,
      \u003C\u0024\u003Eunit_results_remaining_hp = unit_results_remaining_hp,
      \u003C\u0024\u003Eunit_results_rental = unit_results_rental,
      \u003C\u0024\u003Eunit_results_total_damage = unit_results_total_damage,
      \u003C\u0024\u003Eunit_results_total_damage_count = unit_results_total_damage_count,
      \u003C\u0024\u003Eunit_results_total_kill_count = unit_results_total_kill_count,
      \u003C\u0024\u003Eweak_element_attack_count = weak_element_attack_count,
      \u003C\u0024\u003Eweak_kind_attack_count = weak_kind_attack_count,
      \u003C\u0024\u003Ewin = win,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBattleExtraFinish(
    int battle_turn,
    string battle_uuid,
    int continue_count,
    int[] drop_entity_ids,
    int[] duels_critical_count,
    int[] duels_damage,
    int[] duels_hit_damage,
    int[] duels_max_damage,
    int[] enemy_results_dead_count,
    int[] enemy_results_enemy_id,
    int[] enemy_results_kill_count,
    int[] enemy_results_level_difference,
    int[] enemy_results_overkill_damage,
    int[] gear_results_damage_count,
    int[] gear_results_kill_count,
    int[] gear_results_player_gear_id,
    int[] intimate_result_target_player_character_id,
    int[] intimate_results_exp,
    int[] intimate_results_player_character_id,
    bool is_game_over,
    int[] panel_entity_ids,
    int[] supply_results_supply_id,
    int[] supply_results_use_quantity,
    int[] unit_results_player_unit_id,
    int[] unit_results_received_damage,
    int[] unit_results_remaining_hp,
    int[] unit_results_rental,
    int[] unit_results_total_damage,
    int[] unit_results_total_damage_count,
    int[] unit_results_total_kill_count,
    int weak_element_attack_count,
    int weak_kind_attack_count,
    int win,
    Action<WebAPI.Response.BattleExtraFinish> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/battle/extra/finish", new Dictionary<string, object>()
    {
      [nameof (battle_turn)] = (object) battle_turn,
      [nameof (battle_uuid)] = (object) battle_uuid,
      [nameof (continue_count)] = (object) continue_count,
      [nameof (drop_entity_ids)] = (object) drop_entity_ids,
      [nameof (duels_critical_count)] = (object) duels_critical_count,
      [nameof (duels_damage)] = (object) duels_damage,
      [nameof (duels_hit_damage)] = (object) duels_hit_damage,
      [nameof (duels_max_damage)] = (object) duels_max_damage,
      [nameof (enemy_results_dead_count)] = (object) enemy_results_dead_count,
      [nameof (enemy_results_enemy_id)] = (object) enemy_results_enemy_id,
      [nameof (enemy_results_kill_count)] = (object) enemy_results_kill_count,
      [nameof (enemy_results_level_difference)] = (object) enemy_results_level_difference,
      [nameof (enemy_results_overkill_damage)] = (object) enemy_results_overkill_damage,
      [nameof (gear_results_damage_count)] = (object) gear_results_damage_count,
      [nameof (gear_results_kill_count)] = (object) gear_results_kill_count,
      [nameof (gear_results_player_gear_id)] = (object) gear_results_player_gear_id,
      [nameof (intimate_result_target_player_character_id)] = (object) intimate_result_target_player_character_id,
      [nameof (intimate_results_exp)] = (object) intimate_results_exp,
      [nameof (intimate_results_player_character_id)] = (object) intimate_results_player_character_id,
      [nameof (is_game_over)] = (object) is_game_over,
      [nameof (panel_entity_ids)] = (object) panel_entity_ids,
      [nameof (supply_results_supply_id)] = (object) supply_results_supply_id,
      [nameof (supply_results_use_quantity)] = (object) supply_results_use_quantity,
      [nameof (unit_results_player_unit_id)] = (object) unit_results_player_unit_id,
      [nameof (unit_results_received_damage)] = (object) unit_results_received_damage,
      [nameof (unit_results_remaining_hp)] = (object) unit_results_remaining_hp,
      [nameof (unit_results_rental)] = (object) unit_results_rental,
      [nameof (unit_results_total_damage)] = (object) unit_results_total_damage,
      [nameof (unit_results_total_damage_count)] = (object) unit_results_total_damage_count,
      [nameof (unit_results_total_kill_count)] = (object) unit_results_total_kill_count,
      [nameof (weak_element_attack_count)] = (object) weak_element_attack_count,
      [nameof (weak_kind_attack_count)] = (object) weak_kind_attack_count,
      [nameof (win)] = (object) win
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.BattleExtraFinish) null);
      }
      else
        callback(new WebAPI.Response.BattleExtraFinish(json.Json));
    }));
  }

  public static Future<WebAPI.Response.BattleExtraStart> BattleExtraStart(
    int deck_number,
    int deck_type_id,
    int quest_s_id,
    string support_player_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.BattleExtraStart>((Func<Promise<WebAPI.Response.BattleExtraStart>, IEnumerator>) (promise => WebAPI.LoadBattleExtraStart(promise, deck_number, deck_type_id, quest_s_id, support_player_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBattleExtraStart(
    Promise<WebAPI.Response.BattleExtraStart> promise,
    int deck_number,
    int deck_type_id,
    int quest_s_id,
    string support_player_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBattleExtraStart\u003Ec__Iterator4B()
    {
      deck_number = deck_number,
      deck_type_id = deck_type_id,
      quest_s_id = quest_s_id,
      support_player_id = support_player_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Edeck_number = deck_number,
      \u003C\u0024\u003Edeck_type_id = deck_type_id,
      \u003C\u0024\u003Equest_s_id = quest_s_id,
      \u003C\u0024\u003Esupport_player_id = support_player_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBattleExtraStart(
    int deck_number,
    int deck_type_id,
    int quest_s_id,
    string support_player_id,
    Action<WebAPI.Response.BattleExtraStart> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/battle/extra/start", new Dictionary<string, object>()
    {
      [nameof (deck_number)] = (object) deck_number,
      [nameof (deck_type_id)] = (object) deck_type_id,
      [nameof (quest_s_id)] = (object) quest_s_id,
      [nameof (support_player_id)] = (object) support_player_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.BattleExtraStart) null);
      }
      else
        callback(new WebAPI.Response.BattleExtraStart(json.Json));
    }));
  }

  public static Future<WebAPI.Response.BattleForceClose> BattleForceClose(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.BattleForceClose>((Func<Promise<WebAPI.Response.BattleForceClose>, IEnumerator>) (promise => WebAPI.LoadBattleForceClose(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBattleForceClose(
    Promise<WebAPI.Response.BattleForceClose> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBattleForceClose\u003Ec__Iterator4C()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBattleForceClose(
    Action<WebAPI.Response.BattleForceClose> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/battle/force-close", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.BattleForceClose) null);
      }
      else
        callback(new WebAPI.Response.BattleForceClose(json.Json));
    }));
  }

  public static Future<WebAPI.Response.BattleHarmonyFinish> BattleHarmonyFinish(
    int battle_turn,
    string battle_uuid,
    int continue_count,
    int[] drop_entity_ids,
    int[] duels_critical_count,
    int[] duels_damage,
    int[] duels_hit_damage,
    int[] duels_max_damage,
    int[] enemy_results_dead_count,
    int[] enemy_results_enemy_id,
    int[] enemy_results_kill_count,
    int[] enemy_results_level_difference,
    int[] enemy_results_overkill_damage,
    int[] gear_results_damage_count,
    int[] gear_results_kill_count,
    int[] gear_results_player_gear_id,
    int[] intimate_result_target_player_character_id,
    int[] intimate_results_exp,
    int[] intimate_results_player_character_id,
    bool is_game_over,
    int[] panel_entity_ids,
    int[] supply_results_supply_id,
    int[] supply_results_use_quantity,
    int[] unit_results_player_unit_id,
    int[] unit_results_received_damage,
    int[] unit_results_remaining_hp,
    int[] unit_results_rental,
    int[] unit_results_total_damage,
    int[] unit_results_total_damage_count,
    int[] unit_results_total_kill_count,
    int weak_element_attack_count,
    int weak_kind_attack_count,
    int win,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.BattleHarmonyFinish>((Func<Promise<WebAPI.Response.BattleHarmonyFinish>, IEnumerator>) (promise => WebAPI.LoadBattleHarmonyFinish(promise, battle_turn, battle_uuid, continue_count, drop_entity_ids, duels_critical_count, duels_damage, duels_hit_damage, duels_max_damage, enemy_results_dead_count, enemy_results_enemy_id, enemy_results_kill_count, enemy_results_level_difference, enemy_results_overkill_damage, gear_results_damage_count, gear_results_kill_count, gear_results_player_gear_id, intimate_result_target_player_character_id, intimate_results_exp, intimate_results_player_character_id, is_game_over, panel_entity_ids, supply_results_supply_id, supply_results_use_quantity, unit_results_player_unit_id, unit_results_received_damage, unit_results_remaining_hp, unit_results_rental, unit_results_total_damage, unit_results_total_damage_count, unit_results_total_kill_count, weak_element_attack_count, weak_kind_attack_count, win, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBattleHarmonyFinish(
    Promise<WebAPI.Response.BattleHarmonyFinish> promise,
    int battle_turn,
    string battle_uuid,
    int continue_count,
    int[] drop_entity_ids,
    int[] duels_critical_count,
    int[] duels_damage,
    int[] duels_hit_damage,
    int[] duels_max_damage,
    int[] enemy_results_dead_count,
    int[] enemy_results_enemy_id,
    int[] enemy_results_kill_count,
    int[] enemy_results_level_difference,
    int[] enemy_results_overkill_damage,
    int[] gear_results_damage_count,
    int[] gear_results_kill_count,
    int[] gear_results_player_gear_id,
    int[] intimate_result_target_player_character_id,
    int[] intimate_results_exp,
    int[] intimate_results_player_character_id,
    bool is_game_over,
    int[] panel_entity_ids,
    int[] supply_results_supply_id,
    int[] supply_results_use_quantity,
    int[] unit_results_player_unit_id,
    int[] unit_results_received_damage,
    int[] unit_results_remaining_hp,
    int[] unit_results_rental,
    int[] unit_results_total_damage,
    int[] unit_results_total_damage_count,
    int[] unit_results_total_kill_count,
    int weak_element_attack_count,
    int weak_kind_attack_count,
    int win,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBattleHarmonyFinish\u003Ec__Iterator4D()
    {
      battle_turn = battle_turn,
      battle_uuid = battle_uuid,
      continue_count = continue_count,
      drop_entity_ids = drop_entity_ids,
      duels_critical_count = duels_critical_count,
      duels_damage = duels_damage,
      duels_hit_damage = duels_hit_damage,
      duels_max_damage = duels_max_damage,
      enemy_results_dead_count = enemy_results_dead_count,
      enemy_results_enemy_id = enemy_results_enemy_id,
      enemy_results_kill_count = enemy_results_kill_count,
      enemy_results_level_difference = enemy_results_level_difference,
      enemy_results_overkill_damage = enemy_results_overkill_damage,
      gear_results_damage_count = gear_results_damage_count,
      gear_results_kill_count = gear_results_kill_count,
      gear_results_player_gear_id = gear_results_player_gear_id,
      intimate_result_target_player_character_id = intimate_result_target_player_character_id,
      intimate_results_exp = intimate_results_exp,
      intimate_results_player_character_id = intimate_results_player_character_id,
      is_game_over = is_game_over,
      panel_entity_ids = panel_entity_ids,
      supply_results_supply_id = supply_results_supply_id,
      supply_results_use_quantity = supply_results_use_quantity,
      unit_results_player_unit_id = unit_results_player_unit_id,
      unit_results_received_damage = unit_results_received_damage,
      unit_results_remaining_hp = unit_results_remaining_hp,
      unit_results_rental = unit_results_rental,
      unit_results_total_damage = unit_results_total_damage,
      unit_results_total_damage_count = unit_results_total_damage_count,
      unit_results_total_kill_count = unit_results_total_kill_count,
      weak_element_attack_count = weak_element_attack_count,
      weak_kind_attack_count = weak_kind_attack_count,
      win = win,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebattle_turn = battle_turn,
      \u003C\u0024\u003Ebattle_uuid = battle_uuid,
      \u003C\u0024\u003Econtinue_count = continue_count,
      \u003C\u0024\u003Edrop_entity_ids = drop_entity_ids,
      \u003C\u0024\u003Eduels_critical_count = duels_critical_count,
      \u003C\u0024\u003Eduels_damage = duels_damage,
      \u003C\u0024\u003Eduels_hit_damage = duels_hit_damage,
      \u003C\u0024\u003Eduels_max_damage = duels_max_damage,
      \u003C\u0024\u003Eenemy_results_dead_count = enemy_results_dead_count,
      \u003C\u0024\u003Eenemy_results_enemy_id = enemy_results_enemy_id,
      \u003C\u0024\u003Eenemy_results_kill_count = enemy_results_kill_count,
      \u003C\u0024\u003Eenemy_results_level_difference = enemy_results_level_difference,
      \u003C\u0024\u003Eenemy_results_overkill_damage = enemy_results_overkill_damage,
      \u003C\u0024\u003Egear_results_damage_count = gear_results_damage_count,
      \u003C\u0024\u003Egear_results_kill_count = gear_results_kill_count,
      \u003C\u0024\u003Egear_results_player_gear_id = gear_results_player_gear_id,
      \u003C\u0024\u003Eintimate_result_target_player_character_id = intimate_result_target_player_character_id,
      \u003C\u0024\u003Eintimate_results_exp = intimate_results_exp,
      \u003C\u0024\u003Eintimate_results_player_character_id = intimate_results_player_character_id,
      \u003C\u0024\u003Eis_game_over = is_game_over,
      \u003C\u0024\u003Epanel_entity_ids = panel_entity_ids,
      \u003C\u0024\u003Esupply_results_supply_id = supply_results_supply_id,
      \u003C\u0024\u003Esupply_results_use_quantity = supply_results_use_quantity,
      \u003C\u0024\u003Eunit_results_player_unit_id = unit_results_player_unit_id,
      \u003C\u0024\u003Eunit_results_received_damage = unit_results_received_damage,
      \u003C\u0024\u003Eunit_results_remaining_hp = unit_results_remaining_hp,
      \u003C\u0024\u003Eunit_results_rental = unit_results_rental,
      \u003C\u0024\u003Eunit_results_total_damage = unit_results_total_damage,
      \u003C\u0024\u003Eunit_results_total_damage_count = unit_results_total_damage_count,
      \u003C\u0024\u003Eunit_results_total_kill_count = unit_results_total_kill_count,
      \u003C\u0024\u003Eweak_element_attack_count = weak_element_attack_count,
      \u003C\u0024\u003Eweak_kind_attack_count = weak_kind_attack_count,
      \u003C\u0024\u003Ewin = win,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBattleHarmonyFinish(
    int battle_turn,
    string battle_uuid,
    int continue_count,
    int[] drop_entity_ids,
    int[] duels_critical_count,
    int[] duels_damage,
    int[] duels_hit_damage,
    int[] duels_max_damage,
    int[] enemy_results_dead_count,
    int[] enemy_results_enemy_id,
    int[] enemy_results_kill_count,
    int[] enemy_results_level_difference,
    int[] enemy_results_overkill_damage,
    int[] gear_results_damage_count,
    int[] gear_results_kill_count,
    int[] gear_results_player_gear_id,
    int[] intimate_result_target_player_character_id,
    int[] intimate_results_exp,
    int[] intimate_results_player_character_id,
    bool is_game_over,
    int[] panel_entity_ids,
    int[] supply_results_supply_id,
    int[] supply_results_use_quantity,
    int[] unit_results_player_unit_id,
    int[] unit_results_received_damage,
    int[] unit_results_remaining_hp,
    int[] unit_results_rental,
    int[] unit_results_total_damage,
    int[] unit_results_total_damage_count,
    int[] unit_results_total_kill_count,
    int weak_element_attack_count,
    int weak_kind_attack_count,
    int win,
    Action<WebAPI.Response.BattleHarmonyFinish> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/battle/harmony/finish", new Dictionary<string, object>()
    {
      [nameof (battle_turn)] = (object) battle_turn,
      [nameof (battle_uuid)] = (object) battle_uuid,
      [nameof (continue_count)] = (object) continue_count,
      [nameof (drop_entity_ids)] = (object) drop_entity_ids,
      [nameof (duels_critical_count)] = (object) duels_critical_count,
      [nameof (duels_damage)] = (object) duels_damage,
      [nameof (duels_hit_damage)] = (object) duels_hit_damage,
      [nameof (duels_max_damage)] = (object) duels_max_damage,
      [nameof (enemy_results_dead_count)] = (object) enemy_results_dead_count,
      [nameof (enemy_results_enemy_id)] = (object) enemy_results_enemy_id,
      [nameof (enemy_results_kill_count)] = (object) enemy_results_kill_count,
      [nameof (enemy_results_level_difference)] = (object) enemy_results_level_difference,
      [nameof (enemy_results_overkill_damage)] = (object) enemy_results_overkill_damage,
      [nameof (gear_results_damage_count)] = (object) gear_results_damage_count,
      [nameof (gear_results_kill_count)] = (object) gear_results_kill_count,
      [nameof (gear_results_player_gear_id)] = (object) gear_results_player_gear_id,
      [nameof (intimate_result_target_player_character_id)] = (object) intimate_result_target_player_character_id,
      [nameof (intimate_results_exp)] = (object) intimate_results_exp,
      [nameof (intimate_results_player_character_id)] = (object) intimate_results_player_character_id,
      [nameof (is_game_over)] = (object) is_game_over,
      [nameof (panel_entity_ids)] = (object) panel_entity_ids,
      [nameof (supply_results_supply_id)] = (object) supply_results_supply_id,
      [nameof (supply_results_use_quantity)] = (object) supply_results_use_quantity,
      [nameof (unit_results_player_unit_id)] = (object) unit_results_player_unit_id,
      [nameof (unit_results_received_damage)] = (object) unit_results_received_damage,
      [nameof (unit_results_remaining_hp)] = (object) unit_results_remaining_hp,
      [nameof (unit_results_rental)] = (object) unit_results_rental,
      [nameof (unit_results_total_damage)] = (object) unit_results_total_damage,
      [nameof (unit_results_total_damage_count)] = (object) unit_results_total_damage_count,
      [nameof (unit_results_total_kill_count)] = (object) unit_results_total_kill_count,
      [nameof (weak_element_attack_count)] = (object) weak_element_attack_count,
      [nameof (weak_kind_attack_count)] = (object) weak_kind_attack_count,
      [nameof (win)] = (object) win
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.BattleHarmonyFinish) null);
      }
      else
        callback(new WebAPI.Response.BattleHarmonyFinish(json.Json));
    }));
  }

  public static Future<WebAPI.Response.BattleHarmonyStart> BattleHarmonyStart(
    int deck_number,
    int deck_type_id,
    int quest_s_id,
    string support_player_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.BattleHarmonyStart>((Func<Promise<WebAPI.Response.BattleHarmonyStart>, IEnumerator>) (promise => WebAPI.LoadBattleHarmonyStart(promise, deck_number, deck_type_id, quest_s_id, support_player_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBattleHarmonyStart(
    Promise<WebAPI.Response.BattleHarmonyStart> promise,
    int deck_number,
    int deck_type_id,
    int quest_s_id,
    string support_player_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBattleHarmonyStart\u003Ec__Iterator4E()
    {
      deck_number = deck_number,
      deck_type_id = deck_type_id,
      quest_s_id = quest_s_id,
      support_player_id = support_player_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Edeck_number = deck_number,
      \u003C\u0024\u003Edeck_type_id = deck_type_id,
      \u003C\u0024\u003Equest_s_id = quest_s_id,
      \u003C\u0024\u003Esupport_player_id = support_player_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBattleHarmonyStart(
    int deck_number,
    int deck_type_id,
    int quest_s_id,
    string support_player_id,
    Action<WebAPI.Response.BattleHarmonyStart> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/battle/harmony/start", new Dictionary<string, object>()
    {
      [nameof (deck_number)] = (object) deck_number,
      [nameof (deck_type_id)] = (object) deck_type_id,
      [nameof (quest_s_id)] = (object) quest_s_id,
      [nameof (support_player_id)] = (object) support_player_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.BattleHarmonyStart) null);
      }
      else
        callback(new WebAPI.Response.BattleHarmonyStart(json.Json));
    }));
  }

  public static Future<WebAPI.Response.BattleResume> BattleResume(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.BattleResume>((Func<Promise<WebAPI.Response.BattleResume>, IEnumerator>) (promise => WebAPI.LoadBattleResume(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBattleResume(
    Promise<WebAPI.Response.BattleResume> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBattleResume\u003Ec__Iterator4F()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBattleResume(
    Action<WebAPI.Response.BattleResume> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/battle/resume", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.BattleResume) null);
      }
      else
        callback(new WebAPI.Response.BattleResume(json.Json));
    }));
  }

  public static Future<WebAPI.Response.BattleRetire> BattleRetire(
    int continue_count,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.BattleRetire>((Func<Promise<WebAPI.Response.BattleRetire>, IEnumerator>) (promise => WebAPI.LoadBattleRetire(promise, continue_count, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBattleRetire(
    Promise<WebAPI.Response.BattleRetire> promise,
    int continue_count,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBattleRetire\u003Ec__Iterator50()
    {
      continue_count = continue_count,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Econtinue_count = continue_count,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBattleRetire(
    int continue_count,
    Action<WebAPI.Response.BattleRetire> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/battle/retire", new Dictionary<string, object>()
    {
      [nameof (continue_count)] = (object) continue_count
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.BattleRetire) null);
      }
      else
        callback(new WebAPI.Response.BattleRetire(json.Json));
    }));
  }

  public static Future<WebAPI.Response.BattleStoryFinish> BattleStoryFinish(
    int battle_turn,
    string battle_uuid,
    int continue_count,
    int[] drop_entity_ids,
    int[] duels_critical_count,
    int[] duels_damage,
    int[] duels_hit_damage,
    int[] duels_max_damage,
    int[] enemy_results_dead_count,
    int[] enemy_results_enemy_id,
    int[] enemy_results_kill_count,
    int[] enemy_results_level_difference,
    int[] enemy_results_overkill_damage,
    int[] gear_results_damage_count,
    int[] gear_results_kill_count,
    int[] gear_results_player_gear_id,
    int[] intimate_result_target_player_character_id,
    int[] intimate_results_exp,
    int[] intimate_results_player_character_id,
    bool is_game_over,
    int[] panel_entity_ids,
    int[] supply_results_supply_id,
    int[] supply_results_use_quantity,
    int[] unit_results_player_unit_id,
    int[] unit_results_received_damage,
    int[] unit_results_remaining_hp,
    int[] unit_results_rental,
    int[] unit_results_total_damage,
    int[] unit_results_total_damage_count,
    int[] unit_results_total_kill_count,
    int weak_element_attack_count,
    int weak_kind_attack_count,
    int win,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.BattleStoryFinish>((Func<Promise<WebAPI.Response.BattleStoryFinish>, IEnumerator>) (promise => WebAPI.LoadBattleStoryFinish(promise, battle_turn, battle_uuid, continue_count, drop_entity_ids, duels_critical_count, duels_damage, duels_hit_damage, duels_max_damage, enemy_results_dead_count, enemy_results_enemy_id, enemy_results_kill_count, enemy_results_level_difference, enemy_results_overkill_damage, gear_results_damage_count, gear_results_kill_count, gear_results_player_gear_id, intimate_result_target_player_character_id, intimate_results_exp, intimate_results_player_character_id, is_game_over, panel_entity_ids, supply_results_supply_id, supply_results_use_quantity, unit_results_player_unit_id, unit_results_received_damage, unit_results_remaining_hp, unit_results_rental, unit_results_total_damage, unit_results_total_damage_count, unit_results_total_kill_count, weak_element_attack_count, weak_kind_attack_count, win, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBattleStoryFinish(
    Promise<WebAPI.Response.BattleStoryFinish> promise,
    int battle_turn,
    string battle_uuid,
    int continue_count,
    int[] drop_entity_ids,
    int[] duels_critical_count,
    int[] duels_damage,
    int[] duels_hit_damage,
    int[] duels_max_damage,
    int[] enemy_results_dead_count,
    int[] enemy_results_enemy_id,
    int[] enemy_results_kill_count,
    int[] enemy_results_level_difference,
    int[] enemy_results_overkill_damage,
    int[] gear_results_damage_count,
    int[] gear_results_kill_count,
    int[] gear_results_player_gear_id,
    int[] intimate_result_target_player_character_id,
    int[] intimate_results_exp,
    int[] intimate_results_player_character_id,
    bool is_game_over,
    int[] panel_entity_ids,
    int[] supply_results_supply_id,
    int[] supply_results_use_quantity,
    int[] unit_results_player_unit_id,
    int[] unit_results_received_damage,
    int[] unit_results_remaining_hp,
    int[] unit_results_rental,
    int[] unit_results_total_damage,
    int[] unit_results_total_damage_count,
    int[] unit_results_total_kill_count,
    int weak_element_attack_count,
    int weak_kind_attack_count,
    int win,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBattleStoryFinish\u003Ec__Iterator51()
    {
      battle_turn = battle_turn,
      battle_uuid = battle_uuid,
      continue_count = continue_count,
      drop_entity_ids = drop_entity_ids,
      duels_critical_count = duels_critical_count,
      duels_damage = duels_damage,
      duels_hit_damage = duels_hit_damage,
      duels_max_damage = duels_max_damage,
      enemy_results_dead_count = enemy_results_dead_count,
      enemy_results_enemy_id = enemy_results_enemy_id,
      enemy_results_kill_count = enemy_results_kill_count,
      enemy_results_level_difference = enemy_results_level_difference,
      enemy_results_overkill_damage = enemy_results_overkill_damage,
      gear_results_damage_count = gear_results_damage_count,
      gear_results_kill_count = gear_results_kill_count,
      gear_results_player_gear_id = gear_results_player_gear_id,
      intimate_result_target_player_character_id = intimate_result_target_player_character_id,
      intimate_results_exp = intimate_results_exp,
      intimate_results_player_character_id = intimate_results_player_character_id,
      is_game_over = is_game_over,
      panel_entity_ids = panel_entity_ids,
      supply_results_supply_id = supply_results_supply_id,
      supply_results_use_quantity = supply_results_use_quantity,
      unit_results_player_unit_id = unit_results_player_unit_id,
      unit_results_received_damage = unit_results_received_damage,
      unit_results_remaining_hp = unit_results_remaining_hp,
      unit_results_rental = unit_results_rental,
      unit_results_total_damage = unit_results_total_damage,
      unit_results_total_damage_count = unit_results_total_damage_count,
      unit_results_total_kill_count = unit_results_total_kill_count,
      weak_element_attack_count = weak_element_attack_count,
      weak_kind_attack_count = weak_kind_attack_count,
      win = win,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebattle_turn = battle_turn,
      \u003C\u0024\u003Ebattle_uuid = battle_uuid,
      \u003C\u0024\u003Econtinue_count = continue_count,
      \u003C\u0024\u003Edrop_entity_ids = drop_entity_ids,
      \u003C\u0024\u003Eduels_critical_count = duels_critical_count,
      \u003C\u0024\u003Eduels_damage = duels_damage,
      \u003C\u0024\u003Eduels_hit_damage = duels_hit_damage,
      \u003C\u0024\u003Eduels_max_damage = duels_max_damage,
      \u003C\u0024\u003Eenemy_results_dead_count = enemy_results_dead_count,
      \u003C\u0024\u003Eenemy_results_enemy_id = enemy_results_enemy_id,
      \u003C\u0024\u003Eenemy_results_kill_count = enemy_results_kill_count,
      \u003C\u0024\u003Eenemy_results_level_difference = enemy_results_level_difference,
      \u003C\u0024\u003Eenemy_results_overkill_damage = enemy_results_overkill_damage,
      \u003C\u0024\u003Egear_results_damage_count = gear_results_damage_count,
      \u003C\u0024\u003Egear_results_kill_count = gear_results_kill_count,
      \u003C\u0024\u003Egear_results_player_gear_id = gear_results_player_gear_id,
      \u003C\u0024\u003Eintimate_result_target_player_character_id = intimate_result_target_player_character_id,
      \u003C\u0024\u003Eintimate_results_exp = intimate_results_exp,
      \u003C\u0024\u003Eintimate_results_player_character_id = intimate_results_player_character_id,
      \u003C\u0024\u003Eis_game_over = is_game_over,
      \u003C\u0024\u003Epanel_entity_ids = panel_entity_ids,
      \u003C\u0024\u003Esupply_results_supply_id = supply_results_supply_id,
      \u003C\u0024\u003Esupply_results_use_quantity = supply_results_use_quantity,
      \u003C\u0024\u003Eunit_results_player_unit_id = unit_results_player_unit_id,
      \u003C\u0024\u003Eunit_results_received_damage = unit_results_received_damage,
      \u003C\u0024\u003Eunit_results_remaining_hp = unit_results_remaining_hp,
      \u003C\u0024\u003Eunit_results_rental = unit_results_rental,
      \u003C\u0024\u003Eunit_results_total_damage = unit_results_total_damage,
      \u003C\u0024\u003Eunit_results_total_damage_count = unit_results_total_damage_count,
      \u003C\u0024\u003Eunit_results_total_kill_count = unit_results_total_kill_count,
      \u003C\u0024\u003Eweak_element_attack_count = weak_element_attack_count,
      \u003C\u0024\u003Eweak_kind_attack_count = weak_kind_attack_count,
      \u003C\u0024\u003Ewin = win,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBattleStoryFinish(
    int battle_turn,
    string battle_uuid,
    int continue_count,
    int[] drop_entity_ids,
    int[] duels_critical_count,
    int[] duels_damage,
    int[] duels_hit_damage,
    int[] duels_max_damage,
    int[] enemy_results_dead_count,
    int[] enemy_results_enemy_id,
    int[] enemy_results_kill_count,
    int[] enemy_results_level_difference,
    int[] enemy_results_overkill_damage,
    int[] gear_results_damage_count,
    int[] gear_results_kill_count,
    int[] gear_results_player_gear_id,
    int[] intimate_result_target_player_character_id,
    int[] intimate_results_exp,
    int[] intimate_results_player_character_id,
    bool is_game_over,
    int[] panel_entity_ids,
    int[] supply_results_supply_id,
    int[] supply_results_use_quantity,
    int[] unit_results_player_unit_id,
    int[] unit_results_received_damage,
    int[] unit_results_remaining_hp,
    int[] unit_results_rental,
    int[] unit_results_total_damage,
    int[] unit_results_total_damage_count,
    int[] unit_results_total_kill_count,
    int weak_element_attack_count,
    int weak_kind_attack_count,
    int win,
    Action<WebAPI.Response.BattleStoryFinish> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/battle/story/finish", new Dictionary<string, object>()
    {
      [nameof (battle_turn)] = (object) battle_turn,
      [nameof (battle_uuid)] = (object) battle_uuid,
      [nameof (continue_count)] = (object) continue_count,
      [nameof (drop_entity_ids)] = (object) drop_entity_ids,
      [nameof (duels_critical_count)] = (object) duels_critical_count,
      [nameof (duels_damage)] = (object) duels_damage,
      [nameof (duels_hit_damage)] = (object) duels_hit_damage,
      [nameof (duels_max_damage)] = (object) duels_max_damage,
      [nameof (enemy_results_dead_count)] = (object) enemy_results_dead_count,
      [nameof (enemy_results_enemy_id)] = (object) enemy_results_enemy_id,
      [nameof (enemy_results_kill_count)] = (object) enemy_results_kill_count,
      [nameof (enemy_results_level_difference)] = (object) enemy_results_level_difference,
      [nameof (enemy_results_overkill_damage)] = (object) enemy_results_overkill_damage,
      [nameof (gear_results_damage_count)] = (object) gear_results_damage_count,
      [nameof (gear_results_kill_count)] = (object) gear_results_kill_count,
      [nameof (gear_results_player_gear_id)] = (object) gear_results_player_gear_id,
      [nameof (intimate_result_target_player_character_id)] = (object) intimate_result_target_player_character_id,
      [nameof (intimate_results_exp)] = (object) intimate_results_exp,
      [nameof (intimate_results_player_character_id)] = (object) intimate_results_player_character_id,
      [nameof (is_game_over)] = (object) is_game_over,
      [nameof (panel_entity_ids)] = (object) panel_entity_ids,
      [nameof (supply_results_supply_id)] = (object) supply_results_supply_id,
      [nameof (supply_results_use_quantity)] = (object) supply_results_use_quantity,
      [nameof (unit_results_player_unit_id)] = (object) unit_results_player_unit_id,
      [nameof (unit_results_received_damage)] = (object) unit_results_received_damage,
      [nameof (unit_results_remaining_hp)] = (object) unit_results_remaining_hp,
      [nameof (unit_results_rental)] = (object) unit_results_rental,
      [nameof (unit_results_total_damage)] = (object) unit_results_total_damage,
      [nameof (unit_results_total_damage_count)] = (object) unit_results_total_damage_count,
      [nameof (unit_results_total_kill_count)] = (object) unit_results_total_kill_count,
      [nameof (weak_element_attack_count)] = (object) weak_element_attack_count,
      [nameof (weak_kind_attack_count)] = (object) weak_kind_attack_count,
      [nameof (win)] = (object) win
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.BattleStoryFinish) null);
      }
      else
        callback(new WebAPI.Response.BattleStoryFinish(json.Json));
    }));
  }

  public static Future<WebAPI.Response.BattleStoryStart> BattleStoryStart(
    int deck_number,
    int deck_type_id,
    int quest_s_id,
    string support_player_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.BattleStoryStart>((Func<Promise<WebAPI.Response.BattleStoryStart>, IEnumerator>) (promise => WebAPI.LoadBattleStoryStart(promise, deck_number, deck_type_id, quest_s_id, support_player_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBattleStoryStart(
    Promise<WebAPI.Response.BattleStoryStart> promise,
    int deck_number,
    int deck_type_id,
    int quest_s_id,
    string support_player_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBattleStoryStart\u003Ec__Iterator52()
    {
      deck_number = deck_number,
      deck_type_id = deck_type_id,
      quest_s_id = quest_s_id,
      support_player_id = support_player_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Edeck_number = deck_number,
      \u003C\u0024\u003Edeck_type_id = deck_type_id,
      \u003C\u0024\u003Equest_s_id = quest_s_id,
      \u003C\u0024\u003Esupport_player_id = support_player_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBattleStoryStart(
    int deck_number,
    int deck_type_id,
    int quest_s_id,
    string support_player_id,
    Action<WebAPI.Response.BattleStoryStart> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/battle/story/start", new Dictionary<string, object>()
    {
      [nameof (deck_number)] = (object) deck_number,
      [nameof (deck_type_id)] = (object) deck_type_id,
      [nameof (quest_s_id)] = (object) quest_s_id,
      [nameof (support_player_id)] = (object) support_player_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.BattleStoryStart) null);
      }
      else
        callback(new WebAPI.Response.BattleStoryStart(json.Json));
    }));
  }

  public static Future<WebAPI.Response.Bingo2Index> Bingo2Index(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.Bingo2Index>((Func<Promise<WebAPI.Response.Bingo2Index>, IEnumerator>) (promise => WebAPI.LoadBingo2Index(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBingo2Index(
    Promise<WebAPI.Response.Bingo2Index> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBingo2Index\u003Ec__Iterator53()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBingo2Index(
    Action<WebAPI.Response.Bingo2Index> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/bingo2/index", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.Bingo2Index) null);
      }
      else
        callback(new WebAPI.Response.Bingo2Index(json.Json));
    }));
  }

  public static Future<WebAPI.Response.Bingo2ReceiveReward> Bingo2ReceiveReward(
    int panel_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.Bingo2ReceiveReward>((Func<Promise<WebAPI.Response.Bingo2ReceiveReward>, IEnumerator>) (promise => WebAPI.LoadBingo2ReceiveReward(promise, panel_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBingo2ReceiveReward(
    Promise<WebAPI.Response.Bingo2ReceiveReward> promise,
    int panel_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBingo2ReceiveReward\u003Ec__Iterator54()
    {
      panel_id = panel_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Epanel_id = panel_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBingo2ReceiveReward(
    int panel_id,
    Action<WebAPI.Response.Bingo2ReceiveReward> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/bingo2/receive/reward", new Dictionary<string, object>()
    {
      [nameof (panel_id)] = (object) panel_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.Bingo2ReceiveReward) null);
      }
      else
        callback(new WebAPI.Response.Bingo2ReceiveReward(json.Json));
    }));
  }

  public static Future<WebAPI.Response.Bingo2SetComplete> Bingo2SetComplete(
    int selected_reward_group_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.Bingo2SetComplete>((Func<Promise<WebAPI.Response.Bingo2SetComplete>, IEnumerator>) (promise => WebAPI.LoadBingo2SetComplete(promise, selected_reward_group_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBingo2SetComplete(
    Promise<WebAPI.Response.Bingo2SetComplete> promise,
    int selected_reward_group_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBingo2SetComplete\u003Ec__Iterator55()
    {
      selected_reward_group_id = selected_reward_group_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eselected_reward_group_id = selected_reward_group_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBingo2SetComplete(
    int selected_reward_group_id,
    Action<WebAPI.Response.Bingo2SetComplete> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/bingo2/set/complete", new Dictionary<string, object>()
    {
      [nameof (selected_reward_group_id)] = (object) selected_reward_group_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.Bingo2SetComplete) null);
      }
      else
        callback(new WebAPI.Response.Bingo2SetComplete(json.Json));
    }));
  }

  public static Future<WebAPI.Response.BingoIndex> BingoIndex(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.BingoIndex>((Func<Promise<WebAPI.Response.BingoIndex>, IEnumerator>) (promise => WebAPI.LoadBingoIndex(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBingoIndex(
    Promise<WebAPI.Response.BingoIndex> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBingoIndex\u003Ec__Iterator56()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBingoIndex(
    Action<WebAPI.Response.BingoIndex> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/bingo/index", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.BingoIndex) null);
      }
      else
        callback(new WebAPI.Response.BingoIndex(json.Json));
    }));
  }

  public static Future<WebAPI.Response.BingoOpenCheck> BingoOpenCheck(
    int bingo_id,
    int panel_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.BingoOpenCheck>((Func<Promise<WebAPI.Response.BingoOpenCheck>, IEnumerator>) (promise => WebAPI.LoadBingoOpenCheck(promise, bingo_id, panel_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBingoOpenCheck(
    Promise<WebAPI.Response.BingoOpenCheck> promise,
    int bingo_id,
    int panel_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBingoOpenCheck\u003Ec__Iterator57()
    {
      bingo_id = bingo_id,
      panel_id = panel_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebingo_id = bingo_id,
      \u003C\u0024\u003Epanel_id = panel_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBingoOpenCheck(
    int bingo_id,
    int panel_id,
    Action<WebAPI.Response.BingoOpenCheck> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/bingo/open/check", new Dictionary<string, object>()
    {
      [nameof (bingo_id)] = (object) bingo_id,
      [nameof (panel_id)] = (object) panel_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.BingoOpenCheck) null);
      }
      else
        callback(new WebAPI.Response.BingoOpenCheck(json.Json));
    }));
  }

  public static Future<WebAPI.Response.BingoReceiveReward> BingoReceiveReward(
    int bingo_id,
    int panel_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.BingoReceiveReward>((Func<Promise<WebAPI.Response.BingoReceiveReward>, IEnumerator>) (promise => WebAPI.LoadBingoReceiveReward(promise, bingo_id, panel_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBingoReceiveReward(
    Promise<WebAPI.Response.BingoReceiveReward> promise,
    int bingo_id,
    int panel_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBingoReceiveReward\u003Ec__Iterator58()
    {
      bingo_id = bingo_id,
      panel_id = panel_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebingo_id = bingo_id,
      \u003C\u0024\u003Epanel_id = panel_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBingoReceiveReward(
    int bingo_id,
    int panel_id,
    Action<WebAPI.Response.BingoReceiveReward> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/bingo/receive/reward", new Dictionary<string, object>()
    {
      [nameof (bingo_id)] = (object) bingo_id,
      [nameof (panel_id)] = (object) panel_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.BingoReceiveReward) null);
      }
      else
        callback(new WebAPI.Response.BingoReceiveReward(json.Json));
    }));
  }

  public static Future<WebAPI.Response.BingoReview> BingoReview(
    int bingo_id,
    int panel_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.BingoReview>((Func<Promise<WebAPI.Response.BingoReview>, IEnumerator>) (promise => WebAPI.LoadBingoReview(promise, bingo_id, panel_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBingoReview(
    Promise<WebAPI.Response.BingoReview> promise,
    int bingo_id,
    int panel_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBingoReview\u003Ec__Iterator59()
    {
      bingo_id = bingo_id,
      panel_id = panel_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebingo_id = bingo_id,
      \u003C\u0024\u003Epanel_id = panel_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBingoReview(
    int bingo_id,
    int panel_id,
    Action<WebAPI.Response.BingoReview> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/bingo/review", new Dictionary<string, object>()
    {
      [nameof (bingo_id)] = (object) bingo_id,
      [nameof (panel_id)] = (object) panel_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.BingoReview) null);
      }
      else
        callback(new WebAPI.Response.BingoReview(json.Json));
    }));
  }

  public static Future<WebAPI.Response.BingoSelectComplete> BingoSelectComplete(
    int bingo_id,
    int group_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.BingoSelectComplete>((Func<Promise<WebAPI.Response.BingoSelectComplete>, IEnumerator>) (promise => WebAPI.LoadBingoSelectComplete(promise, bingo_id, group_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadBingoSelectComplete(
    Promise<WebAPI.Response.BingoSelectComplete> promise,
    int bingo_id,
    int group_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadBingoSelectComplete\u003Ec__Iterator5A()
    {
      bingo_id = bingo_id,
      group_id = group_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebingo_id = bingo_id,
      \u003C\u0024\u003Egroup_id = group_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalBingoSelectComplete(
    int bingo_id,
    int group_id,
    Action<WebAPI.Response.BingoSelectComplete> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/bingo/select/complete", new Dictionary<string, object>()
    {
      [nameof (bingo_id)] = (object) bingo_id,
      [nameof (group_id)] = (object) group_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.BingoSelectComplete) null);
      }
      else
        callback(new WebAPI.Response.BingoSelectComplete(json.Json));
    }));
  }

  public static Future<WebAPI.Response.CoinbonusHistory> CoinbonusHistory(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.CoinbonusHistory>((Func<Promise<WebAPI.Response.CoinbonusHistory>, IEnumerator>) (promise => WebAPI.LoadCoinbonusHistory(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadCoinbonusHistory(
    Promise<WebAPI.Response.CoinbonusHistory> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadCoinbonusHistory\u003Ec__Iterator5B()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalCoinbonusHistory(
    Action<WebAPI.Response.CoinbonusHistory> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/coinbonus/history", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.CoinbonusHistory) null);
      }
      else
        callback(new WebAPI.Response.CoinbonusHistory(json.Json));
    }));
  }

  public static Future<WebAPI.Response.CoinbonusPresent> CoinbonusPresent(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.CoinbonusPresent>((Func<Promise<WebAPI.Response.CoinbonusPresent>, IEnumerator>) (promise => WebAPI.LoadCoinbonusPresent(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadCoinbonusPresent(
    Promise<WebAPI.Response.CoinbonusPresent> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadCoinbonusPresent\u003Ec__Iterator5C()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalCoinbonusPresent(
    Action<WebAPI.Response.CoinbonusPresent> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/coinbonus/present", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.CoinbonusPresent) null);
      }
      else
        callback(new WebAPI.Response.CoinbonusPresent(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ColosseumBoot> ColosseumBoot(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ColosseumBoot>((Func<Promise<WebAPI.Response.ColosseumBoot>, IEnumerator>) (promise => WebAPI.LoadColosseumBoot(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadColosseumBoot(
    Promise<WebAPI.Response.ColosseumBoot> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadColosseumBoot\u003Ec__Iterator5D()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalColosseumBoot(
    Action<WebAPI.Response.ColosseumBoot> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/colosseum/boot", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ColosseumBoot) null);
      }
      else
        callback(new WebAPI.Response.ColosseumBoot(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ColosseumFinish> ColosseumFinish(
    string arena_transaction_id,
    string battle_log,
    bool is_win,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ColosseumFinish>((Func<Promise<WebAPI.Response.ColosseumFinish>, IEnumerator>) (promise => WebAPI.LoadColosseumFinish(promise, arena_transaction_id, battle_log, is_win, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadColosseumFinish(
    Promise<WebAPI.Response.ColosseumFinish> promise,
    string arena_transaction_id,
    string battle_log,
    bool is_win,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadColosseumFinish\u003Ec__Iterator5E()
    {
      arena_transaction_id = arena_transaction_id,
      battle_log = battle_log,
      is_win = is_win,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Earena_transaction_id = arena_transaction_id,
      \u003C\u0024\u003Ebattle_log = battle_log,
      \u003C\u0024\u003Eis_win = is_win,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalColosseumFinish(
    string arena_transaction_id,
    string battle_log,
    bool is_win,
    Action<WebAPI.Response.ColosseumFinish> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/colosseum/finish", new Dictionary<string, object>()
    {
      [nameof (arena_transaction_id)] = (object) arena_transaction_id,
      [nameof (battle_log)] = (object) battle_log,
      [nameof (is_win)] = (object) is_win
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ColosseumFinish) null);
      }
      else
        callback(new WebAPI.Response.ColosseumFinish(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ColosseumForceClose> ColosseumForceClose(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ColosseumForceClose>((Func<Promise<WebAPI.Response.ColosseumForceClose>, IEnumerator>) (promise => WebAPI.LoadColosseumForceClose(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadColosseumForceClose(
    Promise<WebAPI.Response.ColosseumForceClose> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadColosseumForceClose\u003Ec__Iterator5F()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalColosseumForceClose(
    Action<WebAPI.Response.ColosseumForceClose> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/colosseum/force-close", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ColosseumForceClose) null);
      }
      else
        callback(new WebAPI.Response.ColosseumForceClose(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ColosseumRanking> ColosseumRanking(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ColosseumRanking>((Func<Promise<WebAPI.Response.ColosseumRanking>, IEnumerator>) (promise => WebAPI.LoadColosseumRanking(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadColosseumRanking(
    Promise<WebAPI.Response.ColosseumRanking> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadColosseumRanking\u003Ec__Iterator60()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalColosseumRanking(
    Action<WebAPI.Response.ColosseumRanking> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/colosseum/ranking", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ColosseumRanking) null);
      }
      else
        callback(new WebAPI.Response.ColosseumRanking(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ColosseumResume> ColosseumResume(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ColosseumResume>((Func<Promise<WebAPI.Response.ColosseumResume>, IEnumerator>) (promise => WebAPI.LoadColosseumResume(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadColosseumResume(
    Promise<WebAPI.Response.ColosseumResume> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadColosseumResume\u003Ec__Iterator61()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalColosseumResume(
    Action<WebAPI.Response.ColosseumResume> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/colosseum/resume", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ColosseumResume) null);
      }
      else
        callback(new WebAPI.Response.ColosseumResume(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ColosseumStart> ColosseumStart(
    int deck_number,
    int deck_type_id,
    string target_player_id,
    int target_player_index,
    int total_combat,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ColosseumStart>((Func<Promise<WebAPI.Response.ColosseumStart>, IEnumerator>) (promise => WebAPI.LoadColosseumStart(promise, deck_number, deck_type_id, target_player_id, target_player_index, total_combat, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadColosseumStart(
    Promise<WebAPI.Response.ColosseumStart> promise,
    int deck_number,
    int deck_type_id,
    string target_player_id,
    int target_player_index,
    int total_combat,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadColosseumStart\u003Ec__Iterator62()
    {
      deck_number = deck_number,
      deck_type_id = deck_type_id,
      target_player_id = target_player_id,
      target_player_index = target_player_index,
      total_combat = total_combat,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Edeck_number = deck_number,
      \u003C\u0024\u003Edeck_type_id = deck_type_id,
      \u003C\u0024\u003Etarget_player_id = target_player_id,
      \u003C\u0024\u003Etarget_player_index = target_player_index,
      \u003C\u0024\u003Etotal_combat = total_combat,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalColosseumStart(
    int deck_number,
    int deck_type_id,
    string target_player_id,
    int target_player_index,
    int total_combat,
    Action<WebAPI.Response.ColosseumStart> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/colosseum/start", new Dictionary<string, object>()
    {
      [nameof (deck_number)] = (object) deck_number,
      [nameof (deck_type_id)] = (object) deck_type_id,
      [nameof (target_player_id)] = (object) target_player_id,
      [nameof (target_player_index)] = (object) target_player_index,
      [nameof (total_combat)] = (object) total_combat
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ColosseumStart) null);
      }
      else
        callback(new WebAPI.Response.ColosseumStart(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ColosseumTutorialBoot> ColosseumTutorialBoot(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ColosseumTutorialBoot>((Func<Promise<WebAPI.Response.ColosseumTutorialBoot>, IEnumerator>) (promise => WebAPI.LoadColosseumTutorialBoot(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadColosseumTutorialBoot(
    Promise<WebAPI.Response.ColosseumTutorialBoot> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadColosseumTutorialBoot\u003Ec__Iterator63()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalColosseumTutorialBoot(
    Action<WebAPI.Response.ColosseumTutorialBoot> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/colosseum/tutorial/boot", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ColosseumTutorialBoot) null);
      }
      else
        callback(new WebAPI.Response.ColosseumTutorialBoot(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ColosseumTutorialFinish> ColosseumTutorialFinish(
    string arena_transaction_id,
    string battle_log,
    int deck_number,
    int deck_type_id,
    bool is_win,
    int total_combat,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ColosseumTutorialFinish>((Func<Promise<WebAPI.Response.ColosseumTutorialFinish>, IEnumerator>) (promise => WebAPI.LoadColosseumTutorialFinish(promise, arena_transaction_id, battle_log, deck_number, deck_type_id, is_win, total_combat, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadColosseumTutorialFinish(
    Promise<WebAPI.Response.ColosseumTutorialFinish> promise,
    string arena_transaction_id,
    string battle_log,
    int deck_number,
    int deck_type_id,
    bool is_win,
    int total_combat,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadColosseumTutorialFinish\u003Ec__Iterator64()
    {
      arena_transaction_id = arena_transaction_id,
      battle_log = battle_log,
      deck_number = deck_number,
      deck_type_id = deck_type_id,
      is_win = is_win,
      total_combat = total_combat,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Earena_transaction_id = arena_transaction_id,
      \u003C\u0024\u003Ebattle_log = battle_log,
      \u003C\u0024\u003Edeck_number = deck_number,
      \u003C\u0024\u003Edeck_type_id = deck_type_id,
      \u003C\u0024\u003Eis_win = is_win,
      \u003C\u0024\u003Etotal_combat = total_combat,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalColosseumTutorialFinish(
    string arena_transaction_id,
    string battle_log,
    int deck_number,
    int deck_type_id,
    bool is_win,
    int total_combat,
    Action<WebAPI.Response.ColosseumTutorialFinish> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/colosseum/tutorial/finish", new Dictionary<string, object>()
    {
      [nameof (arena_transaction_id)] = (object) arena_transaction_id,
      [nameof (battle_log)] = (object) battle_log,
      [nameof (deck_number)] = (object) deck_number,
      [nameof (deck_type_id)] = (object) deck_type_id,
      [nameof (is_win)] = (object) is_win,
      [nameof (total_combat)] = (object) total_combat
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ColosseumTutorialFinish) null);
      }
      else
        callback(new WebAPI.Response.ColosseumTutorialFinish(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ColosseumTutorialForceClose> ColosseumTutorialForceClose(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ColosseumTutorialForceClose>((Func<Promise<WebAPI.Response.ColosseumTutorialForceClose>, IEnumerator>) (promise => WebAPI.LoadColosseumTutorialForceClose(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadColosseumTutorialForceClose(
    Promise<WebAPI.Response.ColosseumTutorialForceClose> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadColosseumTutorialForceClose\u003Ec__Iterator65()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalColosseumTutorialForceClose(
    Action<WebAPI.Response.ColosseumTutorialForceClose> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/colosseum/tutorial/force-close", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ColosseumTutorialForceClose) null);
      }
      else
        callback(new WebAPI.Response.ColosseumTutorialForceClose(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ColosseumTutorialResume> ColosseumTutorialResume(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ColosseumTutorialResume>((Func<Promise<WebAPI.Response.ColosseumTutorialResume>, IEnumerator>) (promise => WebAPI.LoadColosseumTutorialResume(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadColosseumTutorialResume(
    Promise<WebAPI.Response.ColosseumTutorialResume> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadColosseumTutorialResume\u003Ec__Iterator66()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalColosseumTutorialResume(
    Action<WebAPI.Response.ColosseumTutorialResume> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/colosseum/tutorial/resume", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ColosseumTutorialResume) null);
      }
      else
        callback(new WebAPI.Response.ColosseumTutorialResume(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ColosseumTutorialStart> ColosseumTutorialStart(
    int deck_number,
    int deck_type_id,
    string target_player_id,
    int target_player_index,
    int total_combat,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ColosseumTutorialStart>((Func<Promise<WebAPI.Response.ColosseumTutorialStart>, IEnumerator>) (promise => WebAPI.LoadColosseumTutorialStart(promise, deck_number, deck_type_id, target_player_id, target_player_index, total_combat, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadColosseumTutorialStart(
    Promise<WebAPI.Response.ColosseumTutorialStart> promise,
    int deck_number,
    int deck_type_id,
    string target_player_id,
    int target_player_index,
    int total_combat,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadColosseumTutorialStart\u003Ec__Iterator67()
    {
      deck_number = deck_number,
      deck_type_id = deck_type_id,
      target_player_id = target_player_id,
      target_player_index = target_player_index,
      total_combat = total_combat,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Edeck_number = deck_number,
      \u003C\u0024\u003Edeck_type_id = deck_type_id,
      \u003C\u0024\u003Etarget_player_id = target_player_id,
      \u003C\u0024\u003Etarget_player_index = target_player_index,
      \u003C\u0024\u003Etotal_combat = total_combat,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalColosseumTutorialStart(
    int deck_number,
    int deck_type_id,
    string target_player_id,
    int target_player_index,
    int total_combat,
    Action<WebAPI.Response.ColosseumTutorialStart> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/colosseum/tutorial/start", new Dictionary<string, object>()
    {
      [nameof (deck_number)] = (object) deck_number,
      [nameof (deck_type_id)] = (object) deck_type_id,
      [nameof (target_player_id)] = (object) target_player_id,
      [nameof (target_player_index)] = (object) target_player_index,
      [nameof (total_combat)] = (object) total_combat
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ColosseumTutorialStart) null);
      }
      else
        callback(new WebAPI.Response.ColosseumTutorialStart(json.Json));
    }));
  }

  public static Future<WebAPI.Response.CrossfestaDetail> CrossfestaDetail(
    int campaign_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.CrossfestaDetail>((Func<Promise<WebAPI.Response.CrossfestaDetail>, IEnumerator>) (promise => WebAPI.LoadCrossfestaDetail(promise, campaign_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadCrossfestaDetail(
    Promise<WebAPI.Response.CrossfestaDetail> promise,
    int campaign_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadCrossfestaDetail\u003Ec__Iterator68()
    {
      campaign_id = campaign_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ecampaign_id = campaign_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalCrossfestaDetail(
    int campaign_id,
    Action<WebAPI.Response.CrossfestaDetail> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/crossfesta/detail", new Dictionary<string, object>()
    {
      [nameof (campaign_id)] = (object) campaign_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.CrossfestaDetail) null);
      }
      else
        callback(new WebAPI.Response.CrossfestaDetail(json.Json));
    }));
  }

  public static Future<WebAPI.Response.CrossfestaIndex> CrossfestaIndex(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.CrossfestaIndex>((Func<Promise<WebAPI.Response.CrossfestaIndex>, IEnumerator>) (promise => WebAPI.LoadCrossfestaIndex(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadCrossfestaIndex(
    Promise<WebAPI.Response.CrossfestaIndex> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadCrossfestaIndex\u003Ec__Iterator69()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalCrossfestaIndex(
    Action<WebAPI.Response.CrossfestaIndex> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/crossfesta/index", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.CrossfestaIndex) null);
      }
      else
        callback(new WebAPI.Response.CrossfestaIndex(json.Json));
    }));
  }

  public static Future<WebAPI.Response.CrossfestaSerial> CrossfestaSerial(
    int campaign_achieve_id,
    int campaign_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.CrossfestaSerial>((Func<Promise<WebAPI.Response.CrossfestaSerial>, IEnumerator>) (promise => WebAPI.LoadCrossfestaSerial(promise, campaign_achieve_id, campaign_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadCrossfestaSerial(
    Promise<WebAPI.Response.CrossfestaSerial> promise,
    int campaign_achieve_id,
    int campaign_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadCrossfestaSerial\u003Ec__Iterator6A()
    {
      campaign_achieve_id = campaign_achieve_id,
      campaign_id = campaign_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ecampaign_achieve_id = campaign_achieve_id,
      \u003C\u0024\u003Ecampaign_id = campaign_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalCrossfestaSerial(
    int campaign_achieve_id,
    int campaign_id,
    Action<WebAPI.Response.CrossfestaSerial> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/crossfesta/serial", new Dictionary<string, object>()
    {
      [nameof (campaign_achieve_id)] = (object) campaign_achieve_id,
      [nameof (campaign_id)] = (object) campaign_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.CrossfestaSerial) null);
      }
      else
        callback(new WebAPI.Response.CrossfestaSerial(json.Json));
    }));
  }

  public static Future<WebAPI.Response.DailymissionIndex> DailymissionIndex(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.DailymissionIndex>((Func<Promise<WebAPI.Response.DailymissionIndex>, IEnumerator>) (promise => WebAPI.LoadDailymissionIndex(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadDailymissionIndex(
    Promise<WebAPI.Response.DailymissionIndex> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadDailymissionIndex\u003Ec__Iterator6B()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalDailymissionIndex(
    Action<WebAPI.Response.DailymissionIndex> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/dailymission/index", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.DailymissionIndex) null);
      }
      else
        callback(new WebAPI.Response.DailymissionIndex(json.Json));
    }));
  }

  public static Future<WebAPI.Response.DailymissionReceive> DailymissionReceive(
    int mission_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.DailymissionReceive>((Func<Promise<WebAPI.Response.DailymissionReceive>, IEnumerator>) (promise => WebAPI.LoadDailymissionReceive(promise, mission_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadDailymissionReceive(
    Promise<WebAPI.Response.DailymissionReceive> promise,
    int mission_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadDailymissionReceive\u003Ec__Iterator6C()
    {
      mission_id = mission_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Emission_id = mission_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalDailymissionReceive(
    int mission_id,
    Action<WebAPI.Response.DailymissionReceive> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/dailymission/receive", new Dictionary<string, object>()
    {
      [nameof (mission_id)] = (object) mission_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.DailymissionReceive) null);
      }
      else
        callback(new WebAPI.Response.DailymissionReceive(json.Json));
    }));
  }

  public static Future<WebAPI.Response.DailymissionReview> DailymissionReview(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.DailymissionReview>((Func<Promise<WebAPI.Response.DailymissionReview>, IEnumerator>) (promise => WebAPI.LoadDailymissionReview(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadDailymissionReview(
    Promise<WebAPI.Response.DailymissionReview> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadDailymissionReview\u003Ec__Iterator6D()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalDailymissionReview(
    Action<WebAPI.Response.DailymissionReview> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/dailymission/review", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.DailymissionReview) null);
      }
      else
        callback(new WebAPI.Response.DailymissionReview(json.Json));
    }));
  }

  public static Future<WebAPI.Response.DeckEdit> DeckEdit(
    int deck_type_id,
    int number,
    int[] player_unit_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.DeckEdit>((Func<Promise<WebAPI.Response.DeckEdit>, IEnumerator>) (promise => WebAPI.LoadDeckEdit(promise, deck_type_id, number, player_unit_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadDeckEdit(
    Promise<WebAPI.Response.DeckEdit> promise,
    int deck_type_id,
    int number,
    int[] player_unit_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadDeckEdit\u003Ec__Iterator6E()
    {
      deck_type_id = deck_type_id,
      number = number,
      player_unit_ids = player_unit_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Edeck_type_id = deck_type_id,
      \u003C\u0024\u003Enumber = number,
      \u003C\u0024\u003Eplayer_unit_ids = player_unit_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalDeckEdit(
    int deck_type_id,
    int number,
    int[] player_unit_ids,
    Action<WebAPI.Response.DeckEdit> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/deck/edit", new Dictionary<string, object>()
    {
      [nameof (deck_type_id)] = (object) deck_type_id,
      [nameof (number)] = (object) number,
      [nameof (player_unit_ids)] = (object) player_unit_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.DeckEdit) null);
      }
      else
        callback(new WebAPI.Response.DeckEdit(json.Json));
    }));
  }

  public static Future<WebAPI.Response.EmblemSet> EmblemSet(
    int emblem_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.EmblemSet>((Func<Promise<WebAPI.Response.EmblemSet>, IEnumerator>) (promise => WebAPI.LoadEmblemSet(promise, emblem_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadEmblemSet(
    Promise<WebAPI.Response.EmblemSet> promise,
    int emblem_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadEmblemSet\u003Ec__Iterator6F()
    {
      emblem_id = emblem_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eemblem_id = emblem_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalEmblemSet(
    int emblem_id,
    Action<WebAPI.Response.EmblemSet> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/emblem/set", new Dictionary<string, object>()
    {
      [nameof (emblem_id)] = (object) emblem_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.EmblemSet) null);
      }
      else
        callback(new WebAPI.Response.EmblemSet(json.Json));
    }));
  }

  public static Future<WebAPI.Response.EmblemStatus> EmblemStatus(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.EmblemStatus>((Func<Promise<WebAPI.Response.EmblemStatus>, IEnumerator>) (promise => WebAPI.LoadEmblemStatus(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadEmblemStatus(
    Promise<WebAPI.Response.EmblemStatus> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadEmblemStatus\u003Ec__Iterator70()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalEmblemStatus(
    Action<WebAPI.Response.EmblemStatus> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/emblem/status", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.EmblemStatus) null);
      }
      else
        callback(new WebAPI.Response.EmblemStatus(json.Json));
    }));
  }

  public static Future<WebAPI.Response.FacebookIsRelated> FacebookIsRelated(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.FacebookIsRelated>((Func<Promise<WebAPI.Response.FacebookIsRelated>, IEnumerator>) (promise => WebAPI.LoadFacebookIsRelated(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadFacebookIsRelated(
    Promise<WebAPI.Response.FacebookIsRelated> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadFacebookIsRelated\u003Ec__Iterator71()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalFacebookIsRelated(
    Action<WebAPI.Response.FacebookIsRelated> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/facebook/is-related", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.FacebookIsRelated) null);
      }
      else
        callback(new WebAPI.Response.FacebookIsRelated(json.Json));
    }));
  }

  public static Future<WebAPI.Response.FacebookRegister> FacebookRegister(
    string access_token,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.FacebookRegister>((Func<Promise<WebAPI.Response.FacebookRegister>, IEnumerator>) (promise => WebAPI.LoadFacebookRegister(promise, access_token, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadFacebookRegister(
    Promise<WebAPI.Response.FacebookRegister> promise,
    string access_token,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadFacebookRegister\u003Ec__Iterator72()
    {
      access_token = access_token,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eaccess_token = access_token,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalFacebookRegister(
    string access_token,
    Action<WebAPI.Response.FacebookRegister> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/facebook/register", new Dictionary<string, object>()
    {
      [nameof (access_token)] = (object) access_token
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.FacebookRegister) null);
      }
      else
        callback(new WebAPI.Response.FacebookRegister(json.Json));
    }));
  }

  public static Future<WebAPI.Response.FriendAccept> FriendAccept(
    string[] target_player_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.FriendAccept>((Func<Promise<WebAPI.Response.FriendAccept>, IEnumerator>) (promise => WebAPI.LoadFriendAccept(promise, target_player_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadFriendAccept(
    Promise<WebAPI.Response.FriendAccept> promise,
    string[] target_player_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadFriendAccept\u003Ec__Iterator73()
    {
      target_player_ids = target_player_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Etarget_player_ids = target_player_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalFriendAccept(
    string[] target_player_ids,
    Action<WebAPI.Response.FriendAccept> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/friend/accept", new Dictionary<string, object>()
    {
      [nameof (target_player_ids)] = (object) target_player_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.FriendAccept) null);
      }
      else
        callback(new WebAPI.Response.FriendAccept(json.Json));
    }));
  }

  public static Future<WebAPI.Response.FriendApply> FriendApply(
    string[] target_player_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.FriendApply>((Func<Promise<WebAPI.Response.FriendApply>, IEnumerator>) (promise => WebAPI.LoadFriendApply(promise, target_player_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadFriendApply(
    Promise<WebAPI.Response.FriendApply> promise,
    string[] target_player_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadFriendApply\u003Ec__Iterator74()
    {
      target_player_ids = target_player_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Etarget_player_ids = target_player_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalFriendApply(
    string[] target_player_ids,
    Action<WebAPI.Response.FriendApply> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/friend/apply", new Dictionary<string, object>()
    {
      [nameof (target_player_ids)] = (object) target_player_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.FriendApply) null);
      }
      else
        callback(new WebAPI.Response.FriendApply(json.Json));
    }));
  }

  public static Future<WebAPI.Response.FriendCancel> FriendCancel(
    string[] target_player_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.FriendCancel>((Func<Promise<WebAPI.Response.FriendCancel>, IEnumerator>) (promise => WebAPI.LoadFriendCancel(promise, target_player_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadFriendCancel(
    Promise<WebAPI.Response.FriendCancel> promise,
    string[] target_player_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadFriendCancel\u003Ec__Iterator75()
    {
      target_player_ids = target_player_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Etarget_player_ids = target_player_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalFriendCancel(
    string[] target_player_ids,
    Action<WebAPI.Response.FriendCancel> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/friend/cancel", new Dictionary<string, object>()
    {
      [nameof (target_player_ids)] = (object) target_player_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.FriendCancel) null);
      }
      else
        callback(new WebAPI.Response.FriendCancel(json.Json));
    }));
  }

  public static Future<WebAPI.Response.FriendFavorite> FriendFavorite(
    string[] target_player_ids,
    string[] unlock_target_player_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.FriendFavorite>((Func<Promise<WebAPI.Response.FriendFavorite>, IEnumerator>) (promise => WebAPI.LoadFriendFavorite(promise, target_player_ids, unlock_target_player_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadFriendFavorite(
    Promise<WebAPI.Response.FriendFavorite> promise,
    string[] target_player_ids,
    string[] unlock_target_player_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadFriendFavorite\u003Ec__Iterator76()
    {
      target_player_ids = target_player_ids,
      unlock_target_player_ids = unlock_target_player_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Etarget_player_ids = target_player_ids,
      \u003C\u0024\u003Eunlock_target_player_ids = unlock_target_player_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalFriendFavorite(
    string[] target_player_ids,
    string[] unlock_target_player_ids,
    Action<WebAPI.Response.FriendFavorite> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/friend/favorite", new Dictionary<string, object>()
    {
      [nameof (target_player_ids)] = (object) target_player_ids,
      [nameof (unlock_target_player_ids)] = (object) unlock_target_player_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.FriendFavorite) null);
      }
      else
        callback(new WebAPI.Response.FriendFavorite(json.Json));
    }));
  }

  public static Future<WebAPI.Response.FriendFriends> FriendFriends(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.FriendFriends>((Func<Promise<WebAPI.Response.FriendFriends>, IEnumerator>) (promise => WebAPI.LoadFriendFriends(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadFriendFriends(
    Promise<WebAPI.Response.FriendFriends> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadFriendFriends\u003Ec__Iterator77()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalFriendFriends(
    Action<WebAPI.Response.FriendFriends> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/friend/friends", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.FriendFriends) null);
      }
      else
        callback(new WebAPI.Response.FriendFriends(json.Json));
    }));
  }

  public static Future<WebAPI.Response.FriendReject> FriendReject(
    string[] target_player_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.FriendReject>((Func<Promise<WebAPI.Response.FriendReject>, IEnumerator>) (promise => WebAPI.LoadFriendReject(promise, target_player_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadFriendReject(
    Promise<WebAPI.Response.FriendReject> promise,
    string[] target_player_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadFriendReject\u003Ec__Iterator78()
    {
      target_player_ids = target_player_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Etarget_player_ids = target_player_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalFriendReject(
    string[] target_player_ids,
    Action<WebAPI.Response.FriendReject> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/friend/reject", new Dictionary<string, object>()
    {
      [nameof (target_player_ids)] = (object) target_player_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.FriendReject) null);
      }
      else
        callback(new WebAPI.Response.FriendReject(json.Json));
    }));
  }

  public static Future<WebAPI.Response.FriendRemove> FriendRemove(
    string[] target_player_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.FriendRemove>((Func<Promise<WebAPI.Response.FriendRemove>, IEnumerator>) (promise => WebAPI.LoadFriendRemove(promise, target_player_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadFriendRemove(
    Promise<WebAPI.Response.FriendRemove> promise,
    string[] target_player_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadFriendRemove\u003Ec__Iterator79()
    {
      target_player_ids = target_player_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Etarget_player_ids = target_player_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalFriendRemove(
    string[] target_player_ids,
    Action<WebAPI.Response.FriendRemove> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/friend/remove", new Dictionary<string, object>()
    {
      [nameof (target_player_ids)] = (object) target_player_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.FriendRemove) null);
      }
      else
        callback(new WebAPI.Response.FriendRemove(json.Json));
    }));
  }

  public static Future<WebAPI.Response.FriendStatus> FriendStatus(
    string target_player_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.FriendStatus>((Func<Promise<WebAPI.Response.FriendStatus>, IEnumerator>) (promise => WebAPI.LoadFriendStatus(promise, target_player_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadFriendStatus(
    Promise<WebAPI.Response.FriendStatus> promise,
    string target_player_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadFriendStatus\u003Ec__Iterator7A()
    {
      target_player_id = target_player_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Etarget_player_id = target_player_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalFriendStatus(
    string target_player_id,
    Action<WebAPI.Response.FriendStatus> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/friend/status", new Dictionary<string, object>()
    {
      [nameof (target_player_id)] = (object) target_player_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.FriendStatus) null);
      }
      else
        callback(new WebAPI.Response.FriendStatus(json.Json));
    }));
  }

  public static Future<WebAPI.Response.Gacha> Gacha(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.Gacha>((Func<Promise<WebAPI.Response.Gacha>, IEnumerator>) (promise => WebAPI.LoadGacha(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGacha(
    Promise<WebAPI.Response.Gacha> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGacha\u003Ec__Iterator7B()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGacha(
    Action<WebAPI.Response.Gacha> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/gacha", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.Gacha) null);
      }
      else
        callback(new WebAPI.Response.Gacha(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG001ChargeMultiPay> GachaG001ChargeMultiPay(
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG001ChargeMultiPay>((Func<Promise<WebAPI.Response.GachaG001ChargeMultiPay>, IEnumerator>) (promise => WebAPI.LoadGachaG001ChargeMultiPay(promise, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG001ChargeMultiPay(
    Promise<WebAPI.Response.GachaG001ChargeMultiPay> promise,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG001ChargeMultiPay\u003Ec__Iterator7C()
    {
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG001ChargeMultiPay(
    int gacha_id,
    Action<WebAPI.Response.GachaG001ChargeMultiPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g001_charge/multi/pay", new Dictionary<string, object>()
    {
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG001ChargeMultiPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG001ChargeMultiPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG001ChargePay> GachaG001ChargePay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG001ChargePay>((Func<Promise<WebAPI.Response.GachaG001ChargePay>, IEnumerator>) (promise => WebAPI.LoadGachaG001ChargePay(promise, execute_count, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG001ChargePay(
    Promise<WebAPI.Response.GachaG001ChargePay> promise,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG001ChargePay\u003Ec__Iterator7D()
    {
      execute_count = execute_count,
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eexecute_count = execute_count,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG001ChargePay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.GachaG001ChargePay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g001_charge/pay", new Dictionary<string, object>()
    {
      [nameof (execute_count)] = (object) execute_count,
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG001ChargePay) null);
      }
      else
        callback(new WebAPI.Response.GachaG001ChargePay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG002FriendpointPay> GachaG002FriendpointPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG002FriendpointPay>((Func<Promise<WebAPI.Response.GachaG002FriendpointPay>, IEnumerator>) (promise => WebAPI.LoadGachaG002FriendpointPay(promise, execute_count, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG002FriendpointPay(
    Promise<WebAPI.Response.GachaG002FriendpointPay> promise,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG002FriendpointPay\u003Ec__Iterator7E()
    {
      execute_count = execute_count,
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eexecute_count = execute_count,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG002FriendpointPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.GachaG002FriendpointPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g002_friendpoint/pay", new Dictionary<string, object>()
    {
      [nameof (execute_count)] = (object) execute_count,
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG002FriendpointPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG002FriendpointPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG004TicketMultiPay> GachaG004TicketMultiPay(
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG004TicketMultiPay>((Func<Promise<WebAPI.Response.GachaG004TicketMultiPay>, IEnumerator>) (promise => WebAPI.LoadGachaG004TicketMultiPay(promise, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG004TicketMultiPay(
    Promise<WebAPI.Response.GachaG004TicketMultiPay> promise,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG004TicketMultiPay\u003Ec__Iterator7F()
    {
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG004TicketMultiPay(
    int gacha_id,
    Action<WebAPI.Response.GachaG004TicketMultiPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g004_ticket/multi/pay", new Dictionary<string, object>()
    {
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG004TicketMultiPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG004TicketMultiPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG004TicketPay> GachaG004TicketPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG004TicketPay>((Func<Promise<WebAPI.Response.GachaG004TicketPay>, IEnumerator>) (promise => WebAPI.LoadGachaG004TicketPay(promise, execute_count, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG004TicketPay(
    Promise<WebAPI.Response.GachaG004TicketPay> promise,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG004TicketPay\u003Ec__Iterator80()
    {
      execute_count = execute_count,
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eexecute_count = execute_count,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG004TicketPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.GachaG004TicketPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g004_ticket/pay", new Dictionary<string, object>()
    {
      [nameof (execute_count)] = (object) execute_count,
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG004TicketPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG004TicketPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG005NewbieMultiPay> GachaG005NewbieMultiPay(
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG005NewbieMultiPay>((Func<Promise<WebAPI.Response.GachaG005NewbieMultiPay>, IEnumerator>) (promise => WebAPI.LoadGachaG005NewbieMultiPay(promise, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG005NewbieMultiPay(
    Promise<WebAPI.Response.GachaG005NewbieMultiPay> promise,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG005NewbieMultiPay\u003Ec__Iterator81()
    {
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG005NewbieMultiPay(
    int gacha_id,
    Action<WebAPI.Response.GachaG005NewbieMultiPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g005_newbie/multi/pay", new Dictionary<string, object>()
    {
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG005NewbieMultiPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG005NewbieMultiPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG005NewbiePay> GachaG005NewbiePay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG005NewbiePay>((Func<Promise<WebAPI.Response.GachaG005NewbiePay>, IEnumerator>) (promise => WebAPI.LoadGachaG005NewbiePay(promise, execute_count, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG005NewbiePay(
    Promise<WebAPI.Response.GachaG005NewbiePay> promise,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG005NewbiePay\u003Ec__Iterator82()
    {
      execute_count = execute_count,
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eexecute_count = execute_count,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG005NewbiePay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.GachaG005NewbiePay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g005_newbie/pay", new Dictionary<string, object>()
    {
      [nameof (execute_count)] = (object) execute_count,
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG005NewbiePay) null);
      }
      else
        callback(new WebAPI.Response.GachaG005NewbiePay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG007PanelMultiPay> GachaG007PanelMultiPay(
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG007PanelMultiPay>((Func<Promise<WebAPI.Response.GachaG007PanelMultiPay>, IEnumerator>) (promise => WebAPI.LoadGachaG007PanelMultiPay(promise, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG007PanelMultiPay(
    Promise<WebAPI.Response.GachaG007PanelMultiPay> promise,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG007PanelMultiPay\u003Ec__Iterator83()
    {
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG007PanelMultiPay(
    int gacha_id,
    Action<WebAPI.Response.GachaG007PanelMultiPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g007_panel/multi/pay", new Dictionary<string, object>()
    {
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG007PanelMultiPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG007PanelMultiPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG007PanelPanelInfo> GachaG007PanelPanelInfo(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG007PanelPanelInfo>((Func<Promise<WebAPI.Response.GachaG007PanelPanelInfo>, IEnumerator>) (promise => WebAPI.LoadGachaG007PanelPanelInfo(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG007PanelPanelInfo(
    Promise<WebAPI.Response.GachaG007PanelPanelInfo> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG007PanelPanelInfo\u003Ec__Iterator84()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG007PanelPanelInfo(
    Action<WebAPI.Response.GachaG007PanelPanelInfo> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/gacha/g007_panel/panel/info", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG007PanelPanelInfo) null);
      }
      else
        callback(new WebAPI.Response.GachaG007PanelPanelInfo(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG007PanelPanelReset> GachaG007PanelPanelReset(
    int sheet_series_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG007PanelPanelReset>((Func<Promise<WebAPI.Response.GachaG007PanelPanelReset>, IEnumerator>) (promise => WebAPI.LoadGachaG007PanelPanelReset(promise, sheet_series_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG007PanelPanelReset(
    Promise<WebAPI.Response.GachaG007PanelPanelReset> promise,
    int sheet_series_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG007PanelPanelReset\u003Ec__Iterator85()
    {
      sheet_series_id = sheet_series_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Esheet_series_id = sheet_series_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG007PanelPanelReset(
    int sheet_series_id,
    Action<WebAPI.Response.GachaG007PanelPanelReset> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g007_panel/panel/reset", new Dictionary<string, object>()
    {
      [nameof (sheet_series_id)] = (object) sheet_series_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG007PanelPanelReset) null);
      }
      else
        callback(new WebAPI.Response.GachaG007PanelPanelReset(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG007PanelPay> GachaG007PanelPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG007PanelPay>((Func<Promise<WebAPI.Response.GachaG007PanelPay>, IEnumerator>) (promise => WebAPI.LoadGachaG007PanelPay(promise, execute_count, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG007PanelPay(
    Promise<WebAPI.Response.GachaG007PanelPay> promise,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG007PanelPay\u003Ec__Iterator86()
    {
      execute_count = execute_count,
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eexecute_count = execute_count,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG007PanelPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.GachaG007PanelPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g007_panel/pay", new Dictionary<string, object>()
    {
      [nameof (execute_count)] = (object) execute_count,
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG007PanelPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG007PanelPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG1035GiftMultiPay> GachaG1035GiftMultiPay(
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG1035GiftMultiPay>((Func<Promise<WebAPI.Response.GachaG1035GiftMultiPay>, IEnumerator>) (promise => WebAPI.LoadGachaG1035GiftMultiPay(promise, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG1035GiftMultiPay(
    Promise<WebAPI.Response.GachaG1035GiftMultiPay> promise,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG1035GiftMultiPay\u003Ec__Iterator87()
    {
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG1035GiftMultiPay(
    int gacha_id,
    Action<WebAPI.Response.GachaG1035GiftMultiPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g1035_gift/multi/pay", new Dictionary<string, object>()
    {
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG1035GiftMultiPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG1035GiftMultiPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG1035GiftPay> GachaG1035GiftPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG1035GiftPay>((Func<Promise<WebAPI.Response.GachaG1035GiftPay>, IEnumerator>) (promise => WebAPI.LoadGachaG1035GiftPay(promise, execute_count, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG1035GiftPay(
    Promise<WebAPI.Response.GachaG1035GiftPay> promise,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG1035GiftPay\u003Ec__Iterator88()
    {
      execute_count = execute_count,
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eexecute_count = execute_count,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG1035GiftPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.GachaG1035GiftPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g1035_gift/pay", new Dictionary<string, object>()
    {
      [nameof (execute_count)] = (object) execute_count,
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG1035GiftPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG1035GiftPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG3032ChargeMultiPay> GachaG3032ChargeMultiPay(
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG3032ChargeMultiPay>((Func<Promise<WebAPI.Response.GachaG3032ChargeMultiPay>, IEnumerator>) (promise => WebAPI.LoadGachaG3032ChargeMultiPay(promise, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG3032ChargeMultiPay(
    Promise<WebAPI.Response.GachaG3032ChargeMultiPay> promise,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG3032ChargeMultiPay\u003Ec__Iterator89()
    {
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG3032ChargeMultiPay(
    int gacha_id,
    Action<WebAPI.Response.GachaG3032ChargeMultiPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g3032_charge/multi/pay", new Dictionary<string, object>()
    {
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG3032ChargeMultiPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG3032ChargeMultiPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG3032ChargePay> GachaG3032ChargePay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG3032ChargePay>((Func<Promise<WebAPI.Response.GachaG3032ChargePay>, IEnumerator>) (promise => WebAPI.LoadGachaG3032ChargePay(promise, execute_count, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG3032ChargePay(
    Promise<WebAPI.Response.GachaG3032ChargePay> promise,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG3032ChargePay\u003Ec__Iterator8A()
    {
      execute_count = execute_count,
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eexecute_count = execute_count,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG3032ChargePay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.GachaG3032ChargePay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g3032_charge/pay", new Dictionary<string, object>()
    {
      [nameof (execute_count)] = (object) execute_count,
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG3032ChargePay) null);
      }
      else
        callback(new WebAPI.Response.GachaG3032ChargePay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG3034ChargeMultiPay> GachaG3034ChargeMultiPay(
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG3034ChargeMultiPay>((Func<Promise<WebAPI.Response.GachaG3034ChargeMultiPay>, IEnumerator>) (promise => WebAPI.LoadGachaG3034ChargeMultiPay(promise, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG3034ChargeMultiPay(
    Promise<WebAPI.Response.GachaG3034ChargeMultiPay> promise,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG3034ChargeMultiPay\u003Ec__Iterator8B()
    {
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG3034ChargeMultiPay(
    int gacha_id,
    Action<WebAPI.Response.GachaG3034ChargeMultiPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g3034_charge/multi/pay", new Dictionary<string, object>()
    {
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG3034ChargeMultiPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG3034ChargeMultiPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG3034ChargePay> GachaG3034ChargePay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG3034ChargePay>((Func<Promise<WebAPI.Response.GachaG3034ChargePay>, IEnumerator>) (promise => WebAPI.LoadGachaG3034ChargePay(promise, execute_count, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG3034ChargePay(
    Promise<WebAPI.Response.GachaG3034ChargePay> promise,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG3034ChargePay\u003Ec__Iterator8C()
    {
      execute_count = execute_count,
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eexecute_count = execute_count,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG3034ChargePay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.GachaG3034ChargePay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g3034_charge/pay", new Dictionary<string, object>()
    {
      [nameof (execute_count)] = (object) execute_count,
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG3034ChargePay) null);
      }
      else
        callback(new WebAPI.Response.GachaG3034ChargePay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG4103StepupMultiPay> GachaG4103StepupMultiPay(
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG4103StepupMultiPay>((Func<Promise<WebAPI.Response.GachaG4103StepupMultiPay>, IEnumerator>) (promise => WebAPI.LoadGachaG4103StepupMultiPay(promise, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG4103StepupMultiPay(
    Promise<WebAPI.Response.GachaG4103StepupMultiPay> promise,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG4103StepupMultiPay\u003Ec__Iterator8D()
    {
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG4103StepupMultiPay(
    int gacha_id,
    Action<WebAPI.Response.GachaG4103StepupMultiPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g4103_stepup/multi/pay", new Dictionary<string, object>()
    {
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG4103StepupMultiPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG4103StepupMultiPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG4103StepupPay> GachaG4103StepupPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG4103StepupPay>((Func<Promise<WebAPI.Response.GachaG4103StepupPay>, IEnumerator>) (promise => WebAPI.LoadGachaG4103StepupPay(promise, execute_count, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG4103StepupPay(
    Promise<WebAPI.Response.GachaG4103StepupPay> promise,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG4103StepupPay\u003Ec__Iterator8E()
    {
      execute_count = execute_count,
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eexecute_count = execute_count,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG4103StepupPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.GachaG4103StepupPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g4103_stepup/pay", new Dictionary<string, object>()
    {
      [nameof (execute_count)] = (object) execute_count,
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG4103StepupPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG4103StepupPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG4104StepupMultiPay> GachaG4104StepupMultiPay(
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG4104StepupMultiPay>((Func<Promise<WebAPI.Response.GachaG4104StepupMultiPay>, IEnumerator>) (promise => WebAPI.LoadGachaG4104StepupMultiPay(promise, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG4104StepupMultiPay(
    Promise<WebAPI.Response.GachaG4104StepupMultiPay> promise,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG4104StepupMultiPay\u003Ec__Iterator8F()
    {
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG4104StepupMultiPay(
    int gacha_id,
    Action<WebAPI.Response.GachaG4104StepupMultiPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g4104_stepup/multi/pay", new Dictionary<string, object>()
    {
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG4104StepupMultiPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG4104StepupMultiPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG4104StepupPay> GachaG4104StepupPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG4104StepupPay>((Func<Promise<WebAPI.Response.GachaG4104StepupPay>, IEnumerator>) (promise => WebAPI.LoadGachaG4104StepupPay(promise, execute_count, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG4104StepupPay(
    Promise<WebAPI.Response.GachaG4104StepupPay> promise,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG4104StepupPay\u003Ec__Iterator90()
    {
      execute_count = execute_count,
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eexecute_count = execute_count,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG4104StepupPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.GachaG4104StepupPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g4104_stepup/pay", new Dictionary<string, object>()
    {
      [nameof (execute_count)] = (object) execute_count,
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG4104StepupPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG4104StepupPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG4105StepupMultiPay> GachaG4105StepupMultiPay(
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG4105StepupMultiPay>((Func<Promise<WebAPI.Response.GachaG4105StepupMultiPay>, IEnumerator>) (promise => WebAPI.LoadGachaG4105StepupMultiPay(promise, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG4105StepupMultiPay(
    Promise<WebAPI.Response.GachaG4105StepupMultiPay> promise,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG4105StepupMultiPay\u003Ec__Iterator91()
    {
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG4105StepupMultiPay(
    int gacha_id,
    Action<WebAPI.Response.GachaG4105StepupMultiPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g4105_stepup/multi/pay", new Dictionary<string, object>()
    {
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG4105StepupMultiPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG4105StepupMultiPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG4105StepupPay> GachaG4105StepupPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG4105StepupPay>((Func<Promise<WebAPI.Response.GachaG4105StepupPay>, IEnumerator>) (promise => WebAPI.LoadGachaG4105StepupPay(promise, execute_count, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG4105StepupPay(
    Promise<WebAPI.Response.GachaG4105StepupPay> promise,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG4105StepupPay\u003Ec__Iterator92()
    {
      execute_count = execute_count,
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eexecute_count = execute_count,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG4105StepupPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.GachaG4105StepupPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g4105_stepup/pay", new Dictionary<string, object>()
    {
      [nameof (execute_count)] = (object) execute_count,
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG4105StepupPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG4105StepupPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG4106StepupMultiPay> GachaG4106StepupMultiPay(
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG4106StepupMultiPay>((Func<Promise<WebAPI.Response.GachaG4106StepupMultiPay>, IEnumerator>) (promise => WebAPI.LoadGachaG4106StepupMultiPay(promise, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG4106StepupMultiPay(
    Promise<WebAPI.Response.GachaG4106StepupMultiPay> promise,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG4106StepupMultiPay\u003Ec__Iterator93()
    {
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG4106StepupMultiPay(
    int gacha_id,
    Action<WebAPI.Response.GachaG4106StepupMultiPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g4106_stepup/multi/pay", new Dictionary<string, object>()
    {
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG4106StepupMultiPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG4106StepupMultiPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG4106StepupPay> GachaG4106StepupPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG4106StepupPay>((Func<Promise<WebAPI.Response.GachaG4106StepupPay>, IEnumerator>) (promise => WebAPI.LoadGachaG4106StepupPay(promise, execute_count, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG4106StepupPay(
    Promise<WebAPI.Response.GachaG4106StepupPay> promise,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG4106StepupPay\u003Ec__Iterator94()
    {
      execute_count = execute_count,
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eexecute_count = execute_count,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG4106StepupPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.GachaG4106StepupPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g4106_stepup/pay", new Dictionary<string, object>()
    {
      [nameof (execute_count)] = (object) execute_count,
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG4106StepupPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG4106StepupPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG5001FriendpointMultiPay> GachaG5001FriendpointMultiPay(
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG5001FriendpointMultiPay>((Func<Promise<WebAPI.Response.GachaG5001FriendpointMultiPay>, IEnumerator>) (promise => WebAPI.LoadGachaG5001FriendpointMultiPay(promise, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG5001FriendpointMultiPay(
    Promise<WebAPI.Response.GachaG5001FriendpointMultiPay> promise,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG5001FriendpointMultiPay\u003Ec__Iterator95()
    {
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG5001FriendpointMultiPay(
    int gacha_id,
    Action<WebAPI.Response.GachaG5001FriendpointMultiPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g5001_friendpoint/multi/pay", new Dictionary<string, object>()
    {
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG5001FriendpointMultiPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG5001FriendpointMultiPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.GachaG5001FriendpointPay> GachaG5001FriendpointPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.GachaG5001FriendpointPay>((Func<Promise<WebAPI.Response.GachaG5001FriendpointPay>, IEnumerator>) (promise => WebAPI.LoadGachaG5001FriendpointPay(promise, execute_count, gacha_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGachaG5001FriendpointPay(
    Promise<WebAPI.Response.GachaG5001FriendpointPay> promise,
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGachaG5001FriendpointPay\u003Ec__Iterator96()
    {
      execute_count = execute_count,
      gacha_id = gacha_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eexecute_count = execute_count,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGachaG5001FriendpointPay(
    int execute_count,
    int gacha_id,
    Action<WebAPI.Response.GachaG5001FriendpointPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/gacha/g5001_friendpoint/pay", new Dictionary<string, object>()
    {
      [nameof (execute_count)] = (object) execute_count,
      [nameof (gacha_id)] = (object) gacha_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.GachaG5001FriendpointPay) null);
      }
      else
        callback(new WebAPI.Response.GachaG5001FriendpointPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.Gamekit> Gamekit(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.Gamekit>((Func<Promise<WebAPI.Response.Gamekit>, IEnumerator>) (promise => WebAPI.LoadGamekit(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadGamekit(
    Promise<WebAPI.Response.Gamekit> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadGamekit\u003Ec__Iterator97()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalGamekit(
    Action<WebAPI.Response.Gamekit> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/gamekit", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.Gamekit) null);
      }
      else
        callback(new WebAPI.Response.Gamekit(json.Json));
    }));
  }

  public static Future<WebAPI.Response.HomeHome> HomeHome(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.HomeHome>((Func<Promise<WebAPI.Response.HomeHome>, IEnumerator>) (promise => WebAPI.LoadHomeHome(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadHomeHome(
    Promise<WebAPI.Response.HomeHome> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadHomeHome\u003Ec__Iterator98()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalHomeHome(
    Action<WebAPI.Response.HomeHome> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/home/home", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.HomeHome) null);
      }
      else
        callback(new WebAPI.Response.HomeHome(json.Json));
    }));
  }

  public static Future<WebAPI.Response.HomeNow> HomeNow(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.HomeNow>((Func<Promise<WebAPI.Response.HomeNow>, IEnumerator>) (promise => WebAPI.LoadHomeNow(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadHomeNow(
    Promise<WebAPI.Response.HomeNow> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadHomeNow\u003Ec__Iterator99()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalHomeNow(
    Action<WebAPI.Response.HomeNow> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/home/now", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.HomeNow) null);
      }
      else
        callback(new WebAPI.Response.HomeNow(json.Json));
    }));
  }

  public static Future<WebAPI.Response.HomeStartUp> HomeStartUp(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.HomeStartUp>((Func<Promise<WebAPI.Response.HomeStartUp>, IEnumerator>) (promise => WebAPI.LoadHomeStartUp(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadHomeStartUp(
    Promise<WebAPI.Response.HomeStartUp> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadHomeStartUp\u003Ec__Iterator9A()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalHomeStartUp(
    Action<WebAPI.Response.HomeStartUp> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/home/start_up", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.HomeStartUp) null);
      }
      else
        callback(new WebAPI.Response.HomeStartUp(json.Json));
    }));
  }

  public static Future<WebAPI.Response.HomeUpdateAllData> HomeUpdateAllData(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.HomeUpdateAllData>((Func<Promise<WebAPI.Response.HomeUpdateAllData>, IEnumerator>) (promise => WebAPI.LoadHomeUpdateAllData(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadHomeUpdateAllData(
    Promise<WebAPI.Response.HomeUpdateAllData> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadHomeUpdateAllData\u003Ec__Iterator9B()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalHomeUpdateAllData(
    Action<WebAPI.Response.HomeUpdateAllData> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/home/update_all_data", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.HomeUpdateAllData) null);
      }
      else
        callback(new WebAPI.Response.HomeUpdateAllData(json.Json));
    }));
  }

  public static Future<WebAPI.Response.InvitationAccept> InvitationAccept(
    string invitation_code,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.InvitationAccept>((Func<Promise<WebAPI.Response.InvitationAccept>, IEnumerator>) (promise => WebAPI.LoadInvitationAccept(promise, invitation_code, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadInvitationAccept(
    Promise<WebAPI.Response.InvitationAccept> promise,
    string invitation_code,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadInvitationAccept\u003Ec__Iterator9C()
    {
      invitation_code = invitation_code,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Einvitation_code = invitation_code,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalInvitationAccept(
    string invitation_code,
    Action<WebAPI.Response.InvitationAccept> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/invitation/accept", new Dictionary<string, object>()
    {
      [nameof (invitation_code)] = (object) invitation_code
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.InvitationAccept) null);
      }
      else
        callback(new WebAPI.Response.InvitationAccept(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ItemGearBuildup> ItemGearBuildup(
    int base_player_gear_id,
    int[] material_player_gear_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ItemGearBuildup>((Func<Promise<WebAPI.Response.ItemGearBuildup>, IEnumerator>) (promise => WebAPI.LoadItemGearBuildup(promise, base_player_gear_id, material_player_gear_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadItemGearBuildup(
    Promise<WebAPI.Response.ItemGearBuildup> promise,
    int base_player_gear_id,
    int[] material_player_gear_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadItemGearBuildup\u003Ec__Iterator9D()
    {
      base_player_gear_id = base_player_gear_id,
      material_player_gear_ids = material_player_gear_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebase_player_gear_id = base_player_gear_id,
      \u003C\u0024\u003Ematerial_player_gear_ids = material_player_gear_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalItemGearBuildup(
    int base_player_gear_id,
    int[] material_player_gear_ids,
    Action<WebAPI.Response.ItemGearBuildup> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/item/gear/buildup", new Dictionary<string, object>()
    {
      [nameof (base_player_gear_id)] = (object) base_player_gear_id,
      [nameof (material_player_gear_ids)] = (object) material_player_gear_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ItemGearBuildup) null);
      }
      else
        callback(new WebAPI.Response.ItemGearBuildup(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ItemGearCombine> ItemGearCombine(
    int[] player_gear_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ItemGearCombine>((Func<Promise<WebAPI.Response.ItemGearCombine>, IEnumerator>) (promise => WebAPI.LoadItemGearCombine(promise, player_gear_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadItemGearCombine(
    Promise<WebAPI.Response.ItemGearCombine> promise,
    int[] player_gear_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadItemGearCombine\u003Ec__Iterator9E()
    {
      player_gear_ids = player_gear_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eplayer_gear_ids = player_gear_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalItemGearCombine(
    int[] player_gear_ids,
    Action<WebAPI.Response.ItemGearCombine> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/item/gear/combine", new Dictionary<string, object>()
    {
      [nameof (player_gear_ids)] = (object) player_gear_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ItemGearCombine) null);
      }
      else
        callback(new WebAPI.Response.ItemGearCombine(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ItemGearDrilling> ItemGearDrilling(
    int base_player_gear_id,
    int[] material_player_gear_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ItemGearDrilling>((Func<Promise<WebAPI.Response.ItemGearDrilling>, IEnumerator>) (promise => WebAPI.LoadItemGearDrilling(promise, base_player_gear_id, material_player_gear_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadItemGearDrilling(
    Promise<WebAPI.Response.ItemGearDrilling> promise,
    int base_player_gear_id,
    int[] material_player_gear_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadItemGearDrilling\u003Ec__Iterator9F()
    {
      base_player_gear_id = base_player_gear_id,
      material_player_gear_ids = material_player_gear_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebase_player_gear_id = base_player_gear_id,
      \u003C\u0024\u003Ematerial_player_gear_ids = material_player_gear_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalItemGearDrilling(
    int base_player_gear_id,
    int[] material_player_gear_ids,
    Action<WebAPI.Response.ItemGearDrilling> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/item/gear/drilling", new Dictionary<string, object>()
    {
      [nameof (base_player_gear_id)] = (object) base_player_gear_id,
      [nameof (material_player_gear_ids)] = (object) material_player_gear_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ItemGearDrilling) null);
      }
      else
        callback(new WebAPI.Response.ItemGearDrilling(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ItemGearDrillingConfirm> ItemGearDrillingConfirm(
    int base_player_gear_id,
    int[] material_player_gear_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ItemGearDrillingConfirm>((Func<Promise<WebAPI.Response.ItemGearDrillingConfirm>, IEnumerator>) (promise => WebAPI.LoadItemGearDrillingConfirm(promise, base_player_gear_id, material_player_gear_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadItemGearDrillingConfirm(
    Promise<WebAPI.Response.ItemGearDrillingConfirm> promise,
    int base_player_gear_id,
    int[] material_player_gear_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadItemGearDrillingConfirm\u003Ec__IteratorA0()
    {
      base_player_gear_id = base_player_gear_id,
      material_player_gear_ids = material_player_gear_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebase_player_gear_id = base_player_gear_id,
      \u003C\u0024\u003Ematerial_player_gear_ids = material_player_gear_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalItemGearDrillingConfirm(
    int base_player_gear_id,
    int[] material_player_gear_ids,
    Action<WebAPI.Response.ItemGearDrillingConfirm> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/item/gear/drilling/confirm", new Dictionary<string, object>()
    {
      [nameof (base_player_gear_id)] = (object) base_player_gear_id,
      [nameof (material_player_gear_ids)] = (object) material_player_gear_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ItemGearDrillingConfirm) null);
      }
      else
        callback(new WebAPI.Response.ItemGearDrillingConfirm(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ItemGearFavorite> ItemGearFavorite(
    int[] favorite_player_gear_ids,
    int[] un_favorite_player_gear_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ItemGearFavorite>((Func<Promise<WebAPI.Response.ItemGearFavorite>, IEnumerator>) (promise => WebAPI.LoadItemGearFavorite(promise, favorite_player_gear_ids, un_favorite_player_gear_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadItemGearFavorite(
    Promise<WebAPI.Response.ItemGearFavorite> promise,
    int[] favorite_player_gear_ids,
    int[] un_favorite_player_gear_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadItemGearFavorite\u003Ec__IteratorA1()
    {
      favorite_player_gear_ids = favorite_player_gear_ids,
      un_favorite_player_gear_ids = un_favorite_player_gear_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Efavorite_player_gear_ids = favorite_player_gear_ids,
      \u003C\u0024\u003Eun_favorite_player_gear_ids = un_favorite_player_gear_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalItemGearFavorite(
    int[] favorite_player_gear_ids,
    int[] un_favorite_player_gear_ids,
    Action<WebAPI.Response.ItemGearFavorite> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/item/gear/favorite", new Dictionary<string, object>()
    {
      [nameof (favorite_player_gear_ids)] = (object) favorite_player_gear_ids,
      [nameof (un_favorite_player_gear_ids)] = (object) un_favorite_player_gear_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ItemGearFavorite) null);
      }
      else
        callback(new WebAPI.Response.ItemGearFavorite(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ItemGearPoweredRepair> ItemGearPoweredRepair(
    int bet,
    int medal,
    int player_gear_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ItemGearPoweredRepair>((Func<Promise<WebAPI.Response.ItemGearPoweredRepair>, IEnumerator>) (promise => WebAPI.LoadItemGearPoweredRepair(promise, bet, medal, player_gear_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadItemGearPoweredRepair(
    Promise<WebAPI.Response.ItemGearPoweredRepair> promise,
    int bet,
    int medal,
    int player_gear_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadItemGearPoweredRepair\u003Ec__IteratorA2()
    {
      bet = bet,
      medal = medal,
      player_gear_id = player_gear_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebet = bet,
      \u003C\u0024\u003Emedal = medal,
      \u003C\u0024\u003Eplayer_gear_id = player_gear_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalItemGearPoweredRepair(
    int bet,
    int medal,
    int player_gear_id,
    Action<WebAPI.Response.ItemGearPoweredRepair> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/item/gear/powered/repair", new Dictionary<string, object>()
    {
      [nameof (bet)] = (object) bet,
      [nameof (medal)] = (object) medal,
      [nameof (player_gear_id)] = (object) player_gear_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ItemGearPoweredRepair) null);
      }
      else
        callback(new WebAPI.Response.ItemGearPoweredRepair(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ItemGearRepair> ItemGearRepair(
    int[] player_gear_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ItemGearRepair>((Func<Promise<WebAPI.Response.ItemGearRepair>, IEnumerator>) (promise => WebAPI.LoadItemGearRepair(promise, player_gear_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadItemGearRepair(
    Promise<WebAPI.Response.ItemGearRepair> promise,
    int[] player_gear_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadItemGearRepair\u003Ec__IteratorA3()
    {
      player_gear_ids = player_gear_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eplayer_gear_ids = player_gear_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalItemGearRepair(
    int[] player_gear_ids,
    Action<WebAPI.Response.ItemGearRepair> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/item/gear/repair", new Dictionary<string, object>()
    {
      [nameof (player_gear_ids)] = (object) player_gear_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ItemGearRepair) null);
      }
      else
        callback(new WebAPI.Response.ItemGearRepair(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ItemSell> ItemSell(
    int[] player_gear_ids,
    int[] supply_ids,
    int[] supply_quantities,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ItemSell>((Func<Promise<WebAPI.Response.ItemSell>, IEnumerator>) (promise => WebAPI.LoadItemSell(promise, player_gear_ids, supply_ids, supply_quantities, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadItemSell(
    Promise<WebAPI.Response.ItemSell> promise,
    int[] player_gear_ids,
    int[] supply_ids,
    int[] supply_quantities,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadItemSell\u003Ec__IteratorA4()
    {
      player_gear_ids = player_gear_ids,
      supply_ids = supply_ids,
      supply_quantities = supply_quantities,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eplayer_gear_ids = player_gear_ids,
      \u003C\u0024\u003Esupply_ids = supply_ids,
      \u003C\u0024\u003Esupply_quantities = supply_quantities,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalItemSell(
    int[] player_gear_ids,
    int[] supply_ids,
    int[] supply_quantities,
    Action<WebAPI.Response.ItemSell> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/item/sell", new Dictionary<string, object>()
    {
      [nameof (player_gear_ids)] = (object) player_gear_ids,
      [nameof (supply_ids)] = (object) supply_ids,
      [nameof (supply_quantities)] = (object) supply_quantities
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ItemSell) null);
      }
      else
        callback(new WebAPI.Response.ItemSell(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ItemSupplyDeckEdit> ItemSupplyDeckEdit(
    int[] deck_quantities,
    int[] deck_supply_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ItemSupplyDeckEdit>((Func<Promise<WebAPI.Response.ItemSupplyDeckEdit>, IEnumerator>) (promise => WebAPI.LoadItemSupplyDeckEdit(promise, deck_quantities, deck_supply_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadItemSupplyDeckEdit(
    Promise<WebAPI.Response.ItemSupplyDeckEdit> promise,
    int[] deck_quantities,
    int[] deck_supply_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadItemSupplyDeckEdit\u003Ec__IteratorA5()
    {
      deck_quantities = deck_quantities,
      deck_supply_ids = deck_supply_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Edeck_quantities = deck_quantities,
      \u003C\u0024\u003Edeck_supply_ids = deck_supply_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalItemSupplyDeckEdit(
    int[] deck_quantities,
    int[] deck_supply_ids,
    Action<WebAPI.Response.ItemSupplyDeckEdit> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/item/supply/deck/edit", new Dictionary<string, object>()
    {
      [nameof (deck_quantities)] = (object) deck_quantities,
      [nameof (deck_supply_ids)] = (object) deck_supply_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ItemSupplyDeckEdit) null);
      }
      else
        callback(new WebAPI.Response.ItemSupplyDeckEdit(json.Json));
    }));
  }

  public static Future<WebAPI.Response.Officialinfo> Officialinfo(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.Officialinfo>((Func<Promise<WebAPI.Response.Officialinfo>, IEnumerator>) (promise => WebAPI.LoadOfficialinfo(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadOfficialinfo(
    Promise<WebAPI.Response.Officialinfo> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadOfficialinfo\u003Ec__IteratorA6()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalOfficialinfo(
    Action<WebAPI.Response.Officialinfo> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/officialinfo", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.Officialinfo) null);
      }
      else
        callback(new WebAPI.Response.Officialinfo(json.Json));
    }));
  }

  public static Future<WebAPI.Response.OfficialinfoMaintenance> OfficialinfoMaintenance(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.OfficialinfoMaintenance>((Func<Promise<WebAPI.Response.OfficialinfoMaintenance>, IEnumerator>) (promise => WebAPI.LoadOfficialinfoMaintenance(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadOfficialinfoMaintenance(
    Promise<WebAPI.Response.OfficialinfoMaintenance> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadOfficialinfoMaintenance\u003Ec__IteratorA7()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalOfficialinfoMaintenance(
    Action<WebAPI.Response.OfficialinfoMaintenance> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/officialinfo/maintenance", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.OfficialinfoMaintenance) null);
      }
      else
        callback(new WebAPI.Response.OfficialinfoMaintenance(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PlayerBoot> PlayerBoot(
    string application_version,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PlayerBoot>((Func<Promise<WebAPI.Response.PlayerBoot>, IEnumerator>) (promise => WebAPI.LoadPlayerBoot(promise, application_version, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPlayerBoot(
    Promise<WebAPI.Response.PlayerBoot> promise,
    string application_version,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPlayerBoot\u003Ec__IteratorA8()
    {
      application_version = application_version,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eapplication_version = application_version,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPlayerBoot(
    string application_version,
    Action<WebAPI.Response.PlayerBoot> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/player/boot", new Dictionary<string, object>()
    {
      [nameof (application_version)] = (object) application_version
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PlayerBoot) null);
      }
      else
        callback(new WebAPI.Response.PlayerBoot(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PlayerBootRelease> PlayerBootRelease(
    string application_version,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PlayerBootRelease>((Func<Promise<WebAPI.Response.PlayerBootRelease>, IEnumerator>) (promise => WebAPI.LoadPlayerBootRelease(promise, application_version, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPlayerBootRelease(
    Promise<WebAPI.Response.PlayerBootRelease> promise,
    string application_version,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPlayerBootRelease\u003Ec__IteratorA9()
    {
      application_version = application_version,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eapplication_version = application_version,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPlayerBootRelease(
    string application_version,
    Action<WebAPI.Response.PlayerBootRelease> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/player/boot/release", new Dictionary<string, object>()
    {
      [nameof (application_version)] = (object) application_version
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PlayerBootRelease) null);
      }
      else
        callback(new WebAPI.Response.PlayerBootRelease(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PlayerNameEdit> PlayerNameEdit(
    string name,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PlayerNameEdit>((Func<Promise<WebAPI.Response.PlayerNameEdit>, IEnumerator>) (promise => WebAPI.LoadPlayerNameEdit(promise, name, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPlayerNameEdit(
    Promise<WebAPI.Response.PlayerNameEdit> promise,
    string name,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPlayerNameEdit\u003Ec__IteratorAA()
    {
      name = name,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ename = name,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPlayerNameEdit(
    string name,
    Action<WebAPI.Response.PlayerNameEdit> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/player/name/edit", new Dictionary<string, object>()
    {
      [nameof (name)] = (object) name
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PlayerNameEdit) null);
      }
      else
        callback(new WebAPI.Response.PlayerNameEdit(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PlayerSearch> PlayerSearch(
    string target_player_short_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PlayerSearch>((Func<Promise<WebAPI.Response.PlayerSearch>, IEnumerator>) (promise => WebAPI.LoadPlayerSearch(promise, target_player_short_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPlayerSearch(
    Promise<WebAPI.Response.PlayerSearch> promise,
    string target_player_short_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPlayerSearch\u003Ec__IteratorAB()
    {
      target_player_short_id = target_player_short_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Etarget_player_short_id = target_player_short_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPlayerSearch(
    string target_player_short_id,
    Action<WebAPI.Response.PlayerSearch> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/player/search", new Dictionary<string, object>()
    {
      [nameof (target_player_short_id)] = (object) target_player_short_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PlayerSearch) null);
      }
      else
        callback(new WebAPI.Response.PlayerSearch(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PlayerSignin> PlayerSignin(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PlayerSignin>((Func<Promise<WebAPI.Response.PlayerSignin>, IEnumerator>) (promise => WebAPI.LoadPlayerSignin(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPlayerSignin(
    Promise<WebAPI.Response.PlayerSignin> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPlayerSignin\u003Ec__IteratorAC()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPlayerSignin(
    Action<WebAPI.Response.PlayerSignin> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/player/signin", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PlayerSignin) null);
      }
      else
        callback(new WebAPI.Response.PlayerSignin(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PlayerSignup> PlayerSignup(
    int killing_count,
    string name,
    int unit_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PlayerSignup>((Func<Promise<WebAPI.Response.PlayerSignup>, IEnumerator>) (promise => WebAPI.LoadPlayerSignup(promise, killing_count, name, unit_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPlayerSignup(
    Promise<WebAPI.Response.PlayerSignup> promise,
    int killing_count,
    string name,
    int unit_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPlayerSignup\u003Ec__IteratorAD()
    {
      killing_count = killing_count,
      name = name,
      unit_id = unit_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ekilling_count = killing_count,
      \u003C\u0024\u003Ename = name,
      \u003C\u0024\u003Eunit_id = unit_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPlayerSignup(
    int killing_count,
    string name,
    int unit_id,
    Action<WebAPI.Response.PlayerSignup> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/player/signup", new Dictionary<string, object>()
    {
      [nameof (killing_count)] = (object) killing_count,
      [nameof (name)] = (object) name,
      [nameof (unit_id)] = (object) unit_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PlayerSignup) null);
      }
      else
        callback(new WebAPI.Response.PlayerSignup(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PlayerStatus> PlayerStatus(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PlayerStatus>((Func<Promise<WebAPI.Response.PlayerStatus>, IEnumerator>) (promise => WebAPI.LoadPlayerStatus(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPlayerStatus(
    Promise<WebAPI.Response.PlayerStatus> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPlayerStatus\u003Ec__IteratorAE()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPlayerStatus(
    Action<WebAPI.Response.PlayerStatus> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/player/status", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PlayerStatus) null);
      }
      else
        callback(new WebAPI.Response.PlayerStatus(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PresentDelete> PresentDelete(
    int[] present_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PresentDelete>((Func<Promise<WebAPI.Response.PresentDelete>, IEnumerator>) (promise => WebAPI.LoadPresentDelete(promise, present_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPresentDelete(
    Promise<WebAPI.Response.PresentDelete> promise,
    int[] present_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPresentDelete\u003Ec__IteratorAF()
    {
      present_ids = present_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Epresent_ids = present_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPresentDelete(
    int[] present_ids,
    Action<WebAPI.Response.PresentDelete> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/present/delete", new Dictionary<string, object>()
    {
      [nameof (present_ids)] = (object) present_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PresentDelete) null);
      }
      else
        callback(new WebAPI.Response.PresentDelete(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PresentRead> PresentRead(
    int[] present_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PresentRead>((Func<Promise<WebAPI.Response.PresentRead>, IEnumerator>) (promise => WebAPI.LoadPresentRead(promise, present_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPresentRead(
    Promise<WebAPI.Response.PresentRead> promise,
    int[] present_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPresentRead\u003Ec__IteratorB0()
    {
      present_ids = present_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Epresent_ids = present_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPresentRead(
    int[] present_ids,
    Action<WebAPI.Response.PresentRead> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/present/read", new Dictionary<string, object>()
    {
      [nameof (present_ids)] = (object) present_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PresentRead) null);
      }
      else
        callback(new WebAPI.Response.PresentRead(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PresentReadLump> PresentReadLump(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PresentReadLump>((Func<Promise<WebAPI.Response.PresentReadLump>, IEnumerator>) (promise => WebAPI.LoadPresentReadLump(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPresentReadLump(
    Promise<WebAPI.Response.PresentReadLump> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPresentReadLump\u003Ec__IteratorB1()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPresentReadLump(
    Action<WebAPI.Response.PresentReadLump> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/present/read/lump", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PresentReadLump) null);
      }
      else
        callback(new WebAPI.Response.PresentReadLump(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PvpBoot> PvpBoot(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PvpBoot>((Func<Promise<WebAPI.Response.PvpBoot>, IEnumerator>) (promise => WebAPI.LoadPvpBoot(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPvpBoot(
    Promise<WebAPI.Response.PvpBoot> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPvpBoot\u003Ec__IteratorB2()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPvpBoot(
    Action<WebAPI.Response.PvpBoot> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/pvp/boot", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PvpBoot) null);
      }
      else
        callback(new WebAPI.Response.PvpBoot(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PvpForceClose> PvpForceClose(
    bool is_lose,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PvpForceClose>((Func<Promise<WebAPI.Response.PvpForceClose>, IEnumerator>) (promise => WebAPI.LoadPvpForceClose(promise, is_lose, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPvpForceClose(
    Promise<WebAPI.Response.PvpForceClose> promise,
    bool is_lose,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPvpForceClose\u003Ec__IteratorB3()
    {
      is_lose = is_lose,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eis_lose = is_lose,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPvpForceClose(
    bool is_lose,
    Action<WebAPI.Response.PvpForceClose> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/pvp/force-close", new Dictionary<string, object>()
    {
      [nameof (is_lose)] = (object) is_lose
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PvpForceClose) null);
      }
      else
        callback(new WebAPI.Response.PvpForceClose(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PvpFriend> PvpFriend(
    string target_player_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PvpFriend>((Func<Promise<WebAPI.Response.PvpFriend>, IEnumerator>) (promise => WebAPI.LoadPvpFriend(promise, target_player_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPvpFriend(
    Promise<WebAPI.Response.PvpFriend> promise,
    string target_player_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPvpFriend\u003Ec__IteratorB4()
    {
      target_player_id = target_player_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Etarget_player_id = target_player_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPvpFriend(
    string target_player_id,
    Action<WebAPI.Response.PvpFriend> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/pvp/friend", new Dictionary<string, object>()
    {
      [nameof (target_player_id)] = (object) target_player_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PvpFriend) null);
      }
      else
        callback(new WebAPI.Response.PvpFriend(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PvpLiteBoot> PvpLiteBoot(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PvpLiteBoot>((Func<Promise<WebAPI.Response.PvpLiteBoot>, IEnumerator>) (promise => WebAPI.LoadPvpLiteBoot(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPvpLiteBoot(
    Promise<WebAPI.Response.PvpLiteBoot> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPvpLiteBoot\u003Ec__IteratorB5()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPvpLiteBoot(
    Action<WebAPI.Response.PvpLiteBoot> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/pvp/lite/boot", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PvpLiteBoot) null);
      }
      else
        callback(new WebAPI.Response.PvpLiteBoot(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PvpPlayerFinish> PvpPlayerFinish(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PvpPlayerFinish>((Func<Promise<WebAPI.Response.PvpPlayerFinish>, IEnumerator>) (promise => WebAPI.LoadPvpPlayerFinish(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPvpPlayerFinish(
    Promise<WebAPI.Response.PvpPlayerFinish> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPvpPlayerFinish\u003Ec__IteratorB6()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPvpPlayerFinish(
    Action<WebAPI.Response.PvpPlayerFinish> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/pvp/player/finish", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PvpPlayerFinish) null);
      }
      else
        callback(new WebAPI.Response.PvpPlayerFinish(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PvpPlayerStatus> PvpPlayerStatus(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PvpPlayerStatus>((Func<Promise<WebAPI.Response.PvpPlayerStatus>, IEnumerator>) (promise => WebAPI.LoadPvpPlayerStatus(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPvpPlayerStatus(
    Promise<WebAPI.Response.PvpPlayerStatus> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPvpPlayerStatus\u003Ec__IteratorB7()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPvpPlayerStatus(
    Action<WebAPI.Response.PvpPlayerStatus> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/pvp/player/status", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PvpPlayerStatus) null);
      }
      else
        callback(new WebAPI.Response.PvpPlayerStatus(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PvpRanking> PvpRanking(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PvpRanking>((Func<Promise<WebAPI.Response.PvpRanking>, IEnumerator>) (promise => WebAPI.LoadPvpRanking(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPvpRanking(
    Promise<WebAPI.Response.PvpRanking> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPvpRanking\u003Ec__IteratorB8()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPvpRanking(
    Action<WebAPI.Response.PvpRanking> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/pvp/ranking", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PvpRanking) null);
      }
      else
        callback(new WebAPI.Response.PvpRanking(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PvpRankingClose> PvpRankingClose(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PvpRankingClose>((Func<Promise<WebAPI.Response.PvpRankingClose>, IEnumerator>) (promise => WebAPI.LoadPvpRankingClose(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPvpRankingClose(
    Promise<WebAPI.Response.PvpRankingClose> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPvpRankingClose\u003Ec__IteratorB9()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPvpRankingClose(
    Action<WebAPI.Response.PvpRankingClose> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/pvp/ranking-close", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PvpRankingClose) null);
      }
      else
        callback(new WebAPI.Response.PvpRankingClose(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PvpResume> PvpResume(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PvpResume>((Func<Promise<WebAPI.Response.PvpResume>, IEnumerator>) (promise => WebAPI.LoadPvpResume(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPvpResume(
    Promise<WebAPI.Response.PvpResume> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPvpResume\u003Ec__IteratorBA()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPvpResume(
    Action<WebAPI.Response.PvpResume> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/pvp/resume", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PvpResume) null);
      }
      else
        callback(new WebAPI.Response.PvpResume(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PvpSeasonClose> PvpSeasonClose(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PvpSeasonClose>((Func<Promise<WebAPI.Response.PvpSeasonClose>, IEnumerator>) (promise => WebAPI.LoadPvpSeasonClose(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPvpSeasonClose(
    Promise<WebAPI.Response.PvpSeasonClose> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPvpSeasonClose\u003Ec__IteratorBB()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPvpSeasonClose(
    Action<WebAPI.Response.PvpSeasonClose> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/pvp/season-close", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PvpSeasonClose) null);
      }
      else
        callback(new WebAPI.Response.PvpSeasonClose(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PvpTutorialPlayerFinish> PvpTutorialPlayerFinish(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PvpTutorialPlayerFinish>((Func<Promise<WebAPI.Response.PvpTutorialPlayerFinish>, IEnumerator>) (promise => WebAPI.LoadPvpTutorialPlayerFinish(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPvpTutorialPlayerFinish(
    Promise<WebAPI.Response.PvpTutorialPlayerFinish> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPvpTutorialPlayerFinish\u003Ec__IteratorBC()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPvpTutorialPlayerFinish(
    Action<WebAPI.Response.PvpTutorialPlayerFinish> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/pvp/tutorial/player/finish", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PvpTutorialPlayerFinish) null);
      }
      else
        callback(new WebAPI.Response.PvpTutorialPlayerFinish(json.Json));
    }));
  }

  public static Future<WebAPI.Response.PvpTutorialProgressFinish> PvpTutorialProgressFinish(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.PvpTutorialProgressFinish>((Func<Promise<WebAPI.Response.PvpTutorialProgressFinish>, IEnumerator>) (promise => WebAPI.LoadPvpTutorialProgressFinish(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadPvpTutorialProgressFinish(
    Promise<WebAPI.Response.PvpTutorialProgressFinish> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadPvpTutorialProgressFinish\u003Ec__IteratorBD()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalPvpTutorialProgressFinish(
    Action<WebAPI.Response.PvpTutorialProgressFinish> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/pvp/tutorial/progress/finish", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.PvpTutorialProgressFinish) null);
      }
      else
        callback(new WebAPI.Response.PvpTutorialProgressFinish(json.Json));
    }));
  }

  public static Future<WebAPI.Response.QuestHistoryExtra> QuestHistoryExtra(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.QuestHistoryExtra>((Func<Promise<WebAPI.Response.QuestHistoryExtra>, IEnumerator>) (promise => WebAPI.LoadQuestHistoryExtra(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadQuestHistoryExtra(
    Promise<WebAPI.Response.QuestHistoryExtra> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadQuestHistoryExtra\u003Ec__IteratorBE()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalQuestHistoryExtra(
    Action<WebAPI.Response.QuestHistoryExtra> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/quest/history/extra", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.QuestHistoryExtra) null);
      }
      else
        callback(new WebAPI.Response.QuestHistoryExtra(json.Json));
    }));
  }

  public static Future<WebAPI.Response.QuestLimitationCharacter> QuestLimitationCharacter(
    int quest_s_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.QuestLimitationCharacter>((Func<Promise<WebAPI.Response.QuestLimitationCharacter>, IEnumerator>) (promise => WebAPI.LoadQuestLimitationCharacter(promise, quest_s_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadQuestLimitationCharacter(
    Promise<WebAPI.Response.QuestLimitationCharacter> promise,
    int quest_s_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadQuestLimitationCharacter\u003Ec__IteratorBF()
    {
      quest_s_id = quest_s_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Equest_s_id = quest_s_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalQuestLimitationCharacter(
    int quest_s_id,
    Action<WebAPI.Response.QuestLimitationCharacter> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/quest/limitation/character", new Dictionary<string, object>()
    {
      [nameof (quest_s_id)] = (object) quest_s_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.QuestLimitationCharacter) null);
      }
      else
        callback(new WebAPI.Response.QuestLimitationCharacter(json.Json));
    }));
  }

  public static Future<WebAPI.Response.QuestLimitationExtra> QuestLimitationExtra(
    int quest_s_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.QuestLimitationExtra>((Func<Promise<WebAPI.Response.QuestLimitationExtra>, IEnumerator>) (promise => WebAPI.LoadQuestLimitationExtra(promise, quest_s_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadQuestLimitationExtra(
    Promise<WebAPI.Response.QuestLimitationExtra> promise,
    int quest_s_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadQuestLimitationExtra\u003Ec__IteratorC0()
    {
      quest_s_id = quest_s_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Equest_s_id = quest_s_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalQuestLimitationExtra(
    int quest_s_id,
    Action<WebAPI.Response.QuestLimitationExtra> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/quest/limitation/extra", new Dictionary<string, object>()
    {
      [nameof (quest_s_id)] = (object) quest_s_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.QuestLimitationExtra) null);
      }
      else
        callback(new WebAPI.Response.QuestLimitationExtra(json.Json));
    }));
  }

  public static Future<WebAPI.Response.QuestLimitationHarmony> QuestLimitationHarmony(
    int quest_s_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.QuestLimitationHarmony>((Func<Promise<WebAPI.Response.QuestLimitationHarmony>, IEnumerator>) (promise => WebAPI.LoadQuestLimitationHarmony(promise, quest_s_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadQuestLimitationHarmony(
    Promise<WebAPI.Response.QuestLimitationHarmony> promise,
    int quest_s_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadQuestLimitationHarmony\u003Ec__IteratorC1()
    {
      quest_s_id = quest_s_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Equest_s_id = quest_s_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalQuestLimitationHarmony(
    int quest_s_id,
    Action<WebAPI.Response.QuestLimitationHarmony> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/quest/limitation/harmony", new Dictionary<string, object>()
    {
      [nameof (quest_s_id)] = (object) quest_s_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.QuestLimitationHarmony) null);
      }
      else
        callback(new WebAPI.Response.QuestLimitationHarmony(json.Json));
    }));
  }

  public static Future<WebAPI.Response.QuestLimitationStory> QuestLimitationStory(
    int quest_s_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.QuestLimitationStory>((Func<Promise<WebAPI.Response.QuestLimitationStory>, IEnumerator>) (promise => WebAPI.LoadQuestLimitationStory(promise, quest_s_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadQuestLimitationStory(
    Promise<WebAPI.Response.QuestLimitationStory> promise,
    int quest_s_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadQuestLimitationStory\u003Ec__IteratorC2()
    {
      quest_s_id = quest_s_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Equest_s_id = quest_s_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalQuestLimitationStory(
    int quest_s_id,
    Action<WebAPI.Response.QuestLimitationStory> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/quest/limitation/story", new Dictionary<string, object>()
    {
      [nameof (quest_s_id)] = (object) quest_s_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.QuestLimitationStory) null);
      }
      else
        callback(new WebAPI.Response.QuestLimitationStory(json.Json));
    }));
  }

  public static Future<WebAPI.Response.QuestProgressCharacter> QuestProgressCharacter(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.QuestProgressCharacter>((Func<Promise<WebAPI.Response.QuestProgressCharacter>, IEnumerator>) (promise => WebAPI.LoadQuestProgressCharacter(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadQuestProgressCharacter(
    Promise<WebAPI.Response.QuestProgressCharacter> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadQuestProgressCharacter\u003Ec__IteratorC3()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalQuestProgressCharacter(
    Action<WebAPI.Response.QuestProgressCharacter> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/quest/progress/character", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.QuestProgressCharacter) null);
      }
      else
        callback(new WebAPI.Response.QuestProgressCharacter(json.Json));
    }));
  }

  public static Future<WebAPI.Response.QuestProgressExtra> QuestProgressExtra(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.QuestProgressExtra>((Func<Promise<WebAPI.Response.QuestProgressExtra>, IEnumerator>) (promise => WebAPI.LoadQuestProgressExtra(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadQuestProgressExtra(
    Promise<WebAPI.Response.QuestProgressExtra> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadQuestProgressExtra\u003Ec__IteratorC4()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalQuestProgressExtra(
    Action<WebAPI.Response.QuestProgressExtra> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/quest/progress/extra", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.QuestProgressExtra) null);
      }
      else
        callback(new WebAPI.Response.QuestProgressExtra(json.Json));
    }));
  }

  public static Future<WebAPI.Response.QuestProgressHarmony> QuestProgressHarmony(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.QuestProgressHarmony>((Func<Promise<WebAPI.Response.QuestProgressHarmony>, IEnumerator>) (promise => WebAPI.LoadQuestProgressHarmony(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadQuestProgressHarmony(
    Promise<WebAPI.Response.QuestProgressHarmony> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadQuestProgressHarmony\u003Ec__IteratorC5()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalQuestProgressHarmony(
    Action<WebAPI.Response.QuestProgressHarmony> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/quest/progress/harmony", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.QuestProgressHarmony) null);
      }
      else
        callback(new WebAPI.Response.QuestProgressHarmony(json.Json));
    }));
  }

  public static Future<WebAPI.Response.QuestProgressStory> QuestProgressStory(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.QuestProgressStory>((Func<Promise<WebAPI.Response.QuestProgressStory>, IEnumerator>) (promise => WebAPI.LoadQuestProgressStory(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadQuestProgressStory(
    Promise<WebAPI.Response.QuestProgressStory> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadQuestProgressStory\u003Ec__IteratorC6()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalQuestProgressStory(
    Action<WebAPI.Response.QuestProgressStory> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/quest/progress/story", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.QuestProgressStory) null);
      }
      else
        callback(new WebAPI.Response.QuestProgressStory(json.Json));
    }));
  }

  public static Future<WebAPI.Response.QuestRankingExtra> QuestRankingExtra(
    int score_campaign_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.QuestRankingExtra>((Func<Promise<WebAPI.Response.QuestRankingExtra>, IEnumerator>) (promise => WebAPI.LoadQuestRankingExtra(promise, score_campaign_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadQuestRankingExtra(
    Promise<WebAPI.Response.QuestRankingExtra> promise,
    int score_campaign_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadQuestRankingExtra\u003Ec__IteratorC7()
    {
      score_campaign_id = score_campaign_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Escore_campaign_id = score_campaign_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalQuestRankingExtra(
    int score_campaign_id,
    Action<WebAPI.Response.QuestRankingExtra> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/quest/ranking/extra", new Dictionary<string, object>()
    {
      [nameof (score_campaign_id)] = (object) score_campaign_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.QuestRankingExtra) null);
      }
      else
        callback(new WebAPI.Response.QuestRankingExtra(json.Json));
    }));
  }

  public static Future<WebAPI.Response.QuestkeyIndex> QuestkeyIndex(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.QuestkeyIndex>((Func<Promise<WebAPI.Response.QuestkeyIndex>, IEnumerator>) (promise => WebAPI.LoadQuestkeyIndex(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadQuestkeyIndex(
    Promise<WebAPI.Response.QuestkeyIndex> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadQuestkeyIndex\u003Ec__IteratorC8()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalQuestkeyIndex(
    Action<WebAPI.Response.QuestkeyIndex> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/questkey/index", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.QuestkeyIndex) null);
      }
      else
        callback(new WebAPI.Response.QuestkeyIndex(json.Json));
    }));
  }

  public static Future<WebAPI.Response.QuestkeySpend> QuestkeySpend(
    int key_id,
    int quantity,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.QuestkeySpend>((Func<Promise<WebAPI.Response.QuestkeySpend>, IEnumerator>) (promise => WebAPI.LoadQuestkeySpend(promise, key_id, quantity, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadQuestkeySpend(
    Promise<WebAPI.Response.QuestkeySpend> promise,
    int key_id,
    int quantity,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadQuestkeySpend\u003Ec__IteratorC9()
    {
      key_id = key_id,
      quantity = quantity,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ekey_id = key_id,
      \u003C\u0024\u003Equantity = quantity,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalQuestkeySpend(
    int key_id,
    int quantity,
    Action<WebAPI.Response.QuestkeySpend> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/questkey/spend", new Dictionary<string, object>()
    {
      [nameof (key_id)] = (object) key_id,
      [nameof (quantity)] = (object) quantity
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.QuestkeySpend) null);
      }
      else
        callback(new WebAPI.Response.QuestkeySpend(json.Json));
    }));
  }

  public static Future<WebAPI.Response.QuestscoreReward> QuestscoreReward(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.QuestscoreReward>((Func<Promise<WebAPI.Response.QuestscoreReward>, IEnumerator>) (promise => WebAPI.LoadQuestscoreReward(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadQuestscoreReward(
    Promise<WebAPI.Response.QuestscoreReward> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadQuestscoreReward\u003Ec__IteratorCA()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalQuestscoreReward(
    Action<WebAPI.Response.QuestscoreReward> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/questscore/reward", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.QuestscoreReward) null);
      }
      else
        callback(new WebAPI.Response.QuestscoreReward(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ReviewCancel> ReviewCancel(
    string review_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ReviewCancel>((Func<Promise<WebAPI.Response.ReviewCancel>, IEnumerator>) (promise => WebAPI.LoadReviewCancel(promise, review_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadReviewCancel(
    Promise<WebAPI.Response.ReviewCancel> promise,
    string review_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadReviewCancel\u003Ec__IteratorCB()
    {
      review_id = review_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ereview_id = review_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalReviewCancel(
    string review_id,
    Action<WebAPI.Response.ReviewCancel> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/review/cancel", new Dictionary<string, object>()
    {
      [nameof (review_id)] = (object) review_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ReviewCancel) null);
      }
      else
        callback(new WebAPI.Response.ReviewCancel(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ReviewContribute> ReviewContribute(
    string review_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ReviewContribute>((Func<Promise<WebAPI.Response.ReviewContribute>, IEnumerator>) (promise => WebAPI.LoadReviewContribute(promise, review_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadReviewContribute(
    Promise<WebAPI.Response.ReviewContribute> promise,
    string review_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadReviewContribute\u003Ec__IteratorCC()
    {
      review_id = review_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ereview_id = review_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalReviewContribute(
    string review_id,
    Action<WebAPI.Response.ReviewContribute> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/review/contribute", new Dictionary<string, object>()
    {
      [nameof (review_id)] = (object) review_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ReviewContribute) null);
      }
      else
        callback(new WebAPI.Response.ReviewContribute(json.Json));
    }));
  }

  public static Future<WebAPI.Response.SeasonticketIndex> SeasonticketIndex(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.SeasonticketIndex>((Func<Promise<WebAPI.Response.SeasonticketIndex>, IEnumerator>) (promise => WebAPI.LoadSeasonticketIndex(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadSeasonticketIndex(
    Promise<WebAPI.Response.SeasonticketIndex> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadSeasonticketIndex\u003Ec__IteratorCD()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalSeasonticketIndex(
    Action<WebAPI.Response.SeasonticketIndex> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/seasonticket/index", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.SeasonticketIndex) null);
      }
      else
        callback(new WebAPI.Response.SeasonticketIndex(json.Json));
    }));
  }

  public static Future<WebAPI.Response.SeasonticketSpend> SeasonticketSpend(
    int quantity,
    int ticket_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.SeasonticketSpend>((Func<Promise<WebAPI.Response.SeasonticketSpend>, IEnumerator>) (promise => WebAPI.LoadSeasonticketSpend(promise, quantity, ticket_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadSeasonticketSpend(
    Promise<WebAPI.Response.SeasonticketSpend> promise,
    int quantity,
    int ticket_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadSeasonticketSpend\u003Ec__IteratorCE()
    {
      quantity = quantity,
      ticket_id = ticket_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Equantity = quantity,
      \u003C\u0024\u003Eticket_id = ticket_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalSeasonticketSpend(
    int quantity,
    int ticket_id,
    Action<WebAPI.Response.SeasonticketSpend> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/seasonticket/spend", new Dictionary<string, object>()
    {
      [nameof (quantity)] = (object) quantity,
      [nameof (ticket_id)] = (object) ticket_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.SeasonticketSpend) null);
      }
      else
        callback(new WebAPI.Response.SeasonticketSpend(json.Json));
    }));
  }

  public static Future<WebAPI.Response.SerialList> SerialList(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.SerialList>((Func<Promise<WebAPI.Response.SerialList>, IEnumerator>) (promise => WebAPI.LoadSerialList(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadSerialList(
    Promise<WebAPI.Response.SerialList> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadSerialList\u003Ec__IteratorCF()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalSerialList(
    Action<WebAPI.Response.SerialList> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/serial/list", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.SerialList) null);
      }
      else
        callback(new WebAPI.Response.SerialList(json.Json));
    }));
  }

  public static Future<WebAPI.Response.SerialRegister> SerialRegister(
    int campaign_id,
    string serial_code,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.SerialRegister>((Func<Promise<WebAPI.Response.SerialRegister>, IEnumerator>) (promise => WebAPI.LoadSerialRegister(promise, campaign_id, serial_code, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadSerialRegister(
    Promise<WebAPI.Response.SerialRegister> promise,
    int campaign_id,
    string serial_code,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadSerialRegister\u003Ec__IteratorD0()
    {
      campaign_id = campaign_id,
      serial_code = serial_code,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ecampaign_id = campaign_id,
      \u003C\u0024\u003Eserial_code = serial_code,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalSerialRegister(
    int campaign_id,
    string serial_code,
    Action<WebAPI.Response.SerialRegister> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/serial/register", new Dictionary<string, object>()
    {
      [nameof (campaign_id)] = (object) campaign_id,
      [nameof (serial_code)] = (object) serial_code
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.SerialRegister) null);
      }
      else
        callback(new WebAPI.Response.SerialRegister(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ShopBuy> ShopBuy(
    int article_id,
    int quantity,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ShopBuy>((Func<Promise<WebAPI.Response.ShopBuy>, IEnumerator>) (promise => WebAPI.LoadShopBuy(promise, article_id, quantity, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadShopBuy(
    Promise<WebAPI.Response.ShopBuy> promise,
    int article_id,
    int quantity,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadShopBuy\u003Ec__IteratorD1()
    {
      article_id = article_id,
      quantity = quantity,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Earticle_id = article_id,
      \u003C\u0024\u003Equantity = quantity,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalShopBuy(
    int article_id,
    int quantity,
    Action<WebAPI.Response.ShopBuy> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/shop/buy", new Dictionary<string, object>()
    {
      [nameof (article_id)] = (object) article_id,
      [nameof (quantity)] = (object) quantity
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ShopBuy) null);
      }
      else
        callback(new WebAPI.Response.ShopBuy(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ShopStatus> ShopStatus(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ShopStatus>((Func<Promise<WebAPI.Response.ShopStatus>, IEnumerator>) (promise => WebAPI.LoadShopStatus(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadShopStatus(
    Promise<WebAPI.Response.ShopStatus> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadShopStatus\u003Ec__IteratorD2()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalShopStatus(
    Action<WebAPI.Response.ShopStatus> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/shop/status", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ShopStatus) null);
      }
      else
        callback(new WebAPI.Response.ShopStatus(json.Json));
    }));
  }

  public static Future<WebAPI.Response.Slot> Slot(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.Slot>((Func<Promise<WebAPI.Response.Slot>, IEnumerator>) (promise => WebAPI.LoadSlot(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadSlot(
    Promise<WebAPI.Response.Slot> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadSlot\u003Ec__IteratorD3()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalSlot(
    Action<WebAPI.Response.Slot> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/slot", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.Slot) null);
      }
      else
        callback(new WebAPI.Response.Slot(json.Json));
    }));
  }

  public static Future<WebAPI.Response.SlotS001MedalPay> SlotS001MedalPay(
    int slot_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.SlotS001MedalPay>((Func<Promise<WebAPI.Response.SlotS001MedalPay>, IEnumerator>) (promise => WebAPI.LoadSlotS001MedalPay(promise, slot_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadSlotS001MedalPay(
    Promise<WebAPI.Response.SlotS001MedalPay> promise,
    int slot_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadSlotS001MedalPay\u003Ec__IteratorD4()
    {
      slot_id = slot_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eslot_id = slot_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalSlotS001MedalPay(
    int slot_id,
    Action<WebAPI.Response.SlotS001MedalPay> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/slot/s001_medal/pay", new Dictionary<string, object>()
    {
      [nameof (slot_id)] = (object) slot_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.SlotS001MedalPay) null);
      }
      else
        callback(new WebAPI.Response.SlotS001MedalPay(json.Json));
    }));
  }

  public static Future<WebAPI.Response.TutorialTutorialResume> TutorialTutorialResume(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.TutorialTutorialResume>((Func<Promise<WebAPI.Response.TutorialTutorialResume>, IEnumerator>) (promise => WebAPI.LoadTutorialTutorialResume(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadTutorialTutorialResume(
    Promise<WebAPI.Response.TutorialTutorialResume> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadTutorialTutorialResume\u003Ec__IteratorD5()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalTutorialTutorialResume(
    Action<WebAPI.Response.TutorialTutorialResume> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/tutorial/tutorial/resume", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.TutorialTutorialResume) null);
      }
      else
        callback(new WebAPI.Response.TutorialTutorialResume(json.Json));
    }));
  }

  public static Future<WebAPI.Response.TutorialTutorialValid> TutorialTutorialValid(
    string name,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.TutorialTutorialValid>((Func<Promise<WebAPI.Response.TutorialTutorialValid>, IEnumerator>) (promise => WebAPI.LoadTutorialTutorialValid(promise, name, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadTutorialTutorialValid(
    Promise<WebAPI.Response.TutorialTutorialValid> promise,
    string name,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadTutorialTutorialValid\u003Ec__IteratorD6()
    {
      name = name,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ename = name,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalTutorialTutorialValid(
    string name,
    Action<WebAPI.Response.TutorialTutorialValid> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/tutorial/tutorial/valid", new Dictionary<string, object>()
    {
      [nameof (name)] = (object) name
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.TutorialTutorialValid) null);
      }
      else
        callback(new WebAPI.Response.TutorialTutorialValid(json.Json));
    }));
  }

  public static Future<WebAPI.Response.UnitCompose> UnitCompose(
    int base_player_unit_id,
    int[] material_player_unit_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.UnitCompose>((Func<Promise<WebAPI.Response.UnitCompose>, IEnumerator>) (promise => WebAPI.LoadUnitCompose(promise, base_player_unit_id, material_player_unit_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadUnitCompose(
    Promise<WebAPI.Response.UnitCompose> promise,
    int base_player_unit_id,
    int[] material_player_unit_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadUnitCompose\u003Ec__IteratorD7()
    {
      base_player_unit_id = base_player_unit_id,
      material_player_unit_ids = material_player_unit_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebase_player_unit_id = base_player_unit_id,
      \u003C\u0024\u003Ematerial_player_unit_ids = material_player_unit_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalUnitCompose(
    int base_player_unit_id,
    int[] material_player_unit_ids,
    Action<WebAPI.Response.UnitCompose> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/unit/compose", new Dictionary<string, object>()
    {
      [nameof (base_player_unit_id)] = (object) base_player_unit_id,
      [nameof (material_player_unit_ids)] = (object) material_player_unit_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.UnitCompose) null);
      }
      else
        callback(new WebAPI.Response.UnitCompose(json.Json));
    }));
  }

  public static Future<WebAPI.Response.UnitEquip> UnitEquip(
    int number,
    int? player_gear_id,
    int player_unit_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.UnitEquip>((Func<Promise<WebAPI.Response.UnitEquip>, IEnumerator>) (promise => WebAPI.LoadUnitEquip(promise, number, player_gear_id, player_unit_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadUnitEquip(
    Promise<WebAPI.Response.UnitEquip> promise,
    int number,
    int? player_gear_id,
    int player_unit_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadUnitEquip\u003Ec__IteratorD8()
    {
      number = number,
      player_gear_id = player_gear_id,
      player_unit_id = player_unit_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Enumber = number,
      \u003C\u0024\u003Eplayer_gear_id = player_gear_id,
      \u003C\u0024\u003Eplayer_unit_id = player_unit_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalUnitEquip(
    int number,
    int? player_gear_id,
    int player_unit_id,
    Action<WebAPI.Response.UnitEquip> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/unit/equip", new Dictionary<string, object>()
    {
      [nameof (number)] = (object) number,
      [nameof (player_gear_id)] = (object) player_gear_id,
      [nameof (player_unit_id)] = (object) player_unit_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.UnitEquip) null);
      }
      else
        callback(new WebAPI.Response.UnitEquip(json.Json));
    }));
  }

  public static Future<WebAPI.Response.UnitEvolution> UnitEvolution(
    int base_player_unit_id,
    int[] material_player_unit_ids,
    int pattern_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.UnitEvolution>((Func<Promise<WebAPI.Response.UnitEvolution>, IEnumerator>) (promise => WebAPI.LoadUnitEvolution(promise, base_player_unit_id, material_player_unit_ids, pattern_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadUnitEvolution(
    Promise<WebAPI.Response.UnitEvolution> promise,
    int base_player_unit_id,
    int[] material_player_unit_ids,
    int pattern_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadUnitEvolution\u003Ec__IteratorD9()
    {
      base_player_unit_id = base_player_unit_id,
      material_player_unit_ids = material_player_unit_ids,
      pattern_id = pattern_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebase_player_unit_id = base_player_unit_id,
      \u003C\u0024\u003Ematerial_player_unit_ids = material_player_unit_ids,
      \u003C\u0024\u003Epattern_id = pattern_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalUnitEvolution(
    int base_player_unit_id,
    int[] material_player_unit_ids,
    int pattern_id,
    Action<WebAPI.Response.UnitEvolution> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/unit/evolution", new Dictionary<string, object>()
    {
      [nameof (base_player_unit_id)] = (object) base_player_unit_id,
      [nameof (material_player_unit_ids)] = (object) material_player_unit_ids,
      [nameof (pattern_id)] = (object) pattern_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.UnitEvolution) null);
      }
      else
        callback(new WebAPI.Response.UnitEvolution(json.Json));
    }));
  }

  public static Future<WebAPI.Response.UnitEvolutionParameter> UnitEvolutionParameter(
    int base_player_unit_id,
    int pattern_id,
    int[] pattern_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.UnitEvolutionParameter>((Func<Promise<WebAPI.Response.UnitEvolutionParameter>, IEnumerator>) (promise => WebAPI.LoadUnitEvolutionParameter(promise, base_player_unit_id, pattern_id, pattern_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadUnitEvolutionParameter(
    Promise<WebAPI.Response.UnitEvolutionParameter> promise,
    int base_player_unit_id,
    int pattern_id,
    int[] pattern_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadUnitEvolutionParameter\u003Ec__IteratorDA()
    {
      base_player_unit_id = base_player_unit_id,
      pattern_id = pattern_id,
      pattern_ids = pattern_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebase_player_unit_id = base_player_unit_id,
      \u003C\u0024\u003Epattern_id = pattern_id,
      \u003C\u0024\u003Epattern_ids = pattern_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalUnitEvolutionParameter(
    int base_player_unit_id,
    int pattern_id,
    int[] pattern_ids,
    Action<WebAPI.Response.UnitEvolutionParameter> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/unit/evolution-parameter", new Dictionary<string, object>()
    {
      [nameof (base_player_unit_id)] = (object) base_player_unit_id,
      [nameof (pattern_id)] = (object) pattern_id,
      [nameof (pattern_ids)] = (object) pattern_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.UnitEvolutionParameter) null);
      }
      else
        callback(new WebAPI.Response.UnitEvolutionParameter(json.Json));
    }));
  }

  public static Future<WebAPI.Response.UnitFavorite> UnitFavorite(
    int[] player_unit_ids,
    int[] unlock_player_unit_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.UnitFavorite>((Func<Promise<WebAPI.Response.UnitFavorite>, IEnumerator>) (promise => WebAPI.LoadUnitFavorite(promise, player_unit_ids, unlock_player_unit_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadUnitFavorite(
    Promise<WebAPI.Response.UnitFavorite> promise,
    int[] player_unit_ids,
    int[] unlock_player_unit_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadUnitFavorite\u003Ec__IteratorDB()
    {
      player_unit_ids = player_unit_ids,
      unlock_player_unit_ids = unlock_player_unit_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eplayer_unit_ids = player_unit_ids,
      \u003C\u0024\u003Eunlock_player_unit_ids = unlock_player_unit_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalUnitFavorite(
    int[] player_unit_ids,
    int[] unlock_player_unit_ids,
    Action<WebAPI.Response.UnitFavorite> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/unit/favorite", new Dictionary<string, object>()
    {
      [nameof (player_unit_ids)] = (object) player_unit_ids,
      [nameof (unlock_player_unit_ids)] = (object) unlock_player_unit_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.UnitFavorite) null);
      }
      else
        callback(new WebAPI.Response.UnitFavorite(json.Json));
    }));
  }

  public static Future<WebAPI.Response.UnitSell> UnitSell(
    int[] player_unit_ids,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.UnitSell>((Func<Promise<WebAPI.Response.UnitSell>, IEnumerator>) (promise => WebAPI.LoadUnitSell(promise, player_unit_ids, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadUnitSell(
    Promise<WebAPI.Response.UnitSell> promise,
    int[] player_unit_ids,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadUnitSell\u003Ec__IteratorDC()
    {
      player_unit_ids = player_unit_ids,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eplayer_unit_ids = player_unit_ids,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalUnitSell(
    int[] player_unit_ids,
    Action<WebAPI.Response.UnitSell> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/unit/sell", new Dictionary<string, object>()
    {
      [nameof (player_unit_ids)] = (object) player_unit_ids
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.UnitSell) null);
      }
      else
        callback(new WebAPI.Response.UnitSell(json.Json));
    }));
  }

  public static Future<WebAPI.Response.UnitTransmigrate> UnitTransmigrate(
    int base_player_unit_id,
    int[] material_player_unit_ids,
    int pattern_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.UnitTransmigrate>((Func<Promise<WebAPI.Response.UnitTransmigrate>, IEnumerator>) (promise => WebAPI.LoadUnitTransmigrate(promise, base_player_unit_id, material_player_unit_ids, pattern_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadUnitTransmigrate(
    Promise<WebAPI.Response.UnitTransmigrate> promise,
    int base_player_unit_id,
    int[] material_player_unit_ids,
    int pattern_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadUnitTransmigrate\u003Ec__IteratorDD()
    {
      base_player_unit_id = base_player_unit_id,
      material_player_unit_ids = material_player_unit_ids,
      pattern_id = pattern_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebase_player_unit_id = base_player_unit_id,
      \u003C\u0024\u003Ematerial_player_unit_ids = material_player_unit_ids,
      \u003C\u0024\u003Epattern_id = pattern_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalUnitTransmigrate(
    int base_player_unit_id,
    int[] material_player_unit_ids,
    int pattern_id,
    Action<WebAPI.Response.UnitTransmigrate> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/unit/transmigrate", new Dictionary<string, object>()
    {
      [nameof (base_player_unit_id)] = (object) base_player_unit_id,
      [nameof (material_player_unit_ids)] = (object) material_player_unit_ids,
      [nameof (pattern_id)] = (object) pattern_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.UnitTransmigrate) null);
      }
      else
        callback(new WebAPI.Response.UnitTransmigrate(json.Json));
    }));
  }

  public static Future<WebAPI.Response.UnitTransmigrateParameter> UnitTransmigrateParameter(
    int base_player_unit_id,
    int pattern_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.UnitTransmigrateParameter>((Func<Promise<WebAPI.Response.UnitTransmigrateParameter>, IEnumerator>) (promise => WebAPI.LoadUnitTransmigrateParameter(promise, base_player_unit_id, pattern_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadUnitTransmigrateParameter(
    Promise<WebAPI.Response.UnitTransmigrateParameter> promise,
    int base_player_unit_id,
    int pattern_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadUnitTransmigrateParameter\u003Ec__IteratorDE()
    {
      base_player_unit_id = base_player_unit_id,
      pattern_id = pattern_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Ebase_player_unit_id = base_player_unit_id,
      \u003C\u0024\u003Epattern_id = pattern_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalUnitTransmigrateParameter(
    int base_player_unit_id,
    int pattern_id,
    Action<WebAPI.Response.UnitTransmigrateParameter> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/unit/transmigrate-parameter", new Dictionary<string, object>()
    {
      [nameof (base_player_unit_id)] = (object) base_player_unit_id,
      [nameof (pattern_id)] = (object) pattern_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.UnitTransmigrateParameter) null);
      }
      else
        callback(new WebAPI.Response.UnitTransmigrateParameter(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ZeroLoad> ZeroLoad(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ZeroLoad>((Func<Promise<WebAPI.Response.ZeroLoad>, IEnumerator>) (promise => WebAPI.LoadZeroLoad(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadZeroLoad(
    Promise<WebAPI.Response.ZeroLoad> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadZeroLoad\u003Ec__IteratorDF()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalZeroLoad(
    Action<WebAPI.Response.ZeroLoad> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/zero/load", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ZeroLoad) null);
      }
      else
        callback(new WebAPI.Response.ZeroLoad(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ZeroReset> ZeroReset(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ZeroReset>((Func<Promise<WebAPI.Response.ZeroReset>, IEnumerator>) (promise => WebAPI.LoadZeroReset(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadZeroReset(
    Promise<WebAPI.Response.ZeroReset> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadZeroReset\u003Ec__IteratorE0()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalZeroReset(
    Action<WebAPI.Response.ZeroReset> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/zero/reset", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ZeroReset) null);
      }
      else
        callback(new WebAPI.Response.ZeroReset(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ZeroSave> ZeroSave(
    string player_data,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ZeroSave>((Func<Promise<WebAPI.Response.ZeroSave>, IEnumerator>) (promise => WebAPI.LoadZeroSave(promise, player_data, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadZeroSave(
    Promise<WebAPI.Response.ZeroSave> promise,
    string player_data,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadZeroSave\u003Ec__IteratorE1()
    {
      player_data = player_data,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Eplayer_data = player_data,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalZeroSave(
    string player_data,
    Action<WebAPI.Response.ZeroSave> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/zero/save", new Dictionary<string, object>()
    {
      [nameof (player_data)] = (object) player_data
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ZeroSave) null);
      }
      else
        callback(new WebAPI.Response.ZeroSave(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ZukanDefeatRewardEnemy> ZukanDefeatRewardEnemy(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ZukanDefeatRewardEnemy>((Func<Promise<WebAPI.Response.ZukanDefeatRewardEnemy>, IEnumerator>) (promise => WebAPI.LoadZukanDefeatRewardEnemy(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadZukanDefeatRewardEnemy(
    Promise<WebAPI.Response.ZukanDefeatRewardEnemy> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadZukanDefeatRewardEnemy\u003Ec__IteratorE2()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalZukanDefeatRewardEnemy(
    Action<WebAPI.Response.ZukanDefeatRewardEnemy> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/zukan/defeat_reward/enemy", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ZukanDefeatRewardEnemy) null);
      }
      else
        callback(new WebAPI.Response.ZukanDefeatRewardEnemy(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ZukanDefeatRewardReceive> ZukanDefeatRewardReceive(
    int defeat_reward_id,
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ZukanDefeatRewardReceive>((Func<Promise<WebAPI.Response.ZukanDefeatRewardReceive>, IEnumerator>) (promise => WebAPI.LoadZukanDefeatRewardReceive(promise, defeat_reward_id, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadZukanDefeatRewardReceive(
    Promise<WebAPI.Response.ZukanDefeatRewardReceive> promise,
    int defeat_reward_id,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadZukanDefeatRewardReceive\u003Ec__IteratorE3()
    {
      defeat_reward_id = defeat_reward_id,
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003Edefeat_reward_id = defeat_reward_id,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalZukanDefeatRewardReceive(
    int defeat_reward_id,
    Action<WebAPI.Response.ZukanDefeatRewardReceive> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Post("/zukan/defeat_reward/receive", new Dictionary<string, object>()
    {
      [nameof (defeat_reward_id)] = (object) defeat_reward_id
    }, (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ZukanDefeatRewardReceive) null);
      }
      else
        callback(new WebAPI.Response.ZukanDefeatRewardReceive(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ZukanEnemy> ZukanEnemy(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ZukanEnemy>((Func<Promise<WebAPI.Response.ZukanEnemy>, IEnumerator>) (promise => WebAPI.LoadZukanEnemy(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadZukanEnemy(
    Promise<WebAPI.Response.ZukanEnemy> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadZukanEnemy\u003Ec__IteratorE4()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalZukanEnemy(
    Action<WebAPI.Response.ZukanEnemy> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/zukan/enemy", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ZukanEnemy) null);
      }
      else
        callback(new WebAPI.Response.ZukanEnemy(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ZukanGear> ZukanGear(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ZukanGear>((Func<Promise<WebAPI.Response.ZukanGear>, IEnumerator>) (promise => WebAPI.LoadZukanGear(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadZukanGear(
    Promise<WebAPI.Response.ZukanGear> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadZukanGear\u003Ec__IteratorE5()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalZukanGear(
    Action<WebAPI.Response.ZukanGear> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/zukan/gear", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ZukanGear) null);
      }
      else
        callback(new WebAPI.Response.ZukanGear(json.Json));
    }));
  }

  public static Future<WebAPI.Response.ZukanUnit> ZukanUnit(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return new Future<WebAPI.Response.ZukanUnit>((Func<Promise<WebAPI.Response.ZukanUnit>, IEnumerator>) (promise => WebAPI.LoadZukanUnit(promise, userErrorCallback)));
  }

  [DebuggerHidden]
  private static IEnumerator LoadZukanUnit(
    Promise<WebAPI.Response.ZukanUnit> promise,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CLoadZukanUnit\u003Ec__IteratorE6()
    {
      userErrorCallback = userErrorCallback,
      promise = promise,
      \u003C\u0024\u003EuserErrorCallback = userErrorCallback,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static void InternalZukanUnit(
    Action<WebAPI.Response.ZukanUnit> callback,
    Action<WebAPI.Response.UserError> userErrorCallback)
  {
    WebQueue.Get("/zukan/unit", (Action<WebResponse>) (json =>
    {
      object obj;
      if (json.Json.TryGetValue("is_error", out obj) && (bool) obj)
      {
        userErrorCallback = userErrorCallback ?? WebAPI.DefaultUserErrorCallback;
        userErrorCallback(new WebAPI.Response.UserError(json.Json));
        callback((WebAPI.Response.ZukanUnit) null);
      }
      else
        callback(new WebAPI.Response.ZukanUnit(json.Json));
    }));
  }

  public static bool IsResponsedAtRecent(string methodName, double thresholdSeconds = 60f)
  {
    return WebAPI.latestResponsedAt.ContainsKey(methodName) && (DateTime.Now - WebAPI.latestResponsedAt[methodName]).TotalSeconds <= thresholdSeconds;
  }

  public static void SetLatestResponsedAt(string methodName)
  {
    WebAPI.latestResponsedAt[methodName] = DateTime.Now;
  }

  public static WebAPI.Response.PlayerBootRelease LastPlayerBoot { get; private set; }

  public static Future<WebAPI.Response.PlayerBootRelease> PlayerBoot(
    Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    return WebAPI.PlayerBootRelease(Revision.ApplicationVersion, userErrorCallback).Then<WebAPI.Response.PlayerBootRelease>((Func<WebAPI.Response.PlayerBootRelease, WebAPI.Response.PlayerBootRelease>) (x =>
    {
      WebAPI.LastPlayerBoot = x;
      return x;
    }));
  }

  public static Future<Dictionary<string, object>> SendError(
    string condition,
    string stacktrace,
    LogType type)
  {
    return new Future<Dictionary<string, object>>((Func<Promise<Dictionary<string, object>>, IEnumerator>) (promise => WebAPI.SendErrorE(promise, condition, stacktrace, type)));
  }

  [DebuggerHidden]
  private static IEnumerator SendErrorE(
    Promise<Dictionary<string, object>> promise,
    string condition,
    string stacktrace,
    LogType type)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CSendErrorE\u003Ec__IteratorE7()
    {
      condition = condition,
      stacktrace = stacktrace,
      type = type,
      promise = promise,
      \u003C\u0024\u003Econdition = condition,
      \u003C\u0024\u003Estacktrace = stacktrace,
      \u003C\u0024\u003Etype = type,
      \u003C\u0024\u003Epromise = promise
    };
  }

  private static Dictionary<string, object> ToDictionary(
    string condition,
    string stacktrace,
    LogType type,
    string deviceId,
    Player player)
  {
    Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
    string[] strArray = condition.Split(WebAPI.SENTRY_MESSAGE_DELIMITERS, 2, StringSplitOptions.None);
    string str = condition;
    string empty = string.Empty;
    if (strArray.Length == 2)
    {
      str = strArray[0];
      empty = strArray[1];
    }
    condition = "[Android] " + str;
    dictionary1.Add("message", (object) str);
    dictionary1.Add("exception", (object) new Dictionary<string, object>()
    {
      {
        nameof (type),
        (object) ((Enum) (object) type).ToString()
      },
      {
        "value",
        (object) (str + "\n\n" + stacktrace)
      }
    });
    if (!string.IsNullOrEmpty(deviceId))
    {
      Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
      dictionary2.Add("id", (object) deviceId);
      if (player != null)
        dictionary2.Add("username", (object) player.name);
      dictionary1.Add("user", (object) dictionary2);
    }
    Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
    dictionary3.Add("message", (object) str);
    if (!string.IsNullOrEmpty(empty))
      dictionary3.Add("message_parameter", (object) empty);
    dictionary3.Add(nameof (stacktrace), (object) stacktrace);
    if (player != null)
    {
      dictionary3.Add("id", (object) player.id);
      dictionary3.Add("short_id", (object) player.short_id);
      dictionary3.Add("level", (object) player.level);
      dictionary3.Add("money", (object) player.money);
      dictionary3.Add("medal", (object) player.medal);
      dictionary3.Add("paid_coin", (object) player.paid_coin);
      dictionary3.Add("free_coin", (object) player.free_coin);
    }
    dictionary3.Add("application_version", (object) Revision.ApplicationVersion);
    dictionary3.Add("dlc_version", (object) Revision.DLCVersion);
    dictionary1.Add("extra", (object) dictionary3);
    return dictionary1;
  }

  private static void InternalSendError(
    string condition,
    string stacktrace,
    LogType type,
    Action<Dictionary<string, object>> callback)
  {
    Dictionary<string, object> dictionary = WebAPI.ToDictionary(condition, stacktrace, type, Persist.auth.Data.DeviceID, SMManager.Get<Player>());
    Dictionary<string, string> headers = new Dictionary<string, string>();
    headers.Add("Content-Type", "application/json; charset=utf-8");
    if (WebQueue.IsAuthToken())
      headers.Add("Authorization", "gumi " + WebQueue.AuthToken);
    headers.Add("User-Agent", DeviceManager.GetUserAgent());
    headers.Add("X-Device-Version", DeviceManager.GetBundleVersion());
    headers.Add("X-Device-ApplicationVersion", Revision.ApplicationVersion);
    headers.Add("X-Device-DLCVersion", Revision.DLCVersion);
    headers.Add("X-Device-Language-Locale", DeviceManager.GetLanguageLocale());
    headers.Add("X-Device-TimeZone", DeviceManager.GetTimeZone());
    headers.Add("X-Device-Platform", "android");
    string url = new WebRequest("api/v2/client/error", WebRequest.RequestMethod.POST, string.Empty, (Action<WebResponse>) null).GetURL();
    if (!Object.op_Inequality((Object) UniWeb.Instance, (Object) null))
      return;
    UniWeb.Instance.StartCoroutine(WebAPI.InternalSendErrorE(url, Encoding.UTF8.GetBytes(Json.Serialize((object) dictionary)), headers));
  }

  [DebuggerHidden]
  private static IEnumerator InternalSendErrorE(
    string url,
    byte[] post,
    Dictionary<string, string> headers)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebAPI.\u003CInternalSendErrorE\u003Ec__IteratorE8()
    {
      url = url,
      post = post,
      headers = headers,
      \u003C\u0024\u003Eurl = url,
      \u003C\u0024\u003Epost = post,
      \u003C\u0024\u003Eheaders = headers
    };
  }

  private static void defaultUserErrorCallback(WebAPI.Response.UserError error)
  {
    throw new Exception(error.Reason);
  }

  public class Response
  {
    [Serializable]
    public class AchievementApiAuth : KeyCompare
    {
      public string auth_url;
      public int auth_status;

      public AchievementApiAuth()
      {
      }

      public AchievementApiAuth(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.auth_url = (string) json[nameof (auth_url)];
        this.auth_status = (int) (long) json[nameof (auth_status)];
      }
    }

    [Serializable]
    public class Agreement : KeyCompare
    {
      public string agreement_title;
      public string not_agreement_title;
      public string agreement_header;
      public string agreement;
      public string not_agreement;

      public Agreement()
      {
      }

      public Agreement(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.agreement_title = (string) json[nameof (agreement_title)];
        this.not_agreement_title = (string) json[nameof (not_agreement_title)];
        this.agreement_header = (string) json[nameof (agreement_header)];
        this.agreement = (string) json[nameof (agreement)];
        this.not_agreement = (string) json[nameof (not_agreement)];
      }
    }

    [Serializable]
    public class BattleCharacterFinish : KeyCompare
    {
      public PlayerCharacterIntimate[] player_character_intimates;
      public PlayerHelper[] player_helpers;
      public PlayerUnit[] player_units;
      public PlayerItem[] player_items;
      public PlayerMissionHistory[] player_mission_histories;
      public Player player;
      public BattleEnd battle_finish;
      public PlayerPresent[] player_presents;
      public PlayerStoryQuestS[] player_story_quests;

      public BattleCharacterFinish()
      {
      }

      public BattleCharacterFinish(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerCharacterIntimate> characterIntimateList = new List<PlayerCharacterIntimate>();
        foreach (object json1 in (List<object>) json[nameof (player_character_intimates)])
          characterIntimateList.Add(json1 != null ? new PlayerCharacterIntimate((Dictionary<string, object>) json1) : (PlayerCharacterIntimate) null);
        this.player_character_intimates = characterIntimateList.ToArray();
        SMManager.UpdateList<PlayerCharacterIntimate>(this.player_character_intimates);
        List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
        foreach (object json2 in (List<object>) json[nameof (player_helpers)])
          playerHelperList.Add(json2 != null ? new PlayerHelper((Dictionary<string, object>) json2) : (PlayerHelper) null);
        this.player_helpers = playerHelperList.ToArray();
        SMManager.UpdateList<PlayerHelper>(this.player_helpers);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json4 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json4 != null ? new PlayerItem((Dictionary<string, object>) json4) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<PlayerMissionHistory> playerMissionHistoryList = new List<PlayerMissionHistory>();
        foreach (object json5 in (List<object>) json[nameof (player_mission_histories)])
          playerMissionHistoryList.Add(json5 != null ? new PlayerMissionHistory((Dictionary<string, object>) json5) : (PlayerMissionHistory) null);
        this.player_mission_histories = playerMissionHistoryList.ToArray();
        SMManager.UpdateList<PlayerMissionHistory>(this.player_mission_histories);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        this.battle_finish = json[nameof (battle_finish)] != null ? new BattleEnd((Dictionary<string, object>) json[nameof (battle_finish)]) : (BattleEnd) null;
        SMManager.Change<BattleEnd>(this.battle_finish);
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json6 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json6 != null ? new PlayerPresent((Dictionary<string, object>) json6) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<PlayerStoryQuestS> playerStoryQuestSList = new List<PlayerStoryQuestS>();
        foreach (object json7 in (List<object>) json[nameof (player_story_quests)])
          playerStoryQuestSList.Add(json7 != null ? new PlayerStoryQuestS((Dictionary<string, object>) json7) : (PlayerStoryQuestS) null);
        this.player_story_quests = playerStoryQuestSList.ToArray();
        SMManager.UpdateList<PlayerStoryQuestS>(this.player_story_quests);
        if (json.ContainsKey("player_presents:delete"))
          SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
        if (!json.ContainsKey("player_items:delete"))
          return;
        SMManager.DeleteList<PlayerItem>(((IEnumerable<object>) json["player_items:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class BattleCharacterStart : KeyCompare
    {
      public PlayerUnit[] user_deck_units;
      public int[] enemy;
      public int deck_type_id;
      public int quest_s_id;
      public int[] user_deck_enemy;
      public WebAPI.Response.BattleCharacterStartPanel_item[] panel_item;
      public string battle_uuid;
      public string support_player_id;
      public WebAPI.Response.BattleCharacterStartUser_deck_enemy_item[] user_deck_enemy_item;
      public bool battle_start;
      public PlayerUnit[] helper_player_units;
      public int quest_type;
      public Player player;
      public PlayerHelper[] helpers;
      public PlayerItem[] helper_player_gears;
      public PlayerItem[] user_deck_gears;
      public int quest_loop_count;
      public WebAPI.Response.BattleCharacterStartEnemy_item[] enemy_item;
      public int deck_number;
      public int[] panel;

      public BattleCharacterStart()
      {
      }

      public BattleCharacterStart(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
        foreach (object json1 in (List<object>) json[nameof (user_deck_units)])
          playerUnitList1.Add(json1 != null ? new PlayerUnit((Dictionary<string, object>) json1) : (PlayerUnit) null);
        this.user_deck_units = playerUnitList1.ToArray();
        this.enemy = ((IEnumerable<object>) json[nameof (enemy)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
        this.deck_type_id = (int) (long) json[nameof (deck_type_id)];
        this.quest_s_id = (int) (long) json[nameof (quest_s_id)];
        this.user_deck_enemy = ((IEnumerable<object>) json[nameof (user_deck_enemy)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
        List<WebAPI.Response.BattleCharacterStartPanel_item> characterStartPanelItemList = new List<WebAPI.Response.BattleCharacterStartPanel_item>();
        foreach (object json2 in (List<object>) json[nameof (panel_item)])
          characterStartPanelItemList.Add(json2 != null ? new WebAPI.Response.BattleCharacterStartPanel_item((Dictionary<string, object>) json2) : (WebAPI.Response.BattleCharacterStartPanel_item) null);
        this.panel_item = characterStartPanelItemList.ToArray();
        this.battle_uuid = (string) json[nameof (battle_uuid)];
        this.support_player_id = json[nameof (support_player_id)] != null ? (string) json[nameof (support_player_id)] : (string) null;
        List<WebAPI.Response.BattleCharacterStartUser_deck_enemy_item> userDeckEnemyItemList = new List<WebAPI.Response.BattleCharacterStartUser_deck_enemy_item>();
        foreach (object json3 in (List<object>) json[nameof (user_deck_enemy_item)])
          userDeckEnemyItemList.Add(json3 != null ? new WebAPI.Response.BattleCharacterStartUser_deck_enemy_item((Dictionary<string, object>) json3) : (WebAPI.Response.BattleCharacterStartUser_deck_enemy_item) null);
        this.user_deck_enemy_item = userDeckEnemyItemList.ToArray();
        this.battle_start = (bool) json[nameof (battle_start)];
        List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
        foreach (object json4 in (List<object>) json[nameof (helper_player_units)])
          playerUnitList2.Add(json4 != null ? new PlayerUnit((Dictionary<string, object>) json4) : (PlayerUnit) null);
        this.helper_player_units = playerUnitList2.ToArray();
        this.quest_type = (int) (long) json[nameof (quest_type)];
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
        foreach (object json5 in (List<object>) json[nameof (helpers)])
          playerHelperList.Add(json5 != null ? new PlayerHelper((Dictionary<string, object>) json5) : (PlayerHelper) null);
        this.helpers = playerHelperList.ToArray();
        List<PlayerItem> playerItemList1 = new List<PlayerItem>();
        foreach (object json6 in (List<object>) json[nameof (helper_player_gears)])
          playerItemList1.Add(json6 != null ? new PlayerItem((Dictionary<string, object>) json6) : (PlayerItem) null);
        this.helper_player_gears = playerItemList1.ToArray();
        List<PlayerItem> playerItemList2 = new List<PlayerItem>();
        foreach (object json7 in (List<object>) json[nameof (user_deck_gears)])
          playerItemList2.Add(json7 != null ? new PlayerItem((Dictionary<string, object>) json7) : (PlayerItem) null);
        this.user_deck_gears = playerItemList2.ToArray();
        this.quest_loop_count = (int) (long) json[nameof (quest_loop_count)];
        List<WebAPI.Response.BattleCharacterStartEnemy_item> characterStartEnemyItemList = new List<WebAPI.Response.BattleCharacterStartEnemy_item>();
        foreach (object json8 in (List<object>) json[nameof (enemy_item)])
          characterStartEnemyItemList.Add(json8 != null ? new WebAPI.Response.BattleCharacterStartEnemy_item((Dictionary<string, object>) json8) : (WebAPI.Response.BattleCharacterStartEnemy_item) null);
        this.enemy_item = characterStartEnemyItemList.ToArray();
        this.deck_number = (int) (long) json[nameof (deck_number)];
        this.panel = ((IEnumerable<object>) json[nameof (panel)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      }
    }

    [Serializable]
    public class BattleCharacterStartEnemy_item : KeyCompare
    {
      public int reward_quantity;
      public int id;
      public int reward_id;
      public int reward_type_id;

      public BattleCharacterStartEnemy_item()
      {
      }

      public BattleCharacterStartEnemy_item(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.id = (int) (long) json[nameof (id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      }
    }

    [Serializable]
    public class BattleCharacterStartUser_deck_enemy_item : KeyCompare
    {
      public int reward_quantity;
      public int id;
      public int reward_id;
      public int reward_type_id;

      public BattleCharacterStartUser_deck_enemy_item()
      {
      }

      public BattleCharacterStartUser_deck_enemy_item(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.id = (int) (long) json[nameof (id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      }
    }

    [Serializable]
    public class BattleCharacterStartPanel_item : KeyCompare
    {
      public int reward_quantity;
      public int id;
      public int reward_id;
      public int reward_type_id;

      public BattleCharacterStartPanel_item()
      {
      }

      public BattleCharacterStartPanel_item(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.id = (int) (long) json[nameof (id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      }
    }

    [Serializable]
    public class BattleExtraFinish : KeyCompare
    {
      public PlayerCharacterIntimate[] player_character_intimates;
      public PlayerHelper[] player_helpers;
      public PlayerUnit[] player_units;
      public PlayerItem[] player_items;
      public PlayerMissionHistory[] player_mission_histories;
      public Player player;
      public BattleEnd battle_finish;
      public PlayerPresent[] player_presents;
      public PlayerStoryQuestS[] player_story_quests;

      public BattleExtraFinish()
      {
      }

      public BattleExtraFinish(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerCharacterIntimate> characterIntimateList = new List<PlayerCharacterIntimate>();
        foreach (object json1 in (List<object>) json[nameof (player_character_intimates)])
          characterIntimateList.Add(json1 != null ? new PlayerCharacterIntimate((Dictionary<string, object>) json1) : (PlayerCharacterIntimate) null);
        this.player_character_intimates = characterIntimateList.ToArray();
        SMManager.UpdateList<PlayerCharacterIntimate>(this.player_character_intimates);
        List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
        foreach (object json2 in (List<object>) json[nameof (player_helpers)])
          playerHelperList.Add(json2 != null ? new PlayerHelper((Dictionary<string, object>) json2) : (PlayerHelper) null);
        this.player_helpers = playerHelperList.ToArray();
        SMManager.UpdateList<PlayerHelper>(this.player_helpers);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json4 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json4 != null ? new PlayerItem((Dictionary<string, object>) json4) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<PlayerMissionHistory> playerMissionHistoryList = new List<PlayerMissionHistory>();
        foreach (object json5 in (List<object>) json[nameof (player_mission_histories)])
          playerMissionHistoryList.Add(json5 != null ? new PlayerMissionHistory((Dictionary<string, object>) json5) : (PlayerMissionHistory) null);
        this.player_mission_histories = playerMissionHistoryList.ToArray();
        SMManager.UpdateList<PlayerMissionHistory>(this.player_mission_histories);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        this.battle_finish = json[nameof (battle_finish)] != null ? new BattleEnd((Dictionary<string, object>) json[nameof (battle_finish)]) : (BattleEnd) null;
        SMManager.Change<BattleEnd>(this.battle_finish);
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json6 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json6 != null ? new PlayerPresent((Dictionary<string, object>) json6) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<PlayerStoryQuestS> playerStoryQuestSList = new List<PlayerStoryQuestS>();
        foreach (object json7 in (List<object>) json[nameof (player_story_quests)])
          playerStoryQuestSList.Add(json7 != null ? new PlayerStoryQuestS((Dictionary<string, object>) json7) : (PlayerStoryQuestS) null);
        this.player_story_quests = playerStoryQuestSList.ToArray();
        SMManager.UpdateList<PlayerStoryQuestS>(this.player_story_quests);
        if (json.ContainsKey("player_presents:delete"))
          SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
        if (!json.ContainsKey("player_items:delete"))
          return;
        SMManager.DeleteList<PlayerItem>(((IEnumerable<object>) json["player_items:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class BattleExtraStart : KeyCompare
    {
      public PlayerUnit[] user_deck_units;
      public int[] enemy;
      public int deck_type_id;
      public int quest_s_id;
      public int[] user_deck_enemy;
      public WebAPI.Response.BattleExtraStartPanel_item[] panel_item;
      public string battle_uuid;
      public string support_player_id;
      public WebAPI.Response.BattleExtraStartUser_deck_enemy_item[] user_deck_enemy_item;
      public bool battle_start;
      public PlayerUnit[] helper_player_units;
      public int quest_type;
      public Player player;
      public PlayerHelper[] helpers;
      public PlayerItem[] helper_player_gears;
      public PlayerItem[] user_deck_gears;
      public int quest_loop_count;
      public WebAPI.Response.BattleExtraStartEnemy_item[] enemy_item;
      public int deck_number;
      public int[] panel;

      public BattleExtraStart()
      {
      }

      public BattleExtraStart(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
        foreach (object json1 in (List<object>) json[nameof (user_deck_units)])
          playerUnitList1.Add(json1 != null ? new PlayerUnit((Dictionary<string, object>) json1) : (PlayerUnit) null);
        this.user_deck_units = playerUnitList1.ToArray();
        this.enemy = ((IEnumerable<object>) json[nameof (enemy)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
        this.deck_type_id = (int) (long) json[nameof (deck_type_id)];
        this.quest_s_id = (int) (long) json[nameof (quest_s_id)];
        this.user_deck_enemy = ((IEnumerable<object>) json[nameof (user_deck_enemy)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
        List<WebAPI.Response.BattleExtraStartPanel_item> extraStartPanelItemList = new List<WebAPI.Response.BattleExtraStartPanel_item>();
        foreach (object json2 in (List<object>) json[nameof (panel_item)])
          extraStartPanelItemList.Add(json2 != null ? new WebAPI.Response.BattleExtraStartPanel_item((Dictionary<string, object>) json2) : (WebAPI.Response.BattleExtraStartPanel_item) null);
        this.panel_item = extraStartPanelItemList.ToArray();
        this.battle_uuid = (string) json[nameof (battle_uuid)];
        this.support_player_id = json[nameof (support_player_id)] != null ? (string) json[nameof (support_player_id)] : (string) null;
        List<WebAPI.Response.BattleExtraStartUser_deck_enemy_item> userDeckEnemyItemList = new List<WebAPI.Response.BattleExtraStartUser_deck_enemy_item>();
        foreach (object json3 in (List<object>) json[nameof (user_deck_enemy_item)])
          userDeckEnemyItemList.Add(json3 != null ? new WebAPI.Response.BattleExtraStartUser_deck_enemy_item((Dictionary<string, object>) json3) : (WebAPI.Response.BattleExtraStartUser_deck_enemy_item) null);
        this.user_deck_enemy_item = userDeckEnemyItemList.ToArray();
        this.battle_start = (bool) json[nameof (battle_start)];
        List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
        foreach (object json4 in (List<object>) json[nameof (helper_player_units)])
          playerUnitList2.Add(json4 != null ? new PlayerUnit((Dictionary<string, object>) json4) : (PlayerUnit) null);
        this.helper_player_units = playerUnitList2.ToArray();
        this.quest_type = (int) (long) json[nameof (quest_type)];
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
        foreach (object json5 in (List<object>) json[nameof (helpers)])
          playerHelperList.Add(json5 != null ? new PlayerHelper((Dictionary<string, object>) json5) : (PlayerHelper) null);
        this.helpers = playerHelperList.ToArray();
        List<PlayerItem> playerItemList1 = new List<PlayerItem>();
        foreach (object json6 in (List<object>) json[nameof (helper_player_gears)])
          playerItemList1.Add(json6 != null ? new PlayerItem((Dictionary<string, object>) json6) : (PlayerItem) null);
        this.helper_player_gears = playerItemList1.ToArray();
        List<PlayerItem> playerItemList2 = new List<PlayerItem>();
        foreach (object json7 in (List<object>) json[nameof (user_deck_gears)])
          playerItemList2.Add(json7 != null ? new PlayerItem((Dictionary<string, object>) json7) : (PlayerItem) null);
        this.user_deck_gears = playerItemList2.ToArray();
        this.quest_loop_count = (int) (long) json[nameof (quest_loop_count)];
        List<WebAPI.Response.BattleExtraStartEnemy_item> extraStartEnemyItemList = new List<WebAPI.Response.BattleExtraStartEnemy_item>();
        foreach (object json8 in (List<object>) json[nameof (enemy_item)])
          extraStartEnemyItemList.Add(json8 != null ? new WebAPI.Response.BattleExtraStartEnemy_item((Dictionary<string, object>) json8) : (WebAPI.Response.BattleExtraStartEnemy_item) null);
        this.enemy_item = extraStartEnemyItemList.ToArray();
        this.deck_number = (int) (long) json[nameof (deck_number)];
        this.panel = ((IEnumerable<object>) json[nameof (panel)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      }
    }

    [Serializable]
    public class BattleExtraStartEnemy_item : KeyCompare
    {
      public int reward_quantity;
      public int id;
      public int reward_id;
      public int reward_type_id;

      public BattleExtraStartEnemy_item()
      {
      }

      public BattleExtraStartEnemy_item(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.id = (int) (long) json[nameof (id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      }
    }

    [Serializable]
    public class BattleExtraStartUser_deck_enemy_item : KeyCompare
    {
      public int reward_quantity;
      public int id;
      public int reward_id;
      public int reward_type_id;

      public BattleExtraStartUser_deck_enemy_item()
      {
      }

      public BattleExtraStartUser_deck_enemy_item(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.id = (int) (long) json[nameof (id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      }
    }

    [Serializable]
    public class BattleExtraStartPanel_item : KeyCompare
    {
      public int reward_quantity;
      public int id;
      public int reward_id;
      public int reward_type_id;

      public BattleExtraStartPanel_item()
      {
      }

      public BattleExtraStartPanel_item(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.id = (int) (long) json[nameof (id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      }
    }

    [Serializable]
    public class BattleForceClose : KeyCompare
    {
      public BattleForceClose()
      {
      }

      public BattleForceClose(Dictionary<string, object> json) => this._hasKey = false;
    }

    [Serializable]
    public class BattleHarmonyFinish : KeyCompare
    {
      public PlayerCharacterIntimate[] player_character_intimates;
      public PlayerHelper[] player_helpers;
      public PlayerUnit[] player_units;
      public PlayerItem[] player_items;
      public PlayerMissionHistory[] player_mission_histories;
      public Player player;
      public BattleEnd battle_finish;
      public PlayerPresent[] player_presents;
      public PlayerStoryQuestS[] player_story_quests;

      public BattleHarmonyFinish()
      {
      }

      public BattleHarmonyFinish(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerCharacterIntimate> characterIntimateList = new List<PlayerCharacterIntimate>();
        foreach (object json1 in (List<object>) json[nameof (player_character_intimates)])
          characterIntimateList.Add(json1 != null ? new PlayerCharacterIntimate((Dictionary<string, object>) json1) : (PlayerCharacterIntimate) null);
        this.player_character_intimates = characterIntimateList.ToArray();
        SMManager.UpdateList<PlayerCharacterIntimate>(this.player_character_intimates);
        List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
        foreach (object json2 in (List<object>) json[nameof (player_helpers)])
          playerHelperList.Add(json2 != null ? new PlayerHelper((Dictionary<string, object>) json2) : (PlayerHelper) null);
        this.player_helpers = playerHelperList.ToArray();
        SMManager.UpdateList<PlayerHelper>(this.player_helpers);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json4 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json4 != null ? new PlayerItem((Dictionary<string, object>) json4) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<PlayerMissionHistory> playerMissionHistoryList = new List<PlayerMissionHistory>();
        foreach (object json5 in (List<object>) json[nameof (player_mission_histories)])
          playerMissionHistoryList.Add(json5 != null ? new PlayerMissionHistory((Dictionary<string, object>) json5) : (PlayerMissionHistory) null);
        this.player_mission_histories = playerMissionHistoryList.ToArray();
        SMManager.UpdateList<PlayerMissionHistory>(this.player_mission_histories);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        this.battle_finish = json[nameof (battle_finish)] != null ? new BattleEnd((Dictionary<string, object>) json[nameof (battle_finish)]) : (BattleEnd) null;
        SMManager.Change<BattleEnd>(this.battle_finish);
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json6 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json6 != null ? new PlayerPresent((Dictionary<string, object>) json6) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<PlayerStoryQuestS> playerStoryQuestSList = new List<PlayerStoryQuestS>();
        foreach (object json7 in (List<object>) json[nameof (player_story_quests)])
          playerStoryQuestSList.Add(json7 != null ? new PlayerStoryQuestS((Dictionary<string, object>) json7) : (PlayerStoryQuestS) null);
        this.player_story_quests = playerStoryQuestSList.ToArray();
        SMManager.UpdateList<PlayerStoryQuestS>(this.player_story_quests);
        if (json.ContainsKey("player_presents:delete"))
          SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
        if (!json.ContainsKey("player_items:delete"))
          return;
        SMManager.DeleteList<PlayerItem>(((IEnumerable<object>) json["player_items:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class BattleHarmonyStart : KeyCompare
    {
      public PlayerUnit[] user_deck_units;
      public int[] enemy;
      public int deck_type_id;
      public int quest_s_id;
      public int[] user_deck_enemy;
      public WebAPI.Response.BattleHarmonyStartPanel_item[] panel_item;
      public string battle_uuid;
      public string support_player_id;
      public WebAPI.Response.BattleHarmonyStartUser_deck_enemy_item[] user_deck_enemy_item;
      public bool battle_start;
      public PlayerUnit[] helper_player_units;
      public int quest_type;
      public Player player;
      public PlayerHelper[] helpers;
      public PlayerItem[] helper_player_gears;
      public PlayerItem[] user_deck_gears;
      public int quest_loop_count;
      public WebAPI.Response.BattleHarmonyStartEnemy_item[] enemy_item;
      public int deck_number;
      public int[] panel;

      public BattleHarmonyStart()
      {
      }

      public BattleHarmonyStart(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
        foreach (object json1 in (List<object>) json[nameof (user_deck_units)])
          playerUnitList1.Add(json1 != null ? new PlayerUnit((Dictionary<string, object>) json1) : (PlayerUnit) null);
        this.user_deck_units = playerUnitList1.ToArray();
        this.enemy = ((IEnumerable<object>) json[nameof (enemy)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
        this.deck_type_id = (int) (long) json[nameof (deck_type_id)];
        this.quest_s_id = (int) (long) json[nameof (quest_s_id)];
        this.user_deck_enemy = ((IEnumerable<object>) json[nameof (user_deck_enemy)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
        List<WebAPI.Response.BattleHarmonyStartPanel_item> harmonyStartPanelItemList = new List<WebAPI.Response.BattleHarmonyStartPanel_item>();
        foreach (object json2 in (List<object>) json[nameof (panel_item)])
          harmonyStartPanelItemList.Add(json2 != null ? new WebAPI.Response.BattleHarmonyStartPanel_item((Dictionary<string, object>) json2) : (WebAPI.Response.BattleHarmonyStartPanel_item) null);
        this.panel_item = harmonyStartPanelItemList.ToArray();
        this.battle_uuid = (string) json[nameof (battle_uuid)];
        this.support_player_id = json[nameof (support_player_id)] != null ? (string) json[nameof (support_player_id)] : (string) null;
        List<WebAPI.Response.BattleHarmonyStartUser_deck_enemy_item> userDeckEnemyItemList = new List<WebAPI.Response.BattleHarmonyStartUser_deck_enemy_item>();
        foreach (object json3 in (List<object>) json[nameof (user_deck_enemy_item)])
          userDeckEnemyItemList.Add(json3 != null ? new WebAPI.Response.BattleHarmonyStartUser_deck_enemy_item((Dictionary<string, object>) json3) : (WebAPI.Response.BattleHarmonyStartUser_deck_enemy_item) null);
        this.user_deck_enemy_item = userDeckEnemyItemList.ToArray();
        this.battle_start = (bool) json[nameof (battle_start)];
        List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
        foreach (object json4 in (List<object>) json[nameof (helper_player_units)])
          playerUnitList2.Add(json4 != null ? new PlayerUnit((Dictionary<string, object>) json4) : (PlayerUnit) null);
        this.helper_player_units = playerUnitList2.ToArray();
        this.quest_type = (int) (long) json[nameof (quest_type)];
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
        foreach (object json5 in (List<object>) json[nameof (helpers)])
          playerHelperList.Add(json5 != null ? new PlayerHelper((Dictionary<string, object>) json5) : (PlayerHelper) null);
        this.helpers = playerHelperList.ToArray();
        List<PlayerItem> playerItemList1 = new List<PlayerItem>();
        foreach (object json6 in (List<object>) json[nameof (helper_player_gears)])
          playerItemList1.Add(json6 != null ? new PlayerItem((Dictionary<string, object>) json6) : (PlayerItem) null);
        this.helper_player_gears = playerItemList1.ToArray();
        List<PlayerItem> playerItemList2 = new List<PlayerItem>();
        foreach (object json7 in (List<object>) json[nameof (user_deck_gears)])
          playerItemList2.Add(json7 != null ? new PlayerItem((Dictionary<string, object>) json7) : (PlayerItem) null);
        this.user_deck_gears = playerItemList2.ToArray();
        this.quest_loop_count = (int) (long) json[nameof (quest_loop_count)];
        List<WebAPI.Response.BattleHarmonyStartEnemy_item> harmonyStartEnemyItemList = new List<WebAPI.Response.BattleHarmonyStartEnemy_item>();
        foreach (object json8 in (List<object>) json[nameof (enemy_item)])
          harmonyStartEnemyItemList.Add(json8 != null ? new WebAPI.Response.BattleHarmonyStartEnemy_item((Dictionary<string, object>) json8) : (WebAPI.Response.BattleHarmonyStartEnemy_item) null);
        this.enemy_item = harmonyStartEnemyItemList.ToArray();
        this.deck_number = (int) (long) json[nameof (deck_number)];
        this.panel = ((IEnumerable<object>) json[nameof (panel)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      }
    }

    [Serializable]
    public class BattleHarmonyStartEnemy_item : KeyCompare
    {
      public int reward_quantity;
      public int id;
      public int reward_id;
      public int reward_type_id;

      public BattleHarmonyStartEnemy_item()
      {
      }

      public BattleHarmonyStartEnemy_item(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.id = (int) (long) json[nameof (id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      }
    }

    [Serializable]
    public class BattleHarmonyStartUser_deck_enemy_item : KeyCompare
    {
      public int reward_quantity;
      public int id;
      public int reward_id;
      public int reward_type_id;

      public BattleHarmonyStartUser_deck_enemy_item()
      {
      }

      public BattleHarmonyStartUser_deck_enemy_item(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.id = (int) (long) json[nameof (id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      }
    }

    [Serializable]
    public class BattleHarmonyStartPanel_item : KeyCompare
    {
      public int reward_quantity;
      public int id;
      public int reward_id;
      public int reward_type_id;

      public BattleHarmonyStartPanel_item()
      {
      }

      public BattleHarmonyStartPanel_item(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.id = (int) (long) json[nameof (id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      }
    }

    [Serializable]
    public class BattleResume : KeyCompare
    {
      public PlayerUnit[] user_deck_units;
      public int[] enemy;
      public int deck_type_id;
      public int quest_s_id;
      public int[] user_deck_enemy;
      public WebAPI.Response.BattleResumePanel_item[] panel_item;
      public string battle_uuid;
      public string support_player_id;
      public WebAPI.Response.BattleResumeUser_deck_enemy_item[] user_deck_enemy_item;
      public bool battle_start;
      public PlayerUnit[] helper_player_units;
      public int quest_type;
      public Player player;
      public PlayerHelper[] helpers;
      public PlayerItem[] helper_player_gears;
      public PlayerItem[] user_deck_gears;
      public int quest_loop_count;
      public WebAPI.Response.BattleResumeEnemy_item[] enemy_item;
      public int deck_number;
      public int[] panel;

      public BattleResume()
      {
      }

      public BattleResume(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
        foreach (object json1 in (List<object>) json[nameof (user_deck_units)])
          playerUnitList1.Add(json1 != null ? new PlayerUnit((Dictionary<string, object>) json1) : (PlayerUnit) null);
        this.user_deck_units = playerUnitList1.ToArray();
        this.enemy = ((IEnumerable<object>) json[nameof (enemy)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
        this.deck_type_id = (int) (long) json[nameof (deck_type_id)];
        this.quest_s_id = (int) (long) json[nameof (quest_s_id)];
        this.user_deck_enemy = ((IEnumerable<object>) json[nameof (user_deck_enemy)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
        List<WebAPI.Response.BattleResumePanel_item> battleResumePanelItemList = new List<WebAPI.Response.BattleResumePanel_item>();
        foreach (object json2 in (List<object>) json[nameof (panel_item)])
          battleResumePanelItemList.Add(json2 != null ? new WebAPI.Response.BattleResumePanel_item((Dictionary<string, object>) json2) : (WebAPI.Response.BattleResumePanel_item) null);
        this.panel_item = battleResumePanelItemList.ToArray();
        this.battle_uuid = (string) json[nameof (battle_uuid)];
        this.support_player_id = json[nameof (support_player_id)] != null ? (string) json[nameof (support_player_id)] : (string) null;
        List<WebAPI.Response.BattleResumeUser_deck_enemy_item> userDeckEnemyItemList = new List<WebAPI.Response.BattleResumeUser_deck_enemy_item>();
        foreach (object json3 in (List<object>) json[nameof (user_deck_enemy_item)])
          userDeckEnemyItemList.Add(json3 != null ? new WebAPI.Response.BattleResumeUser_deck_enemy_item((Dictionary<string, object>) json3) : (WebAPI.Response.BattleResumeUser_deck_enemy_item) null);
        this.user_deck_enemy_item = userDeckEnemyItemList.ToArray();
        this.battle_start = (bool) json[nameof (battle_start)];
        List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
        foreach (object json4 in (List<object>) json[nameof (helper_player_units)])
          playerUnitList2.Add(json4 != null ? new PlayerUnit((Dictionary<string, object>) json4) : (PlayerUnit) null);
        this.helper_player_units = playerUnitList2.ToArray();
        this.quest_type = (int) (long) json[nameof (quest_type)];
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
        foreach (object json5 in (List<object>) json[nameof (helpers)])
          playerHelperList.Add(json5 != null ? new PlayerHelper((Dictionary<string, object>) json5) : (PlayerHelper) null);
        this.helpers = playerHelperList.ToArray();
        List<PlayerItem> playerItemList1 = new List<PlayerItem>();
        foreach (object json6 in (List<object>) json[nameof (helper_player_gears)])
          playerItemList1.Add(json6 != null ? new PlayerItem((Dictionary<string, object>) json6) : (PlayerItem) null);
        this.helper_player_gears = playerItemList1.ToArray();
        List<PlayerItem> playerItemList2 = new List<PlayerItem>();
        foreach (object json7 in (List<object>) json[nameof (user_deck_gears)])
          playerItemList2.Add(json7 != null ? new PlayerItem((Dictionary<string, object>) json7) : (PlayerItem) null);
        this.user_deck_gears = playerItemList2.ToArray();
        this.quest_loop_count = (int) (long) json[nameof (quest_loop_count)];
        List<WebAPI.Response.BattleResumeEnemy_item> battleResumeEnemyItemList = new List<WebAPI.Response.BattleResumeEnemy_item>();
        foreach (object json8 in (List<object>) json[nameof (enemy_item)])
          battleResumeEnemyItemList.Add(json8 != null ? new WebAPI.Response.BattleResumeEnemy_item((Dictionary<string, object>) json8) : (WebAPI.Response.BattleResumeEnemy_item) null);
        this.enemy_item = battleResumeEnemyItemList.ToArray();
        this.deck_number = (int) (long) json[nameof (deck_number)];
        this.panel = ((IEnumerable<object>) json[nameof (panel)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      }
    }

    [Serializable]
    public class BattleResumeEnemy_item : KeyCompare
    {
      public int reward_quantity;
      public int id;
      public int reward_id;
      public int reward_type_id;

      public BattleResumeEnemy_item()
      {
      }

      public BattleResumeEnemy_item(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.id = (int) (long) json[nameof (id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      }
    }

    [Serializable]
    public class BattleResumeUser_deck_enemy_item : KeyCompare
    {
      public int reward_quantity;
      public int id;
      public int reward_id;
      public int reward_type_id;

      public BattleResumeUser_deck_enemy_item()
      {
      }

      public BattleResumeUser_deck_enemy_item(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.id = (int) (long) json[nameof (id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      }
    }

    [Serializable]
    public class BattleResumePanel_item : KeyCompare
    {
      public int reward_quantity;
      public int id;
      public int reward_id;
      public int reward_type_id;

      public BattleResumePanel_item()
      {
      }

      public BattleResumePanel_item(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.id = (int) (long) json[nameof (id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      }
    }

    [Serializable]
    public class BattleRetire : KeyCompare
    {
      public BattleRetire()
      {
      }

      public BattleRetire(Dictionary<string, object> json) => this._hasKey = false;
    }

    [Serializable]
    public class BattleStoryFinish : KeyCompare
    {
      public PlayerCharacterIntimate[] player_character_intimates;
      public PlayerHelper[] player_helpers;
      public PlayerUnit[] player_units;
      public PlayerItem[] player_items;
      public PlayerMissionHistory[] player_mission_histories;
      public Player player;
      public BattleEnd battle_finish;
      public PlayerPresent[] player_presents;
      public PlayerStoryQuestS[] player_story_quests;

      public BattleStoryFinish()
      {
      }

      public BattleStoryFinish(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerCharacterIntimate> characterIntimateList = new List<PlayerCharacterIntimate>();
        foreach (object json1 in (List<object>) json[nameof (player_character_intimates)])
          characterIntimateList.Add(json1 != null ? new PlayerCharacterIntimate((Dictionary<string, object>) json1) : (PlayerCharacterIntimate) null);
        this.player_character_intimates = characterIntimateList.ToArray();
        SMManager.UpdateList<PlayerCharacterIntimate>(this.player_character_intimates);
        List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
        foreach (object json2 in (List<object>) json[nameof (player_helpers)])
          playerHelperList.Add(json2 != null ? new PlayerHelper((Dictionary<string, object>) json2) : (PlayerHelper) null);
        this.player_helpers = playerHelperList.ToArray();
        SMManager.UpdateList<PlayerHelper>(this.player_helpers);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json4 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json4 != null ? new PlayerItem((Dictionary<string, object>) json4) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<PlayerMissionHistory> playerMissionHistoryList = new List<PlayerMissionHistory>();
        foreach (object json5 in (List<object>) json[nameof (player_mission_histories)])
          playerMissionHistoryList.Add(json5 != null ? new PlayerMissionHistory((Dictionary<string, object>) json5) : (PlayerMissionHistory) null);
        this.player_mission_histories = playerMissionHistoryList.ToArray();
        SMManager.UpdateList<PlayerMissionHistory>(this.player_mission_histories);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        this.battle_finish = json[nameof (battle_finish)] != null ? new BattleEnd((Dictionary<string, object>) json[nameof (battle_finish)]) : (BattleEnd) null;
        SMManager.Change<BattleEnd>(this.battle_finish);
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json6 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json6 != null ? new PlayerPresent((Dictionary<string, object>) json6) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<PlayerStoryQuestS> playerStoryQuestSList = new List<PlayerStoryQuestS>();
        foreach (object json7 in (List<object>) json[nameof (player_story_quests)])
          playerStoryQuestSList.Add(json7 != null ? new PlayerStoryQuestS((Dictionary<string, object>) json7) : (PlayerStoryQuestS) null);
        this.player_story_quests = playerStoryQuestSList.ToArray();
        SMManager.UpdateList<PlayerStoryQuestS>(this.player_story_quests);
        if (json.ContainsKey("player_presents:delete"))
          SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
        if (!json.ContainsKey("player_items:delete"))
          return;
        SMManager.DeleteList<PlayerItem>(((IEnumerable<object>) json["player_items:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class BattleStoryStart : KeyCompare
    {
      public PlayerUnit[] user_deck_units;
      public int[] enemy;
      public int deck_type_id;
      public int quest_s_id;
      public int[] user_deck_enemy;
      public WebAPI.Response.BattleStoryStartPanel_item[] panel_item;
      public string battle_uuid;
      public string support_player_id;
      public WebAPI.Response.BattleStoryStartUser_deck_enemy_item[] user_deck_enemy_item;
      public bool battle_start;
      public PlayerUnit[] helper_player_units;
      public int quest_type;
      public Player player;
      public PlayerHelper[] helpers;
      public PlayerItem[] helper_player_gears;
      public PlayerItem[] user_deck_gears;
      public int quest_loop_count;
      public WebAPI.Response.BattleStoryStartEnemy_item[] enemy_item;
      public int deck_number;
      public int[] panel;

      public BattleStoryStart()
      {
      }

      public BattleStoryStart(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
        foreach (object json1 in (List<object>) json[nameof (user_deck_units)])
          playerUnitList1.Add(json1 != null ? new PlayerUnit((Dictionary<string, object>) json1) : (PlayerUnit) null);
        this.user_deck_units = playerUnitList1.ToArray();
        this.enemy = ((IEnumerable<object>) json[nameof (enemy)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
        this.deck_type_id = (int) (long) json[nameof (deck_type_id)];
        this.quest_s_id = (int) (long) json[nameof (quest_s_id)];
        this.user_deck_enemy = ((IEnumerable<object>) json[nameof (user_deck_enemy)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
        List<WebAPI.Response.BattleStoryStartPanel_item> storyStartPanelItemList = new List<WebAPI.Response.BattleStoryStartPanel_item>();
        foreach (object json2 in (List<object>) json[nameof (panel_item)])
          storyStartPanelItemList.Add(json2 != null ? new WebAPI.Response.BattleStoryStartPanel_item((Dictionary<string, object>) json2) : (WebAPI.Response.BattleStoryStartPanel_item) null);
        this.panel_item = storyStartPanelItemList.ToArray();
        this.battle_uuid = (string) json[nameof (battle_uuid)];
        this.support_player_id = json[nameof (support_player_id)] != null ? (string) json[nameof (support_player_id)] : (string) null;
        List<WebAPI.Response.BattleStoryStartUser_deck_enemy_item> userDeckEnemyItemList = new List<WebAPI.Response.BattleStoryStartUser_deck_enemy_item>();
        foreach (object json3 in (List<object>) json[nameof (user_deck_enemy_item)])
          userDeckEnemyItemList.Add(json3 != null ? new WebAPI.Response.BattleStoryStartUser_deck_enemy_item((Dictionary<string, object>) json3) : (WebAPI.Response.BattleStoryStartUser_deck_enemy_item) null);
        this.user_deck_enemy_item = userDeckEnemyItemList.ToArray();
        this.battle_start = (bool) json[nameof (battle_start)];
        List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
        foreach (object json4 in (List<object>) json[nameof (helper_player_units)])
          playerUnitList2.Add(json4 != null ? new PlayerUnit((Dictionary<string, object>) json4) : (PlayerUnit) null);
        this.helper_player_units = playerUnitList2.ToArray();
        this.quest_type = (int) (long) json[nameof (quest_type)];
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
        foreach (object json5 in (List<object>) json[nameof (helpers)])
          playerHelperList.Add(json5 != null ? new PlayerHelper((Dictionary<string, object>) json5) : (PlayerHelper) null);
        this.helpers = playerHelperList.ToArray();
        List<PlayerItem> playerItemList1 = new List<PlayerItem>();
        foreach (object json6 in (List<object>) json[nameof (helper_player_gears)])
          playerItemList1.Add(json6 != null ? new PlayerItem((Dictionary<string, object>) json6) : (PlayerItem) null);
        this.helper_player_gears = playerItemList1.ToArray();
        List<PlayerItem> playerItemList2 = new List<PlayerItem>();
        foreach (object json7 in (List<object>) json[nameof (user_deck_gears)])
          playerItemList2.Add(json7 != null ? new PlayerItem((Dictionary<string, object>) json7) : (PlayerItem) null);
        this.user_deck_gears = playerItemList2.ToArray();
        this.quest_loop_count = (int) (long) json[nameof (quest_loop_count)];
        List<WebAPI.Response.BattleStoryStartEnemy_item> storyStartEnemyItemList = new List<WebAPI.Response.BattleStoryStartEnemy_item>();
        foreach (object json8 in (List<object>) json[nameof (enemy_item)])
          storyStartEnemyItemList.Add(json8 != null ? new WebAPI.Response.BattleStoryStartEnemy_item((Dictionary<string, object>) json8) : (WebAPI.Response.BattleStoryStartEnemy_item) null);
        this.enemy_item = storyStartEnemyItemList.ToArray();
        this.deck_number = (int) (long) json[nameof (deck_number)];
        this.panel = ((IEnumerable<object>) json[nameof (panel)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      }
    }

    [Serializable]
    public class BattleStoryStartEnemy_item : KeyCompare
    {
      public int reward_quantity;
      public int id;
      public int reward_id;
      public int reward_type_id;

      public BattleStoryStartEnemy_item()
      {
      }

      public BattleStoryStartEnemy_item(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.id = (int) (long) json[nameof (id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      }
    }

    [Serializable]
    public class BattleStoryStartUser_deck_enemy_item : KeyCompare
    {
      public int reward_quantity;
      public int id;
      public int reward_id;
      public int reward_type_id;

      public BattleStoryStartUser_deck_enemy_item()
      {
      }

      public BattleStoryStartUser_deck_enemy_item(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.id = (int) (long) json[nameof (id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      }
    }

    [Serializable]
    public class BattleStoryStartPanel_item : KeyCompare
    {
      public int reward_quantity;
      public int id;
      public int reward_id;
      public int reward_type_id;

      public BattleStoryStartPanel_item()
      {
      }

      public BattleStoryStartPanel_item(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.id = (int) (long) json[nameof (id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      }
    }

    [Serializable]
    public class Bingo2Index : KeyCompare
    {
      public Player player;
      public PlayerBingo2[] player_bingo2;

      public Bingo2Index()
      {
      }

      public Bingo2Index(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerBingo2> playerBingo2List = new List<PlayerBingo2>();
        foreach (object json1 in (List<object>) json[nameof (player_bingo2)])
          playerBingo2List.Add(json1 != null ? new PlayerBingo2((Dictionary<string, object>) json1) : (PlayerBingo2) null);
        this.player_bingo2 = playerBingo2List.ToArray();
        SMManager.UpdateList<PlayerBingo2>(this.player_bingo2);
      }
    }

    [Serializable]
    public class Bingo2ReceiveReward : KeyCompare
    {
      public bool is_received_complete_reward;
      public PlayerPresent[] player_presents;
      public PlayerBingo2[] player_bingo2;
      public Player player;

      public Bingo2ReceiveReward()
      {
      }

      public Bingo2ReceiveReward(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.is_received_complete_reward = (bool) json[nameof (is_received_complete_reward)];
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json1 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json1 != null ? new PlayerPresent((Dictionary<string, object>) json1) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<PlayerBingo2> playerBingo2List = new List<PlayerBingo2>();
        foreach (object json2 in (List<object>) json[nameof (player_bingo2)])
          playerBingo2List.Add(json2 != null ? new PlayerBingo2((Dictionary<string, object>) json2) : (PlayerBingo2) null);
        this.player_bingo2 = playerBingo2List.ToArray();
        SMManager.UpdateList<PlayerBingo2>(this.player_bingo2);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class Bingo2SetComplete : KeyCompare
    {
      public PlayerBingo2[] player_bingo2;

      public Bingo2SetComplete()
      {
      }

      public Bingo2SetComplete(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerBingo2> playerBingo2List = new List<PlayerBingo2>();
        foreach (object json1 in (List<object>) json[nameof (player_bingo2)])
          playerBingo2List.Add(json1 != null ? new PlayerBingo2((Dictionary<string, object>) json1) : (PlayerBingo2) null);
        this.player_bingo2 = playerBingo2List.ToArray();
        SMManager.UpdateList<PlayerBingo2>(this.player_bingo2);
      }
    }

    [Serializable]
    public class BingoIndex : KeyCompare
    {
      public Player player;
      public PlayerBingo[] player_bingo;

      public BingoIndex()
      {
      }

      public BingoIndex(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerBingo> playerBingoList = new List<PlayerBingo>();
        foreach (object json1 in (List<object>) json[nameof (player_bingo)])
          playerBingoList.Add(json1 != null ? new PlayerBingo((Dictionary<string, object>) json1) : (PlayerBingo) null);
        this.player_bingo = playerBingoList.ToArray();
        SMManager.UpdateList<PlayerBingo>(this.player_bingo);
      }
    }

    [Serializable]
    public class BingoOpenCheck : KeyCompare
    {
      public PlayerBingo[] player_bingo;

      public BingoOpenCheck()
      {
      }

      public BingoOpenCheck(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerBingo> playerBingoList = new List<PlayerBingo>();
        foreach (object json1 in (List<object>) json[nameof (player_bingo)])
          playerBingoList.Add(json1 != null ? new PlayerBingo((Dictionary<string, object>) json1) : (PlayerBingo) null);
        this.player_bingo = playerBingoList.ToArray();
        SMManager.UpdateList<PlayerBingo>(this.player_bingo);
      }
    }

    [Serializable]
    public class BingoReceiveReward : KeyCompare
    {
      public bool is_complete_receive;
      public bool is_receive;
      public Player player;
      public PlayerBingo[] player_bingo;
      public PlayerPresent[] player_presents;

      public BingoReceiveReward()
      {
      }

      public BingoReceiveReward(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.is_complete_receive = (bool) json[nameof (is_complete_receive)];
        this.is_receive = (bool) json[nameof (is_receive)];
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerBingo> playerBingoList = new List<PlayerBingo>();
        foreach (object json1 in (List<object>) json[nameof (player_bingo)])
          playerBingoList.Add(json1 != null ? new PlayerBingo((Dictionary<string, object>) json1) : (PlayerBingo) null);
        this.player_bingo = playerBingoList.ToArray();
        SMManager.UpdateList<PlayerBingo>(this.player_bingo);
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json2 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json2 != null ? new PlayerPresent((Dictionary<string, object>) json2) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class BingoReview : KeyCompare
    {
      public Player player;
      public PlayerBingo[] player_bingo;

      public BingoReview()
      {
      }

      public BingoReview(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerBingo> playerBingoList = new List<PlayerBingo>();
        foreach (object json1 in (List<object>) json[nameof (player_bingo)])
          playerBingoList.Add(json1 != null ? new PlayerBingo((Dictionary<string, object>) json1) : (PlayerBingo) null);
        this.player_bingo = playerBingoList.ToArray();
        SMManager.UpdateList<PlayerBingo>(this.player_bingo);
      }
    }

    [Serializable]
    public class BingoSelectComplete : KeyCompare
    {
      public PlayerBingo[] player_bingo;

      public BingoSelectComplete()
      {
      }

      public BingoSelectComplete(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerBingo> playerBingoList = new List<PlayerBingo>();
        foreach (object json1 in (List<object>) json[nameof (player_bingo)])
          playerBingoList.Add(json1 != null ? new PlayerBingo((Dictionary<string, object>) json1) : (PlayerBingo) null);
        this.player_bingo = playerBingoList.ToArray();
        SMManager.UpdateList<PlayerBingo>(this.player_bingo);
      }
    }

    [Serializable]
    public class CoinbonusHistory : KeyCompare
    {
      public Player player;
      public CoinBonus[] coin_bonuses;
      public CoinBonusReward[] coin_bonus_rewards;
      public PlayerCoinBonusHistory[] player_coin_bonus_history;

      public CoinbonusHistory()
      {
      }

      public CoinbonusHistory(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<CoinBonus> coinBonusList = new List<CoinBonus>();
        foreach (object json1 in (List<object>) json[nameof (coin_bonuses)])
          coinBonusList.Add(json1 != null ? new CoinBonus((Dictionary<string, object>) json1) : (CoinBonus) null);
        this.coin_bonuses = coinBonusList.ToArray();
        SMManager.UpdateList<CoinBonus>(this.coin_bonuses);
        List<CoinBonusReward> coinBonusRewardList = new List<CoinBonusReward>();
        foreach (object json2 in (List<object>) json[nameof (coin_bonus_rewards)])
          coinBonusRewardList.Add(json2 != null ? new CoinBonusReward((Dictionary<string, object>) json2) : (CoinBonusReward) null);
        this.coin_bonus_rewards = coinBonusRewardList.ToArray();
        SMManager.UpdateList<CoinBonusReward>(this.coin_bonus_rewards);
        List<PlayerCoinBonusHistory> coinBonusHistoryList = new List<PlayerCoinBonusHistory>();
        foreach (object json3 in (List<object>) json[nameof (player_coin_bonus_history)])
          coinBonusHistoryList.Add(json3 != null ? new PlayerCoinBonusHistory((Dictionary<string, object>) json3) : (PlayerCoinBonusHistory) null);
        this.player_coin_bonus_history = coinBonusHistoryList.ToArray();
        SMManager.UpdateList<PlayerCoinBonusHistory>(this.player_coin_bonus_history);
      }
    }

    [Serializable]
    public class CoinbonusPresent : KeyCompare
    {
      public PlayerCoinBonusHistory[] player_coin_bonus_history;
      public CoinBonus[] coin_bonuses;
      public Player player;
      public CoinBonusReward[] coin_bonus_rewards;
      public PlayerPresent[] player_presents;

      public CoinbonusPresent()
      {
      }

      public CoinbonusPresent(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerCoinBonusHistory> coinBonusHistoryList = new List<PlayerCoinBonusHistory>();
        foreach (object json1 in (List<object>) json[nameof (player_coin_bonus_history)])
          coinBonusHistoryList.Add(json1 != null ? new PlayerCoinBonusHistory((Dictionary<string, object>) json1) : (PlayerCoinBonusHistory) null);
        this.player_coin_bonus_history = coinBonusHistoryList.ToArray();
        SMManager.UpdateList<PlayerCoinBonusHistory>(this.player_coin_bonus_history);
        List<CoinBonus> coinBonusList = new List<CoinBonus>();
        foreach (object json2 in (List<object>) json[nameof (coin_bonuses)])
          coinBonusList.Add(json2 != null ? new CoinBonus((Dictionary<string, object>) json2) : (CoinBonus) null);
        this.coin_bonuses = coinBonusList.ToArray();
        SMManager.UpdateList<CoinBonus>(this.coin_bonuses);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<CoinBonusReward> coinBonusRewardList = new List<CoinBonusReward>();
        foreach (object json3 in (List<object>) json[nameof (coin_bonus_rewards)])
          coinBonusRewardList.Add(json3 != null ? new CoinBonusReward((Dictionary<string, object>) json3) : (CoinBonusReward) null);
        this.coin_bonus_rewards = coinBonusRewardList.ToArray();
        SMManager.UpdateList<CoinBonusReward>(this.coin_bonus_rewards);
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json4 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json4 != null ? new PlayerPresent((Dictionary<string, object>) json4) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class ColosseumBoot : KeyCompare
    {
      public bool is_battle;
      public int next_battle_type;
      public Bonus[] bonus;
      public bool is_tutorial;
      public Campaign[] campaigns;
      public Player player;
      public ColosseumRecord colosseum_record;
      public Gladiator[] gladiators;

      public ColosseumBoot()
      {
      }

      public ColosseumBoot(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.is_battle = (bool) json[nameof (is_battle)];
        this.next_battle_type = (int) (long) json[nameof (next_battle_type)];
        List<Bonus> bonusList = new List<Bonus>();
        foreach (object json1 in (List<object>) json[nameof (bonus)])
          bonusList.Add(json1 != null ? new Bonus((Dictionary<string, object>) json1) : (Bonus) null);
        this.bonus = bonusList.ToArray();
        this.is_tutorial = (bool) json[nameof (is_tutorial)];
        List<Campaign> campaignList = new List<Campaign>();
        foreach (object json2 in (List<object>) json[nameof (campaigns)])
          campaignList.Add(json2 != null ? new Campaign((Dictionary<string, object>) json2) : (Campaign) null);
        this.campaigns = campaignList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        this.colosseum_record = json[nameof (colosseum_record)] != null ? new ColosseumRecord((Dictionary<string, object>) json[nameof (colosseum_record)]) : (ColosseumRecord) null;
        List<Gladiator> gladiatorList = new List<Gladiator>();
        foreach (object json3 in (List<object>) json[nameof (gladiators)])
          gladiatorList.Add(json3 != null ? new Gladiator((Dictionary<string, object>) json3) : (Gladiator) null);
        this.gladiators = gladiatorList.ToArray();
      }
    }

    [Serializable]
    public class ColosseumFinish : KeyCompare
    {
      public WebAPI.Response.ColosseumFinishBonus_rewards[] bonus_rewards;
      public WebAPI.Response.ColosseumFinishCampaign_next_rewards[] campaign_next_rewards;
      public bool is_battle;
      public int next_battle_type;
      public Bonus[] bonus;
      public Gladiator[] gladiators;
      public PlayerUnit[] player_units;
      public PlayerCharacterIntimate[] player_character_intimates;
      public ColosseumRecord colosseum_record;
      public PlayerPresent[] player_presents;
      public Campaign[] campaigns;
      public Player player;
      public bool target_player_is_friend;
      public bool is_tutorial;
      public int battle_type;
      public RankUpInfo colosseum_result_rank_up;
      public WebAPI.Response.ColosseumFinishCampaign_rewards[] campaign_rewards;
      public ColosseumEnd colosseum_finish;
      public PlayerItem[] player_items;

      public ColosseumFinish()
      {
      }

      public ColosseumFinish(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<WebAPI.Response.ColosseumFinishBonus_rewards> finishBonusRewardsList = new List<WebAPI.Response.ColosseumFinishBonus_rewards>();
        foreach (object json1 in (List<object>) json[nameof (bonus_rewards)])
          finishBonusRewardsList.Add(json1 != null ? new WebAPI.Response.ColosseumFinishBonus_rewards((Dictionary<string, object>) json1) : (WebAPI.Response.ColosseumFinishBonus_rewards) null);
        this.bonus_rewards = finishBonusRewardsList.ToArray();
        List<WebAPI.Response.ColosseumFinishCampaign_next_rewards> campaignNextRewardsList = new List<WebAPI.Response.ColosseumFinishCampaign_next_rewards>();
        foreach (object json2 in (List<object>) json[nameof (campaign_next_rewards)])
          campaignNextRewardsList.Add(json2 != null ? new WebAPI.Response.ColosseumFinishCampaign_next_rewards((Dictionary<string, object>) json2) : (WebAPI.Response.ColosseumFinishCampaign_next_rewards) null);
        this.campaign_next_rewards = campaignNextRewardsList.ToArray();
        this.is_battle = (bool) json[nameof (is_battle)];
        this.next_battle_type = (int) (long) json[nameof (next_battle_type)];
        List<Bonus> bonusList = new List<Bonus>();
        foreach (object json3 in (List<object>) json[nameof (bonus)])
          bonusList.Add(json3 != null ? new Bonus((Dictionary<string, object>) json3) : (Bonus) null);
        this.bonus = bonusList.ToArray();
        List<Gladiator> gladiatorList = new List<Gladiator>();
        foreach (object json4 in (List<object>) json[nameof (gladiators)])
          gladiatorList.Add(json4 != null ? new Gladiator((Dictionary<string, object>) json4) : (Gladiator) null);
        this.gladiators = gladiatorList.ToArray();
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json5 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json5 != null ? new PlayerUnit((Dictionary<string, object>) json5) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<PlayerCharacterIntimate> characterIntimateList = new List<PlayerCharacterIntimate>();
        foreach (object json6 in (List<object>) json[nameof (player_character_intimates)])
          characterIntimateList.Add(json6 != null ? new PlayerCharacterIntimate((Dictionary<string, object>) json6) : (PlayerCharacterIntimate) null);
        this.player_character_intimates = characterIntimateList.ToArray();
        SMManager.UpdateList<PlayerCharacterIntimate>(this.player_character_intimates);
        this.colosseum_record = json[nameof (colosseum_record)] != null ? new ColosseumRecord((Dictionary<string, object>) json[nameof (colosseum_record)]) : (ColosseumRecord) null;
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json7 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json7 != null ? new PlayerPresent((Dictionary<string, object>) json7) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<Campaign> campaignList = new List<Campaign>();
        foreach (object json8 in (List<object>) json[nameof (campaigns)])
          campaignList.Add(json8 != null ? new Campaign((Dictionary<string, object>) json8) : (Campaign) null);
        this.campaigns = campaignList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        this.target_player_is_friend = (bool) json[nameof (target_player_is_friend)];
        this.is_tutorial = (bool) json[nameof (is_tutorial)];
        this.battle_type = (int) (long) json[nameof (battle_type)];
        this.colosseum_result_rank_up = json[nameof (colosseum_result_rank_up)] != null ? new RankUpInfo((Dictionary<string, object>) json[nameof (colosseum_result_rank_up)]) : (RankUpInfo) null;
        List<WebAPI.Response.ColosseumFinishCampaign_rewards> finishCampaignRewardsList = new List<WebAPI.Response.ColosseumFinishCampaign_rewards>();
        foreach (object json9 in (List<object>) json[nameof (campaign_rewards)])
          finishCampaignRewardsList.Add(json9 != null ? new WebAPI.Response.ColosseumFinishCampaign_rewards((Dictionary<string, object>) json9) : (WebAPI.Response.ColosseumFinishCampaign_rewards) null);
        this.campaign_rewards = finishCampaignRewardsList.ToArray();
        this.colosseum_finish = json[nameof (colosseum_finish)] != null ? new ColosseumEnd((Dictionary<string, object>) json[nameof (colosseum_finish)]) : (ColosseumEnd) null;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json10 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json10 != null ? new PlayerItem((Dictionary<string, object>) json10) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        if (json.ContainsKey("player_items:delete"))
          SMManager.DeleteList<PlayerItem>(((IEnumerable<object>) json["player_items:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class ColosseumFinishCampaign_rewards : KeyCompare
    {
      public int reward_quantity;
      public string show_text2;
      public int reward_type_id;
      public int campaign_id;
      public string show_title;
      public string show_text;
      public int reward_id;

      public ColosseumFinishCampaign_rewards()
      {
      }

      public ColosseumFinishCampaign_rewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.show_text2 = (string) json[nameof (show_text2)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.campaign_id = (int) (long) json[nameof (campaign_id)];
        this.show_title = (string) json[nameof (show_title)];
        this.show_text = (string) json[nameof (show_text)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
      }
    }

    [Serializable]
    public class ColosseumFinishCampaign_next_rewards : KeyCompare
    {
      public string next_reward_title;
      public int campaign_id;
      public string next_reward_text;

      public ColosseumFinishCampaign_next_rewards()
      {
      }

      public ColosseumFinishCampaign_next_rewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.next_reward_title = (string) json[nameof (next_reward_title)];
        this.campaign_id = (int) (long) json[nameof (campaign_id)];
        this.next_reward_text = (string) json[nameof (next_reward_text)];
      }
    }

    [Serializable]
    public class ColosseumFinishBonus_rewards : KeyCompare
    {
      public int reward_quantity;
      public int reward_type_id;
      public int reward_id;

      public ColosseumFinishBonus_rewards()
      {
      }

      public ColosseumFinishBonus_rewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
      }
    }

    [Serializable]
    public class ColosseumForceClose : KeyCompare
    {
      public bool result;

      public ColosseumForceClose()
      {
      }

      public ColosseumForceClose(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.result = (bool) json[nameof (result)];
      }
    }

    [Serializable]
    public class ColosseumRanking : KeyCompare
    {
      public RankingPlayer my_ranking;
      public RankingPlayer[] colosseum_ranking;
      public RankingPlayer[] colosseum_friend_ranking;

      public ColosseumRanking()
      {
      }

      public ColosseumRanking(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.my_ranking = json[nameof (my_ranking)] != null ? new RankingPlayer((Dictionary<string, object>) json[nameof (my_ranking)]) : (RankingPlayer) null;
        List<RankingPlayer> rankingPlayerList1 = new List<RankingPlayer>();
        foreach (object json1 in (List<object>) json[nameof (colosseum_ranking)])
          rankingPlayerList1.Add(json1 != null ? new RankingPlayer((Dictionary<string, object>) json1) : (RankingPlayer) null);
        this.colosseum_ranking = rankingPlayerList1.ToArray();
        List<RankingPlayer> rankingPlayerList2 = new List<RankingPlayer>();
        foreach (object json2 in (List<object>) json[nameof (colosseum_friend_ranking)])
          rankingPlayerList2.Add(json2 != null ? new RankingPlayer((Dictionary<string, object>) json2) : (RankingPlayer) null);
        this.colosseum_friend_ranking = rankingPlayerList2.ToArray();
      }
    }

    [Serializable]
    public class ColosseumResume : KeyCompare
    {
      public DateTime now;
      public Player player;
      public Bonus[] bonus;
      public PlayerItem[] colosseum_target_player_items;
      public PlayerUnit[] colosseum_player_units;
      public string arena_transaction_id;
      public int battle_type;
      public PlayerUnit[] colosseum_target_player_units;
      public PlayerItem[] colosseum_player_items;
      public Gladiator gladiator;

      public ColosseumResume()
      {
      }

      public ColosseumResume(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.now = DateTime.Parse((string) json[nameof (now)]);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        List<Bonus> bonusList = new List<Bonus>();
        foreach (object json1 in (List<object>) json[nameof (bonus)])
          bonusList.Add(json1 != null ? new Bonus((Dictionary<string, object>) json1) : (Bonus) null);
        this.bonus = bonusList.ToArray();
        List<PlayerItem> playerItemList1 = new List<PlayerItem>();
        foreach (object json2 in (List<object>) json[nameof (colosseum_target_player_items)])
          playerItemList1.Add(json2 != null ? new PlayerItem((Dictionary<string, object>) json2) : (PlayerItem) null);
        this.colosseum_target_player_items = playerItemList1.ToArray();
        List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (colosseum_player_units)])
          playerUnitList1.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.colosseum_player_units = playerUnitList1.ToArray();
        this.arena_transaction_id = (string) json[nameof (arena_transaction_id)];
        this.battle_type = (int) (long) json[nameof (battle_type)];
        List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
        foreach (object json4 in (List<object>) json[nameof (colosseum_target_player_units)])
          playerUnitList2.Add(json4 != null ? new PlayerUnit((Dictionary<string, object>) json4) : (PlayerUnit) null);
        this.colosseum_target_player_units = playerUnitList2.ToArray();
        List<PlayerItem> playerItemList2 = new List<PlayerItem>();
        foreach (object json5 in (List<object>) json[nameof (colosseum_player_items)])
          playerItemList2.Add(json5 != null ? new PlayerItem((Dictionary<string, object>) json5) : (PlayerItem) null);
        this.colosseum_player_items = playerItemList2.ToArray();
        this.gladiator = json[nameof (gladiator)] != null ? new Gladiator((Dictionary<string, object>) json[nameof (gladiator)]) : (Gladiator) null;
      }
    }

    [Serializable]
    public class ColosseumStart : KeyCompare
    {
      public DateTime now;
      public Player player;
      public Bonus[] bonus;
      public PlayerItem[] colosseum_target_player_items;
      public PlayerUnit[] colosseum_player_units;
      public string arena_transaction_id;
      public int battle_type;
      public PlayerUnit[] colosseum_target_player_units;
      public PlayerItem[] colosseum_player_items;
      public Gladiator gladiator;

      public ColosseumStart()
      {
      }

      public ColosseumStart(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.now = DateTime.Parse((string) json[nameof (now)]);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<Bonus> bonusList = new List<Bonus>();
        foreach (object json1 in (List<object>) json[nameof (bonus)])
          bonusList.Add(json1 != null ? new Bonus((Dictionary<string, object>) json1) : (Bonus) null);
        this.bonus = bonusList.ToArray();
        List<PlayerItem> playerItemList1 = new List<PlayerItem>();
        foreach (object json2 in (List<object>) json[nameof (colosseum_target_player_items)])
          playerItemList1.Add(json2 != null ? new PlayerItem((Dictionary<string, object>) json2) : (PlayerItem) null);
        this.colosseum_target_player_items = playerItemList1.ToArray();
        List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (colosseum_player_units)])
          playerUnitList1.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.colosseum_player_units = playerUnitList1.ToArray();
        this.arena_transaction_id = (string) json[nameof (arena_transaction_id)];
        this.battle_type = (int) (long) json[nameof (battle_type)];
        List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
        foreach (object json4 in (List<object>) json[nameof (colosseum_target_player_units)])
          playerUnitList2.Add(json4 != null ? new PlayerUnit((Dictionary<string, object>) json4) : (PlayerUnit) null);
        this.colosseum_target_player_units = playerUnitList2.ToArray();
        List<PlayerItem> playerItemList2 = new List<PlayerItem>();
        foreach (object json5 in (List<object>) json[nameof (colosseum_player_items)])
          playerItemList2.Add(json5 != null ? new PlayerItem((Dictionary<string, object>) json5) : (PlayerItem) null);
        this.colosseum_player_items = playerItemList2.ToArray();
        this.gladiator = json[nameof (gladiator)] != null ? new Gladiator((Dictionary<string, object>) json[nameof (gladiator)]) : (Gladiator) null;
      }
    }

    [Serializable]
    public class ColosseumTutorialBoot : KeyCompare
    {
      public bool is_battle;
      public int next_battle_type;
      public Bonus[] bonus;
      public bool is_tutorial;
      public Campaign[] campaigns;
      public Player player;
      public ColosseumRecord colosseum_record;
      public Gladiator[] gladiators;

      public ColosseumTutorialBoot()
      {
      }

      public ColosseumTutorialBoot(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.is_battle = (bool) json[nameof (is_battle)];
        this.next_battle_type = (int) (long) json[nameof (next_battle_type)];
        List<Bonus> bonusList = new List<Bonus>();
        foreach (object json1 in (List<object>) json[nameof (bonus)])
          bonusList.Add(json1 != null ? new Bonus((Dictionary<string, object>) json1) : (Bonus) null);
        this.bonus = bonusList.ToArray();
        this.is_tutorial = (bool) json[nameof (is_tutorial)];
        List<Campaign> campaignList = new List<Campaign>();
        foreach (object json2 in (List<object>) json[nameof (campaigns)])
          campaignList.Add(json2 != null ? new Campaign((Dictionary<string, object>) json2) : (Campaign) null);
        this.campaigns = campaignList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        this.colosseum_record = json[nameof (colosseum_record)] != null ? new ColosseumRecord((Dictionary<string, object>) json[nameof (colosseum_record)]) : (ColosseumRecord) null;
        List<Gladiator> gladiatorList = new List<Gladiator>();
        foreach (object json3 in (List<object>) json[nameof (gladiators)])
          gladiatorList.Add(json3 != null ? new Gladiator((Dictionary<string, object>) json3) : (Gladiator) null);
        this.gladiators = gladiatorList.ToArray();
      }
    }

    [Serializable]
    public class ColosseumTutorialFinish : KeyCompare
    {
      public WebAPI.Response.ColosseumTutorialFinishBonus_rewards[] bonus_rewards;
      public WebAPI.Response.ColosseumTutorialFinishCampaign_next_rewards[] campaign_next_rewards;
      public bool is_battle;
      public int next_battle_type;
      public Bonus[] bonus;
      public Gladiator[] gladiators;
      public PlayerUnit[] player_units;
      public PlayerCharacterIntimate[] player_character_intimates;
      public ColosseumRecord colosseum_record;
      public PlayerPresent[] player_presents;
      public Campaign[] campaigns;
      public Player player;
      public bool target_player_is_friend;
      public bool is_tutorial;
      public int battle_type;
      public RankUpInfo colosseum_result_rank_up;
      public WebAPI.Response.ColosseumTutorialFinishCampaign_rewards[] campaign_rewards;
      public ColosseumEnd colosseum_finish;
      public PlayerItem[] player_items;
      public bool result;

      public ColosseumTutorialFinish()
      {
      }

      public ColosseumTutorialFinish(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<WebAPI.Response.ColosseumTutorialFinishBonus_rewards> finishBonusRewardsList = new List<WebAPI.Response.ColosseumTutorialFinishBonus_rewards>();
        foreach (object json1 in (List<object>) json[nameof (bonus_rewards)])
          finishBonusRewardsList.Add(json1 != null ? new WebAPI.Response.ColosseumTutorialFinishBonus_rewards((Dictionary<string, object>) json1) : (WebAPI.Response.ColosseumTutorialFinishBonus_rewards) null);
        this.bonus_rewards = finishBonusRewardsList.ToArray();
        List<WebAPI.Response.ColosseumTutorialFinishCampaign_next_rewards> campaignNextRewardsList = new List<WebAPI.Response.ColosseumTutorialFinishCampaign_next_rewards>();
        foreach (object json2 in (List<object>) json[nameof (campaign_next_rewards)])
          campaignNextRewardsList.Add(json2 != null ? new WebAPI.Response.ColosseumTutorialFinishCampaign_next_rewards((Dictionary<string, object>) json2) : (WebAPI.Response.ColosseumTutorialFinishCampaign_next_rewards) null);
        this.campaign_next_rewards = campaignNextRewardsList.ToArray();
        this.is_battle = (bool) json[nameof (is_battle)];
        this.next_battle_type = (int) (long) json[nameof (next_battle_type)];
        List<Bonus> bonusList = new List<Bonus>();
        foreach (object json3 in (List<object>) json[nameof (bonus)])
          bonusList.Add(json3 != null ? new Bonus((Dictionary<string, object>) json3) : (Bonus) null);
        this.bonus = bonusList.ToArray();
        List<Gladiator> gladiatorList = new List<Gladiator>();
        foreach (object json4 in (List<object>) json[nameof (gladiators)])
          gladiatorList.Add(json4 != null ? new Gladiator((Dictionary<string, object>) json4) : (Gladiator) null);
        this.gladiators = gladiatorList.ToArray();
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json5 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json5 != null ? new PlayerUnit((Dictionary<string, object>) json5) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<PlayerCharacterIntimate> characterIntimateList = new List<PlayerCharacterIntimate>();
        foreach (object json6 in (List<object>) json[nameof (player_character_intimates)])
          characterIntimateList.Add(json6 != null ? new PlayerCharacterIntimate((Dictionary<string, object>) json6) : (PlayerCharacterIntimate) null);
        this.player_character_intimates = characterIntimateList.ToArray();
        SMManager.UpdateList<PlayerCharacterIntimate>(this.player_character_intimates);
        this.colosseum_record = json[nameof (colosseum_record)] != null ? new ColosseumRecord((Dictionary<string, object>) json[nameof (colosseum_record)]) : (ColosseumRecord) null;
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json7 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json7 != null ? new PlayerPresent((Dictionary<string, object>) json7) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<Campaign> campaignList = new List<Campaign>();
        foreach (object json8 in (List<object>) json[nameof (campaigns)])
          campaignList.Add(json8 != null ? new Campaign((Dictionary<string, object>) json8) : (Campaign) null);
        this.campaigns = campaignList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        this.target_player_is_friend = (bool) json[nameof (target_player_is_friend)];
        this.is_tutorial = (bool) json[nameof (is_tutorial)];
        this.battle_type = (int) (long) json[nameof (battle_type)];
        this.colosseum_result_rank_up = json[nameof (colosseum_result_rank_up)] != null ? new RankUpInfo((Dictionary<string, object>) json[nameof (colosseum_result_rank_up)]) : (RankUpInfo) null;
        List<WebAPI.Response.ColosseumTutorialFinishCampaign_rewards> finishCampaignRewardsList = new List<WebAPI.Response.ColosseumTutorialFinishCampaign_rewards>();
        foreach (object json9 in (List<object>) json[nameof (campaign_rewards)])
          finishCampaignRewardsList.Add(json9 != null ? new WebAPI.Response.ColosseumTutorialFinishCampaign_rewards((Dictionary<string, object>) json9) : (WebAPI.Response.ColosseumTutorialFinishCampaign_rewards) null);
        this.campaign_rewards = finishCampaignRewardsList.ToArray();
        this.colosseum_finish = json[nameof (colosseum_finish)] != null ? new ColosseumEnd((Dictionary<string, object>) json[nameof (colosseum_finish)]) : (ColosseumEnd) null;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json10 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json10 != null ? new PlayerItem((Dictionary<string, object>) json10) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.result = (bool) json[nameof (result)];
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class ColosseumTutorialFinishCampaign_rewards : KeyCompare
    {
      public int reward_quantity;
      public string show_text2;
      public int reward_type_id;
      public int campaign_id;
      public string show_title;
      public string show_text;
      public int reward_id;

      public ColosseumTutorialFinishCampaign_rewards()
      {
      }

      public ColosseumTutorialFinishCampaign_rewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.show_text2 = (string) json[nameof (show_text2)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.campaign_id = (int) (long) json[nameof (campaign_id)];
        this.show_title = (string) json[nameof (show_title)];
        this.show_text = (string) json[nameof (show_text)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
      }
    }

    [Serializable]
    public class ColosseumTutorialFinishCampaign_next_rewards : KeyCompare
    {
      public string next_reward_title;
      public int campaign_id;
      public string next_reward_text;

      public ColosseumTutorialFinishCampaign_next_rewards()
      {
      }

      public ColosseumTutorialFinishCampaign_next_rewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.next_reward_title = (string) json[nameof (next_reward_title)];
        this.campaign_id = (int) (long) json[nameof (campaign_id)];
        this.next_reward_text = (string) json[nameof (next_reward_text)];
      }
    }

    [Serializable]
    public class ColosseumTutorialFinishBonus_rewards : KeyCompare
    {
      public int reward_quantity;
      public int reward_type_id;
      public int reward_id;

      public ColosseumTutorialFinishBonus_rewards()
      {
      }

      public ColosseumTutorialFinishBonus_rewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
      }
    }

    [Serializable]
    public class ColosseumTutorialForceClose : KeyCompare
    {
      public bool result;

      public ColosseumTutorialForceClose()
      {
      }

      public ColosseumTutorialForceClose(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.result = (bool) json[nameof (result)];
      }
    }

    [Serializable]
    public class ColosseumTutorialResume : KeyCompare
    {
      public DateTime now;
      public Player player;
      public Bonus[] bonus;
      public PlayerItem[] colosseum_target_player_items;
      public PlayerUnit[] colosseum_player_units;
      public string arena_transaction_id;
      public int battle_type;
      public PlayerUnit[] colosseum_target_player_units;
      public PlayerItem[] colosseum_player_items;
      public Gladiator gladiator;

      public ColosseumTutorialResume()
      {
      }

      public ColosseumTutorialResume(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.now = DateTime.Parse((string) json[nameof (now)]);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        List<Bonus> bonusList = new List<Bonus>();
        foreach (object json1 in (List<object>) json[nameof (bonus)])
          bonusList.Add(json1 != null ? new Bonus((Dictionary<string, object>) json1) : (Bonus) null);
        this.bonus = bonusList.ToArray();
        List<PlayerItem> playerItemList1 = new List<PlayerItem>();
        foreach (object json2 in (List<object>) json[nameof (colosseum_target_player_items)])
          playerItemList1.Add(json2 != null ? new PlayerItem((Dictionary<string, object>) json2) : (PlayerItem) null);
        this.colosseum_target_player_items = playerItemList1.ToArray();
        List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (colosseum_player_units)])
          playerUnitList1.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.colosseum_player_units = playerUnitList1.ToArray();
        this.arena_transaction_id = (string) json[nameof (arena_transaction_id)];
        this.battle_type = (int) (long) json[nameof (battle_type)];
        List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
        foreach (object json4 in (List<object>) json[nameof (colosseum_target_player_units)])
          playerUnitList2.Add(json4 != null ? new PlayerUnit((Dictionary<string, object>) json4) : (PlayerUnit) null);
        this.colosseum_target_player_units = playerUnitList2.ToArray();
        List<PlayerItem> playerItemList2 = new List<PlayerItem>();
        foreach (object json5 in (List<object>) json[nameof (colosseum_player_items)])
          playerItemList2.Add(json5 != null ? new PlayerItem((Dictionary<string, object>) json5) : (PlayerItem) null);
        this.colosseum_player_items = playerItemList2.ToArray();
        this.gladiator = json[nameof (gladiator)] != null ? new Gladiator((Dictionary<string, object>) json[nameof (gladiator)]) : (Gladiator) null;
      }
    }

    [Serializable]
    public class ColosseumTutorialStart : KeyCompare
    {
      public DateTime now;
      public Player player;
      public Bonus[] bonus;
      public PlayerItem[] colosseum_target_player_items;
      public PlayerUnit[] colosseum_player_units;
      public string arena_transaction_id;
      public int battle_type;
      public PlayerUnit[] colosseum_target_player_units;
      public PlayerItem[] colosseum_player_items;
      public Gladiator gladiator;

      public ColosseumTutorialStart()
      {
      }

      public ColosseumTutorialStart(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.now = DateTime.Parse((string) json[nameof (now)]);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<Bonus> bonusList = new List<Bonus>();
        foreach (object json1 in (List<object>) json[nameof (bonus)])
          bonusList.Add(json1 != null ? new Bonus((Dictionary<string, object>) json1) : (Bonus) null);
        this.bonus = bonusList.ToArray();
        List<PlayerItem> playerItemList1 = new List<PlayerItem>();
        foreach (object json2 in (List<object>) json[nameof (colosseum_target_player_items)])
          playerItemList1.Add(json2 != null ? new PlayerItem((Dictionary<string, object>) json2) : (PlayerItem) null);
        this.colosseum_target_player_items = playerItemList1.ToArray();
        List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (colosseum_player_units)])
          playerUnitList1.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.colosseum_player_units = playerUnitList1.ToArray();
        this.arena_transaction_id = (string) json[nameof (arena_transaction_id)];
        this.battle_type = (int) (long) json[nameof (battle_type)];
        List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
        foreach (object json4 in (List<object>) json[nameof (colosseum_target_player_units)])
          playerUnitList2.Add(json4 != null ? new PlayerUnit((Dictionary<string, object>) json4) : (PlayerUnit) null);
        this.colosseum_target_player_units = playerUnitList2.ToArray();
        List<PlayerItem> playerItemList2 = new List<PlayerItem>();
        foreach (object json5 in (List<object>) json[nameof (colosseum_player_items)])
          playerItemList2.Add(json5 != null ? new PlayerItem((Dictionary<string, object>) json5) : (PlayerItem) null);
        this.colosseum_player_items = playerItemList2.ToArray();
        this.gladiator = json[nameof (gladiator)] != null ? new Gladiator((Dictionary<string, object>) json[nameof (gladiator)]) : (Gladiator) null;
      }
    }

    [Serializable]
    public class CrossfestaDetail : KeyCompare
    {
      public CrossFestaAchieve[] achieves;
      public CrossFestaCampaign campaign;
      public PlayerCrossFestaSerial[] player_serials;

      public CrossfestaDetail()
      {
      }

      public CrossfestaDetail(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<CrossFestaAchieve> crossFestaAchieveList = new List<CrossFestaAchieve>();
        foreach (object json1 in (List<object>) json[nameof (achieves)])
          crossFestaAchieveList.Add(json1 != null ? new CrossFestaAchieve((Dictionary<string, object>) json1) : (CrossFestaAchieve) null);
        this.achieves = crossFestaAchieveList.ToArray();
        this.campaign = json[nameof (campaign)] != null ? new CrossFestaCampaign((Dictionary<string, object>) json[nameof (campaign)]) : (CrossFestaCampaign) null;
        List<PlayerCrossFestaSerial> crossFestaSerialList = new List<PlayerCrossFestaSerial>();
        foreach (object json2 in (List<object>) json[nameof (player_serials)])
          crossFestaSerialList.Add(json2 != null ? new PlayerCrossFestaSerial((Dictionary<string, object>) json2) : (PlayerCrossFestaSerial) null);
        this.player_serials = crossFestaSerialList.ToArray();
      }
    }

    [Serializable]
    public class CrossfestaIndex : KeyCompare
    {
      public CrossFestaCampaign[] campaigns;

      public CrossfestaIndex()
      {
      }

      public CrossfestaIndex(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<CrossFestaCampaign> crossFestaCampaignList = new List<CrossFestaCampaign>();
        foreach (object json1 in (List<object>) json[nameof (campaigns)])
          crossFestaCampaignList.Add(json1 != null ? new CrossFestaCampaign((Dictionary<string, object>) json1) : (CrossFestaCampaign) null);
        this.campaigns = crossFestaCampaignList.ToArray();
      }
    }

    [Serializable]
    public class CrossfestaSerial : KeyCompare
    {
      public PlayerCrossFestaSerial player_serial;
      public CrossFestaAchieve campaign_achieve;
      public CrossFestaCampaign campaign;
      public string serial_code;

      public CrossfestaSerial()
      {
      }

      public CrossfestaSerial(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player_serial = json[nameof (player_serial)] != null ? new PlayerCrossFestaSerial((Dictionary<string, object>) json[nameof (player_serial)]) : (PlayerCrossFestaSerial) null;
        this.campaign_achieve = json[nameof (campaign_achieve)] != null ? new CrossFestaAchieve((Dictionary<string, object>) json[nameof (campaign_achieve)]) : (CrossFestaAchieve) null;
        this.campaign = json[nameof (campaign)] != null ? new CrossFestaCampaign((Dictionary<string, object>) json[nameof (campaign)]) : (CrossFestaCampaign) null;
        this.serial_code = (string) json[nameof (serial_code)];
      }
    }

    [Serializable]
    public class DailymissionIndex : KeyCompare
    {
      public Player player;
      public PlayerDailyMissionAchievement[] player_daily_missions;

      public DailymissionIndex()
      {
      }

      public DailymissionIndex(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerDailyMissionAchievement> missionAchievementList = new List<PlayerDailyMissionAchievement>();
        foreach (object json1 in (List<object>) json[nameof (player_daily_missions)])
          missionAchievementList.Add(json1 != null ? new PlayerDailyMissionAchievement((Dictionary<string, object>) json1) : (PlayerDailyMissionAchievement) null);
        this.player_daily_missions = missionAchievementList.ToArray();
        SMManager.UpdateList<PlayerDailyMissionAchievement>(this.player_daily_missions);
      }
    }

    [Serializable]
    public class DailymissionReceive : KeyCompare
    {
      public Player player;
      public PlayerDailyMissionAchievement[] player_daily_missions;
      public PlayerPresent[] player_presents;

      public DailymissionReceive()
      {
      }

      public DailymissionReceive(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerDailyMissionAchievement> missionAchievementList = new List<PlayerDailyMissionAchievement>();
        foreach (object json1 in (List<object>) json[nameof (player_daily_missions)])
          missionAchievementList.Add(json1 != null ? new PlayerDailyMissionAchievement((Dictionary<string, object>) json1) : (PlayerDailyMissionAchievement) null);
        this.player_daily_missions = missionAchievementList.ToArray();
        SMManager.UpdateList<PlayerDailyMissionAchievement>(this.player_daily_missions);
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json2 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json2 != null ? new PlayerPresent((Dictionary<string, object>) json2) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class DailymissionReview : KeyCompare
    {
      public Player player;

      public DailymissionReview()
      {
      }

      public DailymissionReview(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
      }
    }

    [Serializable]
    public class DeckEdit : KeyCompare
    {
      public PlayerDeck[] player_decks;

      public DeckEdit()
      {
      }

      public DeckEdit(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerDeck> playerDeckList = new List<PlayerDeck>();
        foreach (object json1 in (List<object>) json[nameof (player_decks)])
          playerDeckList.Add(json1 != null ? new PlayerDeck((Dictionary<string, object>) json1) : (PlayerDeck) null);
        this.player_decks = playerDeckList.ToArray();
        SMManager.UpdateList<PlayerDeck>(this.player_decks);
      }
    }

    [Serializable]
    public class EmblemSet : KeyCompare
    {
      public Player player;

      public EmblemSet()
      {
      }

      public EmblemSet(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
      }
    }

    [Serializable]
    public class EmblemStatus : KeyCompare
    {
      public int current_emblem_id;
      public int[] display_emblem_ids;
      public PlayerEmblem[] emblems;

      public EmblemStatus()
      {
      }

      public EmblemStatus(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.current_emblem_id = (int) (long) json[nameof (current_emblem_id)];
        this.display_emblem_ids = ((IEnumerable<object>) json[nameof (display_emblem_ids)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
        List<PlayerEmblem> playerEmblemList = new List<PlayerEmblem>();
        foreach (object json1 in (List<object>) json[nameof (emblems)])
          playerEmblemList.Add(json1 != null ? new PlayerEmblem((Dictionary<string, object>) json1) : (PlayerEmblem) null);
        this.emblems = playerEmblemList.ToArray();
        SMManager.UpdateList<PlayerEmblem>(this.emblems);
      }
    }

    [Serializable]
    public class FacebookIsRelated : KeyCompare
    {
      public bool is_related;

      public FacebookIsRelated()
      {
      }

      public FacebookIsRelated(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.is_related = (bool) json[nameof (is_related)];
      }
    }

    [Serializable]
    public class FacebookRegister : KeyCompare
    {
      public FacebookRegister()
      {
      }

      public FacebookRegister(Dictionary<string, object> json) => this._hasKey = false;
    }

    [Serializable]
    public class FriendAccept : KeyCompare
    {
      public PlayerFriend[] player_friends;

      public FriendAccept()
      {
      }

      public FriendAccept(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerFriend> playerFriendList = new List<PlayerFriend>();
        foreach (object json1 in (List<object>) json[nameof (player_friends)])
          playerFriendList.Add(json1 != null ? new PlayerFriend((Dictionary<string, object>) json1) : (PlayerFriend) null);
        this.player_friends = playerFriendList.ToArray();
        SMManager.UpdateList<PlayerFriend>(this.player_friends);
      }
    }

    [Serializable]
    public class FriendApply : KeyCompare
    {
      public PlayerFriend[] player_friends;

      public FriendApply()
      {
      }

      public FriendApply(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerFriend> playerFriendList = new List<PlayerFriend>();
        foreach (object json1 in (List<object>) json[nameof (player_friends)])
          playerFriendList.Add(json1 != null ? new PlayerFriend((Dictionary<string, object>) json1) : (PlayerFriend) null);
        this.player_friends = playerFriendList.ToArray();
        SMManager.UpdateList<PlayerFriend>(this.player_friends);
      }
    }

    [Serializable]
    public class FriendCancel : KeyCompare
    {
      public PlayerFriend[] player_friends;

      public FriendCancel()
      {
      }

      public FriendCancel(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerFriend> playerFriendList = new List<PlayerFriend>();
        foreach (object json1 in (List<object>) json[nameof (player_friends)])
          playerFriendList.Add(json1 != null ? new PlayerFriend((Dictionary<string, object>) json1) : (PlayerFriend) null);
        this.player_friends = playerFriendList.ToArray();
        SMManager.UpdateList<PlayerFriend>(this.player_friends);
      }
    }

    [Serializable]
    public class FriendFavorite : KeyCompare
    {
      public PlayerFriend[] player_friends;

      public FriendFavorite()
      {
      }

      public FriendFavorite(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerFriend> playerFriendList = new List<PlayerFriend>();
        foreach (object json1 in (List<object>) json[nameof (player_friends)])
          playerFriendList.Add(json1 != null ? new PlayerFriend((Dictionary<string, object>) json1) : (PlayerFriend) null);
        this.player_friends = playerFriendList.ToArray();
        SMManager.UpdateList<PlayerFriend>(this.player_friends);
      }
    }

    [Serializable]
    public class FriendFriends : KeyCompare
    {
      public PlayerFriend[] player_friends;

      public FriendFriends()
      {
      }

      public FriendFriends(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerFriend> playerFriendList = new List<PlayerFriend>();
        foreach (object json1 in (List<object>) json[nameof (player_friends)])
          playerFriendList.Add(json1 != null ? new PlayerFriend((Dictionary<string, object>) json1) : (PlayerFriend) null);
        this.player_friends = playerFriendList.ToArray();
        SMManager.UpdateList<PlayerFriend>(this.player_friends, true);
      }
    }

    [Serializable]
    public class FriendReject : KeyCompare
    {
      public PlayerFriend[] player_friends;

      public FriendReject()
      {
      }

      public FriendReject(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerFriend> playerFriendList = new List<PlayerFriend>();
        foreach (object json1 in (List<object>) json[nameof (player_friends)])
          playerFriendList.Add(json1 != null ? new PlayerFriend((Dictionary<string, object>) json1) : (PlayerFriend) null);
        this.player_friends = playerFriendList.ToArray();
        SMManager.UpdateList<PlayerFriend>(this.player_friends);
      }
    }

    [Serializable]
    public class FriendRemove : KeyCompare
    {
      public PlayerFriend[] player_friends;

      public FriendRemove()
      {
      }

      public FriendRemove(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerFriend> playerFriendList = new List<PlayerFriend>();
        foreach (object json1 in (List<object>) json[nameof (player_friends)])
          playerFriendList.Add(json1 != null ? new PlayerFriend((Dictionary<string, object>) json1) : (PlayerFriend) null);
        this.player_friends = playerFriendList.ToArray();
        SMManager.UpdateList<PlayerFriend>(this.player_friends);
      }
    }

    [Serializable]
    public class FriendStatus : KeyCompare
    {
      public PlayerUnit[] target_player_units;
      public PlayerItem[] target_player_items;
      public bool is_friend;
      public PlayerHelper[] player_helpers;
      public PlayerUnit target_leader_unit;
      public Player target_player;

      public FriendStatus()
      {
      }

      public FriendStatus(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json1 in (List<object>) json[nameof (target_player_units)])
          playerUnitList.Add(json1 != null ? new PlayerUnit((Dictionary<string, object>) json1) : (PlayerUnit) null);
        this.target_player_units = playerUnitList.ToArray();
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json2 in (List<object>) json[nameof (target_player_items)])
          playerItemList.Add(json2 != null ? new PlayerItem((Dictionary<string, object>) json2) : (PlayerItem) null);
        this.target_player_items = playerItemList.ToArray();
        this.is_friend = (bool) json[nameof (is_friend)];
        List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
        foreach (object json3 in (List<object>) json[nameof (player_helpers)])
          playerHelperList.Add(json3 != null ? new PlayerHelper((Dictionary<string, object>) json3) : (PlayerHelper) null);
        this.player_helpers = playerHelperList.ToArray();
        SMManager.UpdateList<PlayerHelper>(this.player_helpers);
        this.target_leader_unit = json[nameof (target_leader_unit)] != null ? new PlayerUnit((Dictionary<string, object>) json[nameof (target_leader_unit)]) : (PlayerUnit) null;
        this.target_player = json[nameof (target_player)] != null ? new Player((Dictionary<string, object>) json[nameof (target_player)]) : (Player) null;
      }
    }

    [Serializable]
    public class Gacha : KeyCompare
    {
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;

      public Gacha()
      {
      }

      public Gacha(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json1 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json1 != null ? new TicketBanner((Dictionary<string, object>) json1) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json2 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json2 != null ? new GachaModule((Dictionary<string, object>) json2) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
      }
    }

    [Serializable]
    public class GachaG001ChargeMultiPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public AnimationPatternMultiAfter[] animation_pattern_gems;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG001ChargeMultiPayResult[] result;

      public GachaG001ChargeMultiPay()
      {
      }

      public GachaG001ChargeMultiPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<AnimationPatternMultiAfter> patternMultiAfterList = new List<AnimationPatternMultiAfter>();
        foreach (object json2 in (List<object>) json[nameof (animation_pattern_gems)])
          patternMultiAfterList.Add(json2 != null ? new AnimationPatternMultiAfter((Dictionary<string, object>) json2) : (AnimationPatternMultiAfter) null);
        this.animation_pattern_gems = patternMultiAfterList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json4 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json4 != null ? new UnlockQuest((Dictionary<string, object>) json4) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json5 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json5 != null ? new TicketBanner((Dictionary<string, object>) json5) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json6 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json6 != null ? new GachaModule((Dictionary<string, object>) json6) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json7 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json7 != null ? new PlayerPresent((Dictionary<string, object>) json7) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG001ChargeMultiPayResult> chargeMultiPayResultList = new List<WebAPI.Response.GachaG001ChargeMultiPayResult>();
        foreach (object json8 in (List<object>) json[nameof (result)])
          chargeMultiPayResultList.Add(json8 != null ? new WebAPI.Response.GachaG001ChargeMultiPayResult((Dictionary<string, object>) json8) : (WebAPI.Response.GachaG001ChargeMultiPayResult) null);
        this.result = chargeMultiPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG001ChargeMultiPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG001ChargeMultiPayResult()
      {
      }

      public GachaG001ChargeMultiPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG001ChargePay : KeyCompare
    {
      public PlayerItem[] player_items;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG001ChargePayResult[] result;

      public GachaG001ChargePay()
      {
      }

      public GachaG001ChargePay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json3 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json3 != null ? new UnlockQuest((Dictionary<string, object>) json3) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json4 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json4 != null ? new TicketBanner((Dictionary<string, object>) json4) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json5 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json5 != null ? new GachaModule((Dictionary<string, object>) json5) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json6 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json6 != null ? new PlayerPresent((Dictionary<string, object>) json6) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG001ChargePayResult> g001ChargePayResultList = new List<WebAPI.Response.GachaG001ChargePayResult>();
        foreach (object json7 in (List<object>) json[nameof (result)])
          g001ChargePayResultList.Add(json7 != null ? new WebAPI.Response.GachaG001ChargePayResult((Dictionary<string, object>) json7) : (WebAPI.Response.GachaG001ChargePayResult) null);
        this.result = g001ChargePayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG001ChargePayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG001ChargePayResult()
      {
      }

      public GachaG001ChargePayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG002FriendpointPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public Player player;
      public PlayerUnit[] player_units;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG002FriendpointPayResult[] result;

      public GachaG002FriendpointPay()
      {
      }

      public GachaG002FriendpointPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json3 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json3 != null ? new TicketBanner((Dictionary<string, object>) json3) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json4 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json4 != null ? new GachaModule((Dictionary<string, object>) json4) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json5 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json5 != null ? new PlayerPresent((Dictionary<string, object>) json5) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG002FriendpointPayResult> friendpointPayResultList = new List<WebAPI.Response.GachaG002FriendpointPayResult>();
        foreach (object json6 in (List<object>) json[nameof (result)])
          friendpointPayResultList.Add(json6 != null ? new WebAPI.Response.GachaG002FriendpointPayResult((Dictionary<string, object>) json6) : (WebAPI.Response.GachaG002FriendpointPayResult) null);
        this.result = friendpointPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG002FriendpointPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG002FriendpointPayResult()
      {
      }

      public GachaG002FriendpointPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG004TicketMultiPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public AnimationPatternMultiAfter[] animation_pattern_gems;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG004TicketMultiPayResult[] result;

      public GachaG004TicketMultiPay()
      {
      }

      public GachaG004TicketMultiPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<AnimationPatternMultiAfter> patternMultiAfterList = new List<AnimationPatternMultiAfter>();
        foreach (object json2 in (List<object>) json[nameof (animation_pattern_gems)])
          patternMultiAfterList.Add(json2 != null ? new AnimationPatternMultiAfter((Dictionary<string, object>) json2) : (AnimationPatternMultiAfter) null);
        this.animation_pattern_gems = patternMultiAfterList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json4 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json4 != null ? new UnlockQuest((Dictionary<string, object>) json4) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json5 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json5 != null ? new TicketBanner((Dictionary<string, object>) json5) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json6 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json6 != null ? new GachaModule((Dictionary<string, object>) json6) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json7 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json7 != null ? new PlayerPresent((Dictionary<string, object>) json7) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG004TicketMultiPayResult> ticketMultiPayResultList = new List<WebAPI.Response.GachaG004TicketMultiPayResult>();
        foreach (object json8 in (List<object>) json[nameof (result)])
          ticketMultiPayResultList.Add(json8 != null ? new WebAPI.Response.GachaG004TicketMultiPayResult((Dictionary<string, object>) json8) : (WebAPI.Response.GachaG004TicketMultiPayResult) null);
        this.result = ticketMultiPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG004TicketMultiPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG004TicketMultiPayResult()
      {
      }

      public GachaG004TicketMultiPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG004TicketPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG004TicketPayResult[] result;

      public GachaG004TicketPay()
      {
      }

      public GachaG004TicketPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json3 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json3 != null ? new UnlockQuest((Dictionary<string, object>) json3) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json4 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json4 != null ? new TicketBanner((Dictionary<string, object>) json4) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json5 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json5 != null ? new GachaModule((Dictionary<string, object>) json5) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json6 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json6 != null ? new PlayerPresent((Dictionary<string, object>) json6) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG004TicketPayResult> g004TicketPayResultList = new List<WebAPI.Response.GachaG004TicketPayResult>();
        foreach (object json7 in (List<object>) json[nameof (result)])
          g004TicketPayResultList.Add(json7 != null ? new WebAPI.Response.GachaG004TicketPayResult((Dictionary<string, object>) json7) : (WebAPI.Response.GachaG004TicketPayResult) null);
        this.result = g004TicketPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG004TicketPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG004TicketPayResult()
      {
      }

      public GachaG004TicketPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG005NewbieMultiPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public AnimationPatternMultiAfter[] animation_pattern_gems;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG005NewbieMultiPayResult[] result;

      public GachaG005NewbieMultiPay()
      {
      }

      public GachaG005NewbieMultiPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<AnimationPatternMultiAfter> patternMultiAfterList = new List<AnimationPatternMultiAfter>();
        foreach (object json2 in (List<object>) json[nameof (animation_pattern_gems)])
          patternMultiAfterList.Add(json2 != null ? new AnimationPatternMultiAfter((Dictionary<string, object>) json2) : (AnimationPatternMultiAfter) null);
        this.animation_pattern_gems = patternMultiAfterList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json4 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json4 != null ? new UnlockQuest((Dictionary<string, object>) json4) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json5 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json5 != null ? new TicketBanner((Dictionary<string, object>) json5) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json6 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json6 != null ? new GachaModule((Dictionary<string, object>) json6) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json7 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json7 != null ? new PlayerPresent((Dictionary<string, object>) json7) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG005NewbieMultiPayResult> newbieMultiPayResultList = new List<WebAPI.Response.GachaG005NewbieMultiPayResult>();
        foreach (object json8 in (List<object>) json[nameof (result)])
          newbieMultiPayResultList.Add(json8 != null ? new WebAPI.Response.GachaG005NewbieMultiPayResult((Dictionary<string, object>) json8) : (WebAPI.Response.GachaG005NewbieMultiPayResult) null);
        this.result = newbieMultiPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG005NewbieMultiPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG005NewbieMultiPayResult()
      {
      }

      public GachaG005NewbieMultiPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG005NewbiePay : KeyCompare
    {
      public PlayerItem[] player_items;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG005NewbiePayResult[] result;

      public GachaG005NewbiePay()
      {
      }

      public GachaG005NewbiePay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json3 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json3 != null ? new UnlockQuest((Dictionary<string, object>) json3) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json4 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json4 != null ? new TicketBanner((Dictionary<string, object>) json4) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json5 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json5 != null ? new GachaModule((Dictionary<string, object>) json5) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json6 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json6 != null ? new PlayerPresent((Dictionary<string, object>) json6) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG005NewbiePayResult> g005NewbiePayResultList = new List<WebAPI.Response.GachaG005NewbiePayResult>();
        foreach (object json7 in (List<object>) json[nameof (result)])
          g005NewbiePayResultList.Add(json7 != null ? new WebAPI.Response.GachaG005NewbiePayResult((Dictionary<string, object>) json7) : (WebAPI.Response.GachaG005NewbiePayResult) null);
        this.result = g005NewbiePayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG005NewbiePayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG005NewbiePayResult()
      {
      }

      public GachaG005NewbiePayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG007PanelMultiPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public AnimationPatternMultiAfter[] animation_pattern_gems;
      public Player player;
      public GachaG007PlayerSheet[] player_sheets;
      public GachaG007OpenPanelResult open_panel_result;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public PlayerUnit[] player_units;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG007PanelMultiPayResult[] result;

      public GachaG007PanelMultiPay()
      {
      }

      public GachaG007PanelMultiPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<AnimationPatternMultiAfter> patternMultiAfterList = new List<AnimationPatternMultiAfter>();
        foreach (object json2 in (List<object>) json[nameof (animation_pattern_gems)])
          patternMultiAfterList.Add(json2 != null ? new AnimationPatternMultiAfter((Dictionary<string, object>) json2) : (AnimationPatternMultiAfter) null);
        this.animation_pattern_gems = patternMultiAfterList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<GachaG007PlayerSheet> gachaG007PlayerSheetList = new List<GachaG007PlayerSheet>();
        foreach (object json3 in (List<object>) json[nameof (player_sheets)])
          gachaG007PlayerSheetList.Add(json3 != null ? new GachaG007PlayerSheet((Dictionary<string, object>) json3) : (GachaG007PlayerSheet) null);
        this.player_sheets = gachaG007PlayerSheetList.ToArray();
        SMManager.UpdateList<GachaG007PlayerSheet>(this.player_sheets);
        this.open_panel_result = json[nameof (open_panel_result)] != null ? new GachaG007OpenPanelResult((Dictionary<string, object>) json[nameof (open_panel_result)]) : (GachaG007OpenPanelResult) null;
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json4 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json4 != null ? new UnlockQuest((Dictionary<string, object>) json4) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json5 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json5 != null ? new TicketBanner((Dictionary<string, object>) json5) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json6 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json6 != null ? new GachaModule((Dictionary<string, object>) json6) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json7 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json7 != null ? new PlayerUnit((Dictionary<string, object>) json7) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json8 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json8 != null ? new PlayerPresent((Dictionary<string, object>) json8) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG007PanelMultiPayResult> panelMultiPayResultList = new List<WebAPI.Response.GachaG007PanelMultiPayResult>();
        foreach (object json9 in (List<object>) json[nameof (result)])
          panelMultiPayResultList.Add(json9 != null ? new WebAPI.Response.GachaG007PanelMultiPayResult((Dictionary<string, object>) json9) : (WebAPI.Response.GachaG007PanelMultiPayResult) null);
        this.result = panelMultiPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG007PanelMultiPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG007PanelMultiPayResult()
      {
      }

      public GachaG007PanelMultiPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG007PanelPanelInfo : KeyCompare
    {
      public GachaG007PlayerSheet[] player_sheets;

      public GachaG007PanelPanelInfo()
      {
      }

      public GachaG007PanelPanelInfo(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<GachaG007PlayerSheet> gachaG007PlayerSheetList = new List<GachaG007PlayerSheet>();
        foreach (object json1 in (List<object>) json[nameof (player_sheets)])
          gachaG007PlayerSheetList.Add(json1 != null ? new GachaG007PlayerSheet((Dictionary<string, object>) json1) : (GachaG007PlayerSheet) null);
        this.player_sheets = gachaG007PlayerSheetList.ToArray();
        SMManager.UpdateList<GachaG007PlayerSheet>(this.player_sheets);
      }
    }

    [Serializable]
    public class GachaG007PanelPanelReset : KeyCompare
    {
      public GachaG007PlayerSheet[] player_sheets;

      public GachaG007PanelPanelReset()
      {
      }

      public GachaG007PanelPanelReset(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<GachaG007PlayerSheet> gachaG007PlayerSheetList = new List<GachaG007PlayerSheet>();
        foreach (object json1 in (List<object>) json[nameof (player_sheets)])
          gachaG007PlayerSheetList.Add(json1 != null ? new GachaG007PlayerSheet((Dictionary<string, object>) json1) : (GachaG007PlayerSheet) null);
        this.player_sheets = gachaG007PlayerSheetList.ToArray();
        SMManager.UpdateList<GachaG007PlayerSheet>(this.player_sheets);
      }
    }

    [Serializable]
    public class GachaG007PanelPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public Player player;
      public GachaG007PlayerSheet[] player_sheets;
      public GachaG007OpenPanelResult open_panel_result;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public PlayerUnit[] player_units;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG007PanelPayResult[] result;

      public GachaG007PanelPay()
      {
      }

      public GachaG007PanelPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<GachaG007PlayerSheet> gachaG007PlayerSheetList = new List<GachaG007PlayerSheet>();
        foreach (object json2 in (List<object>) json[nameof (player_sheets)])
          gachaG007PlayerSheetList.Add(json2 != null ? new GachaG007PlayerSheet((Dictionary<string, object>) json2) : (GachaG007PlayerSheet) null);
        this.player_sheets = gachaG007PlayerSheetList.ToArray();
        SMManager.UpdateList<GachaG007PlayerSheet>(this.player_sheets);
        this.open_panel_result = json[nameof (open_panel_result)] != null ? new GachaG007OpenPanelResult((Dictionary<string, object>) json[nameof (open_panel_result)]) : (GachaG007OpenPanelResult) null;
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json3 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json3 != null ? new UnlockQuest((Dictionary<string, object>) json3) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json4 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json4 != null ? new TicketBanner((Dictionary<string, object>) json4) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json5 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json5 != null ? new GachaModule((Dictionary<string, object>) json5) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json6 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json6 != null ? new PlayerUnit((Dictionary<string, object>) json6) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json7 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json7 != null ? new PlayerPresent((Dictionary<string, object>) json7) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG007PanelPayResult> g007PanelPayResultList = new List<WebAPI.Response.GachaG007PanelPayResult>();
        foreach (object json8 in (List<object>) json[nameof (result)])
          g007PanelPayResultList.Add(json8 != null ? new WebAPI.Response.GachaG007PanelPayResult((Dictionary<string, object>) json8) : (WebAPI.Response.GachaG007PanelPayResult) null);
        this.result = g007PanelPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG007PanelPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG007PanelPayResult()
      {
      }

      public GachaG007PanelPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG1035GiftMultiPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public AnimationPatternMultiAfter[] animation_pattern_gems;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG1035GiftMultiPayResult[] result;

      public GachaG1035GiftMultiPay()
      {
      }

      public GachaG1035GiftMultiPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<AnimationPatternMultiAfter> patternMultiAfterList = new List<AnimationPatternMultiAfter>();
        foreach (object json2 in (List<object>) json[nameof (animation_pattern_gems)])
          patternMultiAfterList.Add(json2 != null ? new AnimationPatternMultiAfter((Dictionary<string, object>) json2) : (AnimationPatternMultiAfter) null);
        this.animation_pattern_gems = patternMultiAfterList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json4 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json4 != null ? new UnlockQuest((Dictionary<string, object>) json4) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json5 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json5 != null ? new TicketBanner((Dictionary<string, object>) json5) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json6 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json6 != null ? new GachaModule((Dictionary<string, object>) json6) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json7 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json7 != null ? new PlayerPresent((Dictionary<string, object>) json7) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG1035GiftMultiPayResult> giftMultiPayResultList = new List<WebAPI.Response.GachaG1035GiftMultiPayResult>();
        foreach (object json8 in (List<object>) json[nameof (result)])
          giftMultiPayResultList.Add(json8 != null ? new WebAPI.Response.GachaG1035GiftMultiPayResult((Dictionary<string, object>) json8) : (WebAPI.Response.GachaG1035GiftMultiPayResult) null);
        this.result = giftMultiPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG1035GiftMultiPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG1035GiftMultiPayResult()
      {
      }

      public GachaG1035GiftMultiPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG1035GiftPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG1035GiftPayResult[] result;

      public GachaG1035GiftPay()
      {
      }

      public GachaG1035GiftPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json3 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json3 != null ? new UnlockQuest((Dictionary<string, object>) json3) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json4 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json4 != null ? new TicketBanner((Dictionary<string, object>) json4) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json5 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json5 != null ? new GachaModule((Dictionary<string, object>) json5) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json6 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json6 != null ? new PlayerPresent((Dictionary<string, object>) json6) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG1035GiftPayResult> g1035GiftPayResultList = new List<WebAPI.Response.GachaG1035GiftPayResult>();
        foreach (object json7 in (List<object>) json[nameof (result)])
          g1035GiftPayResultList.Add(json7 != null ? new WebAPI.Response.GachaG1035GiftPayResult((Dictionary<string, object>) json7) : (WebAPI.Response.GachaG1035GiftPayResult) null);
        this.result = g1035GiftPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG1035GiftPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG1035GiftPayResult()
      {
      }

      public GachaG1035GiftPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG3032ChargeMultiPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public AnimationPatternMultiAfter[] animation_pattern_gems;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG3032ChargeMultiPayResult[] result;

      public GachaG3032ChargeMultiPay()
      {
      }

      public GachaG3032ChargeMultiPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<AnimationPatternMultiAfter> patternMultiAfterList = new List<AnimationPatternMultiAfter>();
        foreach (object json2 in (List<object>) json[nameof (animation_pattern_gems)])
          patternMultiAfterList.Add(json2 != null ? new AnimationPatternMultiAfter((Dictionary<string, object>) json2) : (AnimationPatternMultiAfter) null);
        this.animation_pattern_gems = patternMultiAfterList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json4 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json4 != null ? new UnlockQuest((Dictionary<string, object>) json4) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json5 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json5 != null ? new TicketBanner((Dictionary<string, object>) json5) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json6 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json6 != null ? new GachaModule((Dictionary<string, object>) json6) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json7 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json7 != null ? new PlayerPresent((Dictionary<string, object>) json7) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG3032ChargeMultiPayResult> chargeMultiPayResultList = new List<WebAPI.Response.GachaG3032ChargeMultiPayResult>();
        foreach (object json8 in (List<object>) json[nameof (result)])
          chargeMultiPayResultList.Add(json8 != null ? new WebAPI.Response.GachaG3032ChargeMultiPayResult((Dictionary<string, object>) json8) : (WebAPI.Response.GachaG3032ChargeMultiPayResult) null);
        this.result = chargeMultiPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG3032ChargeMultiPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG3032ChargeMultiPayResult()
      {
      }

      public GachaG3032ChargeMultiPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG3032ChargePay : KeyCompare
    {
      public PlayerItem[] player_items;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG3032ChargePayResult[] result;

      public GachaG3032ChargePay()
      {
      }

      public GachaG3032ChargePay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json3 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json3 != null ? new UnlockQuest((Dictionary<string, object>) json3) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json4 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json4 != null ? new TicketBanner((Dictionary<string, object>) json4) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json5 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json5 != null ? new GachaModule((Dictionary<string, object>) json5) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json6 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json6 != null ? new PlayerPresent((Dictionary<string, object>) json6) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG3032ChargePayResult> g3032ChargePayResultList = new List<WebAPI.Response.GachaG3032ChargePayResult>();
        foreach (object json7 in (List<object>) json[nameof (result)])
          g3032ChargePayResultList.Add(json7 != null ? new WebAPI.Response.GachaG3032ChargePayResult((Dictionary<string, object>) json7) : (WebAPI.Response.GachaG3032ChargePayResult) null);
        this.result = g3032ChargePayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG3032ChargePayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG3032ChargePayResult()
      {
      }

      public GachaG3032ChargePayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG3034ChargeMultiPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public AnimationPatternMultiAfter[] animation_pattern_gems;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG3034ChargeMultiPayResult[] result;

      public GachaG3034ChargeMultiPay()
      {
      }

      public GachaG3034ChargeMultiPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<AnimationPatternMultiAfter> patternMultiAfterList = new List<AnimationPatternMultiAfter>();
        foreach (object json2 in (List<object>) json[nameof (animation_pattern_gems)])
          patternMultiAfterList.Add(json2 != null ? new AnimationPatternMultiAfter((Dictionary<string, object>) json2) : (AnimationPatternMultiAfter) null);
        this.animation_pattern_gems = patternMultiAfterList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json4 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json4 != null ? new UnlockQuest((Dictionary<string, object>) json4) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json5 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json5 != null ? new TicketBanner((Dictionary<string, object>) json5) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json6 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json6 != null ? new GachaModule((Dictionary<string, object>) json6) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json7 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json7 != null ? new PlayerPresent((Dictionary<string, object>) json7) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG3034ChargeMultiPayResult> chargeMultiPayResultList = new List<WebAPI.Response.GachaG3034ChargeMultiPayResult>();
        foreach (object json8 in (List<object>) json[nameof (result)])
          chargeMultiPayResultList.Add(json8 != null ? new WebAPI.Response.GachaG3034ChargeMultiPayResult((Dictionary<string, object>) json8) : (WebAPI.Response.GachaG3034ChargeMultiPayResult) null);
        this.result = chargeMultiPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG3034ChargeMultiPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG3034ChargeMultiPayResult()
      {
      }

      public GachaG3034ChargeMultiPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG3034ChargePay : KeyCompare
    {
      public PlayerItem[] player_items;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG3034ChargePayResult[] result;

      public GachaG3034ChargePay()
      {
      }

      public GachaG3034ChargePay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json3 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json3 != null ? new UnlockQuest((Dictionary<string, object>) json3) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json4 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json4 != null ? new TicketBanner((Dictionary<string, object>) json4) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json5 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json5 != null ? new GachaModule((Dictionary<string, object>) json5) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json6 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json6 != null ? new PlayerPresent((Dictionary<string, object>) json6) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG3034ChargePayResult> g3034ChargePayResultList = new List<WebAPI.Response.GachaG3034ChargePayResult>();
        foreach (object json7 in (List<object>) json[nameof (result)])
          g3034ChargePayResultList.Add(json7 != null ? new WebAPI.Response.GachaG3034ChargePayResult((Dictionary<string, object>) json7) : (WebAPI.Response.GachaG3034ChargePayResult) null);
        this.result = g3034ChargePayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG3034ChargePayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG3034ChargePayResult()
      {
      }

      public GachaG3034ChargePayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG4103StepupMultiPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public AnimationPatternMultiAfter[] animation_pattern_gems;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG4103StepupMultiPayResult[] result;

      public GachaG4103StepupMultiPay()
      {
      }

      public GachaG4103StepupMultiPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<AnimationPatternMultiAfter> patternMultiAfterList = new List<AnimationPatternMultiAfter>();
        foreach (object json2 in (List<object>) json[nameof (animation_pattern_gems)])
          patternMultiAfterList.Add(json2 != null ? new AnimationPatternMultiAfter((Dictionary<string, object>) json2) : (AnimationPatternMultiAfter) null);
        this.animation_pattern_gems = patternMultiAfterList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json4 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json4 != null ? new UnlockQuest((Dictionary<string, object>) json4) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json5 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json5 != null ? new TicketBanner((Dictionary<string, object>) json5) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json6 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json6 != null ? new GachaModule((Dictionary<string, object>) json6) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json7 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json7 != null ? new PlayerPresent((Dictionary<string, object>) json7) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG4103StepupMultiPayResult> stepupMultiPayResultList = new List<WebAPI.Response.GachaG4103StepupMultiPayResult>();
        foreach (object json8 in (List<object>) json[nameof (result)])
          stepupMultiPayResultList.Add(json8 != null ? new WebAPI.Response.GachaG4103StepupMultiPayResult((Dictionary<string, object>) json8) : (WebAPI.Response.GachaG4103StepupMultiPayResult) null);
        this.result = stepupMultiPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG4103StepupMultiPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG4103StepupMultiPayResult()
      {
      }

      public GachaG4103StepupMultiPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG4103StepupPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG4103StepupPayResult[] result;

      public GachaG4103StepupPay()
      {
      }

      public GachaG4103StepupPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json3 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json3 != null ? new UnlockQuest((Dictionary<string, object>) json3) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json4 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json4 != null ? new TicketBanner((Dictionary<string, object>) json4) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json5 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json5 != null ? new GachaModule((Dictionary<string, object>) json5) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json6 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json6 != null ? new PlayerPresent((Dictionary<string, object>) json6) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG4103StepupPayResult> g4103StepupPayResultList = new List<WebAPI.Response.GachaG4103StepupPayResult>();
        foreach (object json7 in (List<object>) json[nameof (result)])
          g4103StepupPayResultList.Add(json7 != null ? new WebAPI.Response.GachaG4103StepupPayResult((Dictionary<string, object>) json7) : (WebAPI.Response.GachaG4103StepupPayResult) null);
        this.result = g4103StepupPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG4103StepupPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG4103StepupPayResult()
      {
      }

      public GachaG4103StepupPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG4104StepupMultiPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public AnimationPatternMultiAfter[] animation_pattern_gems;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG4104StepupMultiPayResult[] result;

      public GachaG4104StepupMultiPay()
      {
      }

      public GachaG4104StepupMultiPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<AnimationPatternMultiAfter> patternMultiAfterList = new List<AnimationPatternMultiAfter>();
        foreach (object json2 in (List<object>) json[nameof (animation_pattern_gems)])
          patternMultiAfterList.Add(json2 != null ? new AnimationPatternMultiAfter((Dictionary<string, object>) json2) : (AnimationPatternMultiAfter) null);
        this.animation_pattern_gems = patternMultiAfterList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json4 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json4 != null ? new UnlockQuest((Dictionary<string, object>) json4) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json5 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json5 != null ? new TicketBanner((Dictionary<string, object>) json5) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json6 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json6 != null ? new GachaModule((Dictionary<string, object>) json6) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json7 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json7 != null ? new PlayerPresent((Dictionary<string, object>) json7) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG4104StepupMultiPayResult> stepupMultiPayResultList = new List<WebAPI.Response.GachaG4104StepupMultiPayResult>();
        foreach (object json8 in (List<object>) json[nameof (result)])
          stepupMultiPayResultList.Add(json8 != null ? new WebAPI.Response.GachaG4104StepupMultiPayResult((Dictionary<string, object>) json8) : (WebAPI.Response.GachaG4104StepupMultiPayResult) null);
        this.result = stepupMultiPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG4104StepupMultiPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG4104StepupMultiPayResult()
      {
      }

      public GachaG4104StepupMultiPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG4104StepupPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG4104StepupPayResult[] result;

      public GachaG4104StepupPay()
      {
      }

      public GachaG4104StepupPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json3 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json3 != null ? new UnlockQuest((Dictionary<string, object>) json3) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json4 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json4 != null ? new TicketBanner((Dictionary<string, object>) json4) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json5 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json5 != null ? new GachaModule((Dictionary<string, object>) json5) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json6 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json6 != null ? new PlayerPresent((Dictionary<string, object>) json6) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG4104StepupPayResult> g4104StepupPayResultList = new List<WebAPI.Response.GachaG4104StepupPayResult>();
        foreach (object json7 in (List<object>) json[nameof (result)])
          g4104StepupPayResultList.Add(json7 != null ? new WebAPI.Response.GachaG4104StepupPayResult((Dictionary<string, object>) json7) : (WebAPI.Response.GachaG4104StepupPayResult) null);
        this.result = g4104StepupPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG4104StepupPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG4104StepupPayResult()
      {
      }

      public GachaG4104StepupPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG4105StepupMultiPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public AnimationPatternMultiAfter[] animation_pattern_gems;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG4105StepupMultiPayResult[] result;

      public GachaG4105StepupMultiPay()
      {
      }

      public GachaG4105StepupMultiPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<AnimationPatternMultiAfter> patternMultiAfterList = new List<AnimationPatternMultiAfter>();
        foreach (object json2 in (List<object>) json[nameof (animation_pattern_gems)])
          patternMultiAfterList.Add(json2 != null ? new AnimationPatternMultiAfter((Dictionary<string, object>) json2) : (AnimationPatternMultiAfter) null);
        this.animation_pattern_gems = patternMultiAfterList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json4 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json4 != null ? new UnlockQuest((Dictionary<string, object>) json4) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json5 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json5 != null ? new TicketBanner((Dictionary<string, object>) json5) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json6 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json6 != null ? new GachaModule((Dictionary<string, object>) json6) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json7 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json7 != null ? new PlayerPresent((Dictionary<string, object>) json7) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG4105StepupMultiPayResult> stepupMultiPayResultList = new List<WebAPI.Response.GachaG4105StepupMultiPayResult>();
        foreach (object json8 in (List<object>) json[nameof (result)])
          stepupMultiPayResultList.Add(json8 != null ? new WebAPI.Response.GachaG4105StepupMultiPayResult((Dictionary<string, object>) json8) : (WebAPI.Response.GachaG4105StepupMultiPayResult) null);
        this.result = stepupMultiPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG4105StepupMultiPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG4105StepupMultiPayResult()
      {
      }

      public GachaG4105StepupMultiPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG4105StepupPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG4105StepupPayResult[] result;

      public GachaG4105StepupPay()
      {
      }

      public GachaG4105StepupPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json3 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json3 != null ? new UnlockQuest((Dictionary<string, object>) json3) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json4 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json4 != null ? new TicketBanner((Dictionary<string, object>) json4) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json5 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json5 != null ? new GachaModule((Dictionary<string, object>) json5) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json6 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json6 != null ? new PlayerPresent((Dictionary<string, object>) json6) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG4105StepupPayResult> g4105StepupPayResultList = new List<WebAPI.Response.GachaG4105StepupPayResult>();
        foreach (object json7 in (List<object>) json[nameof (result)])
          g4105StepupPayResultList.Add(json7 != null ? new WebAPI.Response.GachaG4105StepupPayResult((Dictionary<string, object>) json7) : (WebAPI.Response.GachaG4105StepupPayResult) null);
        this.result = g4105StepupPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG4105StepupPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG4105StepupPayResult()
      {
      }

      public GachaG4105StepupPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG4106StepupMultiPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public AnimationPatternMultiAfter[] animation_pattern_gems;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG4106StepupMultiPayResult[] result;

      public GachaG4106StepupMultiPay()
      {
      }

      public GachaG4106StepupMultiPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<AnimationPatternMultiAfter> patternMultiAfterList = new List<AnimationPatternMultiAfter>();
        foreach (object json2 in (List<object>) json[nameof (animation_pattern_gems)])
          patternMultiAfterList.Add(json2 != null ? new AnimationPatternMultiAfter((Dictionary<string, object>) json2) : (AnimationPatternMultiAfter) null);
        this.animation_pattern_gems = patternMultiAfterList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json4 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json4 != null ? new UnlockQuest((Dictionary<string, object>) json4) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json5 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json5 != null ? new TicketBanner((Dictionary<string, object>) json5) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json6 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json6 != null ? new GachaModule((Dictionary<string, object>) json6) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json7 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json7 != null ? new PlayerPresent((Dictionary<string, object>) json7) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG4106StepupMultiPayResult> stepupMultiPayResultList = new List<WebAPI.Response.GachaG4106StepupMultiPayResult>();
        foreach (object json8 in (List<object>) json[nameof (result)])
          stepupMultiPayResultList.Add(json8 != null ? new WebAPI.Response.GachaG4106StepupMultiPayResult((Dictionary<string, object>) json8) : (WebAPI.Response.GachaG4106StepupMultiPayResult) null);
        this.result = stepupMultiPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG4106StepupMultiPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG4106StepupMultiPayResult()
      {
      }

      public GachaG4106StepupMultiPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG4106StepupPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG4106StepupPayResult[] result;

      public GachaG4106StepupPay()
      {
      }

      public GachaG4106StepupPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json3 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json3 != null ? new UnlockQuest((Dictionary<string, object>) json3) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json4 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json4 != null ? new TicketBanner((Dictionary<string, object>) json4) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json5 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json5 != null ? new GachaModule((Dictionary<string, object>) json5) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json6 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json6 != null ? new PlayerPresent((Dictionary<string, object>) json6) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG4106StepupPayResult> g4106StepupPayResultList = new List<WebAPI.Response.GachaG4106StepupPayResult>();
        foreach (object json7 in (List<object>) json[nameof (result)])
          g4106StepupPayResultList.Add(json7 != null ? new WebAPI.Response.GachaG4106StepupPayResult((Dictionary<string, object>) json7) : (WebAPI.Response.GachaG4106StepupPayResult) null);
        this.result = g4106StepupPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG4106StepupPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG4106StepupPayResult()
      {
      }

      public GachaG4106StepupPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG5001FriendpointMultiPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public AnimationPatternMultiAfter[] animation_pattern_gems;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG5001FriendpointMultiPayResult[] result;

      public GachaG5001FriendpointMultiPay()
      {
      }

      public GachaG5001FriendpointMultiPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<AnimationPatternMultiAfter> patternMultiAfterList = new List<AnimationPatternMultiAfter>();
        foreach (object json2 in (List<object>) json[nameof (animation_pattern_gems)])
          patternMultiAfterList.Add(json2 != null ? new AnimationPatternMultiAfter((Dictionary<string, object>) json2) : (AnimationPatternMultiAfter) null);
        this.animation_pattern_gems = patternMultiAfterList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json4 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json4 != null ? new UnlockQuest((Dictionary<string, object>) json4) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json5 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json5 != null ? new TicketBanner((Dictionary<string, object>) json5) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json6 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json6 != null ? new GachaModule((Dictionary<string, object>) json6) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json7 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json7 != null ? new PlayerPresent((Dictionary<string, object>) json7) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG5001FriendpointMultiPayResult> friendpointMultiPayResultList = new List<WebAPI.Response.GachaG5001FriendpointMultiPayResult>();
        foreach (object json8 in (List<object>) json[nameof (result)])
          friendpointMultiPayResultList.Add(json8 != null ? new WebAPI.Response.GachaG5001FriendpointMultiPayResult((Dictionary<string, object>) json8) : (WebAPI.Response.GachaG5001FriendpointMultiPayResult) null);
        this.result = friendpointMultiPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG5001FriendpointMultiPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG5001FriendpointMultiPayResult()
      {
      }

      public GachaG5001FriendpointMultiPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class GachaG5001FriendpointPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public Player player;
      public PlayerUnit[] player_units;
      public UnlockQuest[] unlock_quests;
      public TicketBanner[] g004_banner_info;
      public GachaModule[] gacha_modules;
      public string[] animation_pattern;
      public PlayerPresent[] player_presents;
      public WebAPI.Response.GachaG5001FriendpointPayResult[] result;

      public GachaG5001FriendpointPay()
      {
      }

      public GachaG5001FriendpointPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json3 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json3 != null ? new UnlockQuest((Dictionary<string, object>) json3) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        List<TicketBanner> ticketBannerList = new List<TicketBanner>();
        foreach (object json4 in (List<object>) json[nameof (g004_banner_info)])
          ticketBannerList.Add(json4 != null ? new TicketBanner((Dictionary<string, object>) json4) : (TicketBanner) null);
        this.g004_banner_info = ticketBannerList.ToArray();
        SMManager.UpdateList<TicketBanner>(this.g004_banner_info);
        List<GachaModule> gachaModuleList = new List<GachaModule>();
        foreach (object json5 in (List<object>) json[nameof (gacha_modules)])
          gachaModuleList.Add(json5 != null ? new GachaModule((Dictionary<string, object>) json5) : (GachaModule) null);
        this.gacha_modules = gachaModuleList.ToArray();
        SMManager.UpdateList<GachaModule>(this.gacha_modules);
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json6 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json6 != null ? new PlayerPresent((Dictionary<string, object>) json6) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<WebAPI.Response.GachaG5001FriendpointPayResult> friendpointPayResultList = new List<WebAPI.Response.GachaG5001FriendpointPayResult>();
        foreach (object json7 in (List<object>) json[nameof (result)])
          friendpointPayResultList.Add(json7 != null ? new WebAPI.Response.GachaG5001FriendpointPayResult((Dictionary<string, object>) json7) : (WebAPI.Response.GachaG5001FriendpointPayResult) null);
        this.result = friendpointPayResultList.ToArray();
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class GachaG5001FriendpointPayResult : KeyCompare
    {
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public GachaG5001FriendpointPayResult()
      {
      }

      public GachaG5001FriendpointPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class Gamekit : KeyCompare
    {
      public PlayerGameKitAchievement[] achievements;
      public PlayerGameKitLeaderboard[] leaderboards;

      public Gamekit()
      {
      }

      public Gamekit(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerGameKitAchievement> gameKitAchievementList = new List<PlayerGameKitAchievement>();
        foreach (object json1 in (List<object>) json[nameof (achievements)])
          gameKitAchievementList.Add(json1 != null ? new PlayerGameKitAchievement((Dictionary<string, object>) json1) : (PlayerGameKitAchievement) null);
        this.achievements = gameKitAchievementList.ToArray();
        SMManager.UpdateList<PlayerGameKitAchievement>(this.achievements);
        List<PlayerGameKitLeaderboard> gameKitLeaderboardList = new List<PlayerGameKitLeaderboard>();
        foreach (object json2 in (List<object>) json[nameof (leaderboards)])
          gameKitLeaderboardList.Add(json2 != null ? new PlayerGameKitLeaderboard((Dictionary<string, object>) json2) : (PlayerGameKitLeaderboard) null);
        this.leaderboards = gameKitLeaderboardList.ToArray();
        SMManager.UpdateList<PlayerGameKitLeaderboard>(this.leaderboards);
      }
    }

    [Serializable]
    public class HomeHome : KeyCompare
    {
      public PlayerUnitHistory[] player_unit_histories;
      public PlayerCharacterIntimate[] player_character_intimates;
      public PlayerUnit[] player_units;
      public PlayerHelper[] player_helpers;
      public PlayerDeck[] player_decks;
      public PlayerExtraQuestS[] player_extra_quests;
      public CoinBonus[] coin_bonuses;
      public PlayerItem[] player_items;
      public PlayerMissionHistory[] player_mission_histories;
      public Player player;
      public PlayerItemHistory[] player_item_histories;
      public PlayerStoryQuestS[] player_story_quests;
      public PlayerFriend[] player_friends;
      public SM.Banner[] banners;
      public PlayerPresent[] player_presents;
      public PlayerQuestKey[] player_quest_keys;

      public HomeHome()
      {
      }

      public HomeHome(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerUnitHistory> playerUnitHistoryList = new List<PlayerUnitHistory>();
        foreach (object json1 in (List<object>) json[nameof (player_unit_histories)])
          playerUnitHistoryList.Add(json1 != null ? new PlayerUnitHistory((Dictionary<string, object>) json1) : (PlayerUnitHistory) null);
        this.player_unit_histories = playerUnitHistoryList.ToArray();
        SMManager.UpdateList<PlayerUnitHistory>(this.player_unit_histories);
        List<PlayerCharacterIntimate> characterIntimateList = new List<PlayerCharacterIntimate>();
        foreach (object json2 in (List<object>) json[nameof (player_character_intimates)])
          characterIntimateList.Add(json2 != null ? new PlayerCharacterIntimate((Dictionary<string, object>) json2) : (PlayerCharacterIntimate) null);
        this.player_character_intimates = characterIntimateList.ToArray();
        SMManager.UpdateList<PlayerCharacterIntimate>(this.player_character_intimates);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
        foreach (object json4 in (List<object>) json[nameof (player_helpers)])
          playerHelperList.Add(json4 != null ? new PlayerHelper((Dictionary<string, object>) json4) : (PlayerHelper) null);
        this.player_helpers = playerHelperList.ToArray();
        SMManager.UpdateList<PlayerHelper>(this.player_helpers);
        List<PlayerDeck> playerDeckList = new List<PlayerDeck>();
        foreach (object json5 in (List<object>) json[nameof (player_decks)])
          playerDeckList.Add(json5 != null ? new PlayerDeck((Dictionary<string, object>) json5) : (PlayerDeck) null);
        this.player_decks = playerDeckList.ToArray();
        SMManager.UpdateList<PlayerDeck>(this.player_decks);
        List<PlayerExtraQuestS> playerExtraQuestSList = new List<PlayerExtraQuestS>();
        foreach (object json6 in (List<object>) json[nameof (player_extra_quests)])
          playerExtraQuestSList.Add(json6 != null ? new PlayerExtraQuestS((Dictionary<string, object>) json6) : (PlayerExtraQuestS) null);
        this.player_extra_quests = playerExtraQuestSList.ToArray();
        SMManager.UpdateList<PlayerExtraQuestS>(this.player_extra_quests);
        List<CoinBonus> coinBonusList = new List<CoinBonus>();
        foreach (object json7 in (List<object>) json[nameof (coin_bonuses)])
          coinBonusList.Add(json7 != null ? new CoinBonus((Dictionary<string, object>) json7) : (CoinBonus) null);
        this.coin_bonuses = coinBonusList.ToArray();
        SMManager.UpdateList<CoinBonus>(this.coin_bonuses);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json8 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json8 != null ? new PlayerItem((Dictionary<string, object>) json8) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<PlayerMissionHistory> playerMissionHistoryList = new List<PlayerMissionHistory>();
        foreach (object json9 in (List<object>) json[nameof (player_mission_histories)])
          playerMissionHistoryList.Add(json9 != null ? new PlayerMissionHistory((Dictionary<string, object>) json9) : (PlayerMissionHistory) null);
        this.player_mission_histories = playerMissionHistoryList.ToArray();
        SMManager.UpdateList<PlayerMissionHistory>(this.player_mission_histories);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerItemHistory> playerItemHistoryList = new List<PlayerItemHistory>();
        foreach (object json10 in (List<object>) json[nameof (player_item_histories)])
          playerItemHistoryList.Add(json10 != null ? new PlayerItemHistory((Dictionary<string, object>) json10) : (PlayerItemHistory) null);
        this.player_item_histories = playerItemHistoryList.ToArray();
        SMManager.UpdateList<PlayerItemHistory>(this.player_item_histories);
        List<PlayerStoryQuestS> playerStoryQuestSList = new List<PlayerStoryQuestS>();
        foreach (object json11 in (List<object>) json[nameof (player_story_quests)])
          playerStoryQuestSList.Add(json11 != null ? new PlayerStoryQuestS((Dictionary<string, object>) json11) : (PlayerStoryQuestS) null);
        this.player_story_quests = playerStoryQuestSList.ToArray();
        SMManager.UpdateList<PlayerStoryQuestS>(this.player_story_quests);
        List<PlayerFriend> playerFriendList = new List<PlayerFriend>();
        foreach (object json12 in (List<object>) json[nameof (player_friends)])
          playerFriendList.Add(json12 != null ? new PlayerFriend((Dictionary<string, object>) json12) : (PlayerFriend) null);
        this.player_friends = playerFriendList.ToArray();
        SMManager.UpdateList<PlayerFriend>(this.player_friends);
        List<SM.Banner> bannerList = new List<SM.Banner>();
        foreach (object json13 in (List<object>) json[nameof (banners)])
          bannerList.Add(json13 != null ? new SM.Banner((Dictionary<string, object>) json13) : (SM.Banner) null);
        this.banners = bannerList.ToArray();
        SMManager.UpdateList<SM.Banner>(this.banners);
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json14 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json14 != null ? new PlayerPresent((Dictionary<string, object>) json14) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<PlayerQuestKey> playerQuestKeyList = new List<PlayerQuestKey>();
        foreach (object json15 in (List<object>) json[nameof (player_quest_keys)])
          playerQuestKeyList.Add(json15 != null ? new PlayerQuestKey((Dictionary<string, object>) json15) : (PlayerQuestKey) null);
        this.player_quest_keys = playerQuestKeyList.ToArray();
        SMManager.UpdateList<PlayerQuestKey>(this.player_quest_keys);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class HomeNow : KeyCompare
    {
      public DateTime now;

      public HomeNow()
      {
      }

      public HomeNow(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.now = DateTime.Parse((string) json[nameof (now)]);
      }
    }

    [Serializable]
    public class HomeStartUp : KeyCompare
    {
      public PlayerItemHistory[] player_item_histories;
      public PlayerQuestGate[] quest_gates;
      public CoinBonus[] coin_bonuses;
      public DateTime last_signed_in_at;
      public Player player;
      public PlayerQuestKey[] player_quest_keys;
      public PlayerLoginBonus[] player_loginbonuses;
      public PlayerExtraQuestS[] player_extra_quests;
      public PlayerHelper[] player_helpers;
      public LevelRewardSchemaMixin[] player_achieve_level_rewards;
      public PlayerUnit[] player_units;
      public PlayerDeck[] player_decks;
      public PlayerItem[] player_items;
      public PlayerPresent[] player_presents;
      public OfficialInformationArticle[] articles;
      public PlayerCharacterIntimate[] player_character_intimates;
      public PlayerUnitHistory[] player_unit_histories;
      public PlayerMissionHistory[] player_mission_histories;
      public DeviceReward[] device_rewards;
      public PlayerFriend[] player_friends;
      public SM.Banner[] banners;
      public PlayerStoryQuestS[] player_story_quests;

      public HomeStartUp()
      {
      }

      public HomeStartUp(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItemHistory> playerItemHistoryList = new List<PlayerItemHistory>();
        foreach (object json1 in (List<object>) json[nameof (player_item_histories)])
          playerItemHistoryList.Add(json1 != null ? new PlayerItemHistory((Dictionary<string, object>) json1) : (PlayerItemHistory) null);
        this.player_item_histories = playerItemHistoryList.ToArray();
        SMManager.UpdateList<PlayerItemHistory>(this.player_item_histories);
        List<PlayerQuestGate> playerQuestGateList = new List<PlayerQuestGate>();
        foreach (object json2 in (List<object>) json[nameof (quest_gates)])
          playerQuestGateList.Add(json2 != null ? new PlayerQuestGate((Dictionary<string, object>) json2) : (PlayerQuestGate) null);
        this.quest_gates = playerQuestGateList.ToArray();
        SMManager.UpdateList<PlayerQuestGate>(this.quest_gates);
        List<CoinBonus> coinBonusList = new List<CoinBonus>();
        foreach (object json3 in (List<object>) json[nameof (coin_bonuses)])
          coinBonusList.Add(json3 != null ? new CoinBonus((Dictionary<string, object>) json3) : (CoinBonus) null);
        this.coin_bonuses = coinBonusList.ToArray();
        SMManager.UpdateList<CoinBonus>(this.coin_bonuses);
        this.last_signed_in_at = DateTime.Parse((string) json[nameof (last_signed_in_at)]);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerQuestKey> playerQuestKeyList = new List<PlayerQuestKey>();
        foreach (object json4 in (List<object>) json[nameof (player_quest_keys)])
          playerQuestKeyList.Add(json4 != null ? new PlayerQuestKey((Dictionary<string, object>) json4) : (PlayerQuestKey) null);
        this.player_quest_keys = playerQuestKeyList.ToArray();
        SMManager.UpdateList<PlayerQuestKey>(this.player_quest_keys);
        List<PlayerLoginBonus> playerLoginBonusList = new List<PlayerLoginBonus>();
        foreach (object json5 in (List<object>) json[nameof (player_loginbonuses)])
          playerLoginBonusList.Add(json5 != null ? new PlayerLoginBonus((Dictionary<string, object>) json5) : (PlayerLoginBonus) null);
        this.player_loginbonuses = playerLoginBonusList.ToArray();
        List<PlayerExtraQuestS> playerExtraQuestSList = new List<PlayerExtraQuestS>();
        foreach (object json6 in (List<object>) json[nameof (player_extra_quests)])
          playerExtraQuestSList.Add(json6 != null ? new PlayerExtraQuestS((Dictionary<string, object>) json6) : (PlayerExtraQuestS) null);
        this.player_extra_quests = playerExtraQuestSList.ToArray();
        SMManager.UpdateList<PlayerExtraQuestS>(this.player_extra_quests);
        List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
        foreach (object json7 in (List<object>) json[nameof (player_helpers)])
          playerHelperList.Add(json7 != null ? new PlayerHelper((Dictionary<string, object>) json7) : (PlayerHelper) null);
        this.player_helpers = playerHelperList.ToArray();
        SMManager.UpdateList<PlayerHelper>(this.player_helpers);
        List<LevelRewardSchemaMixin> rewardSchemaMixinList = new List<LevelRewardSchemaMixin>();
        foreach (object json8 in (List<object>) json[nameof (player_achieve_level_rewards)])
          rewardSchemaMixinList.Add(json8 != null ? new LevelRewardSchemaMixin((Dictionary<string, object>) json8) : (LevelRewardSchemaMixin) null);
        this.player_achieve_level_rewards = rewardSchemaMixinList.ToArray();
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json9 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json9 != null ? new PlayerUnit((Dictionary<string, object>) json9) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<PlayerDeck> playerDeckList = new List<PlayerDeck>();
        foreach (object json10 in (List<object>) json[nameof (player_decks)])
          playerDeckList.Add(json10 != null ? new PlayerDeck((Dictionary<string, object>) json10) : (PlayerDeck) null);
        this.player_decks = playerDeckList.ToArray();
        SMManager.UpdateList<PlayerDeck>(this.player_decks);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json11 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json11 != null ? new PlayerItem((Dictionary<string, object>) json11) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json12 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json12 != null ? new PlayerPresent((Dictionary<string, object>) json12) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<OfficialInformationArticle> informationArticleList = new List<OfficialInformationArticle>();
        foreach (object json13 in (List<object>) json[nameof (articles)])
          informationArticleList.Add(json13 != null ? new OfficialInformationArticle((Dictionary<string, object>) json13) : (OfficialInformationArticle) null);
        this.articles = informationArticleList.ToArray();
        SMManager.UpdateList<OfficialInformationArticle>(this.articles);
        List<PlayerCharacterIntimate> characterIntimateList = new List<PlayerCharacterIntimate>();
        foreach (object json14 in (List<object>) json[nameof (player_character_intimates)])
          characterIntimateList.Add(json14 != null ? new PlayerCharacterIntimate((Dictionary<string, object>) json14) : (PlayerCharacterIntimate) null);
        this.player_character_intimates = characterIntimateList.ToArray();
        SMManager.UpdateList<PlayerCharacterIntimate>(this.player_character_intimates);
        List<PlayerUnitHistory> playerUnitHistoryList = new List<PlayerUnitHistory>();
        foreach (object json15 in (List<object>) json[nameof (player_unit_histories)])
          playerUnitHistoryList.Add(json15 != null ? new PlayerUnitHistory((Dictionary<string, object>) json15) : (PlayerUnitHistory) null);
        this.player_unit_histories = playerUnitHistoryList.ToArray();
        SMManager.UpdateList<PlayerUnitHistory>(this.player_unit_histories);
        List<PlayerMissionHistory> playerMissionHistoryList = new List<PlayerMissionHistory>();
        foreach (object json16 in (List<object>) json[nameof (player_mission_histories)])
          playerMissionHistoryList.Add(json16 != null ? new PlayerMissionHistory((Dictionary<string, object>) json16) : (PlayerMissionHistory) null);
        this.player_mission_histories = playerMissionHistoryList.ToArray();
        SMManager.UpdateList<PlayerMissionHistory>(this.player_mission_histories);
        List<DeviceReward> deviceRewardList = new List<DeviceReward>();
        foreach (object json17 in (List<object>) json[nameof (device_rewards)])
          deviceRewardList.Add(json17 != null ? new DeviceReward((Dictionary<string, object>) json17) : (DeviceReward) null);
        this.device_rewards = deviceRewardList.ToArray();
        List<PlayerFriend> playerFriendList = new List<PlayerFriend>();
        foreach (object json18 in (List<object>) json[nameof (player_friends)])
          playerFriendList.Add(json18 != null ? new PlayerFriend((Dictionary<string, object>) json18) : (PlayerFriend) null);
        this.player_friends = playerFriendList.ToArray();
        SMManager.UpdateList<PlayerFriend>(this.player_friends);
        List<SM.Banner> bannerList = new List<SM.Banner>();
        foreach (object json19 in (List<object>) json[nameof (banners)])
          bannerList.Add(json19 != null ? new SM.Banner((Dictionary<string, object>) json19) : (SM.Banner) null);
        this.banners = bannerList.ToArray();
        SMManager.UpdateList<SM.Banner>(this.banners);
        List<PlayerStoryQuestS> playerStoryQuestSList = new List<PlayerStoryQuestS>();
        foreach (object json20 in (List<object>) json[nameof (player_story_quests)])
          playerStoryQuestSList.Add(json20 != null ? new PlayerStoryQuestS((Dictionary<string, object>) json20) : (PlayerStoryQuestS) null);
        this.player_story_quests = playerStoryQuestSList.ToArray();
        SMManager.UpdateList<PlayerStoryQuestS>(this.player_story_quests);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class HomeUpdateAllData : KeyCompare
    {
      public PlayerUnitHistory[] player_unit_histories;
      public PlayerCharacterIntimate[] player_character_intimates;
      public PlayerUnit[] player_units;
      public PlayerHelper[] player_helpers;
      public PlayerDeck[] player_decks;
      public PlayerExtraQuestS[] player_extra_quests;
      public PlayerItemHistory[] player_item_histories;
      public PlayerItem[] player_items;
      public PlayerMissionHistory[] player_mission_histories;
      public Player player;
      public PlayerStoryQuestS[] player_story_quests;
      public PlayerFriend[] player_friends;
      public PlayerQuestGate[] quest_gates;
      public PlayerPresent[] player_presents;
      public PlayerQuestKey[] player_quest_keys;

      public HomeUpdateAllData()
      {
      }

      public HomeUpdateAllData(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerUnitHistory> playerUnitHistoryList = new List<PlayerUnitHistory>();
        foreach (object json1 in (List<object>) json[nameof (player_unit_histories)])
          playerUnitHistoryList.Add(json1 != null ? new PlayerUnitHistory((Dictionary<string, object>) json1) : (PlayerUnitHistory) null);
        this.player_unit_histories = playerUnitHistoryList.ToArray();
        SMManager.UpdateList<PlayerUnitHistory>(this.player_unit_histories, true);
        List<PlayerCharacterIntimate> characterIntimateList = new List<PlayerCharacterIntimate>();
        foreach (object json2 in (List<object>) json[nameof (player_character_intimates)])
          characterIntimateList.Add(json2 != null ? new PlayerCharacterIntimate((Dictionary<string, object>) json2) : (PlayerCharacterIntimate) null);
        this.player_character_intimates = characterIntimateList.ToArray();
        SMManager.UpdateList<PlayerCharacterIntimate>(this.player_character_intimates, true);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units, true);
        List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
        foreach (object json4 in (List<object>) json[nameof (player_helpers)])
          playerHelperList.Add(json4 != null ? new PlayerHelper((Dictionary<string, object>) json4) : (PlayerHelper) null);
        this.player_helpers = playerHelperList.ToArray();
        SMManager.UpdateList<PlayerHelper>(this.player_helpers, true);
        List<PlayerDeck> playerDeckList = new List<PlayerDeck>();
        foreach (object json5 in (List<object>) json[nameof (player_decks)])
          playerDeckList.Add(json5 != null ? new PlayerDeck((Dictionary<string, object>) json5) : (PlayerDeck) null);
        this.player_decks = playerDeckList.ToArray();
        SMManager.UpdateList<PlayerDeck>(this.player_decks, true);
        List<PlayerExtraQuestS> playerExtraQuestSList = new List<PlayerExtraQuestS>();
        foreach (object json6 in (List<object>) json[nameof (player_extra_quests)])
          playerExtraQuestSList.Add(json6 != null ? new PlayerExtraQuestS((Dictionary<string, object>) json6) : (PlayerExtraQuestS) null);
        this.player_extra_quests = playerExtraQuestSList.ToArray();
        SMManager.UpdateList<PlayerExtraQuestS>(this.player_extra_quests, true);
        List<PlayerItemHistory> playerItemHistoryList = new List<PlayerItemHistory>();
        foreach (object json7 in (List<object>) json[nameof (player_item_histories)])
          playerItemHistoryList.Add(json7 != null ? new PlayerItemHistory((Dictionary<string, object>) json7) : (PlayerItemHistory) null);
        this.player_item_histories = playerItemHistoryList.ToArray();
        SMManager.UpdateList<PlayerItemHistory>(this.player_item_histories, true);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json8 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json8 != null ? new PlayerItem((Dictionary<string, object>) json8) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items, true);
        List<PlayerMissionHistory> playerMissionHistoryList = new List<PlayerMissionHistory>();
        foreach (object json9 in (List<object>) json[nameof (player_mission_histories)])
          playerMissionHistoryList.Add(json9 != null ? new PlayerMissionHistory((Dictionary<string, object>) json9) : (PlayerMissionHistory) null);
        this.player_mission_histories = playerMissionHistoryList.ToArray();
        SMManager.UpdateList<PlayerMissionHistory>(this.player_mission_histories, true);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerStoryQuestS> playerStoryQuestSList = new List<PlayerStoryQuestS>();
        foreach (object json10 in (List<object>) json[nameof (player_story_quests)])
          playerStoryQuestSList.Add(json10 != null ? new PlayerStoryQuestS((Dictionary<string, object>) json10) : (PlayerStoryQuestS) null);
        this.player_story_quests = playerStoryQuestSList.ToArray();
        SMManager.UpdateList<PlayerStoryQuestS>(this.player_story_quests, true);
        List<PlayerFriend> playerFriendList = new List<PlayerFriend>();
        foreach (object json11 in (List<object>) json[nameof (player_friends)])
          playerFriendList.Add(json11 != null ? new PlayerFriend((Dictionary<string, object>) json11) : (PlayerFriend) null);
        this.player_friends = playerFriendList.ToArray();
        SMManager.UpdateList<PlayerFriend>(this.player_friends, true);
        List<PlayerQuestGate> playerQuestGateList = new List<PlayerQuestGate>();
        foreach (object json12 in (List<object>) json[nameof (quest_gates)])
          playerQuestGateList.Add(json12 != null ? new PlayerQuestGate((Dictionary<string, object>) json12) : (PlayerQuestGate) null);
        this.quest_gates = playerQuestGateList.ToArray();
        SMManager.UpdateList<PlayerQuestGate>(this.quest_gates, true);
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json13 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json13 != null ? new PlayerPresent((Dictionary<string, object>) json13) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents, true);
        List<PlayerQuestKey> playerQuestKeyList = new List<PlayerQuestKey>();
        foreach (object json14 in (List<object>) json[nameof (player_quest_keys)])
          playerQuestKeyList.Add(json14 != null ? new PlayerQuestKey((Dictionary<string, object>) json14) : (PlayerQuestKey) null);
        this.player_quest_keys = playerQuestKeyList.ToArray();
        SMManager.UpdateList<PlayerQuestKey>(this.player_quest_keys, true);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class InternalPvpFinish : KeyCompare
    {
      public bool battle_finish;

      public InternalPvpFinish()
      {
      }

      public InternalPvpFinish(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.battle_finish = (bool) json[nameof (battle_finish)];
      }
    }

    [Serializable]
    public class InternalPvpForceClose : KeyCompare
    {
      public bool result;

      public InternalPvpForceClose()
      {
      }

      public InternalPvpForceClose(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.result = (bool) json[nameof (result)];
      }
    }

    [Serializable]
    public class InternalPvpMaintenance : KeyCompare
    {
      public string pvp_maintenance_title;
      public bool pvp_maintenance;
      public string pvp_maintenance_message;

      public InternalPvpMaintenance()
      {
      }

      public InternalPvpMaintenance(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.pvp_maintenance_title = (string) json[nameof (pvp_maintenance_title)];
        this.pvp_maintenance = (bool) json[nameof (pvp_maintenance)];
        this.pvp_maintenance_message = (string) json[nameof (pvp_maintenance_message)];
      }
    }

    [Serializable]
    public class InternalPvpStart : KeyCompare
    {
      public PlayerItem[] player2_items;
      public PlayerUnit[] player2_units;
      public DateTime battle_start_at;
      public string battle_uuid;
      public Bonus[] bonus;
      public bool battle_start;
      public PlayerItem[] player1_items;
      public Player player2;
      public Player player1;
      public PlayerUnit[] player1_units;
      public MpStage stage;

      public InternalPvpStart()
      {
      }

      public InternalPvpStart(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList1 = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player2_items)])
          playerItemList1.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player2_items = playerItemList1.ToArray();
        List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player2_units)])
          playerUnitList1.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player2_units = playerUnitList1.ToArray();
        this.battle_start_at = DateTime.Parse((string) json[nameof (battle_start_at)]);
        this.battle_uuid = (string) json[nameof (battle_uuid)];
        List<Bonus> bonusList = new List<Bonus>();
        foreach (object json3 in (List<object>) json[nameof (bonus)])
          bonusList.Add(json3 != null ? new Bonus((Dictionary<string, object>) json3) : (Bonus) null);
        this.bonus = bonusList.ToArray();
        this.battle_start = (bool) json[nameof (battle_start)];
        List<PlayerItem> playerItemList2 = new List<PlayerItem>();
        foreach (object json4 in (List<object>) json[nameof (player1_items)])
          playerItemList2.Add(json4 != null ? new PlayerItem((Dictionary<string, object>) json4) : (PlayerItem) null);
        this.player1_items = playerItemList2.ToArray();
        this.player2 = json[nameof (player2)] != null ? new Player((Dictionary<string, object>) json[nameof (player2)]) : (Player) null;
        this.player1 = json[nameof (player1)] != null ? new Player((Dictionary<string, object>) json[nameof (player1)]) : (Player) null;
        List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
        foreach (object json5 in (List<object>) json[nameof (player1_units)])
          playerUnitList2.Add(json5 != null ? new PlayerUnit((Dictionary<string, object>) json5) : (PlayerUnit) null);
        this.player1_units = playerUnitList2.ToArray();
        this.stage = json[nameof (stage)] != null ? new MpStage((Dictionary<string, object>) json[nameof (stage)]) : (MpStage) null;
      }
    }

    [Serializable]
    public class InternalPvpStatus : KeyCompare
    {
      public int league_rank;
      public bool is_battle;
      public int point;
      public bool pvp_maintenance;
      public bool auth;
      public string[] friend_ids;

      public InternalPvpStatus()
      {
      }

      public InternalPvpStatus(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.league_rank = (int) (long) json[nameof (league_rank)];
        this.is_battle = (bool) json[nameof (is_battle)];
        this.point = (int) (long) json[nameof (point)];
        this.pvp_maintenance = (bool) json[nameof (pvp_maintenance)];
        this.auth = (bool) json[nameof (auth)];
        this.friend_ids = ((IEnumerable<object>) json[nameof (friend_ids)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
      }
    }

    [Serializable]
    public class InternalPvpTutorialFinish : KeyCompare
    {
      public bool battle_finish;

      public InternalPvpTutorialFinish()
      {
      }

      public InternalPvpTutorialFinish(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.battle_finish = (bool) json[nameof (battle_finish)];
      }
    }

    [Serializable]
    public class InternalPvpTutorialStart : KeyCompare
    {
      public PlayerItem[] player2_items;
      public PlayerUnit[] player2_units;
      public DateTime battle_start_at;
      public string battle_uuid;
      public Bonus[] bonus;
      public bool battle_start;
      public PlayerItem[] player1_items;
      public Player player2;
      public Player player1;
      public PlayerUnit[] player1_units;
      public MpStage stage;

      public InternalPvpTutorialStart()
      {
      }

      public InternalPvpTutorialStart(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList1 = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player2_items)])
          playerItemList1.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player2_items = playerItemList1.ToArray();
        List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player2_units)])
          playerUnitList1.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player2_units = playerUnitList1.ToArray();
        this.battle_start_at = DateTime.Parse((string) json[nameof (battle_start_at)]);
        this.battle_uuid = (string) json[nameof (battle_uuid)];
        List<Bonus> bonusList = new List<Bonus>();
        foreach (object json3 in (List<object>) json[nameof (bonus)])
          bonusList.Add(json3 != null ? new Bonus((Dictionary<string, object>) json3) : (Bonus) null);
        this.bonus = bonusList.ToArray();
        this.battle_start = (bool) json[nameof (battle_start)];
        List<PlayerItem> playerItemList2 = new List<PlayerItem>();
        foreach (object json4 in (List<object>) json[nameof (player1_items)])
          playerItemList2.Add(json4 != null ? new PlayerItem((Dictionary<string, object>) json4) : (PlayerItem) null);
        this.player1_items = playerItemList2.ToArray();
        this.player2 = json[nameof (player2)] != null ? new Player((Dictionary<string, object>) json[nameof (player2)]) : (Player) null;
        this.player1 = json[nameof (player1)] != null ? new Player((Dictionary<string, object>) json[nameof (player1)]) : (Player) null;
        List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
        foreach (object json5 in (List<object>) json[nameof (player1_units)])
          playerUnitList2.Add(json5 != null ? new PlayerUnit((Dictionary<string, object>) json5) : (PlayerUnit) null);
        this.player1_units = playerUnitList2.ToArray();
        this.stage = json[nameof (stage)] != null ? new MpStage((Dictionary<string, object>) json[nameof (stage)]) : (MpStage) null;
      }
    }

    [Serializable]
    public class InvitationAccept : KeyCompare
    {
      public WebAPI.Response.InvitationAcceptRewards[] rewards;
      public bool is_success;
      public PlayerPresent[] player_presents;

      public InvitationAccept()
      {
      }

      public InvitationAccept(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<WebAPI.Response.InvitationAcceptRewards> invitationAcceptRewardsList = new List<WebAPI.Response.InvitationAcceptRewards>();
        foreach (object json1 in (List<object>) json[nameof (rewards)])
          invitationAcceptRewardsList.Add(json1 != null ? new WebAPI.Response.InvitationAcceptRewards((Dictionary<string, object>) json1) : (WebAPI.Response.InvitationAcceptRewards) null);
        this.rewards = invitationAcceptRewardsList.ToArray();
        this.is_success = (bool) json[nameof (is_success)];
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json2 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json2 != null ? new PlayerPresent((Dictionary<string, object>) json2) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class InvitationAcceptRewards : KeyCompare
    {
      public int reward_quantity;
      public int reward_type_id;
      public int reward_id;

      public InvitationAcceptRewards()
      {
      }

      public InvitationAcceptRewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
      }
    }

    [Serializable]
    public class ItemGearBuildup : KeyCompare
    {
      public string[] animation_pattern;
      public Player player;
      public PlayerItem[] player_items;
      public PlayerItem player_item;

      public ItemGearBuildup()
      {
      }

      public ItemGearBuildup(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.player_item = json[nameof (player_item)] != null ? new PlayerItem((Dictionary<string, object>) json[nameof (player_item)]) : (PlayerItem) null;
        if (!json.ContainsKey("player_items:delete"))
          return;
        SMManager.DeleteList<PlayerItem>(((IEnumerable<object>) json["player_items:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class ItemGearCombine : KeyCompare
    {
      public string[] animation_pattern;
      public Player player;
      public PlayerItem[] player_items;
      public PlayerItem player_item;

      public ItemGearCombine()
      {
      }

      public ItemGearCombine(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.player_item = json[nameof (player_item)] != null ? new PlayerItem((Dictionary<string, object>) json[nameof (player_item)]) : (PlayerItem) null;
        if (!json.ContainsKey("player_items:delete"))
          return;
        SMManager.DeleteList<PlayerItem>(((IEnumerable<object>) json["player_items:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class ItemGearDrilling : KeyCompare
    {
      public string[] animation_pattern;
      public Player player;
      public PlayerItem[] player_items;
      public PlayerItem player_item;

      public ItemGearDrilling()
      {
      }

      public ItemGearDrilling(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        this.player_item = json[nameof (player_item)] != null ? new PlayerItem((Dictionary<string, object>) json[nameof (player_item)]) : (PlayerItem) null;
        if (!json.ContainsKey("player_items:delete"))
          return;
        SMManager.DeleteList<PlayerItem>(((IEnumerable<object>) json["player_items:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class ItemGearDrillingConfirm : KeyCompare
    {
      public PlayerItem player_item;
      public int consume_money;

      public ItemGearDrillingConfirm()
      {
      }

      public ItemGearDrillingConfirm(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player_item = json[nameof (player_item)] != null ? new PlayerItem((Dictionary<string, object>) json[nameof (player_item)]) : (PlayerItem) null;
        this.consume_money = (int) (long) json[nameof (consume_money)];
      }
    }

    [Serializable]
    public class ItemGearFavorite : KeyCompare
    {
      public PlayerItem[] player_items;

      public ItemGearFavorite()
      {
      }

      public ItemGearFavorite(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
      }
    }

    [Serializable]
    public class ItemGearPoweredRepair : KeyCompare
    {
      public Player player;
      public PlayerItem[] player_items;
      public WebAPI.Response.ItemGearPoweredRepairRepair_results[] repair_results;
      public PlayerUnit[] player_units;

      public ItemGearPoweredRepair()
      {
      }

      public ItemGearPoweredRepair(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<WebAPI.Response.ItemGearPoweredRepairRepair_results> repairRepairResultsList = new List<WebAPI.Response.ItemGearPoweredRepairRepair_results>();
        foreach (object json2 in (List<object>) json[nameof (repair_results)])
          repairRepairResultsList.Add(json2 != null ? new WebAPI.Response.ItemGearPoweredRepairRepair_results((Dictionary<string, object>) json2) : (WebAPI.Response.ItemGearPoweredRepairRepair_results) null);
        this.repair_results = repairRepairResultsList.ToArray();
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        if (!json.ContainsKey("player_items:delete"))
          return;
        SMManager.DeleteList<PlayerItem>(((IEnumerable<object>) json["player_items:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class ItemGearPoweredRepairRepair_results : KeyCompare
    {
      public int status;
      public int player_gear_id;

      public ItemGearPoweredRepairRepair_results()
      {
      }

      public ItemGearPoweredRepairRepair_results(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.status = (int) (long) json[nameof (status)];
        this.player_gear_id = (int) (long) json[nameof (player_gear_id)];
      }
    }

    [Serializable]
    public class ItemGearRepair : KeyCompare
    {
      public Player player;
      public PlayerItem[] player_items;
      public WebAPI.Response.ItemGearRepairRepair_results[] repair_results;
      public PlayerUnit[] player_units;

      public ItemGearRepair()
      {
      }

      public ItemGearRepair(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<WebAPI.Response.ItemGearRepairRepair_results> repairRepairResultsList = new List<WebAPI.Response.ItemGearRepairRepair_results>();
        foreach (object json2 in (List<object>) json[nameof (repair_results)])
          repairRepairResultsList.Add(json2 != null ? new WebAPI.Response.ItemGearRepairRepair_results((Dictionary<string, object>) json2) : (WebAPI.Response.ItemGearRepairRepair_results) null);
        this.repair_results = repairRepairResultsList.ToArray();
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        if (!json.ContainsKey("player_items:delete"))
          return;
        SMManager.DeleteList<PlayerItem>(((IEnumerable<object>) json["player_items:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class ItemGearRepairRepair_results : KeyCompare
    {
      public int status;
      public int player_gear_id;

      public ItemGearRepairRepair_results()
      {
      }

      public ItemGearRepairRepair_results(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.status = (int) (long) json[nameof (status)];
        this.player_gear_id = (int) (long) json[nameof (player_gear_id)];
      }
    }

    [Serializable]
    public class ItemSell : KeyCompare
    {
      public Player player;
      public PlayerItem[] player_items;

      public ItemSell()
      {
      }

      public ItemSell(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        if (!json.ContainsKey("player_items:delete"))
          return;
        SMManager.DeleteList<PlayerItem>(((IEnumerable<object>) json["player_items:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class ItemSupplyDeckEdit : KeyCompare
    {
      public Player player;
      public PlayerItem[] player_items;

      public ItemSupplyDeckEdit()
      {
      }

      public ItemSupplyDeckEdit(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        if (!json.ContainsKey("player_items:delete"))
          return;
        SMManager.DeleteList<PlayerItem>(((IEnumerable<object>) json["player_items:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class Officialinfo : KeyCompare
    {
      public OfficialInformationArticle[] articles;

      public Officialinfo()
      {
      }

      public Officialinfo(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<OfficialInformationArticle> informationArticleList = new List<OfficialInformationArticle>();
        foreach (object json1 in (List<object>) json[nameof (articles)])
          informationArticleList.Add(json1 != null ? new OfficialInformationArticle((Dictionary<string, object>) json1) : (OfficialInformationArticle) null);
        this.articles = informationArticleList.ToArray();
        SMManager.UpdateList<OfficialInformationArticle>(this.articles);
      }
    }

    [Serializable]
    public class OfficialinfoMaintenance : KeyCompare
    {
      public string message_body;
      public bool hardware_maintenance;
      public bool is_maintenance;
      public string message_schedule;

      public OfficialinfoMaintenance()
      {
      }

      public OfficialinfoMaintenance(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.message_body = (string) json[nameof (message_body)];
        this.hardware_maintenance = (bool) json[nameof (hardware_maintenance)];
        this.is_maintenance = (bool) json[nameof (is_maintenance)];
        this.message_schedule = (string) json[nameof (message_schedule)];
      }
    }

    [Serializable]
    public class PlayerBoot : KeyCompare
    {
      public string pvp_battle_uuid;
      public string game_server_host;
      public bool player_during_battle;
      public string application_download_url;
      public bool latest_application;
      public bool player_during_pvp_result;
      public bool player_during_pvp;
      public string pvp_token;
      public bool player_is_create;
      public string dlc_latest_version;
      public bool application_review;
      public int game_server_port;

      public PlayerBoot()
      {
      }

      public PlayerBoot(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.pvp_battle_uuid = (string) json[nameof (pvp_battle_uuid)];
        this.game_server_host = (string) json[nameof (game_server_host)];
        this.player_during_battle = (bool) json[nameof (player_during_battle)];
        this.application_download_url = (string) json[nameof (application_download_url)];
        this.latest_application = (bool) json[nameof (latest_application)];
        this.player_during_pvp_result = (bool) json[nameof (player_during_pvp_result)];
        this.player_during_pvp = (bool) json[nameof (player_during_pvp)];
        this.pvp_token = (string) json[nameof (pvp_token)];
        this.player_is_create = (bool) json[nameof (player_is_create)];
        this.dlc_latest_version = (string) json[nameof (dlc_latest_version)];
        this.application_review = (bool) json[nameof (application_review)];
        this.game_server_port = (int) (long) json[nameof (game_server_port)];
      }
    }

    [Serializable]
    public class PlayerBootRelease : KeyCompare
    {
      public string pvp_battle_uuid;
      public string game_server_host;
      public bool player_during_battle;
      public string application_download_url;
      public bool latest_application;
      public bool player_during_pvp_result;
      public bool player_during_pvp;
      public string pvp_token;
      public bool player_is_create;
      public string dlc_latest_version;
      public bool application_review;
      public int game_server_port;

      public PlayerBootRelease()
      {
      }

      public PlayerBootRelease(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.pvp_battle_uuid = (string) json[nameof (pvp_battle_uuid)];
        this.game_server_host = (string) json[nameof (game_server_host)];
        this.player_during_battle = (bool) json[nameof (player_during_battle)];
        this.application_download_url = (string) json[nameof (application_download_url)];
        this.latest_application = (bool) json[nameof (latest_application)];
        this.player_during_pvp_result = (bool) json[nameof (player_during_pvp_result)];
        this.player_during_pvp = (bool) json[nameof (player_during_pvp)];
        this.pvp_token = (string) json[nameof (pvp_token)];
        this.player_is_create = (bool) json[nameof (player_is_create)];
        this.dlc_latest_version = (string) json[nameof (dlc_latest_version)];
        this.application_review = (bool) json[nameof (application_review)];
        this.game_server_port = (int) (long) json[nameof (game_server_port)];
      }
    }

    [Serializable]
    public class PlayerNameEdit : KeyCompare
    {
      public Player player;

      public PlayerNameEdit()
      {
      }

      public PlayerNameEdit(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
      }
    }

    [Serializable]
    public class PlayerSearch : KeyCompare
    {
      public PlayerUnit target_leader_unit;
      public PlayerHelper target_player_helper;
      public Player target_player;

      public PlayerSearch()
      {
      }

      public PlayerSearch(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.target_leader_unit = json[nameof (target_leader_unit)] != null ? new PlayerUnit((Dictionary<string, object>) json[nameof (target_leader_unit)]) : (PlayerUnit) null;
        this.target_player_helper = json[nameof (target_player_helper)] != null ? new PlayerHelper((Dictionary<string, object>) json[nameof (target_player_helper)]) : (PlayerHelper) null;
        this.target_player = json[nameof (target_player)] != null ? new Player((Dictionary<string, object>) json[nameof (target_player)]) : (Player) null;
      }
    }

    [Serializable]
    public class PlayerSignin : KeyCompare
    {
      public PlayerLoginBonus[] player_loginbonuses;
      public DateTime last_signed_in_at;
      public DeviceReward[] device_rewards;
      public PlayerPresent[] player_presents;

      public PlayerSignin()
      {
      }

      public PlayerSignin(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerLoginBonus> playerLoginBonusList = new List<PlayerLoginBonus>();
        foreach (object json1 in (List<object>) json[nameof (player_loginbonuses)])
          playerLoginBonusList.Add(json1 != null ? new PlayerLoginBonus((Dictionary<string, object>) json1) : (PlayerLoginBonus) null);
        this.player_loginbonuses = playerLoginBonusList.ToArray();
        this.last_signed_in_at = DateTime.Parse((string) json[nameof (last_signed_in_at)]);
        List<DeviceReward> deviceRewardList = new List<DeviceReward>();
        foreach (object json2 in (List<object>) json[nameof (device_rewards)])
          deviceRewardList.Add(json2 != null ? new DeviceReward((Dictionary<string, object>) json2) : (DeviceReward) null);
        this.device_rewards = deviceRewardList.ToArray();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json3 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json3 != null ? new PlayerPresent((Dictionary<string, object>) json3) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class PlayerSignup : KeyCompare
    {
      public bool is_created;

      public PlayerSignup()
      {
      }

      public PlayerSignup(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.is_created = (bool) json[nameof (is_created)];
      }
    }

    [Serializable]
    public class PlayerStatus : KeyCompare
    {
      public bool is_started;

      public PlayerStatus()
      {
      }

      public PlayerStatus(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.is_started = (bool) json[nameof (is_started)];
      }
    }

    [Serializable]
    public class PresentDelete : KeyCompare
    {
      public PlayerPresent[] player_presents;

      public PresentDelete()
      {
      }

      public PresentDelete(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json1 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json1 != null ? new PlayerPresent((Dictionary<string, object>) json1) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class PresentRead : KeyCompare
    {
      public PlayerItem[] player_items;
      public PlayerUnit[] player_units;
      public WebAPI.Response.PresentReadReceived_presents[] received_presents;
      public Player player;
      public bool is_success;
      public PlayerPresent[] player_presents;
      public PlayerQuestKey[] player_quest_keys;

      public PresentRead()
      {
      }

      public PresentRead(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<WebAPI.Response.PresentReadReceived_presents> receivedPresentsList = new List<WebAPI.Response.PresentReadReceived_presents>();
        foreach (object json3 in (List<object>) json[nameof (received_presents)])
          receivedPresentsList.Add(json3 != null ? new WebAPI.Response.PresentReadReceived_presents((Dictionary<string, object>) json3) : (WebAPI.Response.PresentReadReceived_presents) null);
        this.received_presents = receivedPresentsList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        this.is_success = (bool) json[nameof (is_success)];
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json4 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json4 != null ? new PlayerPresent((Dictionary<string, object>) json4) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<PlayerQuestKey> playerQuestKeyList = new List<PlayerQuestKey>();
        foreach (object json5 in (List<object>) json[nameof (player_quest_keys)])
          playerQuestKeyList.Add(json5 != null ? new PlayerQuestKey((Dictionary<string, object>) json5) : (PlayerQuestKey) null);
        this.player_quest_keys = playerQuestKeyList.ToArray();
        SMManager.UpdateList<PlayerQuestKey>(this.player_quest_keys);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class PresentReadReceived_presents : KeyCompare
    {
      public int reward_quantity;
      public int reward_type_id;
      public int? reward_id;

      public PresentReadReceived_presents()
      {
      }

      public PresentReadReceived_presents(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        int? nullable1;
        if (json[nameof (reward_id)] == null)
        {
          nullable1 = new int?();
        }
        else
        {
          long? nullable2 = (long?) json[nameof (reward_id)];
          nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
        }
        this.reward_id = nullable1;
      }
    }

    [Serializable]
    public class PresentReadLump : KeyCompare
    {
      public PlayerItem[] player_items;
      public PlayerUnit[] player_units;
      public WebAPI.Response.PresentReadLumpReceived_presents[] received_presents;
      public Player player;
      public bool is_success;
      public PlayerPresent[] player_presents;
      public PlayerQuestKey[] player_quest_keys;

      public PresentReadLump()
      {
      }

      public PresentReadLump(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<WebAPI.Response.PresentReadLumpReceived_presents> receivedPresentsList = new List<WebAPI.Response.PresentReadLumpReceived_presents>();
        foreach (object json3 in (List<object>) json[nameof (received_presents)])
          receivedPresentsList.Add(json3 != null ? new WebAPI.Response.PresentReadLumpReceived_presents((Dictionary<string, object>) json3) : (WebAPI.Response.PresentReadLumpReceived_presents) null);
        this.received_presents = receivedPresentsList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        this.is_success = (bool) json[nameof (is_success)];
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json4 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json4 != null ? new PlayerPresent((Dictionary<string, object>) json4) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<PlayerQuestKey> playerQuestKeyList = new List<PlayerQuestKey>();
        foreach (object json5 in (List<object>) json[nameof (player_quest_keys)])
          playerQuestKeyList.Add(json5 != null ? new PlayerQuestKey((Dictionary<string, object>) json5) : (PlayerQuestKey) null);
        this.player_quest_keys = playerQuestKeyList.ToArray();
        SMManager.UpdateList<PlayerQuestKey>(this.player_quest_keys);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class PresentReadLumpReceived_presents : KeyCompare
    {
      public int reward_quantity;
      public int reward_type_id;
      public int? reward_id;

      public PresentReadLumpReceived_presents()
      {
      }

      public PresentReadLumpReceived_presents(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        int? nullable1;
        if (json[nameof (reward_id)] == null)
        {
          nullable1 = new int?();
        }
        else
        {
          long? nullable2 = (long?) json[nameof (reward_id)];
          nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
        }
        this.reward_id = nullable1;
      }
    }

    [Serializable]
    public class PvpBoot : KeyCompare
    {
      public int season_remaining_matches;
      public bool is_battle;
      public string pvp_maintenance_message;
      public bool rank_done;
      public bool is_tutorial;
      public Player player;
      public bool is_tutorial_battle_end;
      public bool is_season_done;
      public PvPCampaign[] pvp_campaigns;
      public int current_class;
      public PlayerDeck[] player_decks;
      public int matching_port;
      public bool medal_shop_is_available;
      public DateTime? matches_finish_time;
      public MpStage stage;
      public int remaining_times;
      public int best_class;
      public bool rank_aggregate;
      public int ranking;
      public Bonus[] bonus;
      public bool friend_match_enable;
      public Campaign[] campaigns;
      public int max_addition_matches;
      public int remaining_addition_matches;
      public DateTime? aggregate_finish_time;
      public int ranking_pt;
      public PvPRecord pvp_record;
      public PvPRecord pvp_record_by_friend;
      public bool pvp_maintenance;
      public bool class_match_enable;
      public string pvp_maintenance_title;
      public PvPClassRecord pvp_class_record;
      public bool battle_medal_shop_is_available;
      public bool is_latest_client_version;
      public string matching_host;
      public int limit_times;

      public PvpBoot()
      {
      }

      public PvpBoot(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.season_remaining_matches = (int) (long) json[nameof (season_remaining_matches)];
        this.is_battle = (bool) json[nameof (is_battle)];
        this.pvp_maintenance_message = (string) json[nameof (pvp_maintenance_message)];
        this.rank_done = (bool) json[nameof (rank_done)];
        this.is_tutorial = (bool) json[nameof (is_tutorial)];
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        this.is_tutorial_battle_end = (bool) json[nameof (is_tutorial_battle_end)];
        this.is_season_done = (bool) json[nameof (is_season_done)];
        List<PvPCampaign> pvPcampaignList = new List<PvPCampaign>();
        foreach (object json1 in (List<object>) json[nameof (pvp_campaigns)])
          pvPcampaignList.Add(json1 != null ? new PvPCampaign((Dictionary<string, object>) json1) : (PvPCampaign) null);
        this.pvp_campaigns = pvPcampaignList.ToArray();
        this.current_class = (int) (long) json[nameof (current_class)];
        List<PlayerDeck> playerDeckList = new List<PlayerDeck>();
        foreach (object json2 in (List<object>) json[nameof (player_decks)])
          playerDeckList.Add(json2 != null ? new PlayerDeck((Dictionary<string, object>) json2) : (PlayerDeck) null);
        this.player_decks = playerDeckList.ToArray();
        this.matching_port = (int) (long) json[nameof (matching_port)];
        this.medal_shop_is_available = (bool) json[nameof (medal_shop_is_available)];
        this.matches_finish_time = json[nameof (matches_finish_time)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (matches_finish_time)])) : new DateTime?();
        this.stage = json[nameof (stage)] != null ? new MpStage((Dictionary<string, object>) json[nameof (stage)]) : (MpStage) null;
        this.remaining_times = (int) (long) json[nameof (remaining_times)];
        this.best_class = (int) (long) json[nameof (best_class)];
        this.rank_aggregate = (bool) json[nameof (rank_aggregate)];
        this.ranking = (int) (long) json[nameof (ranking)];
        List<Bonus> bonusList = new List<Bonus>();
        foreach (object json3 in (List<object>) json[nameof (bonus)])
          bonusList.Add(json3 != null ? new Bonus((Dictionary<string, object>) json3) : (Bonus) null);
        this.bonus = bonusList.ToArray();
        this.friend_match_enable = (bool) json[nameof (friend_match_enable)];
        List<Campaign> campaignList = new List<Campaign>();
        foreach (object json4 in (List<object>) json[nameof (campaigns)])
          campaignList.Add(json4 != null ? new Campaign((Dictionary<string, object>) json4) : (Campaign) null);
        this.campaigns = campaignList.ToArray();
        this.max_addition_matches = (int) (long) json[nameof (max_addition_matches)];
        this.remaining_addition_matches = (int) (long) json[nameof (remaining_addition_matches)];
        this.aggregate_finish_time = json[nameof (aggregate_finish_time)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (aggregate_finish_time)])) : new DateTime?();
        this.ranking_pt = (int) (long) json[nameof (ranking_pt)];
        this.pvp_record = json[nameof (pvp_record)] != null ? new PvPRecord((Dictionary<string, object>) json[nameof (pvp_record)]) : (PvPRecord) null;
        SMManager.Change<PvPRecord>(this.pvp_record);
        this.pvp_record_by_friend = json[nameof (pvp_record_by_friend)] != null ? new PvPRecord((Dictionary<string, object>) json[nameof (pvp_record_by_friend)]) : (PvPRecord) null;
        SMManager.Change<PvPRecord>(this.pvp_record_by_friend);
        this.pvp_maintenance = (bool) json[nameof (pvp_maintenance)];
        this.class_match_enable = (bool) json[nameof (class_match_enable)];
        this.pvp_maintenance_title = (string) json[nameof (pvp_maintenance_title)];
        this.pvp_class_record = json[nameof (pvp_class_record)] != null ? new PvPClassRecord((Dictionary<string, object>) json[nameof (pvp_class_record)]) : (PvPClassRecord) null;
        this.battle_medal_shop_is_available = (bool) json[nameof (battle_medal_shop_is_available)];
        this.is_latest_client_version = (bool) json[nameof (is_latest_client_version)];
        this.matching_host = (string) json[nameof (matching_host)];
        this.limit_times = (int) (long) json[nameof (limit_times)];
      }
    }

    [Serializable]
    public class PvpForceClose : KeyCompare
    {
      public bool result;

      public PvpForceClose()
      {
      }

      public PvpForceClose(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.result = (bool) json[nameof (result)];
      }
    }

    [Serializable]
    public class PvpFriend : KeyCompare
    {
      public int ranking;
      public PvPRecord pvp_record;
      public PvPRecord pvp_record_by_friend;
      public bool is_friend;
      public int level;
      public string target_player_id;
      public DateTime target_player_last_signed_in_at;
      public int target_player_current_class;
      public int ranking_point;
      public int current_emblem_id;
      public int leader_unit_id;
      public string target_player_name;
      public int leader_unit_level;
      public bool is_first_battle;

      public PvpFriend()
      {
      }

      public PvpFriend(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.ranking = (int) (long) json[nameof (ranking)];
        this.pvp_record = json[nameof (pvp_record)] != null ? new PvPRecord((Dictionary<string, object>) json[nameof (pvp_record)]) : (PvPRecord) null;
        this.pvp_record_by_friend = json[nameof (pvp_record_by_friend)] != null ? new PvPRecord((Dictionary<string, object>) json[nameof (pvp_record_by_friend)]) : (PvPRecord) null;
        this.is_friend = (bool) json[nameof (is_friend)];
        this.level = (int) (long) json[nameof (level)];
        this.target_player_id = (string) json[nameof (target_player_id)];
        this.target_player_last_signed_in_at = DateTime.Parse((string) json[nameof (target_player_last_signed_in_at)]);
        this.target_player_current_class = (int) (long) json[nameof (target_player_current_class)];
        this.ranking_point = (int) (long) json[nameof (ranking_point)];
        this.current_emblem_id = (int) (long) json[nameof (current_emblem_id)];
        this.leader_unit_id = (int) (long) json[nameof (leader_unit_id)];
        this.target_player_name = (string) json[nameof (target_player_name)];
        this.leader_unit_level = (int) (long) json[nameof (leader_unit_level)];
        this.is_first_battle = (bool) json[nameof (is_first_battle)];
      }

      public string getClassNameString()
      {
        return MasterData.PvpClassKind[this.target_player_current_class].name;
      }

      public string getRankingString()
      {
        return Player.Current.IsClassMatchRanking() && this.ranking > 0 ? this.ranking.ToLocalizeNumberText() : Consts.Lookup("VERSUS_002610RANKING_DEFAULT");
      }

      public string getPointString()
      {
        return Player.Current.IsClassMatchRanking() ? this.ranking_point.ToLocalizeNumberText() : Consts.Lookup("VERSUS_002610RANKING_DEFAULT");
      }
    }

    [Serializable]
    public class PvpLiteBoot : KeyCompare
    {
      public bool is_battle;
      public string pvp_maintenance_message;
      public bool pvp_maintenance;
      public string pvp_maintenance_title;
      public Player player;
      public bool is_latest_version;

      public PvpLiteBoot()
      {
      }

      public PvpLiteBoot(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.is_battle = (bool) json[nameof (is_battle)];
        this.pvp_maintenance_message = (string) json[nameof (pvp_maintenance_message)];
        this.pvp_maintenance = (bool) json[nameof (pvp_maintenance)];
        this.pvp_maintenance_title = (string) json[nameof (pvp_maintenance_title)];
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        this.is_latest_version = (bool) json[nameof (is_latest_version)];
      }
    }

    [Serializable]
    public class PvpPlayerFinish : KeyCompare
    {
      public bool is_battle;
      public string pvp_maintenance_message;
      public int ranking;
      public int reward_money;
      public bool is_tutorial;
      public Player player;
      public bool is_season_done;
      public PvPEnd pvp_finish;
      public WebAPI.Response.PvpPlayerFinishCampaign_next_rewards[] campaign_next_rewards;
      public int current_class;
      public bool target_player_is_friend;
      public bool rank_aggregate;
      public WebAPI.Response.PvpPlayerFinishBonus_rewards[] bonus_rewards;
      public WebAPI.Response.PvpPlayerFinishFirst_battle_rewards[] first_battle_rewards;
      public PlayerUnit[] player_units;
      public Bonus[] bonus;
      public PlayerItem[] player_items;
      public Campaign[] campaigns;
      public int matching_type;
      public WebAPI.Response.PvpPlayerFinishCampaign_rewards[] campaign_rewards;
      public PlayerPresent[] player_presents;
      public PlayerCharacterIntimate[] player_character_intimates;
      public PvPRecord pvp_record;
      public PvPRecord pvp_record_by_friend;
      public bool pvp_maintenance;
      public string pvp_maintenance_title;
      public PvPClassRecord pvp_class_record;
      public int ranking_pt;
      public PlayerHelper[] gladiators;

      public PvpPlayerFinish()
      {
      }

      public PvpPlayerFinish(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.is_battle = (bool) json[nameof (is_battle)];
        this.pvp_maintenance_message = (string) json[nameof (pvp_maintenance_message)];
        this.ranking = (int) (long) json[nameof (ranking)];
        this.reward_money = (int) (long) json[nameof (reward_money)];
        this.is_tutorial = (bool) json[nameof (is_tutorial)];
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        this.is_season_done = (bool) json[nameof (is_season_done)];
        this.pvp_finish = json[nameof (pvp_finish)] != null ? new PvPEnd((Dictionary<string, object>) json[nameof (pvp_finish)]) : (PvPEnd) null;
        List<WebAPI.Response.PvpPlayerFinishCampaign_next_rewards> campaignNextRewardsList = new List<WebAPI.Response.PvpPlayerFinishCampaign_next_rewards>();
        foreach (object json1 in (List<object>) json[nameof (campaign_next_rewards)])
          campaignNextRewardsList.Add(json1 != null ? new WebAPI.Response.PvpPlayerFinishCampaign_next_rewards((Dictionary<string, object>) json1) : (WebAPI.Response.PvpPlayerFinishCampaign_next_rewards) null);
        this.campaign_next_rewards = campaignNextRewardsList.ToArray();
        this.current_class = (int) (long) json[nameof (current_class)];
        this.target_player_is_friend = (bool) json[nameof (target_player_is_friend)];
        this.rank_aggregate = (bool) json[nameof (rank_aggregate)];
        List<WebAPI.Response.PvpPlayerFinishBonus_rewards> finishBonusRewardsList = new List<WebAPI.Response.PvpPlayerFinishBonus_rewards>();
        foreach (object json2 in (List<object>) json[nameof (bonus_rewards)])
          finishBonusRewardsList.Add(json2 != null ? new WebAPI.Response.PvpPlayerFinishBonus_rewards((Dictionary<string, object>) json2) : (WebAPI.Response.PvpPlayerFinishBonus_rewards) null);
        this.bonus_rewards = finishBonusRewardsList.ToArray();
        List<WebAPI.Response.PvpPlayerFinishFirst_battle_rewards> firstBattleRewardsList = new List<WebAPI.Response.PvpPlayerFinishFirst_battle_rewards>();
        foreach (object json3 in (List<object>) json[nameof (first_battle_rewards)])
          firstBattleRewardsList.Add(json3 != null ? new WebAPI.Response.PvpPlayerFinishFirst_battle_rewards((Dictionary<string, object>) json3) : (WebAPI.Response.PvpPlayerFinishFirst_battle_rewards) null);
        this.first_battle_rewards = firstBattleRewardsList.ToArray();
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json4 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json4 != null ? new PlayerUnit((Dictionary<string, object>) json4) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<Bonus> bonusList = new List<Bonus>();
        foreach (object json5 in (List<object>) json[nameof (bonus)])
          bonusList.Add(json5 != null ? new Bonus((Dictionary<string, object>) json5) : (Bonus) null);
        this.bonus = bonusList.ToArray();
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json6 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json6 != null ? new PlayerItem((Dictionary<string, object>) json6) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<Campaign> campaignList = new List<Campaign>();
        foreach (object json7 in (List<object>) json[nameof (campaigns)])
          campaignList.Add(json7 != null ? new Campaign((Dictionary<string, object>) json7) : (Campaign) null);
        this.campaigns = campaignList.ToArray();
        this.matching_type = (int) (long) json[nameof (matching_type)];
        List<WebAPI.Response.PvpPlayerFinishCampaign_rewards> finishCampaignRewardsList = new List<WebAPI.Response.PvpPlayerFinishCampaign_rewards>();
        foreach (object json8 in (List<object>) json[nameof (campaign_rewards)])
          finishCampaignRewardsList.Add(json8 != null ? new WebAPI.Response.PvpPlayerFinishCampaign_rewards((Dictionary<string, object>) json8) : (WebAPI.Response.PvpPlayerFinishCampaign_rewards) null);
        this.campaign_rewards = finishCampaignRewardsList.ToArray();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json9 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json9 != null ? new PlayerPresent((Dictionary<string, object>) json9) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<PlayerCharacterIntimate> characterIntimateList = new List<PlayerCharacterIntimate>();
        foreach (object json10 in (List<object>) json[nameof (player_character_intimates)])
          characterIntimateList.Add(json10 != null ? new PlayerCharacterIntimate((Dictionary<string, object>) json10) : (PlayerCharacterIntimate) null);
        this.player_character_intimates = characterIntimateList.ToArray();
        SMManager.UpdateList<PlayerCharacterIntimate>(this.player_character_intimates);
        this.pvp_record = json[nameof (pvp_record)] != null ? new PvPRecord((Dictionary<string, object>) json[nameof (pvp_record)]) : (PvPRecord) null;
        this.pvp_record_by_friend = json[nameof (pvp_record_by_friend)] != null ? new PvPRecord((Dictionary<string, object>) json[nameof (pvp_record_by_friend)]) : (PvPRecord) null;
        this.pvp_maintenance = (bool) json[nameof (pvp_maintenance)];
        this.pvp_maintenance_title = (string) json[nameof (pvp_maintenance_title)];
        this.pvp_class_record = json[nameof (pvp_class_record)] != null ? new PvPClassRecord((Dictionary<string, object>) json[nameof (pvp_class_record)]) : (PvPClassRecord) null;
        this.ranking_pt = (int) (long) json[nameof (ranking_pt)];
        List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
        foreach (object json11 in (List<object>) json[nameof (gladiators)])
          playerHelperList.Add(json11 != null ? new PlayerHelper((Dictionary<string, object>) json11) : (PlayerHelper) null);
        this.gladiators = playerHelperList.ToArray();
        if (json.ContainsKey("player_items:delete"))
          SMManager.DeleteList<PlayerItem>(((IEnumerable<object>) json["player_items:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class PvpPlayerFinishCampaign_rewards : KeyCompare
    {
      public int reward_quantity;
      public string show_text2;
      public int reward_type_id;
      public int campaign_id;
      public string show_title;
      public string show_text;
      public int reward_id;

      public PvpPlayerFinishCampaign_rewards()
      {
      }

      public PvpPlayerFinishCampaign_rewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.show_text2 = (string) json[nameof (show_text2)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.campaign_id = (int) (long) json[nameof (campaign_id)];
        this.show_title = (string) json[nameof (show_title)];
        this.show_text = (string) json[nameof (show_text)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
      }
    }

    [Serializable]
    public class PvpPlayerFinishFirst_battle_rewards : KeyCompare
    {
      public int reward_quantity;
      public string show_text2;
      public string show_text;
      public int reward_type_id;
      public int reward_id;

      public PvpPlayerFinishFirst_battle_rewards()
      {
      }

      public PvpPlayerFinishFirst_battle_rewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.show_text2 = (string) json[nameof (show_text2)];
        this.show_text = (string) json[nameof (show_text)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
      }
    }

    [Serializable]
    public class PvpPlayerFinishBonus_rewards : KeyCompare
    {
      public int reward_quantity;
      public int reward_type_id;
      public int reward_id;

      public PvpPlayerFinishBonus_rewards()
      {
      }

      public PvpPlayerFinishBonus_rewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
      }
    }

    [Serializable]
    public class PvpPlayerFinishCampaign_next_rewards : KeyCompare
    {
      public string next_reward_title;
      public int campaign_id;
      public string next_reward_text;

      public PvpPlayerFinishCampaign_next_rewards()
      {
      }

      public PvpPlayerFinishCampaign_next_rewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.next_reward_title = (string) json[nameof (next_reward_title)];
        this.campaign_id = (int) (long) json[nameof (campaign_id)];
        this.next_reward_text = (string) json[nameof (next_reward_text)];
      }
    }

    [Serializable]
    public class PvpPlayerStatus : KeyCompare
    {
      public bool has_battle_result;

      public PvpPlayerStatus()
      {
      }

      public PvpPlayerStatus(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.has_battle_result = (bool) json[nameof (has_battle_result)];
      }
    }

    [Serializable]
    public class PvpRanking : KeyCompare
    {
      public bool rank_aggregate;
      public RankingGroup[] ranking_groups;

      public PvpRanking()
      {
      }

      public PvpRanking(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.rank_aggregate = (bool) json[nameof (rank_aggregate)];
        List<RankingGroup> rankingGroupList = new List<RankingGroup>();
        foreach (object json1 in (List<object>) json[nameof (ranking_groups)])
          rankingGroupList.Add(json1 != null ? new RankingGroup((Dictionary<string, object>) json1) : (RankingGroup) null);
        this.ranking_groups = rankingGroupList.ToArray();
      }
    }

    [Serializable]
    public class PvpRankingClose : KeyCompare
    {
      public int ranking;
      public PlayerEmblem[] new_emblems;
      public DateTime? finish_time;
      public int term_id;
      public DateTime? start_time;
      public int ranking_pt;
      public WebAPI.Response.PvpRankingCloseRanking_rewards[] ranking_rewards;
      public PlayerPresent[] player_presents;

      public PvpRankingClose()
      {
      }

      public PvpRankingClose(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.ranking = (int) (long) json[nameof (ranking)];
        List<PlayerEmblem> playerEmblemList = new List<PlayerEmblem>();
        foreach (object json1 in (List<object>) json[nameof (new_emblems)])
          playerEmblemList.Add(json1 != null ? new PlayerEmblem((Dictionary<string, object>) json1) : (PlayerEmblem) null);
        this.new_emblems = playerEmblemList.ToArray();
        this.finish_time = json[nameof (finish_time)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (finish_time)])) : new DateTime?();
        this.term_id = (int) (long) json[nameof (term_id)];
        this.start_time = json[nameof (start_time)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (start_time)])) : new DateTime?();
        this.ranking_pt = (int) (long) json[nameof (ranking_pt)];
        List<WebAPI.Response.PvpRankingCloseRanking_rewards> closeRankingRewardsList = new List<WebAPI.Response.PvpRankingCloseRanking_rewards>();
        foreach (object json2 in (List<object>) json[nameof (ranking_rewards)])
          closeRankingRewardsList.Add(json2 != null ? new WebAPI.Response.PvpRankingCloseRanking_rewards((Dictionary<string, object>) json2) : (WebAPI.Response.PvpRankingCloseRanking_rewards) null);
        this.ranking_rewards = closeRankingRewardsList.ToArray();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json3 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json3 != null ? new PlayerPresent((Dictionary<string, object>) json3) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class PvpRankingCloseRanking_rewards : KeyCompare
    {
      public int reward_quantity;
      public string show_text;
      public int condition_id;
      public int reward_id;
      public int reward_type_id;

      public PvpRankingCloseRanking_rewards()
      {
      }

      public PvpRankingCloseRanking_rewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.show_text = (string) json[nameof (show_text)];
        this.condition_id = (int) (long) json[nameof (condition_id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      }
    }

    [Serializable]
    public class PvpResume : KeyCompare
    {
      public PlayerItem[] player2_items;
      public PlayerUnit[] player2_units;
      public DateTime battle_start_at;
      public string battle_uuid;
      public Bonus[] bonus;
      public bool battle_start;
      public PlayerItem[] player1_items;
      public PlayerUnit[] player1_units;
      public Player player2;
      public Player player1;
      public int order;
      public MpStage stage;

      public PvpResume()
      {
      }

      public PvpResume(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList1 = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player2_items)])
          playerItemList1.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player2_items = playerItemList1.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player2_items);
        List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player2_units)])
          playerUnitList1.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player2_units = playerUnitList1.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player2_units);
        this.battle_start_at = DateTime.Parse((string) json[nameof (battle_start_at)]);
        this.battle_uuid = (string) json[nameof (battle_uuid)];
        List<Bonus> bonusList = new List<Bonus>();
        foreach (object json3 in (List<object>) json[nameof (bonus)])
          bonusList.Add(json3 != null ? new Bonus((Dictionary<string, object>) json3) : (Bonus) null);
        this.bonus = bonusList.ToArray();
        this.battle_start = (bool) json[nameof (battle_start)];
        List<PlayerItem> playerItemList2 = new List<PlayerItem>();
        foreach (object json4 in (List<object>) json[nameof (player1_items)])
          playerItemList2.Add(json4 != null ? new PlayerItem((Dictionary<string, object>) json4) : (PlayerItem) null);
        this.player1_items = playerItemList2.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player1_items);
        List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
        foreach (object json5 in (List<object>) json[nameof (player1_units)])
          playerUnitList2.Add(json5 != null ? new PlayerUnit((Dictionary<string, object>) json5) : (PlayerUnit) null);
        this.player1_units = playerUnitList2.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player1_units);
        this.player2 = json[nameof (player2)] != null ? new Player((Dictionary<string, object>) json[nameof (player2)]) : (Player) null;
        SMManager.Change<Player>(this.player2);
        this.player1 = json[nameof (player1)] != null ? new Player((Dictionary<string, object>) json[nameof (player1)]) : (Player) null;
        SMManager.Change<Player>(this.player1);
        this.order = (int) (long) json[nameof (order)];
        this.stage = json[nameof (stage)] != null ? new MpStage((Dictionary<string, object>) json[nameof (stage)]) : (MpStage) null;
      }
    }

    [Serializable]
    public class PvpSeasonClose : KeyCompare
    {
      public WebAPI.Response.PvpSeasonCloseClass_rewards[] class_rewards;
      public PlayerEmblem[] new_emblems;
      public PlayerPresent[] player_presents;

      public PvpSeasonClose()
      {
      }

      public PvpSeasonClose(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<WebAPI.Response.PvpSeasonCloseClass_rewards> closeClassRewardsList = new List<WebAPI.Response.PvpSeasonCloseClass_rewards>();
        foreach (object json1 in (List<object>) json[nameof (class_rewards)])
          closeClassRewardsList.Add(json1 != null ? new WebAPI.Response.PvpSeasonCloseClass_rewards((Dictionary<string, object>) json1) : (WebAPI.Response.PvpSeasonCloseClass_rewards) null);
        this.class_rewards = closeClassRewardsList.ToArray();
        List<PlayerEmblem> playerEmblemList = new List<PlayerEmblem>();
        foreach (object json2 in (List<object>) json[nameof (new_emblems)])
          playerEmblemList.Add(json2 != null ? new PlayerEmblem((Dictionary<string, object>) json2) : (PlayerEmblem) null);
        this.new_emblems = playerEmblemList.ToArray();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json3 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json3 != null ? new PlayerPresent((Dictionary<string, object>) json3) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class PvpSeasonCloseClass_rewards : KeyCompare
    {
      public int reward_quantity;
      public int reward_type_id;
      public int class_reward_type;
      public string show_text;
      public int class_kind;
      public int reward_id;

      public PvpSeasonCloseClass_rewards()
      {
      }

      public PvpSeasonCloseClass_rewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.class_reward_type = (int) (long) json[nameof (class_reward_type)];
        this.show_text = (string) json[nameof (show_text)];
        this.class_kind = (int) (long) json[nameof (class_kind)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
      }
    }

    [Serializable]
    public class PvpTutorialPlayerFinish : KeyCompare
    {
      public bool is_battle;
      public string pvp_maintenance_message;
      public int ranking;
      public int reward_money;
      public bool is_tutorial;
      public Player player;
      public bool is_season_done;
      public PvPEnd pvp_finish;
      public WebAPI.Response.PvpTutorialPlayerFinishCampaign_next_rewards[] campaign_next_rewards;
      public int current_class;
      public bool target_player_is_friend;
      public bool rank_aggregate;
      public WebAPI.Response.PvpTutorialPlayerFinishBonus_rewards[] bonus_rewards;
      public WebAPI.Response.PvpTutorialPlayerFinishFirst_battle_rewards[] first_battle_rewards;
      public PlayerUnit[] player_units;
      public Bonus[] bonus;
      public PlayerItem[] player_items;
      public Campaign[] campaigns;
      public int matching_type;
      public WebAPI.Response.PvpTutorialPlayerFinishCampaign_rewards[] campaign_rewards;
      public PlayerPresent[] player_presents;
      public PlayerCharacterIntimate[] player_character_intimates;
      public PvPRecord pvp_record;
      public PvPRecord pvp_record_by_friend;
      public bool pvp_maintenance;
      public string pvp_maintenance_title;
      public PvPClassRecord pvp_class_record;
      public int ranking_pt;
      public PlayerHelper[] gladiators;

      public PvpTutorialPlayerFinish()
      {
      }

      public PvpTutorialPlayerFinish(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.is_battle = (bool) json[nameof (is_battle)];
        this.pvp_maintenance_message = (string) json[nameof (pvp_maintenance_message)];
        this.ranking = (int) (long) json[nameof (ranking)];
        this.reward_money = (int) (long) json[nameof (reward_money)];
        this.is_tutorial = (bool) json[nameof (is_tutorial)];
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        this.is_season_done = (bool) json[nameof (is_season_done)];
        this.pvp_finish = json[nameof (pvp_finish)] != null ? new PvPEnd((Dictionary<string, object>) json[nameof (pvp_finish)]) : (PvPEnd) null;
        List<WebAPI.Response.PvpTutorialPlayerFinishCampaign_next_rewards> campaignNextRewardsList = new List<WebAPI.Response.PvpTutorialPlayerFinishCampaign_next_rewards>();
        foreach (object json1 in (List<object>) json[nameof (campaign_next_rewards)])
          campaignNextRewardsList.Add(json1 != null ? new WebAPI.Response.PvpTutorialPlayerFinishCampaign_next_rewards((Dictionary<string, object>) json1) : (WebAPI.Response.PvpTutorialPlayerFinishCampaign_next_rewards) null);
        this.campaign_next_rewards = campaignNextRewardsList.ToArray();
        this.current_class = (int) (long) json[nameof (current_class)];
        this.target_player_is_friend = (bool) json[nameof (target_player_is_friend)];
        this.rank_aggregate = (bool) json[nameof (rank_aggregate)];
        List<WebAPI.Response.PvpTutorialPlayerFinishBonus_rewards> finishBonusRewardsList = new List<WebAPI.Response.PvpTutorialPlayerFinishBonus_rewards>();
        foreach (object json2 in (List<object>) json[nameof (bonus_rewards)])
          finishBonusRewardsList.Add(json2 != null ? new WebAPI.Response.PvpTutorialPlayerFinishBonus_rewards((Dictionary<string, object>) json2) : (WebAPI.Response.PvpTutorialPlayerFinishBonus_rewards) null);
        this.bonus_rewards = finishBonusRewardsList.ToArray();
        List<WebAPI.Response.PvpTutorialPlayerFinishFirst_battle_rewards> firstBattleRewardsList = new List<WebAPI.Response.PvpTutorialPlayerFinishFirst_battle_rewards>();
        foreach (object json3 in (List<object>) json[nameof (first_battle_rewards)])
          firstBattleRewardsList.Add(json3 != null ? new WebAPI.Response.PvpTutorialPlayerFinishFirst_battle_rewards((Dictionary<string, object>) json3) : (WebAPI.Response.PvpTutorialPlayerFinishFirst_battle_rewards) null);
        this.first_battle_rewards = firstBattleRewardsList.ToArray();
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json4 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json4 != null ? new PlayerUnit((Dictionary<string, object>) json4) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        List<Bonus> bonusList = new List<Bonus>();
        foreach (object json5 in (List<object>) json[nameof (bonus)])
          bonusList.Add(json5 != null ? new Bonus((Dictionary<string, object>) json5) : (Bonus) null);
        this.bonus = bonusList.ToArray();
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json6 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json6 != null ? new PlayerItem((Dictionary<string, object>) json6) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<Campaign> campaignList = new List<Campaign>();
        foreach (object json7 in (List<object>) json[nameof (campaigns)])
          campaignList.Add(json7 != null ? new Campaign((Dictionary<string, object>) json7) : (Campaign) null);
        this.campaigns = campaignList.ToArray();
        this.matching_type = (int) (long) json[nameof (matching_type)];
        List<WebAPI.Response.PvpTutorialPlayerFinishCampaign_rewards> finishCampaignRewardsList = new List<WebAPI.Response.PvpTutorialPlayerFinishCampaign_rewards>();
        foreach (object json8 in (List<object>) json[nameof (campaign_rewards)])
          finishCampaignRewardsList.Add(json8 != null ? new WebAPI.Response.PvpTutorialPlayerFinishCampaign_rewards((Dictionary<string, object>) json8) : (WebAPI.Response.PvpTutorialPlayerFinishCampaign_rewards) null);
        this.campaign_rewards = finishCampaignRewardsList.ToArray();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json9 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json9 != null ? new PlayerPresent((Dictionary<string, object>) json9) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<PlayerCharacterIntimate> characterIntimateList = new List<PlayerCharacterIntimate>();
        foreach (object json10 in (List<object>) json[nameof (player_character_intimates)])
          characterIntimateList.Add(json10 != null ? new PlayerCharacterIntimate((Dictionary<string, object>) json10) : (PlayerCharacterIntimate) null);
        this.player_character_intimates = characterIntimateList.ToArray();
        SMManager.UpdateList<PlayerCharacterIntimate>(this.player_character_intimates);
        this.pvp_record = json[nameof (pvp_record)] != null ? new PvPRecord((Dictionary<string, object>) json[nameof (pvp_record)]) : (PvPRecord) null;
        this.pvp_record_by_friend = json[nameof (pvp_record_by_friend)] != null ? new PvPRecord((Dictionary<string, object>) json[nameof (pvp_record_by_friend)]) : (PvPRecord) null;
        this.pvp_maintenance = (bool) json[nameof (pvp_maintenance)];
        this.pvp_maintenance_title = (string) json[nameof (pvp_maintenance_title)];
        this.pvp_class_record = json[nameof (pvp_class_record)] != null ? new PvPClassRecord((Dictionary<string, object>) json[nameof (pvp_class_record)]) : (PvPClassRecord) null;
        this.ranking_pt = (int) (long) json[nameof (ranking_pt)];
        List<PlayerHelper> playerHelperList = new List<PlayerHelper>();
        foreach (object json11 in (List<object>) json[nameof (gladiators)])
          playerHelperList.Add(json11 != null ? new PlayerHelper((Dictionary<string, object>) json11) : (PlayerHelper) null);
        this.gladiators = playerHelperList.ToArray();
        if (json.ContainsKey("player_items:delete"))
          SMManager.DeleteList<PlayerItem>(((IEnumerable<object>) json["player_items:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class PvpTutorialPlayerFinishCampaign_rewards : KeyCompare
    {
      public int reward_quantity;
      public string show_text2;
      public int reward_type_id;
      public int campaign_id;
      public string show_title;
      public string show_text;
      public int reward_id;

      public PvpTutorialPlayerFinishCampaign_rewards()
      {
      }

      public PvpTutorialPlayerFinishCampaign_rewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.show_text2 = (string) json[nameof (show_text2)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.campaign_id = (int) (long) json[nameof (campaign_id)];
        this.show_title = (string) json[nameof (show_title)];
        this.show_text = (string) json[nameof (show_text)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
      }
    }

    [Serializable]
    public class PvpTutorialPlayerFinishFirst_battle_rewards : KeyCompare
    {
      public int reward_quantity;
      public string show_text2;
      public string show_text;
      public int reward_type_id;
      public int reward_id;

      public PvpTutorialPlayerFinishFirst_battle_rewards()
      {
      }

      public PvpTutorialPlayerFinishFirst_battle_rewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.show_text2 = (string) json[nameof (show_text2)];
        this.show_text = (string) json[nameof (show_text)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
      }
    }

    [Serializable]
    public class PvpTutorialPlayerFinishBonus_rewards : KeyCompare
    {
      public int reward_quantity;
      public int reward_type_id;
      public int reward_id;

      public PvpTutorialPlayerFinishBonus_rewards()
      {
      }

      public PvpTutorialPlayerFinishBonus_rewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
      }
    }

    [Serializable]
    public class PvpTutorialPlayerFinishCampaign_next_rewards : KeyCompare
    {
      public string next_reward_title;
      public int campaign_id;
      public string next_reward_text;

      public PvpTutorialPlayerFinishCampaign_next_rewards()
      {
      }

      public PvpTutorialPlayerFinishCampaign_next_rewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.next_reward_title = (string) json[nameof (next_reward_title)];
        this.campaign_id = (int) (long) json[nameof (campaign_id)];
        this.next_reward_text = (string) json[nameof (next_reward_text)];
      }
    }

    [Serializable]
    public class PvpTutorialProgressFinish : KeyCompare
    {
      public bool tutorial_finish;

      public PvpTutorialProgressFinish()
      {
      }

      public PvpTutorialProgressFinish(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.tutorial_finish = (bool) json[nameof (tutorial_finish)];
      }
    }

    [Serializable]
    public class QuestHistoryExtra : KeyCompare
    {
      public int[] cleared_quest_s_ids;

      public QuestHistoryExtra()
      {
      }

      public QuestHistoryExtra(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.cleared_quest_s_ids = ((IEnumerable<object>) json[nameof (cleared_quest_s_ids)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      }
    }

    [Serializable]
    public class QuestLimitationCharacter : KeyCompare
    {
      public PlayerDeck[] limitation_player_decks;

      public QuestLimitationCharacter()
      {
      }

      public QuestLimitationCharacter(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerDeck> playerDeckList = new List<PlayerDeck>();
        foreach (object json1 in (List<object>) json[nameof (limitation_player_decks)])
          playerDeckList.Add(json1 != null ? new PlayerDeck((Dictionary<string, object>) json1) : (PlayerDeck) null);
        this.limitation_player_decks = playerDeckList.ToArray();
      }
    }

    [Serializable]
    public class QuestLimitationExtra : KeyCompare
    {
      public PlayerDeck[] limitation_player_decks;

      public QuestLimitationExtra()
      {
      }

      public QuestLimitationExtra(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerDeck> playerDeckList = new List<PlayerDeck>();
        foreach (object json1 in (List<object>) json[nameof (limitation_player_decks)])
          playerDeckList.Add(json1 != null ? new PlayerDeck((Dictionary<string, object>) json1) : (PlayerDeck) null);
        this.limitation_player_decks = playerDeckList.ToArray();
      }
    }

    [Serializable]
    public class QuestLimitationHarmony : KeyCompare
    {
      public PlayerDeck[] limitation_player_decks;

      public QuestLimitationHarmony()
      {
      }

      public QuestLimitationHarmony(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerDeck> playerDeckList = new List<PlayerDeck>();
        foreach (object json1 in (List<object>) json[nameof (limitation_player_decks)])
          playerDeckList.Add(json1 != null ? new PlayerDeck((Dictionary<string, object>) json1) : (PlayerDeck) null);
        this.limitation_player_decks = playerDeckList.ToArray();
      }
    }

    [Serializable]
    public class QuestLimitationStory : KeyCompare
    {
      public PlayerDeck[] limitation_player_decks;

      public QuestLimitationStory()
      {
      }

      public QuestLimitationStory(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerDeck> playerDeckList = new List<PlayerDeck>();
        foreach (object json1 in (List<object>) json[nameof (limitation_player_decks)])
          playerDeckList.Add(json1 != null ? new PlayerDeck((Dictionary<string, object>) json1) : (PlayerDeck) null);
        this.limitation_player_decks = playerDeckList.ToArray();
      }
    }

    [Serializable]
    public class QuestProgressCharacter : KeyCompare
    {
      public WebAPI.Response.QuestProgressCharacterHarmony_quest_s_lost_aps[] harmony_quest_s_lost_aps;
      public WebAPI.Response.QuestProgressCharacterCharacter_quest_s_lost_aps[] character_quest_s_lost_aps;
      public PlayerCharacterQuestS[] player_character_quests;
      public PlayerHarmonyQuestM[] harmonies;
      public PlayerCharacterQuestM[] characters;
      public PlayerHarmonyQuestS[] player_harmony_quests;

      public QuestProgressCharacter()
      {
      }

      public QuestProgressCharacter(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<WebAPI.Response.QuestProgressCharacterHarmony_quest_s_lost_aps> harmonyQuestSLostApsList = new List<WebAPI.Response.QuestProgressCharacterHarmony_quest_s_lost_aps>();
        foreach (object json1 in (List<object>) json[nameof (harmony_quest_s_lost_aps)])
          harmonyQuestSLostApsList.Add(json1 != null ? new WebAPI.Response.QuestProgressCharacterHarmony_quest_s_lost_aps((Dictionary<string, object>) json1) : (WebAPI.Response.QuestProgressCharacterHarmony_quest_s_lost_aps) null);
        this.harmony_quest_s_lost_aps = harmonyQuestSLostApsList.ToArray();
        List<WebAPI.Response.QuestProgressCharacterCharacter_quest_s_lost_aps> characterQuestSLostApsList = new List<WebAPI.Response.QuestProgressCharacterCharacter_quest_s_lost_aps>();
        foreach (object json2 in (List<object>) json[nameof (character_quest_s_lost_aps)])
          characterQuestSLostApsList.Add(json2 != null ? new WebAPI.Response.QuestProgressCharacterCharacter_quest_s_lost_aps((Dictionary<string, object>) json2) : (WebAPI.Response.QuestProgressCharacterCharacter_quest_s_lost_aps) null);
        this.character_quest_s_lost_aps = characterQuestSLostApsList.ToArray();
        List<PlayerCharacterQuestS> playerCharacterQuestSList = new List<PlayerCharacterQuestS>();
        foreach (object json3 in (List<object>) json[nameof (player_character_quests)])
          playerCharacterQuestSList.Add(json3 != null ? new PlayerCharacterQuestS((Dictionary<string, object>) json3) : (PlayerCharacterQuestS) null);
        this.player_character_quests = playerCharacterQuestSList.ToArray();
        SMManager.UpdateList<PlayerCharacterQuestS>(this.player_character_quests);
        List<PlayerHarmonyQuestM> playerHarmonyQuestMList = new List<PlayerHarmonyQuestM>();
        foreach (object json4 in (List<object>) json[nameof (harmonies)])
          playerHarmonyQuestMList.Add(json4 != null ? new PlayerHarmonyQuestM((Dictionary<string, object>) json4) : (PlayerHarmonyQuestM) null);
        this.harmonies = playerHarmonyQuestMList.ToArray();
        SMManager.UpdateList<PlayerHarmonyQuestM>(this.harmonies);
        List<PlayerCharacterQuestM> playerCharacterQuestMList = new List<PlayerCharacterQuestM>();
        foreach (object json5 in (List<object>) json[nameof (characters)])
          playerCharacterQuestMList.Add(json5 != null ? new PlayerCharacterQuestM((Dictionary<string, object>) json5) : (PlayerCharacterQuestM) null);
        this.characters = playerCharacterQuestMList.ToArray();
        SMManager.UpdateList<PlayerCharacterQuestM>(this.characters);
        List<PlayerHarmonyQuestS> playerHarmonyQuestSList = new List<PlayerHarmonyQuestS>();
        foreach (object json6 in (List<object>) json[nameof (player_harmony_quests)])
          playerHarmonyQuestSList.Add(json6 != null ? new PlayerHarmonyQuestS((Dictionary<string, object>) json6) : (PlayerHarmonyQuestS) null);
        this.player_harmony_quests = playerHarmonyQuestSList.ToArray();
        SMManager.UpdateList<PlayerHarmonyQuestS>(this.player_harmony_quests);
      }
    }

    [Serializable]
    public class QuestProgressCharacterCharacter_quest_s_lost_aps : KeyCompare
    {
      public int lost_ap;
      public int quest_s_id;

      public QuestProgressCharacterCharacter_quest_s_lost_aps()
      {
      }

      public QuestProgressCharacterCharacter_quest_s_lost_aps(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.lost_ap = (int) (long) json[nameof (lost_ap)];
        this.quest_s_id = (int) (long) json[nameof (quest_s_id)];
      }
    }

    [Serializable]
    public class QuestProgressCharacterHarmony_quest_s_lost_aps : KeyCompare
    {
      public int lost_ap;
      public int quest_s_id;

      public QuestProgressCharacterHarmony_quest_s_lost_aps()
      {
      }

      public QuestProgressCharacterHarmony_quest_s_lost_aps(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.lost_ap = (int) (long) json[nameof (lost_ap)];
        this.quest_s_id = (int) (long) json[nameof (quest_s_id)];
      }
    }

    [Serializable]
    public class QuestProgressExtra : KeyCompare
    {
      public PlayerExtraQuestS[] player_extra_quests;
      public QuestScoreCampaignProgress[] score_campaigns;

      public QuestProgressExtra()
      {
      }

      public QuestProgressExtra(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerExtraQuestS> playerExtraQuestSList = new List<PlayerExtraQuestS>();
        foreach (object json1 in (List<object>) json[nameof (player_extra_quests)])
          playerExtraQuestSList.Add(json1 != null ? new PlayerExtraQuestS((Dictionary<string, object>) json1) : (PlayerExtraQuestS) null);
        this.player_extra_quests = playerExtraQuestSList.ToArray();
        SMManager.UpdateList<PlayerExtraQuestS>(this.player_extra_quests);
        List<QuestScoreCampaignProgress> campaignProgressList = new List<QuestScoreCampaignProgress>();
        foreach (object json2 in (List<object>) json[nameof (score_campaigns)])
          campaignProgressList.Add(json2 != null ? new QuestScoreCampaignProgress((Dictionary<string, object>) json2) : (QuestScoreCampaignProgress) null);
        this.score_campaigns = campaignProgressList.ToArray();
        SMManager.UpdateList<QuestScoreCampaignProgress>(this.score_campaigns);
      }
    }

    [Serializable]
    public class QuestProgressHarmony : KeyCompare
    {
      public PlayerHarmonyQuestM[] harmonies;
      public PlayerHarmonyQuestS[] player_harmony_quests;

      public QuestProgressHarmony()
      {
      }

      public QuestProgressHarmony(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerHarmonyQuestM> playerHarmonyQuestMList = new List<PlayerHarmonyQuestM>();
        foreach (object json1 in (List<object>) json[nameof (harmonies)])
          playerHarmonyQuestMList.Add(json1 != null ? new PlayerHarmonyQuestM((Dictionary<string, object>) json1) : (PlayerHarmonyQuestM) null);
        this.harmonies = playerHarmonyQuestMList.ToArray();
        SMManager.UpdateList<PlayerHarmonyQuestM>(this.harmonies);
        List<PlayerHarmonyQuestS> playerHarmonyQuestSList = new List<PlayerHarmonyQuestS>();
        foreach (object json2 in (List<object>) json[nameof (player_harmony_quests)])
          playerHarmonyQuestSList.Add(json2 != null ? new PlayerHarmonyQuestS((Dictionary<string, object>) json2) : (PlayerHarmonyQuestS) null);
        this.player_harmony_quests = playerHarmonyQuestSList.ToArray();
        SMManager.UpdateList<PlayerHarmonyQuestS>(this.player_harmony_quests);
      }
    }

    [Serializable]
    public class QuestProgressStory : KeyCompare
    {
      public PlayerStoryQuestS[] player_story_quests;

      public QuestProgressStory()
      {
      }

      public QuestProgressStory(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerStoryQuestS> playerStoryQuestSList = new List<PlayerStoryQuestS>();
        foreach (object json1 in (List<object>) json[nameof (player_story_quests)])
          playerStoryQuestSList.Add(json1 != null ? new PlayerStoryQuestS((Dictionary<string, object>) json1) : (PlayerStoryQuestS) null);
        this.player_story_quests = playerStoryQuestSList.ToArray();
      }
    }

    [Serializable]
    public class QuestRankingExtra : KeyCompare
    {
      public QuestScoreRankingPlayer[] ranking;
      public QuestScoreRankingPlayer my_ranking;

      public QuestRankingExtra()
      {
      }

      public QuestRankingExtra(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<QuestScoreRankingPlayer> scoreRankingPlayerList = new List<QuestScoreRankingPlayer>();
        foreach (object json1 in (List<object>) json[nameof (ranking)])
          scoreRankingPlayerList.Add(json1 != null ? new QuestScoreRankingPlayer((Dictionary<string, object>) json1) : (QuestScoreRankingPlayer) null);
        this.ranking = scoreRankingPlayerList.ToArray();
        this.my_ranking = json[nameof (my_ranking)] != null ? new QuestScoreRankingPlayer((Dictionary<string, object>) json[nameof (my_ranking)]) : (QuestScoreRankingPlayer) null;
      }
    }

    [Serializable]
    public class QuestkeyIndex : KeyCompare
    {
      public PlayerQuestGate[] quest_gates;
      public PlayerExtraQuestS[] player_extra_quests;
      public PlayerQuestKey[] player_quest_keys;

      public QuestkeyIndex()
      {
      }

      public QuestkeyIndex(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerQuestGate> playerQuestGateList = new List<PlayerQuestGate>();
        foreach (object json1 in (List<object>) json[nameof (quest_gates)])
          playerQuestGateList.Add(json1 != null ? new PlayerQuestGate((Dictionary<string, object>) json1) : (PlayerQuestGate) null);
        this.quest_gates = playerQuestGateList.ToArray();
        SMManager.UpdateList<PlayerQuestGate>(this.quest_gates);
        List<PlayerExtraQuestS> playerExtraQuestSList = new List<PlayerExtraQuestS>();
        foreach (object json2 in (List<object>) json[nameof (player_extra_quests)])
          playerExtraQuestSList.Add(json2 != null ? new PlayerExtraQuestS((Dictionary<string, object>) json2) : (PlayerExtraQuestS) null);
        this.player_extra_quests = playerExtraQuestSList.ToArray();
        SMManager.UpdateList<PlayerExtraQuestS>(this.player_extra_quests);
        List<PlayerQuestKey> playerQuestKeyList = new List<PlayerQuestKey>();
        foreach (object json3 in (List<object>) json[nameof (player_quest_keys)])
          playerQuestKeyList.Add(json3 != null ? new PlayerQuestKey((Dictionary<string, object>) json3) : (PlayerQuestKey) null);
        this.player_quest_keys = playerQuestKeyList.ToArray();
        SMManager.UpdateList<PlayerQuestKey>(this.player_quest_keys);
      }
    }

    [Serializable]
    public class QuestkeySpend : KeyCompare
    {
      public QuestKeyGate[] quest_key_gates;
      public PlayerQuestKey[] player_quest_keys;

      public QuestkeySpend()
      {
      }

      public QuestkeySpend(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<QuestKeyGate> questKeyGateList = new List<QuestKeyGate>();
        foreach (object json1 in (List<object>) json[nameof (quest_key_gates)])
          questKeyGateList.Add(json1 != null ? new QuestKeyGate((Dictionary<string, object>) json1) : (QuestKeyGate) null);
        this.quest_key_gates = questKeyGateList.ToArray();
        SMManager.UpdateList<QuestKeyGate>(this.quest_key_gates);
        List<PlayerQuestKey> playerQuestKeyList = new List<PlayerQuestKey>();
        foreach (object json2 in (List<object>) json[nameof (player_quest_keys)])
          playerQuestKeyList.Add(json2 != null ? new PlayerQuestKey((Dictionary<string, object>) json2) : (PlayerQuestKey) null);
        this.player_quest_keys = playerQuestKeyList.ToArray();
        SMManager.UpdateList<PlayerQuestKey>(this.player_quest_keys);
      }
    }

    [Serializable]
    public class QuestscoreReward : KeyCompare
    {
      public WebAPI.Response.QuestscoreRewardRewards[] rewards;
      public bool already_received;
      public PlayerPresent[] player_presents;
      public QuestScoreCampaignProgress[] score_campaigns;

      public QuestscoreReward()
      {
      }

      public QuestscoreReward(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<WebAPI.Response.QuestscoreRewardRewards> questscoreRewardRewardsList = new List<WebAPI.Response.QuestscoreRewardRewards>();
        foreach (object json1 in (List<object>) json[nameof (rewards)])
          questscoreRewardRewardsList.Add(json1 != null ? new WebAPI.Response.QuestscoreRewardRewards((Dictionary<string, object>) json1) : (WebAPI.Response.QuestscoreRewardRewards) null);
        this.rewards = questscoreRewardRewardsList.ToArray();
        this.already_received = (bool) json[nameof (already_received)];
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json2 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json2 != null ? new PlayerPresent((Dictionary<string, object>) json2) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<QuestScoreCampaignProgress> campaignProgressList = new List<QuestScoreCampaignProgress>();
        foreach (object json3 in (List<object>) json[nameof (score_campaigns)])
          campaignProgressList.Add(json3 != null ? new QuestScoreCampaignProgress((Dictionary<string, object>) json3) : (QuestScoreCampaignProgress) null);
        this.score_campaigns = campaignProgressList.ToArray();
        SMManager.UpdateList<QuestScoreCampaignProgress>(this.score_campaigns);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class QuestscoreRewardRewards : KeyCompare
    {
      public int reward_quantity;
      public int ranking_group_id;
      public int reward_type_id;
      public int? reward_id;

      public QuestscoreRewardRewards()
      {
      }

      public QuestscoreRewardRewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.ranking_group_id = (int) (long) json[nameof (ranking_group_id)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        int? nullable1;
        if (json[nameof (reward_id)] == null)
        {
          nullable1 = new int?();
        }
        else
        {
          long? nullable2 = (long?) json[nameof (reward_id)];
          nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
        }
        this.reward_id = nullable1;
      }
    }

    [Serializable]
    public class ReviewCancel : KeyCompare
    {
      public bool is_success;

      public ReviewCancel()
      {
      }

      public ReviewCancel(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.is_success = (bool) json[nameof (is_success)];
      }
    }

    [Serializable]
    public class ReviewContribute : KeyCompare
    {
      public bool is_success;

      public ReviewContribute()
      {
      }

      public ReviewContribute(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.is_success = (bool) json[nameof (is_success)];
      }
    }

    [Serializable]
    public class RpcMasterdataList : KeyCompare
    {
      public WebAPI.Response.RpcMasterdataListVersions[] versions;

      public RpcMasterdataList()
      {
      }

      public RpcMasterdataList(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<WebAPI.Response.RpcMasterdataListVersions> masterdataListVersionsList = new List<WebAPI.Response.RpcMasterdataListVersions>();
        foreach (object json1 in (List<object>) json[nameof (versions)])
          masterdataListVersionsList.Add(json1 != null ? new WebAPI.Response.RpcMasterdataListVersions((Dictionary<string, object>) json1) : (WebAPI.Response.RpcMasterdataListVersions) null);
        this.versions = masterdataListVersionsList.ToArray();
      }
    }

    [Serializable]
    public class RpcMasterdataListVersions : KeyCompare
    {
      public string dlc_version;
      public DateTime created_at;
      public DateTime updated_at;
      public string platform;
      public string masterdata_version;
      public string client_version;
      public string application_version;
      public bool is_maintenance;

      public RpcMasterdataListVersions()
      {
      }

      public RpcMasterdataListVersions(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.dlc_version = (string) json[nameof (dlc_version)];
        this.created_at = DateTime.Parse((string) json[nameof (created_at)]);
        this.updated_at = DateTime.Parse((string) json[nameof (updated_at)]);
        this.platform = (string) json[nameof (platform)];
        this.masterdata_version = (string) json[nameof (masterdata_version)];
        this.client_version = (string) json[nameof (client_version)];
        this.application_version = (string) json[nameof (application_version)];
        this.is_maintenance = (bool) json[nameof (is_maintenance)];
      }
    }

    [Serializable]
    public class RpcMasterdataQuery : KeyCompare
    {
      public string dlc_version;
      public DateTime created_at;
      public DateTime updated_at;
      public string platform;
      public string masterdata_version;
      public string client_version;
      public string application_version;
      public bool is_maintenance;

      public RpcMasterdataQuery()
      {
      }

      public RpcMasterdataQuery(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.dlc_version = (string) json[nameof (dlc_version)];
        this.created_at = DateTime.Parse((string) json[nameof (created_at)]);
        this.updated_at = DateTime.Parse((string) json[nameof (updated_at)]);
        this.platform = (string) json[nameof (platform)];
        this.masterdata_version = (string) json[nameof (masterdata_version)];
        this.client_version = (string) json[nameof (client_version)];
        this.application_version = (string) json[nameof (application_version)];
        this.is_maintenance = (bool) json[nameof (is_maintenance)];
      }
    }

    [Serializable]
    public class SeasonticketIndex : KeyCompare
    {
      public PlayerSeasonTicket[] player_season_tickets;

      public SeasonticketIndex()
      {
      }

      public SeasonticketIndex(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerSeasonTicket> playerSeasonTicketList = new List<PlayerSeasonTicket>();
        foreach (object json1 in (List<object>) json[nameof (player_season_tickets)])
          playerSeasonTicketList.Add(json1 != null ? new PlayerSeasonTicket((Dictionary<string, object>) json1) : (PlayerSeasonTicket) null);
        this.player_season_tickets = playerSeasonTicketList.ToArray();
        SMManager.UpdateList<PlayerSeasonTicket>(this.player_season_tickets);
      }
    }

    [Serializable]
    public class SeasonticketSpend : KeyCompare
    {
      public PlayerSeasonTicket[] player_season_tickets;

      public SeasonticketSpend()
      {
      }

      public SeasonticketSpend(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerSeasonTicket> playerSeasonTicketList = new List<PlayerSeasonTicket>();
        foreach (object json1 in (List<object>) json[nameof (player_season_tickets)])
          playerSeasonTicketList.Add(json1 != null ? new PlayerSeasonTicket((Dictionary<string, object>) json1) : (PlayerSeasonTicket) null);
        this.player_season_tickets = playerSeasonTicketList.ToArray();
        SMManager.UpdateList<PlayerSeasonTicket>(this.player_season_tickets);
      }
    }

    [Serializable]
    public class SerialList : KeyCompare
    {
      public SerialCampaign[] campaigns;

      public SerialList()
      {
      }

      public SerialList(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<SerialCampaign> serialCampaignList = new List<SerialCampaign>();
        foreach (object json1 in (List<object>) json[nameof (campaigns)])
          serialCampaignList.Add(json1 != null ? new SerialCampaign((Dictionary<string, object>) json1) : (SerialCampaign) null);
        this.campaigns = serialCampaignList.ToArray();
      }
    }

    [Serializable]
    public class SerialRegister : KeyCompare
    {
      public WebAPI.Response.SerialRegisterRewards[] rewards;
      public bool is_success;
      public PlayerPresent[] player_presents;

      public SerialRegister()
      {
      }

      public SerialRegister(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<WebAPI.Response.SerialRegisterRewards> serialRegisterRewardsList = new List<WebAPI.Response.SerialRegisterRewards>();
        foreach (object json1 in (List<object>) json[nameof (rewards)])
          serialRegisterRewardsList.Add(json1 != null ? new WebAPI.Response.SerialRegisterRewards((Dictionary<string, object>) json1) : (WebAPI.Response.SerialRegisterRewards) null);
        this.rewards = serialRegisterRewardsList.ToArray();
        this.is_success = (bool) json[nameof (is_success)];
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json2 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json2 != null ? new PlayerPresent((Dictionary<string, object>) json2) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class SerialRegisterRewards : KeyCompare
    {
      public int reward_quantity;
      public int reward_type_id;
      public int reward_id;

      public SerialRegisterRewards()
      {
      }

      public SerialRegisterRewards(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_id = (int) (long) json[nameof (reward_id)];
      }
    }

    [Serializable]
    public class ShopBuy : KeyCompare
    {
      public PlayerItem[] player_items;
      public PlayerUnit[] player_units;
      public WebAPI.Response.ShopBuyAfter after;
      public PlayerSeasonTicket[] player_season_tickets;
      public Player player;
      public Shop[] shops;
      public PlayerQuestKey[] player_quest_keys;
      public WebAPI.Response.ShopBuyBefore before;

      public ShopBuy()
      {
      }

      public ShopBuy(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        this.after = json[nameof (after)] != null ? new WebAPI.Response.ShopBuyAfter((Dictionary<string, object>) json[nameof (after)]) : (WebAPI.Response.ShopBuyAfter) null;
        List<PlayerSeasonTicket> playerSeasonTicketList = new List<PlayerSeasonTicket>();
        foreach (object json3 in (List<object>) json[nameof (player_season_tickets)])
          playerSeasonTicketList.Add(json3 != null ? new PlayerSeasonTicket((Dictionary<string, object>) json3) : (PlayerSeasonTicket) null);
        this.player_season_tickets = playerSeasonTicketList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<Shop> shopList = new List<Shop>();
        foreach (object json4 in (List<object>) json[nameof (shops)])
          shopList.Add(json4 != null ? new Shop((Dictionary<string, object>) json4) : (Shop) null);
        this.shops = shopList.ToArray();
        SMManager.UpdateList<Shop>(this.shops);
        List<PlayerQuestKey> playerQuestKeyList = new List<PlayerQuestKey>();
        foreach (object json5 in (List<object>) json[nameof (player_quest_keys)])
          playerQuestKeyList.Add(json5 != null ? new PlayerQuestKey((Dictionary<string, object>) json5) : (PlayerQuestKey) null);
        this.player_quest_keys = playerQuestKeyList.ToArray();
        SMManager.UpdateList<PlayerQuestKey>(this.player_quest_keys);
        this.before = json[nameof (before)] != null ? new WebAPI.Response.ShopBuyBefore((Dictionary<string, object>) json[nameof (before)]) : (WebAPI.Response.ShopBuyBefore) null;
      }
    }

    [Serializable]
    public class ShopBuyBefore : KeyCompare
    {
      public int money;
      public int battle_medal;
      public int coin;
      public int medal;

      public ShopBuyBefore()
      {
      }

      public ShopBuyBefore(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.money = (int) (long) json[nameof (money)];
        this.battle_medal = (int) (long) json[nameof (battle_medal)];
        this.coin = (int) (long) json[nameof (coin)];
        this.medal = (int) (long) json[nameof (medal)];
      }
    }

    [Serializable]
    public class ShopBuyAfter : KeyCompare
    {
      public int money;
      public int battle_medal;
      public int coin;
      public int medal;

      public ShopBuyAfter()
      {
      }

      public ShopBuyAfter(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.money = (int) (long) json[nameof (money)];
        this.battle_medal = (int) (long) json[nameof (battle_medal)];
        this.coin = (int) (long) json[nameof (coin)];
        this.medal = (int) (long) json[nameof (medal)];
      }
    }

    [Serializable]
    public class ShopStatus : KeyCompare
    {
      public Shop[] shops;
      public DateTime? limited_shop_end_at;
      public string limited_shop_banner_url;

      public ShopStatus()
      {
      }

      public ShopStatus(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<Shop> shopList = new List<Shop>();
        foreach (object json1 in (List<object>) json[nameof (shops)])
          shopList.Add(json1 != null ? new Shop((Dictionary<string, object>) json1) : (Shop) null);
        this.shops = shopList.ToArray();
        SMManager.UpdateList<Shop>(this.shops);
        this.limited_shop_end_at = json[nameof (limited_shop_end_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (limited_shop_end_at)])) : new DateTime?();
        this.limited_shop_banner_url = (string) json[nameof (limited_shop_banner_url)];
      }
    }

    [Serializable]
    public class Slot : KeyCompare
    {
      public SlotModule[] slot_modules;

      public Slot()
      {
      }

      public Slot(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<SlotModule> slotModuleList = new List<SlotModule>();
        foreach (object json1 in (List<object>) json[nameof (slot_modules)])
          slotModuleList.Add(json1 != null ? new SlotModule((Dictionary<string, object>) json1) : (SlotModule) null);
        this.slot_modules = slotModuleList.ToArray();
        SMManager.UpdateList<SlotModule>(this.slot_modules);
      }
    }

    [Serializable]
    public class SlotS001MedalPay : KeyCompare
    {
      public PlayerItem[] player_items;
      public PlayerUnit[] player_units;
      public int[] result_reel_index;
      public Player player;
      public WebAPI.Response.SlotS001MedalPayResult[] result;
      public int[] animation_pattern;
      public PlayerPresent[] player_presents;
      public PlayerQuestKey[] player_quest_keys;

      public SlotS001MedalPay()
      {
      }

      public SlotS001MedalPay(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        this.result_reel_index = ((IEnumerable<object>) json[nameof (result_reel_index)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<WebAPI.Response.SlotS001MedalPayResult> s001MedalPayResultList = new List<WebAPI.Response.SlotS001MedalPayResult>();
        foreach (object json3 in (List<object>) json[nameof (result)])
          s001MedalPayResultList.Add(json3 != null ? new WebAPI.Response.SlotS001MedalPayResult((Dictionary<string, object>) json3) : (WebAPI.Response.SlotS001MedalPayResult) null);
        this.result = s001MedalPayResultList.ToArray();
        this.animation_pattern = ((IEnumerable<object>) json[nameof (animation_pattern)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
        List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
        foreach (object json4 in (List<object>) json[nameof (player_presents)])
          playerPresentList.Add(json4 != null ? new PlayerPresent((Dictionary<string, object>) json4) : (PlayerPresent) null);
        this.player_presents = playerPresentList.ToArray();
        SMManager.UpdateList<PlayerPresent>(this.player_presents);
        List<PlayerQuestKey> playerQuestKeyList = new List<PlayerQuestKey>();
        foreach (object json5 in (List<object>) json[nameof (player_quest_keys)])
          playerQuestKeyList.Add(json5 != null ? new PlayerQuestKey((Dictionary<string, object>) json5) : (PlayerQuestKey) null);
        this.player_quest_keys = playerQuestKeyList.ToArray();
        SMManager.UpdateList<PlayerQuestKey>(this.player_quest_keys);
        if (!json.ContainsKey("player_presents:delete"))
          return;
        SMManager.DeleteList<PlayerPresent>(((IEnumerable<object>) json["player_presents:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class SlotS001MedalPayResult : KeyCompare
    {
      public int rarity_id;
      public int reward_result_quantity;
      public bool is_new;
      public int reward_type_id;
      public int reward_result_id;

      public SlotS001MedalPayResult()
      {
      }

      public SlotS001MedalPayResult(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.rarity_id = (int) (long) json[nameof (rarity_id)];
        this.reward_result_quantity = (int) (long) json[nameof (reward_result_quantity)];
        this.is_new = (bool) json[nameof (is_new)];
        this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
        this.reward_result_id = (int) (long) json[nameof (reward_result_id)];
      }
    }

    [Serializable]
    public class TutorialTutorialResume : KeyCompare
    {
      public PlayerDeck[] player_decks;
      public Player player;
      public PlayerItem[] player_items;
      public PlayerUnit[] player_units;

      public TutorialTutorialResume()
      {
      }

      public TutorialTutorialResume(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerDeck> playerDeckList = new List<PlayerDeck>();
        foreach (object json1 in (List<object>) json[nameof (player_decks)])
          playerDeckList.Add(json1 != null ? new PlayerDeck((Dictionary<string, object>) json1) : (PlayerDeck) null);
        this.player_decks = playerDeckList.ToArray();
        SMManager.UpdateList<PlayerDeck>(this.player_decks);
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json2 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json2 != null ? new PlayerItem((Dictionary<string, object>) json2) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json3 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json3 != null ? new PlayerUnit((Dictionary<string, object>) json3) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
      }
    }

    [Serializable]
    public class TutorialTutorialValid : KeyCompare
    {
      public bool is_valid;

      public TutorialTutorialValid()
      {
      }

      public TutorialTutorialValid(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.is_valid = (bool) json[nameof (is_valid)];
      }
    }

    [Serializable]
    public class UnitCompose : KeyCompare
    {
      public PlayerItem[] player_items;
      public PlayerUnit[] player_units;
      public int increment_medal;
      public UnlockQuest[] unlock_quests;
      public Player player;
      public bool is_success;

      public UnitCompose()
      {
      }

      public UnitCompose(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        this.increment_medal = (int) (long) json[nameof (increment_medal)];
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json3 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json3 != null ? new UnlockQuest((Dictionary<string, object>) json3) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        this.is_success = (bool) json[nameof (is_success)];
        if (!json.ContainsKey("player_units:delete"))
          return;
        SMManager.DeleteList<PlayerUnit>(((IEnumerable<object>) json["player_units:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class UnitEquip : KeyCompare
    {
      public Player player;
      public PlayerItem[] player_items;
      public PlayerUnit[] player_units;

      public UnitEquip()
      {
      }

      public UnitEquip(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
      }
    }

    [Serializable]
    public class UnitEvolution : KeyCompare
    {
      public Player player;
      public UnlockQuest[] unlock_quests;
      public bool is_new;
      public PlayerUnit[] player_units;

      public UnitEvolution()
      {
      }

      public UnitEvolution(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
        foreach (object json1 in (List<object>) json[nameof (unlock_quests)])
          unlockQuestList.Add(json1 != null ? new UnlockQuest((Dictionary<string, object>) json1) : (UnlockQuest) null);
        this.unlock_quests = unlockQuestList.ToArray();
        this.is_new = (bool) json[nameof (is_new)];
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        if (!json.ContainsKey("player_units:delete"))
          return;
        SMManager.DeleteList<PlayerUnit>(((IEnumerable<object>) json["player_units:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class UnitEvolutionParameter : KeyCompare
    {
      public PlayerUnit[] target_player_units;
      public PlayerUnit target_player_unit;

      public UnitEvolutionParameter()
      {
      }

      public UnitEvolutionParameter(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json1 in (List<object>) json[nameof (target_player_units)])
          playerUnitList.Add(json1 != null ? new PlayerUnit((Dictionary<string, object>) json1) : (PlayerUnit) null);
        this.target_player_units = playerUnitList.ToArray();
        this.target_player_unit = json[nameof (target_player_unit)] != null ? new PlayerUnit((Dictionary<string, object>) json[nameof (target_player_unit)]) : (PlayerUnit) null;
      }
    }

    [Serializable]
    public class UnitFavorite : KeyCompare
    {
      public PlayerUnit[] player_units;

      public UnitFavorite()
      {
      }

      public UnitFavorite(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json1 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json1 != null ? new PlayerUnit((Dictionary<string, object>) json1) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
      }
    }

    [Serializable]
    public class UnitSell : KeyCompare
    {
      public Player player;
      public PlayerItem[] player_items;
      public PlayerUnit[] player_units;

      public UnitSell()
      {
      }

      public UnitSell(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerItem> playerItemList = new List<PlayerItem>();
        foreach (object json1 in (List<object>) json[nameof (player_items)])
          playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
        this.player_items = playerItemList.ToArray();
        SMManager.UpdateList<PlayerItem>(this.player_items);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json2 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        if (!json.ContainsKey("player_units:delete"))
          return;
        SMManager.DeleteList<PlayerUnit>(((IEnumerable<object>) json["player_units:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class UnitTransmigrate : KeyCompare
    {
      public Player player;
      public PlayerUnit[] player_units;

      public UnitTransmigrate()
      {
      }

      public UnitTransmigrate(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player = json[nameof (player)] != null ? new Player((Dictionary<string, object>) json[nameof (player)]) : (Player) null;
        SMManager.Change<Player>(this.player);
        List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
        foreach (object json1 in (List<object>) json[nameof (player_units)])
          playerUnitList.Add(json1 != null ? new PlayerUnit((Dictionary<string, object>) json1) : (PlayerUnit) null);
        this.player_units = playerUnitList.ToArray();
        SMManager.UpdateList<PlayerUnit>(this.player_units);
        if (!json.ContainsKey("player_units:delete"))
          return;
        SMManager.DeleteList<PlayerUnit>(((IEnumerable<object>) json["player_units:delete"]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).Select<int, object>((Func<int, object>) (x => (object) x)).ToArray<object>());
      }
    }

    [Serializable]
    public class UnitTransmigrateParameter : KeyCompare
    {
      public PlayerUnit target_player_unit;

      public UnitTransmigrateParameter()
      {
      }

      public UnitTransmigrateParameter(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.target_player_unit = json[nameof (target_player_unit)] != null ? new PlayerUnit((Dictionary<string, object>) json[nameof (target_player_unit)]) : (PlayerUnit) null;
      }
    }

    [Serializable]
    public class ZeroLoad : KeyCompare
    {
      public string player_data;
      public bool has_data;

      public ZeroLoad()
      {
      }

      public ZeroLoad(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.player_data = (string) json[nameof (player_data)];
        this.has_data = (bool) json[nameof (has_data)];
      }
    }

    [Serializable]
    public class ZeroReset : KeyCompare
    {
      public bool is_success;

      public ZeroReset()
      {
      }

      public ZeroReset(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.is_success = (bool) json[nameof (is_success)];
      }
    }

    [Serializable]
    public class ZeroSave : KeyCompare
    {
      public bool is_success;

      public ZeroSave()
      {
      }

      public ZeroSave(Dictionary<string, object> json)
      {
        this._hasKey = false;
        this.is_success = (bool) json[nameof (is_success)];
      }
    }

    [Serializable]
    public class ZukanDefeatRewardEnemy : KeyCompare
    {
      public PlayerEnemyHistory[] histories;
      public PlayerDefeatReward[] defeat_rewards;

      public ZukanDefeatRewardEnemy()
      {
      }

      public ZukanDefeatRewardEnemy(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerEnemyHistory> playerEnemyHistoryList = new List<PlayerEnemyHistory>();
        foreach (object json1 in (List<object>) json[nameof (histories)])
          playerEnemyHistoryList.Add(json1 != null ? new PlayerEnemyHistory((Dictionary<string, object>) json1) : (PlayerEnemyHistory) null);
        this.histories = playerEnemyHistoryList.ToArray();
        SMManager.UpdateList<PlayerEnemyHistory>(this.histories);
        List<PlayerDefeatReward> playerDefeatRewardList = new List<PlayerDefeatReward>();
        foreach (object json2 in (List<object>) json[nameof (defeat_rewards)])
          playerDefeatRewardList.Add(json2 != null ? new PlayerDefeatReward((Dictionary<string, object>) json2) : (PlayerDefeatReward) null);
        this.defeat_rewards = playerDefeatRewardList.ToArray();
        SMManager.UpdateList<PlayerDefeatReward>(this.defeat_rewards);
      }
    }

    [Serializable]
    public class ZukanDefeatRewardReceive : KeyCompare
    {
      public PlayerDefeatReward[] defeat_rewards;

      public ZukanDefeatRewardReceive()
      {
      }

      public ZukanDefeatRewardReceive(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerDefeatReward> playerDefeatRewardList = new List<PlayerDefeatReward>();
        foreach (object json1 in (List<object>) json[nameof (defeat_rewards)])
          playerDefeatRewardList.Add(json1 != null ? new PlayerDefeatReward((Dictionary<string, object>) json1) : (PlayerDefeatReward) null);
        this.defeat_rewards = playerDefeatRewardList.ToArray();
        SMManager.UpdateList<PlayerDefeatReward>(this.defeat_rewards);
      }
    }

    [Serializable]
    public class ZukanEnemy : KeyCompare
    {
      public PlayerEnemyHistory[] histories;

      public ZukanEnemy()
      {
      }

      public ZukanEnemy(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerEnemyHistory> playerEnemyHistoryList = new List<PlayerEnemyHistory>();
        foreach (object json1 in (List<object>) json[nameof (histories)])
          playerEnemyHistoryList.Add(json1 != null ? new PlayerEnemyHistory((Dictionary<string, object>) json1) : (PlayerEnemyHistory) null);
        this.histories = playerEnemyHistoryList.ToArray();
        SMManager.UpdateList<PlayerEnemyHistory>(this.histories);
      }
    }

    [Serializable]
    public class ZukanGear : KeyCompare
    {
      public PlayerGearHistory[] histories;

      public ZukanGear()
      {
      }

      public ZukanGear(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerGearHistory> playerGearHistoryList = new List<PlayerGearHistory>();
        foreach (object json1 in (List<object>) json[nameof (histories)])
          playerGearHistoryList.Add(json1 != null ? new PlayerGearHistory((Dictionary<string, object>) json1) : (PlayerGearHistory) null);
        this.histories = playerGearHistoryList.ToArray();
        SMManager.UpdateList<PlayerGearHistory>(this.histories);
      }
    }

    [Serializable]
    public class ZukanUnit : KeyCompare
    {
      public PlayerUnitHistory[] histories;

      public ZukanUnit()
      {
      }

      public ZukanUnit(Dictionary<string, object> json)
      {
        this._hasKey = false;
        List<PlayerUnitHistory> playerUnitHistoryList = new List<PlayerUnitHistory>();
        foreach (object json1 in (List<object>) json[nameof (histories)])
          playerUnitHistoryList.Add(json1 != null ? new PlayerUnitHistory((Dictionary<string, object>) json1) : (PlayerUnitHistory) null);
        this.histories = playerUnitHistoryList.ToArray();
        SMManager.UpdateList<PlayerUnitHistory>(this.histories);
      }
    }

    public class UserError
    {
      public readonly string Code = string.Empty;
      public readonly string Reason = string.Empty;

      public UserError(Dictionary<string, object> json)
      {
        object obj;
        if (json.TryGetValue("code", out obj))
        {
          if (!(obj is string str))
            str = string.Empty;
          this.Code = str;
        }
        if (!json.TryGetValue("reason", out obj))
          return;
        if (!(obj is string str1))
          str1 = string.Empty;
        this.Reason = str1;
      }
    }
  }

  public static class Request
  {
    public class BattleFinish
    {
      public CommonQuestType quest_type;
      public bool win;
      public bool is_game_over;
      public string battle_uuid;
      public int player_money;
      public int battle_turn;
      public int continue_count;
      public int week_element_attack_count;
      public int week_kind_attack_count;
      public List<int> panel_entity_ids = new List<int>();
      public List<int> drop_entity_ids = new List<int>();
      public List<GameCore.Reward> panel_reward = new List<GameCore.Reward>();
      public List<GameCore.Reward> drop_reward = new List<GameCore.Reward>();
      public List<int> duels_critical_count = new List<int>();
      public List<int> duels_damage = new List<int>();
      public List<int> duels_hit_damage = new List<int>();
      public List<int> duels_max_damage = new List<int>();
      public List<WebAPI.Request.BattleFinish.UnitResult> units = new List<WebAPI.Request.BattleFinish.UnitResult>();
      public List<WebAPI.Request.BattleFinish.EnemyResult> enemies = new List<WebAPI.Request.BattleFinish.EnemyResult>();
      public List<WebAPI.Request.BattleFinish.GearResult> gears = new List<WebAPI.Request.BattleFinish.GearResult>();
      public List<WebAPI.Request.BattleFinish.SupplyResult> supplies = new List<WebAPI.Request.BattleFinish.SupplyResult>();
      public List<WebAPI.Request.BattleFinish.IntimateResult> intimates = new List<WebAPI.Request.BattleFinish.IntimateResult>();

      public class UnitResult
      {
        public int player_unit_id;
        public int total_damage;
        public int total_damage_count;
        public int total_kill_count;
        public int remaining_hp;
        public int rental;
        public int received_damage;
      }

      public class EnemyResult
      {
        public int enemy_id;
        public int kill_count;
        public int dead_count;
        public int level_difference;
        public int overkill_damage;
        public int kill_by_playerunit_id;
      }

      public class GearResult
      {
        public int player_gear_id;
        public int damage_count;
        public int kill_count;
      }

      public class SupplyResult
      {
        public int supply_id;
        public int use_quantity;
      }

      public class IntimateResult
      {
        public int character_id;
        public int target_character_id;
        public int exp;
      }
    }
  }
}
