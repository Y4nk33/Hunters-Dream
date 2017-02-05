using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms_Wurds
{
    class Word
    {
        //
        //  CONSTRUCTOR
        //
        public Word(Collection<string> authors)
        {
            //Set Authors
            set_authors(authors);        
        }
        //
        //  ATTRIBUTES
        //
        //Contains every Occurrence as a LineKEY,
        //use this to lookup additional info in Line.cs
        List<int> lineKEY = new List<int>();

        //Occurrence by author
        Dictionary<string, int> author_occurrence = new Dictionary<string, int>();

        //
        //  FUNCTIONS
        //

        //  GETS   
        public List<int> get_lineKEY()
        {
            return lineKEY;
        }
        public Dictionary<string, int> get_author_occurrence()
        {
            return author_occurrence;
        }

        //  SETS
        public void set_lineKEY(List<int> in_lineKEY)
        {
            lineKEY = in_lineKEY;
        }
        public void set_author_occurrence(Dictionary<string, int> in_author_occurrence)
        {
            author_occurrence = in_author_occurrence;
        }

        //  OTHER

        //Uses author_occurrence to add up the total occurrences
        public int get_totaloccurrences()
        {
            int sum = 0;
            foreach (string author in author_occurrence.Keys)
            {
                sum += author_occurrence[author];
            }
            return sum;
        }

        //Add a lineKEY
        public void add_lineKEY(int i)
        {
            lineKEY.Add(i);
        }

        //Prefilling authors as placeholders
        public void set_authors(Collection<string> authors)
        {
            foreach (string author in authors)
            {
                author_occurrence.Add(author, 0);
            }
        }

        //Add occurrence
        public void add_author_occurrence(string author)
        {
            author_occurrence[author]++;
        }
    }
}
