// Decompiled with JetBrains decompiler
// Type: HTTP.Response
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using Ionic.Zlib;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;

#nullable disable
namespace HTTP
{
  public class Response : BaseHTTP
  {
    public readonly Headers headers = new Headers();
    private byte[] bytes;

    public Response(Request request)
    {
    }

    public int status { get; private set; }

    public string message { get; private set; }

    public float progress { get; private set; }

    public UnityEngine.AssetBundleCreateRequest AssetBundleCreateRequest()
    {
      return AssetBundle.LoadFromMemoryAsync(this.Bytes);
    }

    public string Text => Encoding.UTF8.GetString(this.Bytes);

    public byte[] Bytes => this.bytes;

    private string ReadLine(Stream stream)
    {
      List<byte> byteList = new List<byte>();
      while (true)
      {
        int num1;
        try
        {
          num1 = stream.ReadByte();
        }
        catch (IOException ex)
        {
          throw new HTTPException("Terminated Stream");
        }
        if (num1 != -1)
        {
          byte num2 = (byte) num1;
          if ((int) num2 != (int) BaseHTTP.EOL[1])
            byteList.Add(num2);
          else
            goto label_8;
        }
        else
          break;
      }
      throw new HTTPException("Unterminated Stream");
label_8:
      return Encoding.ASCII.GetString(byteList.ToArray()).Trim();
    }

    private string[] ReadKeyValue(Stream stream)
    {
      string str = this.ReadLine(stream);
      if (str == string.Empty)
        return (string[]) null;
      int length = str.IndexOf(':');
      if (length == -1)
        return (string[]) null;
      return new string[2]
      {
        str.Substring(0, length).Trim(),
        str.Substring(length + 1).Trim()
      };
    }

    private void ReadChunks(Stream inputStream, Stream output)
    {
      byte[] buffer = new byte[8192];
      while (true)
      {
        string s = this.ReadLine(inputStream);
        if (!(s == "0"))
        {
          int num1 = int.Parse(s, NumberStyles.AllowHexSpecifier);
          this.progress = 0.0f;
          int num2 = num1;
          int count;
          for (; num1 > 0; num1 -= count)
          {
            count = inputStream.Read(buffer, 0, Mathf.Min(buffer.Length, num1));
            output.Write(buffer, 0, count);
            this.progress = Mathf.Clamp01((float) (1.0 - (double) num1 / (double) num2));
          }
          this.progress = 1f;
          inputStream.ReadByte();
          inputStream.ReadByte();
        }
        else
          break;
      }
      this.CollectHeaders(inputStream);
    }

    private void ReadBody(Stream inputStream, Stream output)
    {
      byte[] buffer = new byte[8192];
      int result = 0;
      if (int.TryParse(this.headers.Get("Content-Length"), out result))
      {
        if (result <= 0)
          return;
        int num = result;
        while (num > 0)
        {
          int count = inputStream.Read(buffer, 0, buffer.Length);
          if (count == 0)
            break;
          num -= count;
          output.Write(buffer, 0, count);
          this.progress = Mathf.Clamp01((float) (1.0 - (double) num / (double) result));
        }
      }
      else
      {
        for (int count = inputStream.Read(buffer, 0, buffer.Length); count > 0; count = inputStream.Read(buffer, 0, buffer.Length))
          output.Write(buffer, 0, count);
        this.progress = 1f;
      }
    }

    private void CollectHeaders(Stream inputStream)
    {
      while (true)
      {
        string[] strArray = this.ReadKeyValue(inputStream);
        if (strArray != null)
          this.headers.Add(strArray[0], strArray[1]);
        else
          break;
      }
    }

    public void ReadFromStream(Stream inputStream)
    {
      this.progress = 0.0f;
      string[] strArray = inputStream != null ? this.ReadLine(inputStream).Split(' ') : throw new HTTPException("Cannot read from server, server probably dropped the connection.");
      this.status = -1;
      int result = -1;
      if (strArray.Length <= 0 || !int.TryParse(strArray[1], out result))
        throw new HTTPException("Bad Status Code, server probably dropped the connection.");
      this.status = result;
      this.message = string.Join(" ", strArray, 2, strArray.Length - 2);
      this.CollectHeaders(inputStream);
      if (this.status == 101)
        this.progress = 1f;
      else if (this.status == 204)
      {
        this.progress = 1f;
      }
      else
      {
        bool flag = string.Compare(this.headers.Get("Transfer-Encoding"), "chunked", true) == 0;
        if (!flag && !this.headers.Contains("Content-Length"))
        {
          this.progress = 1f;
        }
        else
        {
          using (MemoryStream output = new MemoryStream())
          {
            if (flag)
              this.ReadChunks(inputStream, (Stream) output);
            else
              this.ReadBody(inputStream, (Stream) output);
            this.ProcessReceivedBytes(output);
          }
        }
      }
    }

    private void ProcessReceivedBytes(MemoryStream output)
    {
      bool flag = string.Compare(this.headers.Get("Content-Encoding"), "gzip", true) == 0;
      lock (output)
      {
        if (flag)
        {
          using (GZipStream gzipStream = new GZipStream((Stream) output, (CompressionMode) 1))
          {
            byte[] buffer = new byte[1024];
            int count = -1;
            output.Seek(0L, SeekOrigin.Begin);
            using (MemoryStream memoryStream = new MemoryStream())
            {
              while (count != 0)
              {
                count = gzipStream.Read(buffer, 0, buffer.Length);
                memoryStream.Write(buffer, 0, count);
              }
              this.bytes = memoryStream.ToArray();
            }
          }
        }
        else
          this.bytes = output.ToArray();
      }
    }
  }
}
