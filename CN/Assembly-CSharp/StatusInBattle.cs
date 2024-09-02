// Decompiled with JetBrains decompiler
// Type: StatusInBattle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
[Serializable]
public class StatusInBattle
{
  [SerializeField]
  private StatusInBattle.Status MyStatus;
  [SerializeField]
  private StatusInBattle.Status EnStatus;

  [DebuggerHidden]
  public IEnumerator ResourceLoad(GuildRegistration myData, GuildRegistration enData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StatusInBattle.\u003CResourceLoad\u003Ec__Iterator6CE()
    {
      myData = myData,
      enData = enData,
      \u003C\u0024\u003EmyData = myData,
      \u003C\u0024\u003EenData = enData,
      \u003C\u003Ef__this = this
    };
  }

  public void SetStatus(GuildRegistration myData, GuildRegistration enData)
  {
    this.MyStatus.SetStatus(myData);
    this.EnStatus.SetStatus(enData);
  }

  [Serializable]
  private class Status
  {
    [SerializeField]
    private UI2DSprite guildTitleImage;
    private Future<Sprite> futureGuildTitleImage;
    public UISprite start_1;
    public UISprite start_10;
    public UILabel guildRank;
    public UILabel guildCurrentMember;
    public UILabel guildMaxMember;
    public UILabel guildName;
    public NGTweenGaugeScale starGauge;

    [DebuggerHidden]
    public IEnumerator ResourceLoad(GuildRegistration data)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new StatusInBattle.Status.\u003CResourceLoad\u003Ec__Iterator6CF()
      {
        data = data,
        \u003C\u0024\u003Edata = data,
        \u003C\u003Ef__this = this
      };
    }

    public void SetStatus(GuildRegistration data)
    {
      this.guildTitleImage.sprite2D = this.futureGuildTitleImage.Result;
      this.guildRank.SetTextLocalize(data.appearance.level.ToString());
      this.guildCurrentMember.SetTextLocalize(data.memberships.Length.ToString());
      this.guildName.SetTextLocalize(data.guild_name);
      this.starGauge.setValue(99, 99);
      this.start_1.SetSprite(string.Format("slc_SetupTime{0}.png__GUI__battleUI__battleUI_prefab", (object) 0));
      this.start_10.SetSprite(string.Format("slc_SetupTime{0}.png__GUI__battleUI__battleUI_prefab", (object) 0));
    }
  }
}
