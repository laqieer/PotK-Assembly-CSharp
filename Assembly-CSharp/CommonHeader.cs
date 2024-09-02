// Decompiled with JetBrains decompiler
// Type: CommonHeader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System;
using UnityEngine;

public class CommonHeader : CommonHeaderBase
{
  public CommonHeaderLevel level;
  public UILabel jobText;
  public UILabel moneyText;
  public UILabel playerText;
  public UILabel pointText;
  public UILabel stoneText;
  public UILabel _lbl_date;
  public UILabel _lbl_time;
  public UILabel _lbl_wday;
  public UISprite deviceBatteryIcon;
  public UISprite deviceBatteryGauge;
  private DateTime _last_datetime;
  public static string[] _wday_label = new string[7]
  {
    "SUN",
    "MON",
    "TUE",
    "WED",
    "THU",
    "FRI",
    "SAT"
  };
  public CommonHeaderChat headerChat;
  [SerializeField]
  private TweenPosition entryTweenAnime;

  private void Awake() => this.transform.Find("DebugContainer").gameObject.SetActive(false);

  private void Start()
  {
    this.Init();
    if ((UnityEngine.Object) this._lbl_date != (UnityEngine.Object) null)
      this.UpdateDateTime(DateTime.Now);
    this.deviceBatteryIcon.gameObject.SetActive(false);
    this.deviceBatteryGauge.gameObject.SetActive(false);
  }

  protected void UpdateDateTime(DateTime now)
  {
    this.setText(this._lbl_date, string.Format("{0:00}/{1:00}", (object) now.Month, (object) now.Day));
    this.setText(this._lbl_time, string.Format("{0:00}:{1:00}", (object) now.Hour, (object) now.Minute));
    this.setText(this._lbl_wday, CommonHeader._wday_label[(int) now.DayOfWeek]);
    this._last_datetime = now;
    this._last_datetime = this._last_datetime.AddMilliseconds((double) -now.Millisecond);
    this._last_datetime = this._last_datetime.AddSeconds((double) -now.Second);
  }

  private void ShowBatteryInfo()
  {
    this.deviceBatteryIcon.gameObject.SetActive(true);
    this.deviceBatteryGauge.gameObject.SetActive(true);
    this.deviceBatteryGauge.fillAmount = SystemInfo.batteryLevel;
    if ((double) SystemInfo.batteryLevel <= 0.200000002980232)
    {
      this.deviceBatteryIcon.color = Color.yellow;
      this.deviceBatteryGauge.color = Color.yellow;
    }
    else
    {
      this.deviceBatteryIcon.color = Color.gray;
      this.deviceBatteryGauge.color = Color.gray;
    }
  }

  protected override void Update()
  {
    if (this.player.Value == null)
      return;
    base.Update();
    if (this.UpdateApGauge())
    {
      Player player = this.player.Value;
      this.bp.setValue(player.bp);
      this.level.setLevel(player.level);
      this.level.setExperience(player.exp, player.exp_next + player.exp);
      if (Persist.tutorial.Data.IsFinishTutorial())
        this.setText(this.playerText, player.name);
      else
        this.setText(this.playerText, Persist.tutorial.Data.PlayerName);
      this.setText(this.moneyText, string.Concat((object) player.money));
      this.setText(this.pointText, string.Concat((object) player.medal));
      this.setText(this.stoneText, string.Concat((object) player.coin));
    }
    if (!((UnityEngine.Object) this._lbl_date != (UnityEngine.Object) null))
      return;
    DateTime now = DateTime.Now;
    if ((now - this._last_datetime).TotalMinutes < 1.0)
      return;
    this.UpdateDateTime(now);
  }

  public void PlayEntryAnime() => this.entryTweenAnime.PlayForward();

  public void PlayExitAnime() => this.entryTweenAnime.PlayReverse();
}
