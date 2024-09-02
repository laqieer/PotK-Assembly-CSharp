// Decompiled with JetBrains decompiler
// Type: CommonHeader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class CommonHeader : CommonHeaderBase
{
  public CommonHeaderLevel level;
  public UILabel jobText;
  public UILabel moneyText;
  public UILabel playerText;
  public UILabel pointText;
  public UILabel stoneText;

  private void Awake()
  {
    ((Component) ((Component) this).transform.Find("DebugContainer")).gameObject.SetActive(false);
  }

  private void Start() => this.Init();

  protected override void Update()
  {
    if (this.player.Value == null)
      return;
    base.Update();
    if (!this.UpdateApGauge())
      return;
    Player player = this.player.Value;
    this.bp.setValue(player.bp);
    this.level.setLevel(player.level);
    string rolename = player.name.Trim();
    DDebug.Log("SDKroleEvent CommonHeader tempName:" + rolename + "end");
    SDK.instance.SDKroleEvent(rolename, player.level, player.coin);
    this.level.setExperience(player.exp, player.exp_next + player.exp);
    this.setText(this.playerText, player.name);
    this.setText(this.moneyText, player.money.ToString() + string.Empty);
    this.setText(this.pointText, player.medal.ToString() + string.Empty);
    this.setText(this.stoneText, player.coin.ToString() + string.Empty);
  }
}
