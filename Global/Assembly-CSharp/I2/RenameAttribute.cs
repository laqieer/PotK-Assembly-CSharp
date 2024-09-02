// Decompiled with JetBrains decompiler
// Type: I2.RenameAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace I2
{
  public class RenameAttribute : PropertyAttribute
  {
    public readonly string Name;
    public readonly string Tooltip;
    public readonly int HorizSpace;

    public RenameAttribute(int hspace, string name, string tooltip = null)
    {
      this.Name = name;
      this.Tooltip = tooltip;
      this.HorizSpace = hspace;
    }

    public RenameAttribute(string name, string tooltip = null)
      : this(0, name, tooltip)
    {
    }
  }
}
