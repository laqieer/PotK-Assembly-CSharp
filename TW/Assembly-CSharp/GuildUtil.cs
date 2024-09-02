// Decompiled with JetBrains decompiler
// Type: GuildUtil
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
using UniLinq;
using UnityEngine;

#nullable disable
public class GuildUtil
{
  public const string ERR_NG_WORD = "GLD011";
  public const string ERR_NO_APPLICANT = "GLD006";
  public const string ERR_APPLIED = "GLD001";
  public const string ERR_NO_AUTOLIZATION = "GLD002";
  public const string ERR_GUILD_MAINTENANCE = "GLD014";
  public const string ERR_GUILD_CHAT_MAINTENANCE = "GLD015";
  public const string ERR_GUILD_FACILITY_CONSISTENCY = "GLD016";
  public const string ERR_GVG_BATTLE_ALREADY_FINISHED = "GVG001";
  public const string ERR_GVG_CANNOT_USE_ON_GVG = "GVG002";
  public const string ERR_GVG_INVALID_GVG_RESULT = "GVG003";
  public const string ERR_GVG_BATTLE_TARGET_IS_IN_BATTLE = "GVG005";
  public const string ERR_GVG_BATTLE_EXPIRED = "GVG006";
  public const string ERR_GVG_DEF_FRIEND_ALREADY_SELECTED = "GVG007";
  public const string slcTextGLVNumber = "slc_text_glv_number{0}.png__GUI__guild_common__guild_common_prefab";
  public const int GvgExcellentWinStarNum = 3;
  public const int GvgGreatWinStarNum = 2;
  public const int GvgWinStarNum = 1;
  public static GvgDeck gvgDeckAttack = (GvgDeck) null;
  public static GvgDeck gvgDeckDefense = (GvgDeck) null;
  public static GvgReinforcement gvgFriendDefense = (GvgReinforcement) null;
  public static GvgCandidate gvgFriendAttack = (GvgCandidate) null;
  public static GuildUtil.GvGPopupState gvgPopupState = GuildUtil.GvGPopupState.None;
  public static string gvgBattleIDServer = string.Empty;

  public static void setBadgeState(GuildUtil.GuildBadgeInfoType key, bool state)
  {
    try
    {
      Persist.guildSetting.Data.setBadgeState(key, state);
    }
    catch (Exception ex)
    {
      Persist.guildSetting.Delete();
    }
  }

  public static bool getBadgeState(GuildUtil.GuildBadgeInfoType key)
  {
    try
    {
      return Persist.guildSetting.Data.getBadgeState(key);
    }
    catch (Exception ex)
    {
      Persist.guildSetting.Delete();
    }
    return false;
  }

  public static int getGuildMemberNum()
  {
    try
    {
      return Persist.guildSetting.Data.memberNum;
    }
    catch (Exception ex)
    {
      Persist.guildSetting.Delete();
    }
    return -1;
  }

  public static void setGuildMemberNum(int num)
  {
    try
    {
      Persist.guildSetting.Data.memberNum = num;
    }
    catch (Exception ex)
    {
      Persist.guildSetting.Delete();
    }
  }

  public static void setTitleSortCategory(int val)
  {
    try
    {
      Persist.guildSetting.Data.titleSortCategory = val;
    }
    catch (Exception ex)
    {
      Persist.guildSetting.Delete();
    }
  }

  public static int getTitleSortCategory()
  {
    try
    {
      return Persist.guildSetting.Data.titleSortCategory;
    }
    catch (Exception ex)
    {
      Persist.guildSetting.Delete();
    }
    return 0;
  }

  public static void setTimeTitleAppear(DateTime time)
  {
    try
    {
      Persist.guildSetting.Data.timeTitleAppear = time;
    }
    catch (Exception ex)
    {
      Persist.guildSetting.Delete();
    }
  }

  public static DateTime getTimeTitleAppear()
  {
    try
    {
      return Persist.guildSetting.Data.timeTitleAppear;
    }
    catch (Exception ex)
    {
      Persist.guildSetting.Delete();
    }
    return new DateTime(2000, 1, 1);
  }

  public static string gvgBattleIDLocal
  {
    get
    {
      try
      {
        return Persist.gvgBattleEnvironment.Data.core.battleInfo.battleId;
      }
      catch (Exception ex)
      {
      }
      return string.Empty;
    }
  }

  [DebuggerHidden]
  public static IEnumerator EditGuildDeckAttack(int[] playerUnitIds, System.Action action = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildUtil.\u003CEditGuildDeckAttack\u003Ec__IteratorBFC()
    {
      playerUnitIds = playerUnitIds,
      action = action,
      \u003C\u0024\u003EplayerUnitIds = playerUnitIds,
      \u003C\u0024\u003Eaction = action
    };
  }

  [DebuggerHidden]
  public static IEnumerator EditGuildDeckDefense(int[] playerUnitIds, System.Action action = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildUtil.\u003CEditGuildDeckDefense\u003Ec__IteratorBFD()
    {
      playerUnitIds = playerUnitIds,
      action = action,
      \u003C\u0024\u003EplayerUnitIds = playerUnitIds,
      \u003C\u0024\u003Eaction = action
    };
  }

  [DebuggerHidden]
  public static IEnumerator UpdateGuildDeckAttack(string guild_id, string player_id, System.Action action = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildUtil.\u003CUpdateGuildDeckAttack\u003Ec__IteratorBFE()
    {
      guild_id = guild_id,
      player_id = player_id,
      action = action,
      \u003C\u0024\u003Eguild_id = guild_id,
      \u003C\u0024\u003Eplayer_id = player_id,
      \u003C\u0024\u003Eaction = action
    };
  }

  [DebuggerHidden]
  public static IEnumerator UpdateGuildDeckDefanse(
    string guild_id,
    string player_id,
    System.Action action = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildUtil.\u003CUpdateGuildDeckDefanse\u003Ec__IteratorBFF()
    {
      guild_id = guild_id,
      player_id = player_id,
      action = action,
      \u003C\u0024\u003Eguild_id = guild_id,
      \u003C\u0024\u003Eplayer_id = player_id,
      \u003C\u0024\u003Eaction = action
    };
  }

  public static void UpdateMembershipDeckValue(
    GuildMembership[] members,
    GvgDeck deck,
    string player_id,
    bool isAttack)
  {
    if (PlayerAffiliation.Current == null)
      return;
    for (int index = 0; index < members.Length; ++index)
    {
      GuildMembership member = members[index];
      if (member.player.player_id.Equals(player_id))
      {
        int combat = 0;
        ((IEnumerable<PlayerUnit>) deck.player_units).ForEach<PlayerUnit>((Action<PlayerUnit>) (x =>
        {
          if (!(x != (PlayerUnit) null))
            return;
          combat += Judgement.NonBattleParameter.FromPlayerUnit(x).Combat;
        }));
        if (isAttack)
        {
          member.total_attack = combat;
          break;
        }
        member.total_defense = combat;
        break;
      }
    }
  }

  public static float GVGStartHour() => GuildUtil.GVGKeyGetHour("GVG_START_HOUR");

  public static float GVGEndHour() => GuildUtil.GVGKeyGetHour("GVG_END_HOUR");

  public static float GVGReleaseEntryHour() => GuildUtil.GVGKeyGetHour("GVG_RELEASE_ENTRY_HOUR");

  public static float GVGEntryExpiredHour() => GuildUtil.GVGKeyGetHour("GVG_ENTRY_EXPIRED_HOUR");

  public static int GetGuildSettingInt(string key)
  {
    float result = 0.0f;
    float.TryParse(((IEnumerable<MasterDataTable.GuildSetting>) MasterData.GuildSettingList).Where<MasterDataTable.GuildSetting>((Func<MasterDataTable.GuildSetting, bool>) (x => x.key == key)).FirstOrDefault<MasterDataTable.GuildSetting>().value, out result);
    return (int) result;
  }

  private static float GVGKeyGetHour(string key)
  {
    float result = 0.0f;
    float.TryParse(((IEnumerable<MasterDataTable.GuildSetting>) MasterData.GuildSettingList).Where<MasterDataTable.GuildSetting>((Func<MasterDataTable.GuildSetting, bool>) (x => x.key == key)).FirstOrDefault<MasterDataTable.GuildSetting>().value, out result);
    return result;
  }

  [DebuggerHidden]
  public static IEnumerator TimeCountSprite(
    List<SpriteNumberSelectDirect> hour,
    List<SpriteNumberSelectDirect> minute,
    double actionTime,
    System.Action action,
    NGMenuBase menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildUtil.\u003CTimeCountSprite\u003Ec__IteratorC00()
    {
      actionTime = actionTime,
      menu = menu,
      hour = hour,
      minute = minute,
      action = action,
      \u003C\u0024\u003EactionTime = actionTime,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Ehour = hour,
      \u003C\u0024\u003Eminute = minute,
      \u003C\u0024\u003Eaction = action
    };
  }

  [DebuggerHidden]
  public static IEnumerator TimeCountText(
    UILabel label,
    string text,
    double actionTime,
    System.Action action,
    MonoBehaviour menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildUtil.\u003CTimeCountText\u003Ec__IteratorC01()
    {
      actionTime = actionTime,
      menu = menu,
      label = label,
      text = text,
      action = action,
      \u003C\u0024\u003EactionTime = actionTime,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Elabel = label,
      \u003C\u0024\u003Etext = text,
      \u003C\u0024\u003Eaction = action
    };
  }

  private static DateTime TargetTime(DateTime now, double actionTime)
  {
    int hour = now.Hour;
    DateTime dateTime = new DateTime(now.Year, now.Month, now.Day);
    if ((double) hour >= actionTime)
      dateTime = dateTime.AddDays(1.0);
    return dateTime.AddHours(actionTime);
  }

  public static bool isBattleOrPreparing(GvgStatus gvgStatus)
  {
    return gvgStatus == GvgStatus.preparing || gvgStatus == GvgStatus.fighting;
  }

  public static bool isBattle(GvgStatus gvgStatus) => gvgStatus == GvgStatus.fighting;

  public enum GvGPopupState
  {
    None,
    AtkTeam,
    DefTeam,
    Sortie,
  }

  public enum FooterGuildBadge
  {
    bikkuri,
    label,
    chat,
  }

  public enum GuildBadgeLabelType
  {
    none,
    entry,
    prepare,
    battle,
  }

  public enum GuildBadgeInfoType
  {
    newApplicant,
    newTitle,
    newGift,
    changeRole,
    startHuntingEvent,
    receiveHuntingReward,
    newMember,
    guildLevelup,
    baseRankUp,
    postNewChat,
    gvg_entry,
    gvg_matched,
    gvg_started,
  }
}
