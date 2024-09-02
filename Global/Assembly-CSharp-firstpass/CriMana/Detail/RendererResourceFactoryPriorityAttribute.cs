// Decompiled with JetBrains decompiler
// Type: CriMana.Detail.RendererResourceFactoryPriorityAttribute
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;

#nullable disable
namespace CriMana.Detail
{
  [AttributeUsage(AttributeTargets.Class)]
  public class RendererResourceFactoryPriorityAttribute : Attribute
  {
    public readonly int priority;

    public RendererResourceFactoryPriorityAttribute(int priority) => this.priority = priority;
  }
}
