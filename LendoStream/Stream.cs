using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LendoStream
{
    public interface IStream
    {
        char getNext();
        Boolean hasNext();
    }
    public class Stream : IStream
    {
        private static string textStream;
        private static StreamReader reader;

        public Stream(string pTextStream)
        {
            textStream = pTextStream;

            byte[] byteArray = Encoding.ASCII.GetBytes(textStream);
            MemoryStream stream = new MemoryStream(byteArray);
            reader = new StreamReader(stream);
        }

        public char getNext()
        {
            if (hasNext() == true)
            {
                char character = (char)reader.Read();
                return character;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public Boolean hasNext()
        {
            if (reader.EndOfStream == false)
            {
                return true;
            }
            else if (reader.EndOfStream == true)
            {
                return false;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
}
}
