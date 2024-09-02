// Decompiled with JetBrains decompiler
// Type: Guide0113Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guide0113Scene : NGSceneBase
{
  public Guide0113Menu menu;
  public GameObject bottomFromation;
  public GameObject bottomPossesion;
  public GameObject bottomSell;
  public UIPanel scrollPanel;
  public UIWidget scrollBarWidget;
  [SerializeField]
  private UILabel textTitle;

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("guide011_3", stack);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide0113Scene.\u003ConInitSceneAsync\u003Ec__Iterator4BA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide0113Scene.\u003ConStartSceneAsync\u003Ec__Iterator4BB()
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
