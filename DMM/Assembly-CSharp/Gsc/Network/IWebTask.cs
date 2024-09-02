// Decompiled with JetBrains decompiler
// Type: Gsc.Network.IWebTask
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using Gsc.Tasks;
using System;
using System.Collections;

namespace Gsc.Network
{
  public interface IWebTask : IWebTaskBase, ITask, IEnumerator
  {
    bool handled { get; }

    WebTaskResult Result { get; }

    void Retry();

    bool IsAcceptResult(WebTaskResult result);

    bool HasAttributes(WebTaskAttribute attributes);

    WebInternalTask GetInternalTask();

    Type GetRequestType();
  }
}
