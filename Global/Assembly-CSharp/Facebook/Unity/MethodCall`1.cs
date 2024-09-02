// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.MethodCall`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace Facebook.Unity
{
  internal abstract class MethodCall<T> where T : IResult
  {
    public MethodCall(FacebookBase facebookImpl, string methodName)
    {
      this.Parameters = new MethodArguments();
      this.FacebookImpl = facebookImpl;
      this.MethodName = methodName;
    }

    public string MethodName { get; private set; }

    public FacebookDelegate<T> Callback { protected get; set; }

    protected FacebookBase FacebookImpl { get; set; }

    protected MethodArguments Parameters { get; set; }

    public abstract void Call(MethodArguments args = null);
  }
}
