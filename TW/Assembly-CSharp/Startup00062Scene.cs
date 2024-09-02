// Decompiled with JetBrains decompiler
// Type: Startup00062Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Startup00062Scene : MonoBehaviour
{
  [SerializeField]
  private UIRoot uiRoot;

  private void Awake() => ModalWindow.setupRootPanel(this.uiRoot);
}
