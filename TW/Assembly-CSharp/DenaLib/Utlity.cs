// Decompiled with JetBrains decompiler
// Type: DenaLib.Utlity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SevenZip;
using SevenZip.Compression.LZMA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

#nullable disable
namespace DenaLib
{
  public class Utlity : Singleton<Utlity>
  {
    private MD5 m_md5 = (MD5) new MD5CryptoServiceProvider();
    private Encoder m_LzmaCoder = new Encoder();
    private Decoder m_LzmaDecoder = new Decoder();
    private Dictionary<int, Utlity.MessageInfo> m_MsgDic = new Dictionary<int, Utlity.MessageInfo>();

    public string CalcFileMD5(string filename)
    {
      string empty = string.Empty;
      if (File.Exists(filename))
      {
        using (FileStream inputStream = new FileStream(filename, FileMode.Open))
          empty = BitConverter.ToString(this.m_md5.ComputeHash((Stream) inputStream));
      }
      return empty;
    }

    public string CalcFileMD5(byte[] buffer)
    {
      string empty = string.Empty;
      return BitConverter.ToString(this.m_md5.ComputeHash(buffer));
    }

    public void CompressFileLZMA(FileStream input, FileStream output)
    {
      this.m_LzmaCoder.WriteCoderProperties((Stream) output);
      output.Write(BitConverter.GetBytes(input.Length), 0, 8);
      this.m_LzmaCoder.Code((Stream) input, (Stream) output, input.Length, -1L, (ICodeProgress) null);
      output.Flush();
      output.Close();
    }

    public void DecompressFileLZMA(FileStream input, FileStream output)
    {
      byte[] numArray = new byte[5];
      input.Read(numArray, 0, 5);
      byte[] array = new byte[8];
      input.Read(array, 0, 8);
      long int64 = BitConverter.ToInt64(array, 0);
      this.m_LzmaDecoder.SetDecoderProperties(numArray);
      this.m_LzmaDecoder.Code((Stream) input, (Stream) output, input.Length, int64, (ICodeProgress) null);
      output.Flush();
      input.Close();
    }

    public bool IsWifi() => Application.internetReachability == 2;

    public bool HasConnection() => Application.internetReachability != 0;

    public void RegisterMsg(int code, string message)
    {
      Utlity.MessageInfo messageInfo = (Utlity.MessageInfo) null;
      if (this.m_MsgDic.TryGetValue(code, out messageInfo))
        messageInfo.Message = message;
      else
        this.m_MsgDic.Add(code, new Utlity.MessageInfo()
        {
          MessageCode = code,
          Message = message
        });
    }

    public void LogMsg(EMessageCode code, string msg)
    {
      Debuger.Log((object) (code.ToString() + ":" + msg));
    }

    public void CreateDir(string root, string relativePath)
    {
      string str = root;
      string[] strArray = relativePath.Split('\\');
      for (int index = 0; index < strArray.Length - 1; ++index)
      {
        string path = str + "/" + strArray[index];
        if (!Directory.Exists(path))
        {
          Directory.CreateDirectory(path);
          str = path;
        }
      }
    }

    public class MessageInfo
    {
      public int MessageCode;
      public string Message = string.Empty;
    }
  }
}
