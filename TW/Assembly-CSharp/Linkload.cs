// Decompiled with JetBrains decompiler
// Type: Linkload
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Bode;
using UnityEngine;

#nullable disable
public class Linkload : MonoBehaviour
{
  public void link() => SDK.instance.link(string.Empty);

  public void unlink() => SDK.instance.unlink();

  public void load() => SDK.instance.loadaccount(string.Empty, string.Empty);
}
