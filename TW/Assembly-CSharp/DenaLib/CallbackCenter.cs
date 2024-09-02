// Decompiled with JetBrains decompiler
// Type: DenaLib.CallbackCenter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
