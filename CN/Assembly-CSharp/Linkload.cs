// Decompiled with JetBrains decompiler
// Type: Linkload
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Linkload : MonoBehaviour
{
  public void link() => SDK.instance.link(string.Empty);

  public void unlink() => SDK.instance.unlink();

  public void load() => SDK.instance.loadaccount(string.Empty, string.Empty);
}
