// Decompiled with JetBrains decompiler
// Type: CommonHeaderBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class CommonHeaderBase : NGMenuBase
{
  [SerializeField]
  protected CommonHeaderAP ap;
  [SerializeField]
  protected CommonHeaderBP bp;
  protected Modified<Player> player;
  protected Modified<PlayerItem[]> items;
  protected Modified<PlayerUnit[]> units;
  protected Modified<NGGameDataManager.TimeCounter> timeCounter;
  private bool isChangedOncePlayer;
  private bool isChangedOncePlayerUnits;
  private bool isChangedOncePlayerItems;
  private bool isChangedOnceTimeCounter;

  public CommonHeaderAP Ap => this.ap;

  public CommonHeaderBP Bp => this.bp;

  private void Awake()
  {
  }

  protected void Init()
  {
    this.player = SMManager.Observe<Player>();
    this.player.NotifyChanged();
    this.items = SMManager.Observe<PlayerItem[]>();
    this.items.NotifyChanged();
    this.units = SMManager.Observe<PlayerUnit[]>();
    this.units.NotifyChanged();
    this.timeCounter = SMManager.Observe<NGGameDataManager.TimeCounter>();
    this.timeCounter.NotifyChanged();
  }

  protected virtual void Update()
  {
    if (this.player == null)
      this.Init();
    this.isChangedOncePlayer = this.player.IsChangedOnce();
    this.isChangedOncePlayerUnits = this.units.IsChangedOnce();
    this.isChangedOncePlayerItems = this.items.IsChangedOnce();
    this.isChangedOnceTimeCounter = this.timeCounter.IsChangedOnce();
  }

  protected void setText(UILabel label, string text) => label.SetTextLocalize(text);

  protected bool UpdateApRecoveryTime()
  {
    if (this.isChangedOnceTimeCounter)
      this.ap.setTime(this.timeCounter.Value.ApRecoverySecondsPerPoint);
    return this.isChangedOnceTimeCounter;
  }

  protected bool UpdateApGauge()
  {
    if (this.isChangedOncePlayer)
    {
      Player player = this.player.Value;
      this.ap.setGauge(player.ap, player.ap_overflow, player.ap_max);
    }
    return this.isChangedOncePlayer;
  }

  protected bool UpdateBpReocveryTime()
  {
    if (this.isChangedOnceTimeCounter)
      this.bp.setTime(this.timeCounter.Value.BpRecoverySecondsPerPoint);
    return this.isChangedOnceTimeCounter;
  }

  protected bool UpdateBpPoint()
  {
    if (this.isChangedOncePlayer)
      this.bp.setValue(this.player.Value.bp);
    return this.isChangedOncePlayer;
  }

  protected bool UpdateUnits() => this.isChangedOncePlayerUnits;

  protected bool UpdateItems() => this.isChangedOncePlayerItems;
}
