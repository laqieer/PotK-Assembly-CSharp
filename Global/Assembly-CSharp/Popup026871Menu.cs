// Decompiled with JetBrains decompiler
// Type: Popup026871Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup026871Menu : BackButtonMonoBehaiviour
{
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtDescription1;
  [SerializeField]
  private UILabel txtDescription2;

  public void Init(int battleCnt)
  {
    this.txtTitle.SetText(Consts.Lookup("VERSUS_0026871POPUP_TITLE"));
    this.txtDescription1.SetText(Consts.Lookup("VERSUS_0026871POPUP_DESCRIPTION1"));
    this.txtDescription2.SetText(Consts.Lookup("VERSUS_0026871POPUP_DESCRIPTION2", (IDictionary) new Hashtable()
    {
      {
        (object) "cnt",
        (object) battleCnt.ToLocalizeNumberText()
      }
    }));
  }

  public void IbtnOK()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    Singleton<NGGameDataManager>.GetInstance().StartCoroutine(this.SceneUpdate());
  }

  [DebuggerHidden]
  private IEnumerator SceneUpdate()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup026871Menu.\u003CSceneUpdate\u003Ec__Iterator7F5 updateCIterator7F5 = new Popup026871Menu.\u003CSceneUpdate\u003Ec__Iterator7F5();
    return (IEnumerator) updateCIterator7F5;
  }

  public void IbtnNo() => this.IbtnOK();

  public override void onBackButton() => this.IbtnNo();
}
