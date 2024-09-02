// Decompiled with JetBrains decompiler
// Type: NGScrollPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Reflection;
using UnityEngine;

#nullable disable
public class NGScrollPanel : MonoBehaviour
{
  public UIPanel panel;
  private int count;

  private void Update()
  {
    if (++this.count % 3 == 0)
      return;
    ((object) this.panel).GetType().GetField("mUpdateFrame", BindingFlags.Static | BindingFlags.NonPublic).SetValue((object) this.panel, (object) Time.frameCount);
  }
}
