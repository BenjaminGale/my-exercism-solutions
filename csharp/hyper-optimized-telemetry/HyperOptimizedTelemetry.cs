using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        var buffer = new byte[9];
        (var numberOfBytes, var bytes) = reading switch
        {
            (>= -1 and <= 0) => (254, BitConverter.GetBytes((ushort)reading)),
            (< int.MinValue or > uint.MaxValue) => (248, BitConverter.GetBytes(reading)),
            (> int.MaxValue) => (4, BitConverter.GetBytes(reading)),
            (< short.MinValue or > ushort.MaxValue) => (252, BitConverter.GetBytes((uint)reading)),
            (> short.MaxValue) => (2, BitConverter.GetBytes(reading)),
            (< sbyte.MinValue or > byte.MaxValue) => (254, BitConverter.GetBytes((short)reading)),
        };

        buffer[0] = (byte)numberOfBytes;
        bytes.CopyTo(buffer, 1);
        
        return buffer;
    }

    public static long FromBuffer(byte[] buffer) =>
        buffer[0] switch
        {
            248 => BitConverter.ToInt64(buffer, 1),
            252 => BitConverter.ToInt32(buffer, 1),
            254 => BitConverter.ToInt16(buffer, 1),
            2 => BitConverter.ToUInt16(buffer, 1),
            4 => BitConverter.ToUInt32(buffer, 1),
            _ => 0
        };
}
