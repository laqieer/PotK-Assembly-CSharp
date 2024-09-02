// Decompiled with JetBrains decompiler
// Type: Popup9992Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Popup9992Menu : NGMenuBase
{
  public IEnumerator Init()
  {
    yield break;
  }

  public virtual void IbtnOk()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    Singleton<NGGameDataManager>.GetInstance().refreshHomeHome = true;
    if ((Object) instance != (Object) null)
      StartScript.Restart();
    else
      SceneManager.LoadScene("startup000_6");
  }
}
