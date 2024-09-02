// Decompiled with JetBrains decompiler
// Type: PunitiveexpeditionType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
