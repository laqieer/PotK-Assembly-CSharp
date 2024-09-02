// Decompiled with JetBrains decompiler
// Type: Shop00743Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UniLinq;
using UnityEngine;

#nullable disable
public class Shop00743Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtOwnnumber;
  [SerializeField]
  protected UILabel TxtTitle30;
  [SerializeField]
  private UILabel txtLimitMedal;
  public Modified<Shop[]> shopModify;
  public NGxScroll scroll;
  public GameObject detailPopupF;
  private List<Shop0074Scroll> products;
  private List<Shop00743Menu.Medal> medals;
  private int debListCount;
  private GameObject detailPopupM;
  private Modified<PlayerBattleMedal[]> modified;

  public Player _player { get; set; }

  [DebuggerHidden]
  public IEnumerator Init(Player player, bool isUpdate = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00743Menu.\u003CInit\u003Ec__Iterator4EE()
    {
      player = player,
      isUpdate = isUpdate,
      \u003C\u0024\u003Eplayer = player,
      \u003C\u0024\u003EisUpdate = isUpdate,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator updateScroll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00743Menu.\u003CupdateScroll\u003Ec__Iterator4EF()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void SetTextData(string medal) => this.TxtOwnnumber.SetTextLocalize(medal);

  [DebuggerHidden]
  private IEnumerator DetailPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00743Menu.\u003CDetailPopup\u003Ec__Iterator4F0()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void Foreground()
  {
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void VScrollBar()
  {
  }

  private int lastDay(int year, int month)
  {
    return new DateTime(year, month, 1, (Calendar) new JapaneseCalendar()).AddMonths(1).AddDays(-1.0).Day;
  }

  public void onDetailPressed()
  {
    if (Object.op_Equality((Object) this.detailPopupM, (Object) null))
      return;
    this.StartCoroutine(this.openDetail());
  }

  [DebuggerHidden]
  private IEnumerator openDetail()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00743Menu.\u003CopenDetail\u003Ec__Iterator4F1()
    {
      \u003C\u003Ef__this = this
    };
  }

  private new void Update()
  {
    if (this.modified == null || !this.modified.IsChangedOnce())
      return;
    this.UpdateMedal(this.modified.Value);
  }

  private void UpdateMedal(PlayerBattleMedal[] allmedal)
  {
    DateTime ndt = ServerTime.NowAppTime();
    this.medals = new List<Shop00743Menu.Medal>();
    int limitmedal = 0;
    int nolimitmedal = 0;
    ((IEnumerable<PlayerBattleMedal>) allmedal).Where<PlayerBattleMedal>((Func<PlayerBattleMedal, bool>) (m => !m.end_at.HasValue || m.end_at.Value > ndt)).ToList<PlayerBattleMedal>().ForEach((Action<PlayerBattleMedal>) (m =>
    {
      if (m.end_at.HasValue)
      {
        limitmedal += m.count;
        Shop00743Menu.Medal medal = this.medals.Find((Predicate<Shop00743Menu.Medal>) (tm => tm.limit == m.end_at.Value));
        if (medal != null)
          medal.count += m.count;
        else
          this.medals.Add(new Shop00743Menu.Medal(m.end_at.Value, m.count));
      }
      else
        nolimitmedal += m.count;
    }));
    if (this.medals.Count > 1)
      this.medals = this.medals.OrderBy<Shop00743Menu.Medal, long>((Func<Shop00743Menu.Medal, long>) (m => m.limit.Ticks)).ToList<Shop00743Menu.Medal>();
    this.medals.Add(new Shop00743Menu.Medal(new DateTime(0L), nolimitmedal));
    this.TxtOwnnumber.SetTextLocalize(this._player.battle_medal.ToString());
    this.txtLimitMedal.SetTextLocalize(string.Format(Consts.GetInstance().SHOP_00743_MEDAL_LIMIT, (object) limitmedal));
  }

  public class Medal
  {
    public DateTime limit;
    public int count;

    public Medal()
    {
      this.limit = new DateTime(0L);
      this.count = 0;
    }

    public Medal(DateTime l, int c)
    {
      this.limit = l;
      this.count = c;
    }

    public Medal(Shop00743Menu.Medal m)
    {
      this.limit = m.limit;
      this.count = m.count;
    }
  }
}
