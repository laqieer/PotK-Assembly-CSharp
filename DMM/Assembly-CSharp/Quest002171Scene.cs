// Decompiled with JetBrains decompiler
// Type: Quest002171Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System.Collections;
using UnityEngine;

[AddComponentMenu("Scenes/QuestExtra/LocksScene")]
public class Quest002171Scene : NGSceneBase
{
  public Quest002171Menu menu;

  public static void ChangeScene(bool stack) => Singleton<NGSceneManager>.GetInstance().changeScene("quest002_17_1", stack);

  public IEnumerator onStartSceneAsync()
  {
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    IEnumerator e = WebAPI.QuestkeyIndex((System.Action<WebAPI.Response.UserError>) (error => WebAPI.DefaultUserErrorCallback(error))).Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = this.menu.Init(SMManager.Get<PlayerQuestGate[]>());
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    Singleton<CommonRoot>.GetInstance().isLoading = false;
  }
}
