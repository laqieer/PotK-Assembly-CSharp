﻿// Decompiled with JetBrains decompiler
// Type: GameCore.Calculator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace GameCore
{
  public class Calculator
  {
    private readonly Parser parser;
    private readonly INode root;
    private Dictionary<string, float> vars;

    public Calculator(string expression)
    {
      this.parser = new Parser(expression);
      this.root = this.parser.Root;
    }

    public string Show() => this.parser.Show();

    public float Eval() => this.root.Eval(new Func<string, float>(float.Parse));

    public float Eval(Func<string, float> convert) => this.root.Eval(convert);

    public float Eval(Dictionary<string, float> vars_)
    {
      this.vars = vars_ ?? new Dictionary<string, float>();
      return this.root.Eval(new Func<string, float>(this.dictConvert));
    }

    private float dictConvert(string name)
    {
      float num;
      if (this.vars.TryGetValue(name, out num))
        return num;
      if (name.Contains("."))
        return !this.vars.ContainsKey(name) ? 0.0f : 1f;
      throw new KeyNotFoundException("Not in scope '" + name + "' : " + this.parser.Show());
    }

    private INode getEdgeNode(Dictionary<string, float> vars_)
    {
      INode root;
      for (root = this.root; root is If; root = (root as IParam<INode>).getParam(new Func<string, float>(this.dictConvert)))
        this.vars = vars_ ?? new Dictionary<string, float>();
      return root;
    }

    public bool isType<T>(Dictionary<string, float> vars_) => this.getEdgeNode(vars_) is T;

    public T getParam<T>(Dictionary<string, float> vars_)
    {
      return this.getEdgeNode(vars_) is IParam<T> edgeNode ? edgeNode.getParam(new Func<string, float>(this.dictConvert)) : default (T);
    }
  }
}
