// Decompiled with JetBrains decompiler
// Type: Startup000144Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class Startup000144Menu : NGMenuBase
{
  [SerializeField]
  protected UILabel TxtDescription01;
  [SerializeField]
  protected UILabel TxtDescription02;
  [SerializeField]
  protected UILabel TxtDescription03;
  [SerializeField]
  protected UILabel TxtDescription04;
  [SerializeField]
  protected UILabel TxtPopuptitle;
  [SerializeField]
  protected UILabel TxtREADME;
  public UIButton ibtn_ok;
  [SerializeField]
  private GameObject description03;
  [SerializeField]
  private GameObject description04;

  public void InitScene(PlayerLoginBonus loginBonus)
  {
    this.TxtPopuptitle.SetText(loginBonus.loginbonus.name);
    this.TxtDescription01.SetTextLocalize(loginBonus.rewards[0].client_reward_message);
    ((Component) this.TxtDescription01).gameObject.SetActive(true);
    ((Component) this.TxtDescription02).gameObject.SetActive(false);
    ((Component) this.TxtDescription03).gameObject.SetActive(false);
    ((Component) this.TxtDescription04).gameObject.SetActive(false);
    List<PlayerLoginBonus> list = ((IEnumerable<PlayerLoginBonus>) Singleton<NGGameDataManager>.GetInstance().homeStartUp.player_loginbonuses).ToList<PlayerLoginBonus>();
    list.Remove(loginBonus);
    Singleton<NGGameDataManager>.GetInstance().homeStartUp.player_loginbonuses = list.ToArray();
  }
}
