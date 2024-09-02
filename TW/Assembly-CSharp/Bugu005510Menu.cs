// Decompiled with JetBrains decompiler
// Type: Bugu005510Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu005510Menu : BackButtonMenuBase
{
  [SerializeField]
  public GameObject SetBuguForm1;
  [SerializeField]
  public GameObject SetBuguForm2;
  [SerializeField]
  public GameObject LinkBugu0101;
  [SerializeField]
  public GameObject LinkBugu0102;
  [SerializeField]
  public GameObject LinkBugu0103;
  [SerializeField]
  public GameObject LinkBugu0104;
  [SerializeField]
  public GameObject LinkBugu0105;
  [SerializeField]
  public GameObject LinkBugu0201;
  [SerializeField]
  public GameObject LinkBugu0202;
  [SerializeField]
  public GameObject LinkBugu0203;
  [SerializeField]
  public GameObject LinkBugu0204;
  [SerializeField]
  private UILabel TxtDescription;
  [SerializeField]
  private UILabel TxtPopuptitle;
  [SerializeField]
  public UIButton yesButton;

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void Show(PlayerItem[] playerItems)
  {
    this.StartCoroutine(this.SetSelectedItemIcons(playerItems));
  }

  private GameObject SelectPosition(int cnt, int num)
  {
    GameObject gameObject = this.LinkBugu0103;
    switch (num)
    {
      case 1:
        if (cnt == 0)
        {
          gameObject = this.LinkBugu0103;
          break;
        }
        break;
      case 2:
        if (cnt == 0)
          gameObject = this.LinkBugu0202;
        if (cnt == 1)
        {
          gameObject = this.LinkBugu0203;
          break;
        }
        break;
      case 3:
        if (cnt == 0)
          gameObject = this.LinkBugu0102;
        if (cnt == 1)
          gameObject = this.LinkBugu0103;
        if (cnt == 2)
        {
          gameObject = this.LinkBugu0104;
          break;
        }
        break;
      case 4:
        if (cnt == 0)
          gameObject = this.LinkBugu0201;
        if (cnt == 1)
          gameObject = this.LinkBugu0202;
        if (cnt == 2)
          gameObject = this.LinkBugu0203;
        if (cnt == 3)
        {
          gameObject = this.LinkBugu0204;
          break;
        }
        break;
      case 5:
        if (cnt == 0)
          gameObject = this.LinkBugu0101;
        if (cnt == 1)
          gameObject = this.LinkBugu0102;
        if (cnt == 2)
          gameObject = this.LinkBugu0103;
        if (cnt == 3)
          gameObject = this.LinkBugu0104;
        if (cnt == 4)
        {
          gameObject = this.LinkBugu0105;
          break;
        }
        break;
    }
    return gameObject;
  }

  [DebuggerHidden]
  private IEnumerator SetSelectedItemIcons(PlayerItem[] playerItems)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005510Menu.\u003CSetSelectedItemIcons\u003Ec__Iterator3DA()
    {
      playerItems = playerItems,
      \u003C\u0024\u003EplayerItems = playerItems,
      \u003C\u003Ef__this = this
    };
  }
}
