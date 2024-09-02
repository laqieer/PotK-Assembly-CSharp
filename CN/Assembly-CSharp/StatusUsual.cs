// Decompiled with JetBrains decompiler
// Type: StatusUsual
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
public class StatusUsual
{
  [SerializeField]
  private UI2DSprite guildTitleImage;
  private Future<Sprite> futureGuildTitleImage;
  [SerializeField]
  private UILabel guildName;
  [SerializeField]
  private UILabel guildRank;
  [SerializeField]
  private UILabel currentMember;
  [SerializeField]
  private UILabel maxMember;

  [DebuggerHidden]
  public IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StatusUsual.\u003CResourceLoad\u003Ec__Iterator6CD()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void SetStatus(GuildRegistration data)
  {
    this.guildTitleImage.sprite2D = this.futureGuildTitleImage.Result;
    this.guildName.SetTextLocalize(data.guild_name);
    this.guildRank.SetTextLocalize(data.appearance.level.ToString());
    this.currentMember.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_4_CURRENT_MEMBER, (IDictionary) new Hashtable()
    {
      {
        (object) "currentMember",
        (object) data.appearance.membership_num
      }
    }));
    this.maxMember.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_4_MAX_MEMBER, (IDictionary) new Hashtable()
    {
      {
        (object) "maxMember",
        (object) data.appearance.membership_capacity
      }
    }));
  }
}
