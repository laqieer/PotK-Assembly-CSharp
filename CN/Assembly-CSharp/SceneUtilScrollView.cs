// Decompiled with JetBrains decompiler
// Type: SceneUtilScrollView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SceneUtilScrollView : MonoBehaviour
{
  public System.Action UpdateCallback;

  private void Update() => this.UpdateCallback();
}
