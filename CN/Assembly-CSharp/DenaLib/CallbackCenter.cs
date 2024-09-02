// Decompiled with JetBrains decompiler
// Type: DenaLib.CallbackCenter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace DenaLib
{
  public class CallbackCenter
  {
    private List<ObjectCallback> m_CallbackList = new List<ObjectCallback>();

    public void InitCallbackList(int count)
    {
      this.m_CallbackList.Clear();
      for (int index = 0; index < count; ++index)
        this.m_CallbackList.Add((ObjectCallback) null);
    }

    public void SetCallback(int index, ObjectCallback cb)
    {
      if (index < 0 || index >= this.m_CallbackList.Count)
        return;
      this.m_CallbackList[index] = cb;
    }

    public void Call(int index, params object[] param)
    {
      if (index < 0 || index >= this.m_CallbackList.Count || this.m_CallbackList[index] == null)
        return;
      this.m_CallbackList[index](param);
    }
  }
}
