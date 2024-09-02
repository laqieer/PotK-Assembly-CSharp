// Decompiled with JetBrains decompiler
// Type: Popup9992Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class Popup9992Menu : NGMenuBase
{
  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup9992Menu.\u003CInit\u003Ec__Iterator97F initCIterator97F = new Popup9992Menu.\u003CInit\u003Ec__Iterator97F();
    return (IEnumerator) initCIterator97F;
  }

  public virtual void IbtnOk()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    Singleton<NGGameDataManager>.GetInstance().refreshHomeHome = true;
    if (Object.op_Inequality((Object) instance, (Object) null))
      StartScript.Restart();
    else
      SceneManager.LoadScene("startup000_6");
  }
}
