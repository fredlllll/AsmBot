using System;
using System.IO;

namespace Assets.Scripts
{
    public static class Extensions
    {
        /// <summary>
        /// copied here because its protected in net standard 2.1
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        public static void Write7BitEncodedInt(this BinaryWriter writer, int value)
        {
            //from https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/IO/BinaryWriter.cs,2daa1d14ff1877bd

            uint uValue = (uint)value;

            while (uValue > 0x7Fu)
            {
                writer.Write((byte)(uValue | ~0x7Fu));
                uValue >>= 7;
            }

            writer.Write((byte)uValue);
        }

        public static int Read7BitEncodedInt(this BinaryReader reader)
        {
            //from https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/IO/BinaryReader.cs,f30b8b6e8ca06e0f

            uint result = 0;
            byte byteReadJustNow;

            const int MaxBytesWithoutOverflow = 4;
            for (int shift = 0; shift < MaxBytesWithoutOverflow * 7; shift += 7)
            {
                // ReadByte handles end of stream cases for us.
                byteReadJustNow = reader.ReadByte();
                result |= (byteReadJustNow & 0x7Fu) << shift;

                if (byteReadJustNow <= 0x7Fu)
                {
                    return (int)result; // early exit
                }
            }

            byteReadJustNow = reader.ReadByte();
            if (byteReadJustNow > 0b_1111u)
            {
                throw new FormatException("Format_Bad7BitInt");
            }

            result |= (uint)byteReadJustNow << (MaxBytesWithoutOverflow * 7);
            return (int)result;
        }
    }
}
