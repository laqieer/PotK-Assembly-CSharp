// Decompiled with JetBrains decompiler
// Type: NGScrollPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
