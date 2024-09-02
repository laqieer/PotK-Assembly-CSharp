// Decompiled with JetBrains decompiler
// Type: Story00191Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class Story00191Scene : NGSceneBase
{
  [SerializeField]
  public NGxScroll ScrollContainer;
  [SerializeField]
  public Story00191Menu menu;
  public bool flg_init = true;
  [SerializeField]
  public GameObject IbtnSerialcord;
  [SerializeField]
  public GameObject IbtnSyoutai;
  [SerializeField]
  public GameObject IbtnCopyRight;
  [SerializeField]
  public GameObject IbtnColabo;
  [SerializeField]
  private GameObject IbtnMigrate;
  [SerializeField]
  private GameObject LobiButton;
  [SerializeField]
  private GameObject AchievementsButton;

  public override IEnumerator onInitSceneAsync()
  {
    this.IbtnColabo.SetActive(false);
    this.menu.showBtnCredit(false);
    this.ScrollContainer.ResolvePosition();
    return base.onInitSceneAsync();
  }

  public void onStartScene()
  {
    if (this.flg_init)
    {
      this.ScrollContainer.ResolvePosition();
      this.flg_init = false;
    }
    this.menu.Init();
  }
}
