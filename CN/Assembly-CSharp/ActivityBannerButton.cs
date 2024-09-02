// Decompiled with JetBrains decompiler
// Type: ActivityBannerButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class ActivityBannerButton : MonoBehaviour
{
  [SerializeField]
  private UILabel label;
  [SerializeField]
  private UIButton button;
  private ActivityMission00418Menu menu;
  private ActivityTotalTable activityTotal;
  private int activityState;

  [DebuggerHidden]
  public IEnumerator Init(
    ActivityMission00418Menu acitivtyMenu,
    ActivityTotalTable table,
    int listState,
    UIScrollView scrollView)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ActivityBannerButton.\u003CInit\u003Ec__Iterator298()
    {
      acitivtyMenu = acitivtyMenu,
      table = table,
      listState = listState,
      scrollView = scrollView,
      \u003C\u0024\u003EacitivtyMenu = acitivtyMenu,
      \u003C\u0024\u003Etable = table,
      \u003C\u0024\u003ElistState = listState,
      \u003C\u0024\u003EscrollView = scrollView,
      \u003C\u003Ef__this = this
    };
  }

  public void changeSprite(string path) => this.button.normalSprite = path;
}
