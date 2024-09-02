// Decompiled with JetBrains decompiler
// Type: AI.Logic.LispAILogic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using GameCore.LispCore;
using GameCore.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

#nullable disable
namespace AI.Logic
{
  public class LispAILogic : AILogicBase
  {
    private AILisp engine;
    private SExpNumber numberDic = new SExpNumber(new Dictionary<Decimal, Decimal?>());
    private bool loadInitialized;
    private bool isTerminate;
    private IELisp.ReturnObject retObj = new IELisp.ReturnObject();

    public void clearCache() => this.engine.clearCache();

    public object readLisp(string script)
    {
      StringBuilder stringBuilder = new StringBuilder();
      string str1 = script;
      char[] chArray = new char[1]{ '\n' };
      foreach (string str2 in str1.Split(chArray))
      {
        string str3 = str2.Trim();
        if (str3.Length != 0 && !str3.StartsWith(";"))
          stringBuilder.AppendLine(str3);
      }
      return new SExpReader(this.numberDic).parse(stringBuilder.ToString(), true);
    }

    public object readLisp(byte[] scriptBytes, byte[] numberBytes)
    {
      if (numberBytes != null)
        this.numberDic = EasySerializer.DeserializeObjectFromMemory(numberBytes) as SExpNumber;
      return EasySerializer.DeserializeObjectFromMemory(scriptBytes);
    }

    public void setReloadFlag() => this.loadInitialized = false;

    [DebuggerHidden]
    public IEnumerator createEngine(object sexp)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new LispAILogic.\u003CcreateEngine\u003Ec__Iterator19()
      {
        sexp = sexp,
        \u003C\u0024\u003Esexp = sexp,
        \u003C\u003Ef__this = this
      };
    }

    private bool initLocal() => this.loadInitialized && this.isInitialized;

    [DebuggerHidden]
    public override IEnumerator doExecute()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new LispAILogic.\u003CdoExecute\u003Ec__Iterator1A()
      {
        \u003C\u003Ef__this = this
      };
    }

    public override bool terminateAI() => this.isTerminate = true;

    [DebuggerHidden]
    private IEnumerator doAI()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new LispAILogic.\u003CdoAI\u003Ec__Iterator1B()
      {
        \u003C\u003Ef__this = this
      };
    }
  }
}
