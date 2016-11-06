using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms_Wurds
{
    public class Line
    {
        internal Forms_Wurds.Word[] Word
        {
            get;
            set;
        }

        private DateTime DateTime
        {
            get;
            set;
        }

        private string Author
        {
            get;
            set;
        }

        private string Literal
        {
            get;
            set;
        }

        public String getAuthor()
        {
            return Author;
        }

        public void setAuthor(string author)
        {
            Author = author;
        }

        public DateTime getDateTime()
        {
            return DateTime;
        }

        public void setDateTime(DateTime datetime)
        {
            DateTime = datetime;
        }

        public String getLiteral()
        {
            return Literal;
        }

        public void setLiteral(string literal)
        {
            Literal = literal;
        }
    }
}
