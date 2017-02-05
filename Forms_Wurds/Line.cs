using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms_Wurds
{
    public class Line
    {
        //
        //  ATTRIBUTES
        //

        public DateTime DateTime
        {
            get;
            set;
        }

        public string Author
        {
            get;
            set;
        }

        public string Literal
        {
            get;
            set;
        }

        //
        //  FUNCTIONS
        //

        //  GETS

        public String getAuthor()
        {
            return Author;
        }

        public DateTime getDateTime()
        {
            return DateTime;
        }

        public String getLiteral()
        {
            return Literal;
        }

        //  SETS

        public void setAuthor(string author)
        {
            Author = author;
        }

        public void setDateTime(DateTime datetime)
        {
            DateTime = datetime;
        }

        public void setLiteral(string literal)
        {
            Literal = literal;
        }
    }
}
