// Decompiled with JetBrains decompiler
// Type: MissionData.Util
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using SM;

namespace MissionData
{
  public static class Util
  {
    public static IMissionReward Create(DailyMissionReward dat) => dat == null ? (IMissionReward) null : (IMissionReward) new DailyIMissionReward(dat);

    public static IMissionReward Create(GuildMissionReward dat) => dat == null ? (IMissionReward) null : (IMissionReward) new GuildIMissionReward(dat);

    public static IMissionAchievement Create(PlayerDailyMissionAchievement data) => data == null ? (IMissionAchievement) null : (IMissionAchievement) new DailyIMissionAchievement(data);

    public static IMissionAchievement Create(GuildMissionInfo data) => data == null ? (IMissionAchievement) null : (IMissionAchievement) new GuildIMissionAchievement(data);

    public static IMission Create(DailyMission data) => data == null ? (IMission) null : (IMission) new DailyIMission(data);

    public static IMission Create(GuildMission data) => data == null ? (IMission) null : (IMission) new GuildIMission(data);
  }
}
