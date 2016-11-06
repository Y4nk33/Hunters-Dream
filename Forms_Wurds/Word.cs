using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms_Wurds
{
    class Word
    {
        private String Literal
        {
            get;
            set;
        }

        private int Occurrence
        {
            get;
            set;
        }

        private Dictionary<string, int> Dict
        {
            get;
            set;
        }

        public int getOccurrence()
        {
            return Occurrence;
        }

        public void setOccurrence(int i)
        {
            Occurrence = i;
        }

        public string getLiteral()
        {
            return Literal;
        }

        public void setLiteral(string s)
        {
            Literal = s;
        }

        public Dictionary<string, int> getDict()
        {
            return Dict;
        }

        public void setDict(Dictionary<string, int> d)
        {
            Dict = d;
        }
    }
}
