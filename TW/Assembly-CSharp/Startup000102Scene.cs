// Decompiled with JetBrains decompiler
// Type: Startup000102Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Startup000102Scene : MonoBehaviour
{
  [SerializeField]
  private Startup000102Menu menu;

  public void Start() => StartupDownLoad.StartDownload();
}
