// Decompiled with JetBrains decompiler
// Type: RealMachineDebug
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using UniLinq;
using UnityEngine;

#nullable disable
public class RealMachineDebug : MonoBehaviour
{
  private const float wait_loop_seconds = 3f;
  private const int max_send_size = 8388608;
  private const int max_nesting = 5;
  private string api_url = "https://develop-game.punkww.gu3.jp/debug/machine/";
  [SerializeField]
  private RealMachineDebug.RequestParameter request = new RealMachineDebug.RequestParameter();
  [SerializeField]
  private string send_at;
  [SerializeField]
  private string command;
  [SerializeField]
  private bool on;

  private void Awake()
  {
    this.on = false;
    this.request.id = ((Enum) (object) Application.platform).ToString() + ":" + Persist.auth.Data.DeviceID;
    this.StartCoroutine(this.loop());
  }

  [DebuggerHidden]
  private IEnumerator loop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new RealMachineDebug.\u003Cloop\u003Ec__Iterator8A7()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void commandExecute(WWW www)
  {
    if (string.IsNullOrEmpty(www.error))
    {
      this.command = www.text;
      if (this.command == "wait")
      {
        this.request.info = string.Empty;
      }
      else
      {
        try
        {
          this.request.info = this.run(this.command);
        }
        catch (Exception ex)
        {
          this.request.info = ex.Message + "\n\n" + ex.StackTrace;
        }
        if (this.request.info.Length <= 8388608)
          return;
        string str = " (...clamped...)";
        this.request.info = this.request.info.Substring(0, 8388608 - str.Length) + str;
      }
    }
    else
      this.request.info = www.error + "\n" + this.send_at + "\n\n" + this.request.ToString();
  }

  private string run(string command) => new RealMachineDebug.Command(command).result;

  private class Command
  {
    public string result;
    private readonly string text;

    public Command(string text_)
    {
      this.text = text_.Trim();
      if (this.parse("dump_hierarchy", (Func<string, string>) (_ => this.dump_hierarchy())) || this.parse("dump_screenshot", (Func<string, string>) (_ => this.dump_screenshot())) || this.parse("dump_memory", (Func<string, string>) (_ => this.dump_memory())) || this.parse("dump_persist", (Func<string, string>) (_ => this.dump_persist())) || this.parse("dump_component ", (Func<string, string>) (x => this.dump_component(x))) || this.parse("dump_components", (Func<string, string>) (_ => this.dump_components())))
        return;
      this.result = "unknown command " + this.text;
    }

    private bool parse(string prefix, Func<string, string> execute)
    {
      bool flag = this.text.StartsWith(prefix);
      if (flag)
        this.result = execute(this.text.Substring(prefix.Length));
      return flag;
    }

    private string dump_hierarchy()
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (Transform component1 in this.getComponents<Transform>())
      {
        stringBuilder.Append(this.fullname(component1));
        stringBuilder.Append("\n");
        foreach (Component component2 in ((Component) component1).gameObject.GetComponents<Component>())
        {
          if (!(component2 is Transform))
          {
            stringBuilder.Append("  + ");
            try
            {
              stringBuilder.Append(component2.GetType().ToString());
            }
            catch (Exception ex)
            {
              stringBuilder.Append("Exception(");
              stringBuilder.Append(ex.Message);
              stringBuilder.Append(")");
            }
            stringBuilder.Append("\n");
          }
        }
      }
      return stringBuilder.ToString();
    }

    private string dump_components()
    {
      return ((IEnumerable<Assembly>) AppDomain.CurrentDomain.GetAssemblies()).Select<Assembly, System.Type[]>((Func<Assembly, System.Type[]>) (x => x.GetTypes())).SelectMany<System.Type[], System.Type>((Func<System.Type[], IEnumerable<System.Type>>) (x => (IEnumerable<System.Type>) x)).Where<System.Type>((Func<System.Type, bool>) (x => x.IsSubclassOf(typeof (MonoBehaviour)))).Select<System.Type, string>((Func<System.Type, string>) (x => x.FullName)).OrderBy<string, string>((Func<string, string>) (x => x)).Join("\n");
    }

    private string dump_component(string typeName)
    {
      System.Type t = ((IEnumerable<Assembly>) AppDomain.CurrentDomain.GetAssemblies()).Select<Assembly, System.Type>((Func<Assembly, System.Type>) (x => ((IEnumerable<System.Type>) x.GetTypes()).Where<System.Type>((Func<System.Type, bool>) (y => y.Name == typeName)).FirstOrDefault<System.Type>())).Where<System.Type>((Func<System.Type, bool>) (x => (object) x != null)).FirstOrDefault<System.Type>();
      if ((object) t == null)
        return "Not found Type.GetType(" + typeName + ")";
      StringBuilder ls = new StringBuilder();
      IEnumerable<Component> components = this.getComponents(t);
      foreach (Component o in components)
      {
        ls.Append("+ ");
        ls.Append(this.fullname(o.gameObject.transform));
        ls.Append("\n");
        this.walk_value(1, (object) o, ls);
        ls.Append("\n");
      }
      return components.Any<Component>() ? ls.ToString() : "not found components";
    }

    private string dump_screenshot()
    {
      int width = Screen.width;
      int height = Screen.height;
      Texture2D texture2D = new Texture2D(width, height, (TextureFormat) 3, false);
      texture2D.ReadPixels(new Rect(0.0f, 0.0f, (float) width, (float) height), 0, 0);
      texture2D.Apply();
      return Convert.ToBase64String(texture2D.EncodeToJPG(), Base64FormattingOptions.None);
    }

    private string dump_memory()
    {
      int count = 30;
      List<string> self = new List<string>();
      IEnumerable<System.Type> types = ((IEnumerable<Object>) Resources.FindObjectsOfTypeAll(typeof (Object))).Select<Object, System.Type>((Func<Object, System.Type>) (x => x.GetType())).Distinct<System.Type>().OrderByDescending<System.Type, int>((Func<System.Type, int>) (x => ((IEnumerable<Object>) Resources.FindObjectsOfTypeAll(x)).Sum<Object>((Func<Object, int>) (y => Profiler.GetRuntimeMemorySize(y))))).Take<System.Type>(count);
      foreach (System.Type type in types)
      {
        Object[] objectsOfTypeAll = Resources.FindObjectsOfTypeAll(type);
        self.Add(string.Format("{0},{1},{2}", (object) type.Name, (object) objectsOfTypeAll.Length, (object) this.toLabel(((IEnumerable<Object>) objectsOfTypeAll).Sum<Object>((Func<Object, int>) (x => Profiler.GetRuntimeMemorySize(x))))));
      }
      foreach (System.Type type in types)
      {
        Object[] objectsOfTypeAll = Resources.FindObjectsOfTypeAll(type);
        string label1 = this.toLabel(((IEnumerable<Object>) objectsOfTypeAll).Sum<Object>((Func<Object, int>) (x => Profiler.GetRuntimeMemorySize(x))));
        self.Add(string.Empty);
        self.Add(string.Format("Detail {0}({1})---", (object) type.Name, (object) label1));
        foreach (Object @object in ((IEnumerable<Object>) objectsOfTypeAll).OrderByDescending<Object, int>((Func<Object, int>) (x => Profiler.GetRuntimeMemorySize(x))).Take<Object>(count))
        {
          int runtimeMemorySize = Profiler.GetRuntimeMemorySize(@object);
          string label2 = this.toLabel(runtimeMemorySize);
          self.Add(@object.name + "," + label2 + "," + (object) runtimeMemorySize);
        }
        if (((IEnumerable<Object>) objectsOfTypeAll).Count<Object>() > count)
          self.Add("more " + (object) (((IEnumerable<Object>) objectsOfTypeAll).Count<Object>() - count) + " items.");
      }
      return self.Join("\n");
    }

    private string toLabel(int bytes)
    {
      if (bytes < 1024)
        return bytes.ToString();
      if (bytes < 1048576)
        return (bytes / 1024).ToString() + "K";
      return bytes < 1073741824 ? (bytes / 1024 / 1024).ToString() + "M" : (bytes / 1024 / 1024 / 1024).ToString() + "G";
    }

    private void walk_value(int indent, object o, StringBuilder ls)
    {
      List<FieldInfo> list = ((IEnumerable<FieldInfo>) o.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)).ToList<FieldInfo>();
      list.Sort((Comparison<FieldInfo>) ((a, b) => a.Name.CompareTo(b.Name)));
      foreach (FieldInfo fieldInfo in list)
      {
        object o1 = fieldInfo.GetValue(o);
        try
        {
          this.walk_object(indent, o1, fieldInfo.Name, ls);
        }
        catch (Exception ex)
        {
          ls.Append(">>>>>>");
          ls.Append(ex.Message);
          ls.Append(ex.StackTrace);
          ls.Append("<<<<<<");
        }
      }
    }

    private void walk_object(int indent, object o, string name, StringBuilder ls)
    {
      string str = new string(' ', indent * 2);
      if (indent >= 5)
      {
        ls.Append(str);
        ls.Append(name);
        ls.Append(": ");
        try
        {
          ls.Append(o.ToString());
          ls.Append(" (stop. too deep nesting)\n");
        }
        catch (Exception ex)
        {
          ls.Append("EXCEPTION: " + ex.Message);
        }
      }
      else if (o == null)
      {
        ls.Append(str);
        ls.Append(name);
        ls.Append(": (null)\n");
      }
      else
      {
        System.Type type = o.GetType();
        if (o is string || o is float || o is double || o is short || o is int || o is long || o is bool)
        {
          ls.Append(str);
          ls.Append(name);
          ls.Append(": ");
          ls.Append(o.ToString());
          ls.Append("\n");
        }
        else if (o is GameObject)
        {
          GameObject gameObject = o as GameObject;
          ls.Append(str);
          ls.Append(name);
          ls.Append(": GameObject ");
          try
          {
            ls.Append(((Object) gameObject).name);
          }
          catch (Exception ex)
          {
            ls.Append("Exception " + ex.Message);
          }
          ls.Append("\n");
        }
        else if (o is MonoBehaviour)
        {
          MonoBehaviour o1 = o as MonoBehaviour;
          ls.Append(str);
          ls.Append(name);
          ls.Append(": ");
          ls.Append(((Object) ((Component) o1).gameObject).name);
          ls.Append("(");
          ls.Append(type.ToString());
          ls.Append(") -> \n");
          this.walk_value(indent + 1, (object) o1, ls);
        }
        else if (type.IsArray)
        {
          int num = 0;
          Array array = o as Array;
          foreach (object o2 in array)
          {
            this.walk_object(indent + 1, o2, "- " + name + "[" + (object) num + "]", ls);
            ++num;
          }
          if (array.Length != 0)
            return;
          ls.Append(str);
          ls.Append(name);
          ls.Append("[0]\n");
        }
        else
        {
          switch (o)
          {
            case IList _:
              int num1 = 0;
              IList list = o as IList;
              foreach (object o3 in (IEnumerable) list)
              {
                this.walk_object(indent + 1, o3, "- " + name + "[" + (object) num1 + "]", ls);
                ++num1;
              }
              if (list.Count != 0)
                break;
              ls.Append(str);
              ls.Append(name);
              ls.Append("[0]\n");
              break;
            case IDictionary _:
              IDictionary dictionary = o as IDictionary;
              foreach (object key in (IEnumerable) dictionary.Keys)
              {
                object o4 = dictionary[key];
                ls.Append(str);
                ls.Append(name);
                ls.Append("[");
                ls.Append(key.ToString());
                ls.Append("] -> \n");
                this.walk_value(indent + 1, o4, ls);
                ls.Append("\n");
              }
              if (dictionary.Count != 0)
                break;
              ls.Append(str);
              ls.Append(name);
              ls.Append(": (empty)\n");
              break;
            default:
              ls.Append(str);
              ls.Append(name);
              ls.Append(" -> \n");
              this.walk_value(indent + 1, o, ls);
              break;
          }
        }
      }
    }

    private string dump_persist()
    {
      StringBuilder ls = new StringBuilder();
      this.show_persist<Persist.Auth>("auth", ls, Persist.auth);
      this.show_persist<BE>("battleEnvironment", ls, Persist.battleEnvironment);
      this.show_persist<Persist.Notification>("notification", ls, Persist.notification);
      this.show_persist<Persist.SortOrder>("sortOrder", ls, Persist.sortOrder);
      this.show_persist<Persist.Tutorial>("tutorial", ls, Persist.tutorial);
      this.show_persist<Persist.Volume>("volume", ls, Persist.volume);
      return ls.ToString();
    }

    private void show_persist<T>(string label, StringBuilder ls, Persist<T> p) where T : new()
    {
      ls.Append(label);
      ls.Append(" -> \n");
      this.walk_value(1, (object) p.Data, ls);
      if (p.Exists)
      {
        string base64String = Convert.ToBase64String(File.ReadAllBytes(p.FilePath), Base64FormattingOptions.InsertLineBreaks);
        ls.Append("-- binary to base64 path=" + p.FilePath);
        ls.Append("\n");
        ls.Append(base64String);
      }
      else
        ls.Append("-- file not found path=" + p.FilePath);
      ls.Append("\n\n");
    }

    private string fullname(Transform t)
    {
      List<string> self = new List<string>();
      for (Transform parent = t.parent; Object.op_Inequality((Object) parent, (Object) null); parent = parent.parent)
        self.Add(((Object) parent).name);
      self.Reverse();
      return self.Join(".") + "." + ((Object) t).name;
    }

    private IEnumerable<T> getComponents<T>() where T : Component
    {
      return this.getComponents(typeof (T)).Select<Component, T>((Func<Component, T>) (x => x as T));
    }

    private IEnumerable<Component> getComponents(System.Type t)
    {
      return ((IEnumerable<Object>) Resources.FindObjectsOfTypeAll(t)).Select<Object, Component>((Func<Object, Component>) (x => x as Component)).Where<Component>((Func<Component, bool>) (x => Object.op_Inequality((Object) x, (Object) null) && ((Object) x.gameObject).hideFlags != 1));
    }
  }

  [Serializable]
  private class RequestParameter
  {
    public string id = string.Empty;
    public string info = string.Empty;

    public WWWForm Param()
    {
      WWWForm wwwForm = new WWWForm();
      wwwForm.AddField("id", this.id);
      wwwForm.AddField("info", this.info);
      return wwwForm;
    }
  }
}
