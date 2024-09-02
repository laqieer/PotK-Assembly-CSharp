// Decompiled with JetBrains decompiler
// Type: TransformExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public static class TransformExtension
{
  [DebuggerHidden]
  public static IEnumerable<Transform> GetChildren(this Transform self)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    TransformExtension.\u003CGetChildren\u003Ec__Iterator8C7 children = new TransformExtension.\u003CGetChildren\u003Ec__Iterator8C7()
    {
      self = self,
      \u003C\u0024\u003Eself = self
    };
    // ISSUE: reference to a compiler-generated field
    children.\u0024PC = -2;
    return (IEnumerable<Transform>) children;
  }

  public static void Clear(this Transform self)
  {
    foreach (Component child in self.GetChildren())
      Object.DestroyObject((Object) child.gameObject);
    self.DetachChildren();
  }

  public static string GetFullPath(this Transform self)
  {
    return Object.op_Equality((Object) self.parent, (Object) null) ? ((Object) self).name : self.parent.GetFullPath() + "/" + ((Object) self).name;
  }

  public static Transform FindByFullPath(this Transform self, string name)
  {
    string[] strArray = name.Split('/');
    if (strArray.Length == 0)
      return (Transform) null;
    if (strArray[0] != ((Object) self).name)
      return (Transform) null;
    int index = 1;
    while (index < strArray.Length)
    {
      bool flag = false;
      foreach (Transform child in self.GetChildren())
      {
        if (((Object) child).name == strArray[index])
        {
          self = child;
          ++index;
          flag = true;
          break;
        }
      }
      if (!flag)
        return (Transform) null;
    }
    return self;
  }

  public static Transform GetChildInFind(this Transform self, string name)
  {
    if (((Object) ((Component) self).gameObject).name == name)
      return self;
    foreach (Transform self1 in self)
    {
      Transform childInFind = self1.GetChildInFind(name);
      if (Object.op_Inequality((Object) childInFind, (Object) null))
        return childInFind;
    }
    return (Transform) null;
  }

  public static Transform GetParentInFind(this Transform self, string name)
  {
    if (((Object) ((Component) self).gameObject).name == name)
      return self;
    if (Object.op_Equality((Object) self.parent, (Object) null))
      return (Transform) null;
    Transform parentInFind = self.parent.GetParentInFind(name);
    return Object.op_Inequality((Object) parentInFind, (Object) null) ? parentInFind : (Transform) null;
  }
}
