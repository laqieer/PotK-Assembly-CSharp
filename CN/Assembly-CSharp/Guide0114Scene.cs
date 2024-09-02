// Decompiled with JetBrains decompiler
// Type: Guide0114Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guide0114Scene : NGSceneBase
{
  public Guide0114Menu menu;
  public GameObject bottomFromation;
  public GameObject bottomPossesion;
  public GameObject bottomSell;
  public UIPanel scrollPanel;
  public UIWidget scrollBarWidget;
  [SerializeField]
  private UILabel textTitle;

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("guide011_4", stack);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide0114Scene.\u003ConInitSceneAsync\u003Ec__Iterator566()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide0114Scene.\u003ConStartSceneAsync\u003Ec__Iterator567()
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
