// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.MethodCall`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
