// Decompiled with JetBrains decompiler
// Type: Startup000102Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Startup000102Scene : MonoBehaviour
{
  [SerializeField]
  private Startup000102Menu menu;

  public void Start() => StartupDownLoad.StartDownload(false);
}
