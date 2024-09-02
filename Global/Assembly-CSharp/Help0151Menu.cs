// Decompiled with JetBrains decompiler
// Type: Help0151Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Help0151Menu : BackButtonMenuBase
{
  [SerializeField]
  protected GameObject ScrollGrid;
  public NGxScroll scroll;
  public UIScrollView scrollview;
  private GameObject barPrefab;

  public virtual void Foreground()
  {
  }

  public virtual void IbtnHelp()
  {
  }

  public virtual void IbtnHelp2()
  {
  }

  public virtual void IbtnHelp3()
  {
  }

  public virtual void IbtnHelp4()
  {
  }

  public virtual void IbtnHelp5()
  {
  }

  public virtual void IbtnHelp6()
  {
  }

  public virtual void VScrollBar()
  {
  }

  [DebuggerHidden]
  public IEnumerator InitHelp()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Help0151Menu.\u003CInitHelp\u003Ec__Iterator4D2()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void CreateContactBar()
  {
    GameObject gameObject = this.barPrefab.Clone();
    this.scroll.Add(gameObject);
    Help0151Button component = gameObject.GetComponent<Help0151Button>();
    component.setTextHelp01(Consts.Lookup("HELP_CONTACT"), true);
    EventDelegate.Set(component.button.onClick, new EventDelegate.Callback(this.ChangeContactScene));
  }

  private void ChangeContactScene() => Help0154Scene.ChangeScene(true);

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
