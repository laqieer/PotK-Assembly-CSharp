﻿// Decompiled with JetBrains decompiler
// Type: UniWebViewEdgeInsets
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
[Serializable]
public class UniWebViewEdgeInsets
{
  public int top;
  public int left;
  public int bottom;
  public int right;

  public UniWebViewEdgeInsets(int aTop, int aLeft, int aBottom, int aRight)
  {
    this.top = aTop;
    this.left = aLeft;
    this.bottom = aBottom;
    this.right = aRight;
  }

  public override int GetHashCode()
  {
    return (this.top + this.left + this.bottom + this.right).GetHashCode();
  }

  public override bool Equals(object obj)
  {
    if (obj == null || (object) this.GetType() != (object) obj.GetType())
      return false;
    UniWebViewEdgeInsets webViewEdgeInsets = (UniWebViewEdgeInsets) obj;
    return this.top == webViewEdgeInsets.top && this.left == webViewEdgeInsets.left && this.bottom == webViewEdgeInsets.bottom && this.right == webViewEdgeInsets.right;
  }

  public static bool operator ==(UniWebViewEdgeInsets inset1, UniWebViewEdgeInsets inset2)
  {
    return inset1.Equals((object) inset2);
  }

  public static bool operator !=(UniWebViewEdgeInsets inset1, UniWebViewEdgeInsets inset2)
  {
    return !inset1.Equals((object) inset2);
  }
}
