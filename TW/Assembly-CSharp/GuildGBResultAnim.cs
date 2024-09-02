// Decompiled with JetBrains decompiler
// Type: GuildGBResultAnim
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildGBResultAnim : MonoBehaviour
{
  [SerializeField]
  private float sstaranimduration;
  [SerializeField]
  private float sstaranimendduration;
  [SerializeField]
  private float waitBigStarAnim;
  [SerializeField]
  private float sstarSEFadeTime;
  [SerializeField]
  private float battleResultWait;
  [SerializeField]
  private GuildGBResultAnim.GuildData ownGuild;
  [SerializeField]
  private GuildGBResultAnim.GuildData enemyGuild;
  [SerializeField]
  private Animator dir_center;
  private GameObject resultObj;
  private bool skipFlag;
  public int ownStar;
  public int eneStar;

  public void Next() => this.skipFlag = true;

  public void Start()
  {
    this.ownGuild.Set(this);
    this.enemyGuild.Set(this);
    this.ownGuild.SetUseSStart(this.ownStar);
    this.enemyGuild.SetUseSStart(this.eneStar);
  }

  [DebuggerHidden]
  public IEnumerator InitializeAsync(WebAPI.Response.GvgResult result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildGBResultAnim.\u003CInitializeAsync\u003Ec__Iterator736()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  public void Initialize(WebAPI.Response.GvgResult result, GameObject resultObj)
  {
    this.resultObj = resultObj;
    this.ownGuild.Initialize(this, PlayerAffiliation.Current.guild.guild_name, result.score.total_damage);
    this.enemyGuild.Initialize(this, result.opponent.guild_name, result.score.opponent_total_damage);
    this.ownStar = result.score.total_capture_star;
    this.eneStar = result.score.opponent_total_capture_star;
    this.ownGuild.SetUseSStart(this.ownStar);
    this.enemyGuild.SetUseSStart(this.eneStar);
  }

  public void StartAnimation() => this.StartCoroutine(this.Animation());

  private void OnDisable() => Object.Destroy((Object) this.resultObj);

  [DebuggerHidden]
  private IEnumerator Animation()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildGBResultAnim.\u003CAnimation\u003Ec__Iterator737()
    {
      \u003C\u003Ef__this = this
    };
  }

  [Serializable]
  private class GuildData
  {
    private const string s_star_get = "s_star_get";
    private const string s_star_get_close = "s_star_get_close";
    private const string l_star = "l_star_{0:D2}";
    private const string s_star_set_to_l_star = "s_star_set_to_l_star_{0:D2}";
    private const string l_star_get = "l_star_get";
    [SerializeField]
    private List<SpriteNumberSelectDirect> slc_text_number;
    [SerializeField]
    private SpriteNumberSelectDirect slc_text_number_single_digit;
    [SerializeField]
    private UILabel txt_guild_name;
    [SerializeField]
    private UILabel txt_guild_damage_num;
    [SerializeField]
    private GameObject dyn_GuildBase;
    [SerializeField]
    private UI2DSprite guildTitleImage;
    [SerializeField]
    private List<Transform> dir_l_star;
    [SerializeField]
    private List<Animator> dir_guild_GB_result_l_star_count;
    [SerializeField]
    private Animator dir_star_s_star_position;
    [SerializeField]
    private List<TweenPosition> dir_star_s;
    [SerializeField]
    private List<Animator> dir_s_star;
    [SerializeField]
    private List<Animator> dir_s_star_until_10;
    [SerializeField]
    private Animator dir_guild_GB_result_l_star_count_position;
    public bool animationEnd;
    private GuildGBResultAnim cntrl;

    public void Set(GuildGBResultAnim _cntrl) => this.cntrl = _cntrl;

    [DebuggerHidden]
    public IEnumerator InitializeAsync(Future<GameObject> fgObj, GuildAppearance guildData)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new GuildGBResultAnim.GuildData.\u003CInitializeAsync\u003Ec__Iterator738()
      {
        fgObj = fgObj,
        guildData = guildData,
        \u003C\u0024\u003EfgObj = fgObj,
        \u003C\u0024\u003EguildData = guildData,
        \u003C\u003Ef__this = this
      };
    }

    public void Initialize(GuildGBResultAnim _cntrl, string guildName, int damageVal)
    {
      this.cntrl = _cntrl;
      this.txt_guild_damage_num.SetTextLocalize(damageVal);
      this.txt_guild_name.SetTextLocalize(guildName);
    }

    public void Reset()
    {
      for (int index = 0; index < this.dir_s_star.Count; ++index)
        this.dir_s_star[index].SetTrigger("s_star_get_close");
      for (int index = 0; index < this.dir_s_star_until_10.Count; ++index)
        this.dir_s_star_until_10[index].SetTrigger("s_star_get_close");
    }

    public int Digit(int num) => num == 0 ? 1 : (int) Mathf.Log10((float) num) + 1;

    public void DisbleSlcNumber(int num)
    {
      if (num > 1)
      {
        ((Component) this.slc_text_number_single_digit).gameObject.SetActive(false);
        for (int index = 0; index < this.slc_text_number.Count; ++index)
        {
          this.slc_text_number[index].setNumber(0, Color.white);
          ((Component) this.slc_text_number[index]).gameObject.SetActive(index <= num - 1);
        }
      }
      else
      {
        this.slc_text_number.ForEach((Action<SpriteNumberSelectDirect>) (x => ((Component) x).gameObject.SetActive(false)));
        ((Component) this.slc_text_number_single_digit).gameObject.SetActive(true);
        this.slc_text_number_single_digit.setNumber(0, Color.white);
      }
    }

    public void SetNumber(int num, int max)
    {
      if (max > 1)
      {
        int index = 0;
        do
        {
          int n = num % 10;
          num /= 10;
          this.slc_text_number[index].setNumber(n, Color.white);
          ++index;
        }
        while (max != index);
      }
      else
        this.slc_text_number_single_digit.setNumber(num, Color.white);
    }

    public void SetUseSStart(int starValue)
    {
      if (starValue < 10)
      {
        ((Component) ((Component) this.dir_s_star[0]).transform.parent.parent).gameObject.SetActive(false);
        ((Component) ((Component) this.dir_s_star_until_10[0]).transform.parent.parent).gameObject.SetActive(true);
      }
      else
      {
        ((Component) ((Component) this.dir_s_star[0]).transform.parent.parent).gameObject.SetActive(true);
        ((Component) ((Component) this.dir_s_star_until_10[0]).transform.parent.parent).gameObject.SetActive(false);
      }
      this.Reset();
    }

    [DebuggerHidden]
    public IEnumerator StartAnimation(int starValue)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new GuildGBResultAnim.GuildData.\u003CStartAnimation\u003Ec__Iterator739()
      {
        starValue = starValue,
        \u003C\u0024\u003EstarValue = starValue,
        \u003C\u003Ef__this = this
      };
    }

    public void DamageAnimation()
    {
      ((IEnumerable<UITweener>) ((Component) this.txt_guild_damage_num).GetComponents<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x => ((Behaviour) x).enabled = true));
    }
  }
}
