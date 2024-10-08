// InBuffer.cs
namespace ClashLand.External.LZMA.Common
{
    public class InBuffer
    {
        private byte[] m_Buffer;
        private uint m_Pos;
        private uint m_Limit;
        private uint m_BufferSize;
        private System.IO.Stream m_Stream;
        private bool m_StreamWasExhausted;
        private ulong m_ProcessedSize;

        public InBuffer(uint bufferSize)
        {
            m_Buffer = new byte[bufferSize];
            m_BufferSize = bufferSize;
        }

        public void Init(System.IO.Stream stream)
        {
            m_Stream = stream;
            m_ProcessedSize = 0;
            m_Limit = 0;
            m_Pos = 0;
            m_StreamWasExhausted = false;
        }

        public bool ReadBlock()
        {
            if (m_StreamWasExhausted)
                return false;
            m_ProcessedSize += m_Pos;
            int aNumProcessedBytes = m_Stream.Read(m_Buffer, 0, (int)m_BufferSize);
            m_Pos = 0;
            m_Limit = (uint)aNumProcessedBytes;
            m_StreamWasExhausted = (aNumProcessedBytes == 0);
            return (!m_StreamWasExhausted);
        }

        public void ReleaseStream()
        {
            m_Stream = null;
        }

        public bool ReadByte(byte b)
        {
            if (m_Pos >= m_Limit)
                if (!ReadBlock())
                    return false;
            b = m_Buffer[m_Pos++];
            return true;
        }

        public byte ReadByte()
        {
            if (m_Pos >= m_Limit)
                if (!ReadBlock())
                    return 0xFF;
            return m_Buffer[m_Pos++];
        }

        public ulong GetProcessedSize()
        {
            return m_ProcessedSize + m_Pos;
        }
    }
}