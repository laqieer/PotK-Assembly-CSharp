// Decompiled with JetBrains decompiler
// Type: Guild0281GuildMapButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using UnityEngine;

#nullable disable
public class Guild0281GuildMapButton : MonoBehaviour
{
  [SerializeField]
  private Guild0281GuildMapButton.GuildMap guildMap;
  [SerializeField]
  private Guild0281GuildMapButton.GuildMapMatching guildMapMatching;
  [SerializeField]
  private Guild0281GuildMapButton.GuildMapInBattle guildMapInBattle;
  [SerializeField]
  private Guild0281GuildMapButton.GuildMapInAggregate guildMapInAggregate;

  public void Initialize()
  {
    switch (PlayerAffiliation.Current.guild.gvg_status)
    {
      case GvgStatus.not_enough_member:
      case GvgStatus.lock_entry:
      case GvgStatus.can_entry:
      case GvgStatus.matching:
      case GvgStatus.finished:
      case GvgStatus.out_of_term:
        this.guildMap.SetActive(true);
        this.guildMapMatching.SetActive(false);
        this.guildMapInBattle.SetActive(false);
        this.guildMapInAggregate.SetActive(false);
        break;
      case GvgStatus.preparing:
        this.guildMap.SetActive(false);
        this.guildMapMatching.SetActive(true);
        this.guildMapInBattle.SetActive(false);
        this.guildMapInAggregate.SetActive(false);
        this.SetGVGStartHour();
        break;
      case GvgStatus.fighting:
        this.guildMap.SetActive(false);
        this.guildMapMatching.SetActive(false);
        this.guildMapInBattle.SetActive(true);
        this.guildMapInAggregate.SetActive(false);
        this.SetGVGEndHour();
        break;
      case GvgStatus.aggregating:
        this.guildMap.SetActive(false);
        this.guildMapMatching.SetActive(false);
        this.guildMapInBattle.SetActive(false);
        this.guildMapInAggregate.SetActive(true);
        break;
      default:
        this.guildMap.DirGuildMap.SetActive(true);
        this.guildMapMatching.SetActive(false);
        this.guildMapInBattle.SetActive(false);
        this.guildMapInAggregate.SetActive(false);
        break;
    }
  }

  private void SetGVGStartHour()
  {
    this.StopCoroutineTimeCounter();
    this.StartCoroutine(GuildUtil.TimeCountText(this.guildMapMatching.TxtRemainTime, Consts.GetInstance().GUILD_TOP_REMAIN_TIME, (double) GuildUtil.GVGStartHour(), (System.Action) (() => this.Initialize()), (MonoBehaviour) this));
  }

  private void SetGVGEndHour()
  {
    this.StopCoroutineTimeCounter();
    this.StartCoroutine(GuildUtil.TimeCountText(this.guildMapInBattle.TxtRemainTime, Consts.GetInstance().GUILD_TOP_REMAIN_TIME, (double) GuildUtil.GVGEndHour(), (System.Action) (() => this.Initialize()), (MonoBehaviour) this));
  }

  private void StopCoroutineTimeCounter() => this.StopCoroutine("TimeCountText");

  [Serializable]
  private class GuildMap
  {
    [SerializeField]
    private GameObject dir_guild_map;
    [SerializeField]
    private GameObject slc_background;

    public GameObject DirGuildMap
    {
      get => this.dir_guild_map;
      set => this.dir_guild_map = value;
    }

    public GameObject SlcBackGround
    {
      get => this.slc_background;
      set => this.slc_background = value;
    }

    public void SetActive(bool flag)
    {
      this.DirGuildMap.SetActive(flag);
      this.SlcBackGround.SetActive(flag);
    }
  }

  [Serializable]
  private class GuildMapMatching
  {
    [SerializeField]
    private GameObject dir_guild_map_matching;
    [SerializeField]
    private UILabel txt_remain_time;
    [SerializeField]
    private GameObject slc_background;

    public GameObject DirGuildMapMatching
    {
      get => this.dir_guild_map_matching;
      set => this.dir_guild_map_matching = value;
    }

    public UILabel TxtRemainTime
    {
      get => this.txt_remain_time;
      set => this.txt_remain_time = value;
    }

    public GameObject SlcBackGround
    {
      get => this.slc_background;
      set => this.slc_background = value;
    }

    public void SetActive(bool flag)
    {
      this.DirGuildMapMatching.SetActive(flag);
      this.SlcBackGround.SetActive(flag);
    }
  }

  [Serializable]
  private class GuildMapInBattle
  {
    [SerializeField]
    private GameObject dir_guild_map_in_battle;
    [SerializeField]
    private UILabel txt_remain_time;
    [SerializeField]
    private GameObject slc_background;

    public GameObject DirGuildMapInBattle
    {
      get => this.dir_guild_map_in_battle;
      set => this.dir_guild_map_in_battle = value;
    }

    public UILabel TxtRemainTime
    {
      get => this.txt_remain_time;
      set => this.txt_remain_time = value;
    }

    public GameObject SlcBackGround
    {
      get => this.slc_background;
      set => this.slc_background = value;
    }

    public void SetActive(bool flag)
    {
      this.DirGuildMapInBattle.SetActive(flag);
      this.SlcBackGround.SetActive(flag);
    }
  }

  [Serializable]
  private class GuildMapInAggregate
  {
    [SerializeField]
    private GameObject dir_guild_map_in_aggregate;
    [SerializeField]
    private UILabel txt_remain_time;
    [SerializeField]
    private GameObject slc_background;

    public GameObject DirGuildMapInAggregate
    {
      get => this.dir_guild_map_in_aggregate;
      set => this.dir_guild_map_in_aggregate = value;
    }

    public UILabel TxtRemainTime
    {
      get => this.txt_remain_time;
      set => this.txt_remain_time = value;
    }

    public GameObject SlcBackGround
    {
      get => this.slc_background;
      set => this.slc_background = value;
    }

    public void SetActive(bool flag)
    {
      this.DirGuildMapInAggregate.SetActive(flag);
      this.SlcBackGround.SetActive(flag);
    }
  }
}
