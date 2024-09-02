// Decompiled with JetBrains decompiler
// Type: Guild02811Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild02811Scroll : MonoBehaviour
{
  private GuildDirectory guild;
  private GuildInfoPopup guildPopup;
  [SerializeField]
  private Transform guildBasePos;
  private GameObject guildBasePrefab;
  private Guild0282GuildBase guildBase;
  [SerializeField]
  private UI2DSprite guildTitleImage;
  [SerializeField]
  private UILabel guildName;
  [SerializeField]
  private UISprite guildRank1;
  [SerializeField]
  private UISprite guildRank10;
  [SerializeField]
  private UILabel nextExp;
  [SerializeField]
  private UILabel currentMember;
  [SerializeField]
  private UILabel maxMember;
  [SerializeField]
  private NGTweenGaugeScale expGauge;
  [SerializeField]
  private GameObject applyObj;
  private GuildImageCache guildImageCache;

  [DebuggerHidden]
  public IEnumerator Initialize(GuildDirectory guildData, GuildInfoPopup popup, bool IsApply)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02811Scroll.\u003CInitialize\u003Ec__Iterator6AC()
    {
      IsApply = IsApply,
      guildData = guildData,
      popup = popup,
      \u003C\u0024\u003EIsApply = IsApply,
      \u003C\u0024\u003EguildData = guildData,
      \u003C\u0024\u003Epopup = popup,
      \u003C\u003Ef__this = this
    };
  }

  public void UpdateApply(string guildID)
  {
    this.applyObj.SetActive(this.guild.guild_id == guildID);
  }

  [DebuggerHidden]
  private IEnumerator SetGuildData(GuildDirectory data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02811Scroll.\u003CSetGuildData\u003Ec__Iterator6AD()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  private void SetGuildData(GuildAppearance data, string guild_id)
  {
    if (Object.op_Inequality((Object) this.guildBase, (Object) null))
      Object.Destroy((Object) this.guildBase);
    this.guildBase = this.guildBasePrefab.Clone(((Component) this.guildBasePos).transform).GetComponent<Guild0282GuildBase>();
    ((Collider) ((Component) this.guildBase).GetComponent<BoxCollider>()).enabled = false;
    this.guildBase.SetSprite(data, this.guildImageCache);
    if (data.level / 10 == 0)
    {
      ((Component) this.guildRank1).gameObject.SetActive(false);
      ((Component) this.guildRank10).gameObject.SetActive(true);
      this.guildRank10.SetSprite(string.Format("slc_text_glv_number{0}.png__GUI__guild_common__guild_common_prefab", (object) (data.level % 10)));
    }
    else
    {
      ((Component) this.guildRank10).gameObject.SetActive(true);
      this.guildRank10.SetSprite(string.Format("slc_text_glv_number{0}.png__GUI__guild_common__guild_common_prefab", (object) (data.level / 10)));
      this.guildRank1.SetSprite(string.Format("slc_text_glv_number{0}.png__GUI__guild_common__guild_common_prefab", (object) (data.level % 10)));
    }
    this.nextExp.SetTextLocalize(Consts.Format(Consts.GetInstance().Guild0281MENU_NEXTEXP, (IDictionary) new Hashtable()
    {
      {
        (object) "nextExp",
        (object) data.experience_next
      }
    }));
    if (data.experience_next == 0)
      this.expGauge.setValue(0, 1);
    else
      this.expGauge.setValue(data.experience, data.experience + data.experience_next);
    this.currentMember.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_4_CURRENT_MEMBER, (IDictionary) new Hashtable()
    {
      {
        (object) "currentMember",
        (object) data.membership_num
      }
    }));
    this.maxMember.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_4_MAX_MEMBER, (IDictionary) new Hashtable()
    {
      {
        (object) "maxMember",
        (object) data.membership_capacity
      }
    }));
  }

  public void onButtonGuildInfo() => this.StartCoroutine(this.ShowGuildInfo());

  [DebuggerHidden]
  private IEnumerator ShowGuildInfo()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02811Scroll.\u003CShowGuildInfo\u003Ec__Iterator6AE()
    {
      \u003C\u003Ef__this = this
    };
  }
}
