// Decompiled with JetBrains decompiler
// Type: Gsc.Network.IErrorResponse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using Gsc.DOM;

namespace Gsc.Network
{
  public interface IErrorResponse : IResponse
  {
    IDocument data { get; }

    string ErrorCode { get; }
  }
}
