// Decompiled with JetBrains decompiler
// Type: SceneButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SceneButton : NGMenuBase
{
  public string scene = string.Empty;

  private void Start()
  {
    UILabel componentInChildren = ((Component) this).GetComponentInChildren<UILabel>();
    if (!Object.op_Inequality((Object) componentInChildren, (Object) null))
      return;
    string text = this.scene.Replace("_", " ");
    if (text.Length > 20)
      componentInChildren.SetText(text.Substring(0, 18) + "..");
    else
      componentInChildren.SetText(text);
  }

  public void onButtonScene()
  {
    if (string.IsNullOrEmpty(this.scene))
      this.backScene();
    else
      this.changeScene(this.scene);
  }
}
