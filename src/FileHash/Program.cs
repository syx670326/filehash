using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FileHash
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string path = args[0];
                if (File.Exists(path))
                {
                    string hash;
                    var file = new FileInfo(path);
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        SHA256 sha256 = SHA256.Create();
                        Byte[] buffer = sha256.ComputeHash(fs);
                        sha256.Clear();
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < buffer.Length; i++)
                        {
                            sb.Append(buffer[i].ToString("x2"));
                        }
                        hash = sb.ToString();
                    }
                    Console.WriteLine("------");
                    Console.WriteLine($"SHA256:{hash}");
                    Console.WriteLine("------");
                    return;
                }
            }
        }
    }
}
