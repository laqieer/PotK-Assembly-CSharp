// Decompiled with JetBrains decompiler
// Type: CriMana.Detail.RendererResourceFactoryPriorityAttribute
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

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
