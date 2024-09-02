// Decompiled with JetBrains decompiler
// Type: Startup00012ButtonManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using gu3.Device;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;
using UnityEngine;

#nullable disable
public class Startup00012ButtonManager : MonoBehaviour
{
  public string scene;
  public string param;

  public void onChangeScene()
  {
    if (this.scene == string.Empty)
      return;
    Singleton<NGSoundManager>.GetInstance().playSE("SE_1002");
    if (Regex.IsMatch(this.scene, "https?://[-_.!~*'()a-zA-Z0-9;/?:@&=+$,%#]+"))
      DeviceManager.OpenUrl(this.scene);
    else if (this.scene == "quest002_4")
      this.changeScene();
    else if (this.scene == "quest002_19" || this.scene == "quest002_20")
      this.StartCoroutine(this.QuestExtraCheck(int.Parse(this.param), this.scene));
    else
      Singleton<NGSceneManager>.GetInstance().changeScene(this.scene);
  }

  public void changeScene() => Quest00240723Scene.ChangeScene0024(true, 1);

  [DebuggerHidden]
  private IEnumerator QuestExtraCheck(int param, string scene)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00012ButtonManager.\u003CQuestExtraCheck\u003Ec__Iterator16D()
    {
      param = param,
      scene = scene,
      \u003C\u0024\u003Eparam = param,
      \u003C\u0024\u003Escene = scene,
      \u003C\u003Ef__this = this
    };
  }
}
