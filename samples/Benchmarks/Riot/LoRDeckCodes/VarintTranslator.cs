#pragma warning disable

namespace Benchmarks.Riot.LoRDeckCodes;

public class VarintTranslator
{
    private const byte AllButMSB = 0x7f;
    private const byte JustMSB = 0x80;

    public static int PopVarint(List<byte> bytes)
    {
        ulong result = 0;
        int currentShift = 0;
        int bytesPopped = 0;

        for (int i = 0; i < bytes.Count; i++)
        {
            bytesPopped++;
            ulong current = (ulong)bytes[i] & AllButMSB;
            result |= current << currentShift;

            if ((bytes[i] & JustMSB) != JustMSB)
            {
                bytes.RemoveRange(0, bytesPopped);
                return (int)result;
            }

            currentShift += 7;

        }

        throw new ArgumentException("Byte array did not contain valid varints.");
    }

    public static byte[] GetVarint(ulong value)
    {
        var buff = new byte[10];
        var currentIndex = 0;

        if (value == 0)
            return new byte[1] { 0 };

        while (value != 0)
        {
            var byteVal = value & AllButMSB;
            value >>= 7;

            if (value != 0)
                byteVal |= 0x80;

            buff[currentIndex++] = (byte)byteVal;

        }

        byte[] result = new byte[currentIndex];
        Buffer.BlockCopy(buff, 0, result, 0, currentIndex);

        return result;
    }

    public static byte[] GetVarint(int value)
    {
        return GetVarint((ulong)value);
    }
}
