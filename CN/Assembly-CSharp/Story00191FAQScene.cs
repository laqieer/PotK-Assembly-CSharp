// Decompiled with JetBrains decompiler
// Type: Story00191FAQScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class Story00191FAQScene : NGSceneBase
{
  [SerializeField]
  private NGxScroll ScrollContainer;
  [SerializeField]
  private Story00191FAQMenu menu;
  private bool flg_init = true;
  [SerializeField]
  private GameObject IbtnInvite;
  [SerializeField]
  private GameObject IbtnSerialcord;
  [SerializeField]
  private GameObject IbtnSyoutai;
  [SerializeField]
  private GameObject IbtnCopyRight;
  [SerializeField]
  private GameObject IbtnColabo;

  public override IEnumerator onInitSceneAsync()
  {
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
