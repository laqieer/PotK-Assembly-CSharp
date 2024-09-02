// Decompiled with JetBrains decompiler
// Type: PunitiveexpeditionType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;

#nullable disable
public static class PunitiveexpeditionType
{
  public static bool IsGuild(this WebAPI.Response.EventTop eventTop) => eventTop.period_type == 2;

  public static bool IsGuild(this EventBattleFinish eventBattleFinish)
  {
    return eventBattleFinish.period_type == 2;
  }

  public static bool IsGuild(this EventInfo eventInfo) => eventInfo.period_type == 2;
}
