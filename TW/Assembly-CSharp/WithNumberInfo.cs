// Decompiled with JetBrains decompiler
// Type: WithNumberInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;

#nullable disable
public class WithNumberInfo
{
  public WithNumber icon;
  public bool buttonOn;
  private GuideUnitUnit ud;
  private WithNumber.ZUKAN_STATUS st;
  private GearKind gk;
  private CommonElement el;
  private SpriteCash sc;

  public bool IsMaterial
  {
    get => this.ud.IsMaterial;
    set => this.ud.IsMaterial = value;
  }

  public GuideUnitUnit unitData
  {
    get => this.ud;
    set => this.ud = value;
  }

  public WithNumber.ZUKAN_STATUS status
  {
    get => this.st;
    set => this.st = value;
  }

  public GearKind gearKind
  {
    get => this.gk;
    set => this.gk = value;
  }

  public CommonElement element
  {
    get => this.el;
    set => this.el = value;
  }

  public SpriteCash spriteCash
  {
    get => this.sc;
    set => this.sc = value;
  }
}
