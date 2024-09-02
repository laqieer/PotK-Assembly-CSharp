// Decompiled with JetBrains decompiler
// Type: PopupTitleBack
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class PopupTitleBack : BackButtonMonoBehaiviour
{
  private const float csWaitTime = 1f;
  [SerializeField]
  private UIButton ibtnYes;
  [SerializeField]
  private UIButton ibtnNo;
  [SerializeField]
  private UILabel title;
  [SerializeField]
  private UILabel description;
  public static bool BackKeyValid = true;

  public void Init()
  {
    PopupTitleBack.BackKeyValid = false;
    this.StartCoroutine(this.waitTimeValid());
    Consts instance = Consts.GetInstance();
    this.title.SetText(instance.titleback_title);
    this.description.SetText(instance.titleback_text);
  }

  public void IbtnYes()
  {
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    Singleton<NGGameDataManager>.GetInstance().refreshHomeHome = true;
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.RestartGame();
    else
      SceneManager.LoadScene("startup000_6");
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  [DebuggerHidden]
  private IEnumerator waitTimeValid()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    PopupTitleBack.\u003CwaitTimeValid\u003Ec__Iterator915 validCIterator915 = new PopupTitleBack.\u003CwaitTimeValid\u003Ec__Iterator915();
    return (IEnumerator) validCIterator915;
  }

  public override void onBackButton()
  {
    if (!PopupTitleBack.BackKeyValid)
      return;
    this.IbtnNo();
  }
}
