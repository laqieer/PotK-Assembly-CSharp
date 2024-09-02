// Decompiled with JetBrains decompiler
// Type: Startup000102Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Startup000102Scene : MonoBehaviour
{
  [SerializeField]
  private Startup000102Menu menu;

  public void Start() => StartupDownLoad.StartDownload();
}
