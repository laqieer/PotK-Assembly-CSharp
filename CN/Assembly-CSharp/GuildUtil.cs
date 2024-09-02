// Decompiled with JetBrains decompiler
// Type: GuildUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
public class GuildUtil
{
  public const string ERR_NG_WORD = "GLD011";
  public const string ERR_NO_APPLICANT = "GLD006";
  public const string ERR_APPLIED = "GLD001";
  public const string ERR_GUILD_MAINTENANCE = "GLD014";
  public const string ERR_GUILD_CHAT_MAINTENANCE = "GLD015";
  public const string ERR_GUILD_FACILITY_CONSISTENCY = "GLD016";
  public const string slcTextGLVNumber = "slc_text_glv_number{0}.png__GUI__guild_common__guild_common_prefab";

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

  public enum GuildBadgeInfoType
  {
    newApplicant,
    newTitle,
    newGift,
    changeRole,
    startHuntingEvent,
    receiveHuntingReward,
    newMember,
  }
}
