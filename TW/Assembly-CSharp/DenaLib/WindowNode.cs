// Decompiled with JetBrains decompiler
// Type: DenaLib.WindowNode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace DenaLib
{
  public class WindowNode
  {
    public string name;
    public int id;
    public int type;
    public WindowNode parent;
    public WindowNode child;
    public IWindow windowProxy;
    public GameObject pageGameObject;
  }
}
