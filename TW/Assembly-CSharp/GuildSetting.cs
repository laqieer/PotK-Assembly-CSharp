// Decompiled with JetBrains decompiler
// Type: GuildSetting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public class GuildSetting
{
  public string guildName;
  public string atmosphere;
  public string approval;
  public string autoApproval;
  public string availability;

  public GuildSetting()
  {
    this.guildName = string.Empty;
    this.atmosphere = Consts.GetInstance().GUILD_SETTING_CONDITIONS_NULL;
    this.approval = Consts.GetInstance().GUILD_SETTING_CONDITIONS_NULL;
    this.autoApproval = Consts.GetInstance().GUILD_SETTING_CONDITIONS_NULL;
    this.availability = Consts.GetInstance().GUILD_SETTING_CONDITIONS_NULL;
  }

  public int atmosphereID
  {
    get
    {
      return this.atmosphere == Consts.GetInstance().GUILD_SETTING_CONDITIONS_NULL ? -1 : ((IEnumerable<GuildAtmosphere>) MasterData.GuildAtmosphereList).Where<GuildAtmosphere>((Func<GuildAtmosphere, bool>) (x => x.name == this.atmosphere)).First<GuildAtmosphere>().ID;
    }
  }

  public int approvalID
  {
    get
    {
      return this.approval == Consts.GetInstance().GUILD_SETTING_CONDITIONS_NULL ? -1 : ((IEnumerable<GuildApprovalPolicy>) MasterData.GuildApprovalPolicyList).Where<GuildApprovalPolicy>((Func<GuildApprovalPolicy, bool>) (x => x.name == this.approval)).First<GuildApprovalPolicy>().ID;
    }
  }

  public int autoApprovalID
  {
    get
    {
      return this.autoApproval == Consts.GetInstance().GUILD_SETTING_CONDITIONS_NULL ? -1 : ((IEnumerable<GuildAutoApproval>) MasterData.GuildAutoApprovalList).Where<GuildAutoApproval>((Func<GuildAutoApproval, bool>) (x => x.name == this.autoApproval)).First<GuildAutoApproval>().ID;
    }
  }

  public int availabilityID
  {
    get
    {
      return this.availability == Consts.GetInstance().GUILD_SETTING_CONDITIONS_NULL ? -1 : ((IEnumerable<GuildAvailability>) MasterData.GuildAvailabilityList).Where<GuildAvailability>((Func<GuildAvailability, bool>) (x => x.name == this.availability)).First<GuildAvailability>().ID;
    }
  }
}
