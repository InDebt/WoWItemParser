using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowItemParser.Internal.DBC
{
    using System.ComponentModel;
    using System.IO;

    internal class DbcFile
    {
        public DbcFile(string path)
        {
            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                this.Header = new DbcFileHeader(file);
                this.Records = new Dictionary<int, int[]>((int)this.Header.RecordCount);
                for (int i = 0; i < this.Header.RecordCount; i++)
                {
                    byte[] bytes = new byte[this.Header.RecordSize];
                    int toRead = (int)this.Header.RecordSize, bytesRead;
                    int offset = 0;
                    while (toRead > 0 && (bytesRead = file.Read(bytes, offset, toRead)) > 0)
                    {
                        toRead -= bytesRead;
                        offset += bytesRead;
                    }
                    int[] record = new int[this.Header.FieldCount];
                    for (int j = 0; j < this.Header.FieldCount; j++)
                    {
                        record[j] = BitConverter.ToInt32(bytes, j * sizeof(int));
                    }
                    this.Records[record[0]] = record;
                }

                this.Strings = new byte[this.Header.StringBlockSize];
                int blockSize = (int)this.Header.StringBlockSize;
                int off = 0, inBytes;
                while (blockSize > 0 && (inBytes = file.Read(this.Strings, off, blockSize)) > 0)
                {
                    blockSize -= inBytes;
                    off += inBytes;
                }
            }
        }

        public DbcFileHeader Header { get; private set; }
        public Dictionary<int, int[]> Records { get; private set; }
        public byte[] Strings { get; private set; }

        public string ParseString(int offset)
        {
            List<byte> bytes = new List<byte>();
            int i = 0;
            while (this.Strings[offset + i] != 0)
            {
                bytes.Add(this.Strings[offset + i]);
                i++;
            }

            return Encoding.UTF8.GetString(bytes.ToArray());
        }
    }
}
