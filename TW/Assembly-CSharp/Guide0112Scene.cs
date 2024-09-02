// Decompiled with JetBrains decompiler
// Type: Guide0112Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guide0112Scene : NGSceneBase
{
  public Guide0112Menu menu;
  public GameObject bottomFromation;
  public GameObject bottomPossesion;
  public GameObject bottomSell;
  public UIPanel scrollPanel;
  public UIWidget scrollBarWidget;
  [SerializeField]
  private UILabel textTitle;

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("guide011_2", stack);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide0112Scene.\u003ConInitSceneAsync\u003Ec__Iterator5A0()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide0112Scene.\u003ConStartSceneAsync\u003Ec__Iterator5A1()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene()
  {
    this.menu.StopCreateUnitIconImage();
    Singleton<PopupManager>.GetInstance().closeAll();
  }

  private void changeMenu()
  {
    this.scrollPanel.bottomAnchor.absolute = 40;
    this.scrollBarWidget.bottomAnchor.absolute = 60;
  }
}
