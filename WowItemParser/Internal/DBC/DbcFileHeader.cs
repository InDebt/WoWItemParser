// This source is for use by Netfira developers or development partners only.
// 
// File: DbcFileHeader.cs
// Date: 2015-11-17

namespace WowItemParser.Internal.DBC
{
    using System;
    using System.IO;

    /// <summary>
    ///     File header for a WoW dbc file
    ///     See: http://www.pxr.dk/wowdev/wiki/index.php?title=DBC
    /// </summary>
    internal class DbcFileHeader
    {
        public DbcFileHeader(Stream fileStream)
        {
            // read header from file
            byte[] buffer = new byte[20];
            fileStream.Read(buffer, 0, 20);

            // Magic offset = 0
            this.Magic = BitConverter.ToUInt32(buffer, 0);

            // RecordCount offset = 4
            this.RecordCount = BitConverter.ToUInt32(buffer, 4);

            // FieldCount offset = 8
            this.FieldCount = BitConverter.ToUInt32(buffer, 8);

            // RecordSize offset = 12
            this.RecordSize = BitConverter.ToUInt32(buffer, 12);

            // StringBlockSize offset = 16
            this.StringBlockSize = BitConverter.ToUInt32(buffer, 16);
        }

        public uint Magic { get; private set; }

        public uint RecordCount { get; private set; }

        public uint FieldCount { get; private set; }

        public uint RecordSize { get; private set; }

        public uint StringBlockSize { get; private set; }
    }
}