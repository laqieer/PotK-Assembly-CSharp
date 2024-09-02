// Decompiled with JetBrains decompiler
// Type: ResourceInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using UniLinq;
using UnityEngine;

#nullable disable
public class ResourceInfo : IEnumerable, IEnumerable<ResourceInfo.Resource>
{
  private ResourceInfo.Resource[] resourceInfo;
  private Dictionary<Tuple<int, int>, ResourceInfo.Resource> resourceDict;
  public static string[] INFO_PATH_TYPE_STR = new string[4]
  {
    string.Empty,
    "AssetBundle",
    "StreamingAssets",
    "Resource"
  };
  public static string[] INFO_TYPE_STR = new string[12]
  {
    string.Empty,
    "GameObject",
    "Object",
    "Texture2D",
    "AnimatorController",
    "TextAsset",
    "Material",
    "AnimationClip",
    "MovieTexture",
    "Shader",
    "Font",
    "PhysicMaterial"
  };
  public static string[] INFO_STEPS_TYPE_STR = new string[5]
  {
    string.Empty,
    "Renderer",
    "UIAtlas",
    "UILabel",
    "UISprite"
  };

  IEnumerator IEnumerable.GetEnumerator() => this.resourceInfo.GetEnumerator();

  public ResourceInfo.Resource this[int n] => this.resourceInfo[n];

  [DebuggerHidden]
  public IEnumerator<ResourceInfo.Resource> GetEnumerator()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator<ResourceInfo.Resource>) new ResourceInfo.\u003CGetEnumerator\u003Ec__IteratorBCD()
    {
      \u003C\u003Ef__this = this
    };
  }

  public static ResourceInfo.Resource SearchResourceInfo(string path, ResourceInfo resourceInfo)
  {
    ResourceInfo.Resource resource = new ResourceInfo.Resource();
    if (resourceInfo == null)
      return resource;
    resourceInfo.resourceDict.TryGetValue(new Tuple<int, int>(path.GetHashCode(), path.Length), out resource);
    return resource;
  }

  public static ResourceInfo Deserialize(Stream stream)
  {
    GC.Collect();
    GC.WaitForPendingFinalizers();
    List<ResourceInfo.Resource> resourceList = new List<ResourceInfo.Resource>();
    using (ResourceInfo.Parser parser = new ResourceInfo.Parser(stream))
    {
      foreach (KeyValuePair<string, object> info in parser.ParseObjectEnum())
      {
        ResourceInfo.Resource resource = new ResourceInfo.Resource();
        resource.Set(info);
        resourceList.Add(resource);
      }
    }
    ResourceInfo resourceInfo = new ResourceInfo();
    resourceInfo.resourceInfo = resourceList.ToArray();
    Array.Sort<ResourceInfo.Resource>(resourceInfo.resourceInfo, (IComparer<ResourceInfo.Resource>) ResourceInfo.PathComparer.Default);
    resourceInfo.resourceDict = ((IEnumerable<ResourceInfo.Resource>) resourceInfo.resourceInfo).ToDictionary<ResourceInfo.Resource, Tuple<int, int>>((Func<ResourceInfo.Resource, Tuple<int, int>>) (x => new Tuple<int, int>(x._key.GetHashCode(), x._key.Length)));
    return resourceInfo;
  }

  public ResourceInfo.Resource SearchResourceInfo(string path)
  {
    return ResourceInfo.SearchResourceInfo(path, this);
  }

  public enum INFO_PATH_TYPE
  {
    NONE,
    ASSET_BUNDLE,
    STREAMING,
    RESOURCE,
    MAX,
  }

  public enum INFO_TYPE
  {
    NONE,
    GAME_OBJECT,
    OBJECT,
    TEXTURE2D,
    ANIM_CONTROLLER,
    TEXT_ASSET,
    MATERIAL,
    ANIM_CLIP,
    MOVIE_TEXTURE,
    SHADER,
    FONT,
    PHYSIC_MATERIAL,
    MAX,
  }

  public enum INFO_STEPS_TYPE
  {
    NONE,
    RENDERER,
    UI_ATLAS,
    UI_LABEL,
    UI_SPRITE,
    MAX,
  }

  public struct Value
  {
    public uint _store_size;
    public string _asset_bundle;
    public byte _path_type;
    public byte _type;
    public ushort _id;
    public string _ext;
    public uint _download_size;
    public ResourceInfo.Step[] _steps;
    public string _file_name;
    public bool _compressed;
    public bool _mask;
    public uint _file_size;
    public ushort _width;
    public ushort _height;

    public string GetPathTypeName() => ResourceInfo.INFO_PATH_TYPE_STR[(int) this._path_type];

    public string GetTypeName() => ResourceInfo.INFO_TYPE_STR[(int) this._type];

    public ResourceInfo.INFO_PATH_TYPE path_type => (ResourceInfo.INFO_PATH_TYPE) this._path_type;

    public bool Exists
    {
      get
      {
        if (this.path_type == ResourceInfo.INFO_PATH_TYPE.ASSET_BUNDLE)
          return CachedFile.Exists(DLC.ResourceDirectory("ab"));
        return this.path_type != ResourceInfo.INFO_PATH_TYPE.STREAMING || CachedFile.Exists(DLC.ResourceDirectory("sa"));
      }
    }
  }

  public struct Step
  {
    public byte _type;
    public bool _has_mask;
    public string _path1;
    public string _path2;
    public string _transform;
    public string _shader;
    public Dictionary<string, ResourceInfo.Step._InternalTextureData>[] _sharedMaterials;

    public string _path => this._path2 == null ? this._path1 : this._path1 + this._path2;

    public string GetSharedMaterials(int num, string key)
    {
      return this._sharedMaterials[num][key].name[1] == null ? this._sharedMaterials[num][key].name[0] : this._sharedMaterials[num][key].name[0] + this._sharedMaterials[num][key].name[1];
    }

    public FilterMode GetSharedMaterialFilterMode(int num, string key)
    {
      return this._sharedMaterials[num][key].filterMode;
    }

    public TextureWrapMode GetSharedMaterialTextureWrapMode(int num, string key)
    {
      return this._sharedMaterials[num][key].wrapMode;
    }

    public string GetTypeName() => ResourceInfo.INFO_STEPS_TYPE_STR[(int) this._type];

    public struct _InternalTextureData
    {
      public string[] name;
      public FilterMode filterMode;
      public TextureWrapMode wrapMode;
    }
  }

  public struct Resource
  {
    public string _key;
    public ResourceInfo.Value _value;

    public void Set(KeyValuePair<string, object> info)
    {
      this._key = string.Intern(info.Key);
      foreach (KeyValuePair<string, object> keyValuePair1 in (Dictionary<string, object>) info.Value)
      {
        string key1 = keyValuePair1.Key;
        if (key1 != null)
        {
          // ISSUE: reference to a compiler-generated field
          if (ResourceInfo.Resource.\u003C\u003Ef__switch\u0024map27 == null)
          {
            // ISSUE: reference to a compiler-generated field
            ResourceInfo.Resource.\u003C\u003Ef__switch\u0024map27 = new Dictionary<string, int>(17)
            {
              {
                "store_size",
                0
              },
              {
                "asset_bundle",
                1
              },
              {
                "file_name",
                2
              },
              {
                "path_type",
                3
              },
              {
                "ext",
                4
              },
              {
                "id",
                5
              },
              {
                "type",
                6
              },
              {
                "steps",
                7
              },
              {
                "download_size",
                8
              },
              {
                "compressed",
                9
              },
              {
                "file_size",
                10
              },
              {
                "width",
                11
              },
              {
                "height",
                12
              },
              {
                "mask",
                13
              },
              {
                "full_path",
                14
              },
              {
                "short_path",
                15
              },
              {
                "crc",
                16
              }
            };
          }
          int num1;
          // ISSUE: reference to a compiler-generated field
          if (ResourceInfo.Resource.\u003C\u003Ef__switch\u0024map27.TryGetValue(key1, out num1))
          {
            switch (num1)
            {
              case 0:
                this._value._store_size = (uint) (long) keyValuePair1.Value;
                continue;
              case 1:
                this._value._asset_bundle = string.Copy(keyValuePair1.Value.ToString());
                continue;
              case 2:
                this._value._file_name = string.Copy(keyValuePair1.Value.ToString());
                continue;
              case 3:
                string str1 = keyValuePair1.Value.ToString();
                this._value._path_type = (byte) 0;
                int num2 = Array.IndexOf<string>(ResourceInfo.INFO_PATH_TYPE_STR, str1);
                if (num2 >= 0)
                {
                  this._value._path_type = (byte) num2;
                  continue;
                }
                continue;
              case 4:
                this._value._ext = string.Intern(keyValuePair1.Value.ToString());
                continue;
              case 5:
                this._value._id = (ushort) (long) keyValuePair1.Value;
                continue;
              case 6:
                string str2 = keyValuePair1.Value.ToString();
                this._value._type = (byte) 0;
                int num3 = Array.IndexOf<string>(ResourceInfo.INFO_TYPE_STR, str2);
                if (num3 >= 0)
                {
                  this._value._type = (byte) num3;
                  continue;
                }
                continue;
              case 7:
                int count1 = ((List<object>) keyValuePair1.Value).Count;
                if (count1 > 0)
                {
                  this._value._steps = new ResourceInfo.Step[count1];
                  int index1 = 0;
                  using (List<object>.Enumerator enumerator1 = ((List<object>) keyValuePair1.Value).GetEnumerator())
                  {
                    while (enumerator1.MoveNext())
                    {
                      foreach (KeyValuePair<string, object> keyValuePair2 in (Dictionary<string, object>) enumerator1.Current)
                      {
                        string key2 = keyValuePair2.Key;
                        if (key2 != null)
                        {
                          // ISSUE: reference to a compiler-generated field
                          if (ResourceInfo.Resource.\u003C\u003Ef__switch\u0024map26 == null)
                          {
                            // ISSUE: reference to a compiler-generated field
                            ResourceInfo.Resource.\u003C\u003Ef__switch\u0024map26 = new Dictionary<string, int>(6)
                            {
                              {
                                "type",
                                0
                              },
                              {
                                "path",
                                1
                              },
                              {
                                "sharedMaterials",
                                2
                              },
                              {
                                "transform",
                                3
                              },
                              {
                                "has_mask",
                                4
                              },
                              {
                                "shader",
                                5
                              }
                            };
                          }
                          int num4;
                          // ISSUE: reference to a compiler-generated field
                          if (ResourceInfo.Resource.\u003C\u003Ef__switch\u0024map26.TryGetValue(key2, out num4))
                          {
                            switch (num4)
                            {
                              case 0:
                                string str3 = keyValuePair2.Value.ToString();
                                this._value._steps[index1]._type = (byte) 0;
                                int num5 = Array.IndexOf<string>(ResourceInfo.INFO_STEPS_TYPE_STR, str3);
                                if (num5 >= 0)
                                {
                                  this._value._steps[index1]._type = (byte) num5;
                                  continue;
                                }
                                continue;
                              case 1:
                                string str4 = keyValuePair2.Value.ToString();
                                int num6 = str4.LastIndexOf('/');
                                if (num6 <= 0)
                                {
                                  this._value._steps[index1]._path1 = string.Intern(str4);
                                  continue;
                                }
                                int num7 = num6 + 1;
                                this._value._steps[index1]._path1 = string.Intern(str4.Substring(0, num7));
                                this._value._steps[index1]._path2 = string.Intern(str4.Substring(num7));
                                continue;
                              case 2:
                                int count2 = ((Dictionary<string, object>) keyValuePair2.Value).Count;
                                if (count2 > 0)
                                {
                                  this._value._steps[index1]._sharedMaterials = new Dictionary<string, ResourceInfo.Step._InternalTextureData>[count2];
                                  int index2 = 0;
                                  using (Dictionary<string, object>.Enumerator enumerator2 = ((Dictionary<string, object>) keyValuePair2.Value).GetEnumerator())
                                  {
                                    while (enumerator2.MoveNext())
                                    {
                                      KeyValuePair<string, object> current = enumerator2.Current;
                                      this._value._steps[index1]._sharedMaterials[index2] = new Dictionary<string, ResourceInfo.Step._InternalTextureData>();
                                      foreach (KeyValuePair<string, object> keyValuePair3 in (Dictionary<string, object>) current.Value)
                                      {
                                        string[] strArray = new string[2];
                                        List<object> objectList = (List<object>) keyValuePair3.Value;
                                        string str5 = objectList[0].ToString();
                                        int num8 = str5.LastIndexOf('/');
                                        if (num8 <= 0)
                                        {
                                          strArray[0] = string.Intern(str5);
                                        }
                                        else
                                        {
                                          int num9 = num8 + 1;
                                          strArray[0] = string.Intern(str5.Substring(0, num9));
                                          strArray[1] = string.Intern(str5.Substring(num9));
                                        }
                                        FilterMode filterMode = (FilterMode) 1;
                                        switch (objectList[1].ToString())
                                        {
                                          case "Point":
                                            filterMode = (FilterMode) 0;
                                            break;
                                          case "Trilinear":
                                            filterMode = (FilterMode) 2;
                                            break;
                                        }
                                        TextureWrapMode textureWrapMode = (TextureWrapMode) 1;
                                        if (objectList[2].ToString() == "Repeat")
                                          textureWrapMode = (TextureWrapMode) 0;
                                        this._value._steps[index1]._sharedMaterials[index2][keyValuePair3.Key] = new ResourceInfo.Step._InternalTextureData()
                                        {
                                          name = strArray,
                                          filterMode = filterMode,
                                          wrapMode = textureWrapMode
                                        };
                                      }
                                      ++index2;
                                    }
                                    continue;
                                  }
                                }
                                else
                                  continue;
                              case 3:
                                this._value._steps[index1]._transform = string.Intern(keyValuePair2.Value.ToString());
                                continue;
                              case 4:
                                this._value._steps[index1]._has_mask = (bool) keyValuePair2.Value;
                                continue;
                              case 5:
                                this._value._steps[index1]._shader = string.Intern(keyValuePair2.Value.ToString());
                                continue;
                              default:
                                continue;
                            }
                          }
                        }
                      }
                      ++index1;
                    }
                    continue;
                  }
                }
                else
                  continue;
              case 8:
                this._value._download_size = (uint) (long) keyValuePair1.Value;
                continue;
              case 9:
                this._value._compressed = (bool) keyValuePair1.Value;
                continue;
              case 10:
                this._value._file_size = (uint) (long) keyValuePair1.Value;
                continue;
              case 11:
                this._value._width = (ushort) (long) keyValuePair1.Value;
                continue;
              case 12:
                this._value._height = (ushort) (long) keyValuePair1.Value;
                continue;
              case 13:
                this._value._mask = (bool) keyValuePair1.Value;
                continue;
              default:
                continue;
            }
          }
        }
      }
    }
  }

  private class PathComparer : IComparer<ResourceInfo.Resource>
  {
    public static ResourceInfo.PathComparer Default = new ResourceInfo.PathComparer();

    public int Compare(ResourceInfo.Resource x, ResourceInfo.Resource y)
    {
      return Comparer<string>.Default.Compare(x._key, y._key);
    }
  }

  private sealed class Parser : IDisposable
  {
    private const string WHITE_SPACE = " \t\n\r";
    private const string WORD_BREAK = " \t\n\r{}[],:\"";
    private StreamReader json;

    public Parser(Stream stream) => this.json = new StreamReader(stream, Encoding.UTF8);

    public void Dispose()
    {
      this.json.Dispose();
      this.json = (StreamReader) null;
    }

    [DebuggerHidden]
    public IEnumerable<KeyValuePair<string, object>> ParseObjectEnum()
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      ResourceInfo.Parser.\u003CParseObjectEnum\u003Ec__IteratorBCE objectEnum = new ResourceInfo.Parser.\u003CParseObjectEnum\u003Ec__IteratorBCE()
      {
        \u003C\u003Ef__this = this
      };
      // ISSUE: reference to a compiler-generated field
      objectEnum.\u0024PC = -2;
      return (IEnumerable<KeyValuePair<string, object>>) objectEnum;
    }

    private Dictionary<string, object> ParseObject()
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      this.json.Read();
      while (true)
      {
        ResourceInfo.Parser.TOKEN nextToken;
        do
        {
          nextToken = this.NextToken;
          switch (nextToken)
          {
            case ResourceInfo.Parser.TOKEN.NONE:
              goto label_3;
            case ResourceInfo.Parser.TOKEN.CURLY_CLOSE:
              goto label_4;
            default:
              continue;
          }
        }
        while (nextToken == ResourceInfo.Parser.TOKEN.COMMA);
        string key = this.ParseString();
        if (key != null)
        {
          if (this.NextToken == ResourceInfo.Parser.TOKEN.COLON)
          {
            this.json.Read();
            dictionary[key] = this.ParseValue();
          }
          else
            goto label_8;
        }
        else
          goto label_6;
      }
label_3:
      return (Dictionary<string, object>) null;
label_4:
      return dictionary;
label_6:
      return (Dictionary<string, object>) null;
label_8:
      return (Dictionary<string, object>) null;
    }

    private List<object> ParseArray()
    {
      List<object> array = new List<object>();
      this.json.Read();
      bool flag = true;
      while (flag)
      {
        ResourceInfo.Parser.TOKEN nextToken = this.NextToken;
        ResourceInfo.Parser.TOKEN token = nextToken;
        switch (token)
        {
          case ResourceInfo.Parser.TOKEN.SQUARED_CLOSE:
            flag = false;
            continue;
          case ResourceInfo.Parser.TOKEN.COMMA:
            continue;
          default:
            if (token == ResourceInfo.Parser.TOKEN.NONE)
              return (List<object>) null;
            object byToken = this.ParseByToken(nextToken);
            array.Add(byToken);
            continue;
        }
      }
      return array;
    }

    private object ParseValue() => this.ParseByToken(this.NextToken);

    private object ParseByToken(ResourceInfo.Parser.TOKEN token)
    {
      switch (token)
      {
        case ResourceInfo.Parser.TOKEN.CURLY_OPEN:
          return (object) this.ParseObject();
        case ResourceInfo.Parser.TOKEN.SQUARED_OPEN:
          return (object) this.ParseArray();
        case ResourceInfo.Parser.TOKEN.STRING:
          return (object) this.ParseString();
        case ResourceInfo.Parser.TOKEN.NUMBER:
          return this.ParseNumber();
        case ResourceInfo.Parser.TOKEN.TRUE:
          return (object) true;
        case ResourceInfo.Parser.TOKEN.FALSE:
          return (object) false;
        case ResourceInfo.Parser.TOKEN.NULL:
          return (object) null;
        default:
          return (object) null;
      }
    }

    private string ParseString()
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      this.json.Read();
      bool flag = true;
      while (flag)
      {
        if (this.json.Peek() == -1)
          break;
        char nextChar1 = this.NextChar;
        switch (nextChar1)
        {
          case '"':
            flag = false;
            continue;
          case '\\':
            if (this.json.Peek() == -1)
            {
              flag = false;
              continue;
            }
            char nextChar2 = this.NextChar;
            char ch = nextChar2;
            switch (ch)
            {
              case 'n':
                stringBuilder1.Append('\n');
                continue;
              case 'r':
                stringBuilder1.Append('\r');
                continue;
              case 't':
                stringBuilder1.Append('\t');
                continue;
              case 'u':
                StringBuilder stringBuilder2 = new StringBuilder();
                for (int index = 0; index < 4; ++index)
                  stringBuilder2.Append(this.NextChar);
                stringBuilder1.Append((char) Convert.ToInt32(stringBuilder2.ToString(), 16));
                continue;
              default:
                if (ch != '"' && ch != '/' && ch != '\\')
                {
                  switch (ch)
                  {
                    case 'b':
                      stringBuilder1.Append('\b');
                      continue;
                    case 'f':
                      stringBuilder1.Append('\f');
                      continue;
                    default:
                      continue;
                  }
                }
                else
                {
                  stringBuilder1.Append(nextChar2);
                  continue;
                }
            }
          default:
            stringBuilder1.Append(nextChar1);
            continue;
        }
      }
      return stringBuilder1.ToString();
    }

    private object ParseNumber()
    {
      string nextWord = this.NextWord;
      if (nextWord.IndexOf('.') == -1)
      {
        long result;
        long.TryParse(nextWord, out result);
        return (object) result;
      }
      double result1;
      double.TryParse(nextWord, out result1);
      return (object) result1;
    }

    private void EatWhitespace()
    {
      while (" \t\n\r".IndexOf(this.PeekChar) != -1)
      {
        this.json.Read();
        if (this.json.Peek() == -1)
          break;
      }
    }

    private char PeekChar => Convert.ToChar(this.json.Peek());

    private char NextChar => Convert.ToChar(this.json.Read());

    private string NextWord
    {
      get
      {
        StringBuilder stringBuilder = new StringBuilder();
        while (" \t\n\r{}[],:\"".IndexOf(this.PeekChar) == -1)
        {
          stringBuilder.Append(this.NextChar);
          if (this.json.Peek() == -1)
            break;
        }
        return stringBuilder.ToString();
      }
    }

    private ResourceInfo.Parser.TOKEN NextToken
    {
      get
      {
        this.EatWhitespace();
        if (this.json.Peek() == -1)
          return ResourceInfo.Parser.TOKEN.NONE;
        char peekChar = this.PeekChar;
        switch (peekChar)
        {
          case '"':
            return ResourceInfo.Parser.TOKEN.STRING;
          case ',':
            this.json.Read();
            return ResourceInfo.Parser.TOKEN.COMMA;
          case '-':
          case '0':
          case '1':
          case '2':
          case '3':
          case '4':
          case '5':
          case '6':
          case '7':
          case '8':
          case '9':
            return ResourceInfo.Parser.TOKEN.NUMBER;
          case ':':
            return ResourceInfo.Parser.TOKEN.COLON;
          default:
            switch (peekChar)
            {
              case '[':
                return ResourceInfo.Parser.TOKEN.SQUARED_OPEN;
              case ']':
                this.json.Read();
                return ResourceInfo.Parser.TOKEN.SQUARED_CLOSE;
              default:
                switch (peekChar)
                {
                  case '{':
                    return ResourceInfo.Parser.TOKEN.CURLY_OPEN;
                  case '}':
                    this.json.Read();
                    return ResourceInfo.Parser.TOKEN.CURLY_CLOSE;
                  default:
                    string nextWord = this.NextWord;
                    if (nextWord != null)
                    {
                      if (ResourceInfo.Parser.\u003C\u003Ef__switch\u0024map28 == null)
                        ResourceInfo.Parser.\u003C\u003Ef__switch\u0024map28 = new Dictionary<string, int>(3)
                        {
                          {
                            "false",
                            0
                          },
                          {
                            "true",
                            1
                          },
                          {
                            "null",
                            2
                          }
                        };
                      int num;
                      if (ResourceInfo.Parser.\u003C\u003Ef__switch\u0024map28.TryGetValue(nextWord, out num))
                      {
                        switch (num)
                        {
                          case 0:
                            return ResourceInfo.Parser.TOKEN.FALSE;
                          case 1:
                            return ResourceInfo.Parser.TOKEN.TRUE;
                          case 2:
                            return ResourceInfo.Parser.TOKEN.NULL;
                        }
                      }
                    }
                    return ResourceInfo.Parser.TOKEN.NONE;
                }
            }
        }
      }
    }

    private enum TOKEN
    {
      NONE,
      CURLY_OPEN,
      CURLY_CLOSE,
      SQUARED_OPEN,
      SQUARED_CLOSE,
      COLON,
      COMMA,
      STRING,
      NUMBER,
      TRUE,
      FALSE,
      NULL,
    }
  }
}
