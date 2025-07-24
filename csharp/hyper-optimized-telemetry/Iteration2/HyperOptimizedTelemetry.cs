using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        var buffer = new byte[9];
        (var prefix, var payload) = reading switch
        {
            < int.MinValue     => (248, BitConverter.GetBytes((long)reading)),
            < Int16.MinValue   => (252, BitConverter.GetBytes((int)reading)),
            < ushort.MinValue  => (254, BitConverter.GetBytes((short)reading)),
            <= ushort.MaxValue => (2,   BitConverter.GetBytes((ushort)reading)),
            <= int.MaxValue    => (252, BitConverter.GetBytes((int)reading)),
            <= uint.MaxValue   => (4,   BitConverter.GetBytes((uint)reading)),
            <= Int64.MaxValue  => (248, BitConverter.GetBytes((long)reading)),
        };

        buffer[0] = (byte)prefix;
        payload.CopyTo(buffer, 1);
        
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
