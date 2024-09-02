// Decompiled with JetBrains decompiler
// Type: CriMana.Detail.RendererResourceFactoryPriorityAttribute
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

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
