// Decompiled with JetBrains decompiler
// Type: Story00191Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  public GameObject IbtnInvite;
  [SerializeField]
  public GameObject IbtnSerialcord;
  [SerializeField]
  public GameObject IbtnSyoutai;
  [SerializeField]
  public GameObject IbtnCopyRight;
  [SerializeField]
  public GameObject IbtnColabo;

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
