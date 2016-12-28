using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Reflection;
using Microsoft.SqlServer;
using System.Windows.Forms.DataVisualization.Charting;

namespace Forms_Wurds
{
    public partial class Form1 : Form
    {
        //Global Variables
        BindingSource bs = new BindingSource();

        //Name der zu lesenden Datei
        static string path = Txt_Lesen("brudis");
        //Ab Wann der Name beginnt
        static int index_name_start = 19;
        //Length of DateTime
        static int datetime_length = 17;
        //all lines
        static string[] lines_literal = File.ReadAllLines(path);
        //sum of all words
        static int words_count = 0;

        //all words
        Dictionary<string, dynamic[]> words = new Dictionary<string, dynamic[]>();

        //authors and their sum of words
        Dictionary<string, int> authors_sum_of_words = new Dictionary<string, int>();
        //authors and their sum of messages
        Dictionary<string, int> authors_sum_of_messages = new Dictionary<string, int>();
        //authors and their sum of words in a message
        Dictionary<string, int> authors_words_per_message = new Dictionary<string, int>();

        //all lines
        Line[] lines = new Line[File.ReadAllLines(path).Count()];

        //all authors
        static Collection<string> authors = new Collection<string>();

        //this array of objects holds every property of words
        static dynamic[] words_properties = new dynamic[4];

        //words_properties
        public static void initialization()
        {
            //declaration of objects:

            //LineID to carry over the corresponding Line
            List<int>               lineID              = new List<int>();
            //DateTime of occurrence
            List<DateTime>          datetime            = new List<DateTime>();
            //Amount of occurrence
            int                     occurrence          = 1;
            //Occurrence by author
            Dictionary<string, int> author_occurrence   = new Dictionary<string, int>();
            //fill this dictionary
            foreach (var author in authors)
            {
                author_occurrence.Add(author, 0);
            }
            //assign properties
            words_properties[0] = lineID;
            words_properties[1] = datetime;
            words_properties[2] = occurrence;
            words_properties[3] = author_occurrence;
        }
        
        //Ermittelt die Länge des Namens des Verfassers einer Zeile
        /*
        public static int get_Name_length(string line)
        {
            int i;
            for (i = index_name_start; line[i] != ':'; i++);

            return i - index_name_start;
        }
        */

        //Get Author of a line
        public static string get_Author(string line, string previous_author)
        {
            switch (get_message_type(line))
            {
                //if line is normal
                case 0:
                    int i;
                    //increment i for author.length
                    for (i = index_name_start; line[i] != ':'; i++) ;
                    //And use this length to write author
                    return line.Substring(index_name_start, i - index_name_start);
                
                //if line is newline
                case 1:
                    return previous_author;
                
                //if line is system
                case 2:
                    return "System";
                default:
                    return "System";
            }
        }
        
        //Checks wether a line belongs to the previous line
        public static bool Line_is_newLine(String line)
        {
            if (line.Length >= 9 && line[2] == '/' && line[5] == '/' && line[8] == ' ')
                return false;
            else
                return true;
        }

        //Checks if a line is a System Message
        public static bool Line_is_System(String line)
        {
            if (line.Contains(":"))
                return false;
            //if String does contain : then do NOT blacklist

            /*
            TODO: If Subject contains :
            Example, the first line needs to be blacklisted:
            13/03/16 19:09:07: You changed the subject to “Text:huso:”
            13/03/16 19:09:07: Alex: changed the subject to “Text:huso:"
            */
            else
                return true;
        }

        //Get DateTime of a Line
        public static DateTime get_DateTime(string line, DateTime previous_datetime)
        {
            if (get_message_type(line) != 1)
                return DateTime.ParseExact(line.Substring(0, datetime_length), "dd/MM/yy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            else
                return previous_datetime;
        }

        //Find all authors in a file
        public void set_allAuthors()
        {
            string author = "";
            for (int i = 0; i < lines_literal.Count(); i++)
            {
                author = get_Author(lines_literal[i], author);

                if (authors.Contains(author) == false)
                {
                    authors.Add(author);
                    authors_sum_of_words.Add(author, 0);
                    authors_sum_of_messages.Add(author, 0);
                }
            }
        }

        //Gibt Dateipfad aus
        public static string Txt_Lesen(string s)
        {
            if (Directory.Exists("C:\\Users\\Alex"))
                return "C:\\Users\\Alex\\Source\\Repos\\Hunters-Dream\\Forms_Wurds\\txts\\" + s + ".txt";
            else
                return "C:\\Users\\alhe\\Source\\Repos\\Hunters-Dream\\Forms_Wurds\\txts\\" + s + ".txt";
        }

        public Form1()
        {
            InitializeComponent();
        }

        //Word trimmed of Blacklisted characters
        public static string trimmed_string(string word)
        {
            //chars to trim
            char[] charstotrim = { '!', '?', '"', '.', '[', ']', ','};

            //trim emoji
            word = Regex.Replace(word, @"\p{Cs}", "");

            //trim images, videos
            word.Replace("<image", "");
            word.Replace("<video", "");
            word.Replace("<audio", "");
            word.Replace("omitted>", "");
            //trim chars
            foreach (char item in charstotrim)
            {
                word = word.Replace(item.ToString(), "");
            }

            return word;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //initiliaze
            set_allAuthors();
        }

        //Gets rid of the DateTime
        public static String TrimDateTime(String line)
        {
            return line.Substring(index_name_start);
        }

        //Checks the prebuilt authors collection to get the author //I thinks it's faster this way than using get_Author()
        public static string get_Author_byCollection(string line, string previous_author)
        {
            switch (get_message_type(line))
            {
                //if line is normal
                case 0:
                    //omit DateTime
                    line = TrimDateTime(line);
                    int i;
                    for (i = 0; i <= authors.Count(); i++)
                    {
                        if (authors[i].Length <= line.Length && line.Substring(0, authors[i].Length) == authors[i])
                        {
                            return authors[i];
                        }
                    }
                    return "System";
                //if line is newline
                case 1:
                    return previous_author;
                //if line is system
                case 2:
                    return "System";
                default:
                    return "System";
            }
        }

        //uses message type to get message
        public static String get_message(String line, int author_length)
        {
            switch (get_message_type(line))
            {
                case 0:
                    return line.Substring(index_name_start + 2 + author_length);
                case 1:
                    return line;
                case 2:
                    return line.Substring(index_name_start);
                default:
                    return line;
            }
        }

        //get message type (0=normal, with author | 1=newline, belongs to previous line | 2=system message
        public static int get_message_type(String line)
        {
            if (Line_is_newLine(line))
                return 1;
            else
            {
                line = TrimDateTime(line);
                if (Line_is_System(line) == false)
                    return 0;
                else
                    return 2;
            }
        }

        public static void Analysis()
        {

            ;

        }

        //Button Analysis
        private void button1_Click(object sender, EventArgs e)
        {
            initialization();

            int i = 0;

            //fill initial line into array
            string initialauthor = "System";
            DateTime initialdatetime = DateTime.ParseExact("01/01/01", "dd/mm/yy", System.Globalization.CultureInfo.InvariantCulture);

            lines[i] = new Line();
            //set Author
            lines[i].setAuthor(get_Author_byCollection(lines_literal[i], initialauthor));
            //set DateTime
            lines[i].setDateTime(get_DateTime(lines_literal[i], initialdatetime));
            //set Literal
            lines[i].setLiteral(get_message(lines_literal[i], lines[i].getAuthor().Length));

            //Separate every line into words
            string[] split = trimmed_string(lines[i].getLiteral().ToLower()).Split(' ');

            //for every word in the first line do the following
            for (int j = 0; j < split.Count(); j++)
            {
                //Check if word is already contained
                if (words.ContainsKey(split[j]))
                {
                    //if yes, count occurrence up by 1
                    words[split[j]][2] += 1;
                }
                else
                {
                    //if not, assign predefined properties
                    words.Add(split[j], new dynamic[4]);
                    //words[split[j]] = words_properties;

                    words[split[j]][0] = new List<int>();
                    words[split[j]][1] = new List<DateTime>();
                    words[split[j]][2] = 1;
                    words[split[j]][3] = new Dictionary<string, int>();

                    //fill authors
                    foreach (var author in authors)
                    {
                        words[split[j]][3].Add(author, 0);
                    }

                }

                //Those are always added
                //LineID
                words[split[j]][0].Add(i);
                //DateTime
                words[split[j]][1].Add(lines[i].getDateTime());
                //Dictionary authors
                words[split[j]][3][lines[i].getAuthor()] += 1;
            }

            //Outer loop to fill Lines
            for (i = 1; i < lines.Count(); i++)
            {
                lines[i] = new Line();
                //set Author
                lines[i].setAuthor(get_Author_byCollection(lines_literal[i], lines[i - 1].getAuthor()));
                //set DateTime
                lines[i].setDateTime(get_DateTime(lines_literal[i], lines[i - 1].getDateTime()));
                //set Literal
                lines[i].setLiteral(get_message(lines_literal[i], lines[i].getAuthor().Length));

                //Separate every line into words
                split = trimmed_string(lines[i].getLiteral().ToLower()).Split(' ');

                //Inner loop to fill Wurds (that kill, would you speak them to me?)
                for (int j = 0; j < split.Count(); j++)
                {
                    //Check if word is already contained
                    if (words.ContainsKey(split[j]))
                    {
                        //if yes, count occurrence up by 1
                        words[split[j]][2] += 1;
                    }
                    else
                    {
                        //if not, assign predefined properties
                        words.Add(split[j], new dynamic[4]);
                        words[split[j]][0] = new List<int>();
                        words[split[j]][1] = new List<DateTime>();
                        words[split[j]][2] = 1;
                        words[split[j]][3] = new Dictionary<string, int>();

                        //fill authors
                        foreach (var author in authors)
                        {
                            words[split[j]][3].Add(author, 0);
                        }

                    }

                    //Those are always added
                    //LineID
                    words[split[j]][0].Add(i);
                    //DateTime
                    words[split[j]][1].Add(lines[i].getDateTime());
                    //Dictionary authors
                    words[split[j]][3][lines[i].getAuthor()] += 1;
                }

                authors_sum_of_messages[lines[i].getAuthor()]++;

            }

            button1.Hide();

            //fill_namelist();

            //*******************************************************************
            //                                                                  *
            //                                                                  *
            //                 Done with major Loops! Now What?                 *
            //                                                                  *
            //                                                                  *
            //*******************************************************************


            //HOW THE FUCK DO I SORTABLEBINDINGLIST!?


            //lets try to fill a DataGrid

            //
            //Fill DataGridView DG_whole_chat with the whole chat, duh. Easy as that

            BindingList<Line[]> sortablelines = new BindingList<Line[]>();
            //sortablelines.AddNew();
            sortablelines.Add(lines);

            //sortablelines.OrderByDescending(x => x[0].Literal).ToList();

            //DG_whole_chat.DataSource = sortablelines[0];

            DG_whole_chat.DataSource = sortablelines[0].OrderByDescending(x => x.DateTime).ToList();

            //Style of Column 0, DateTime
            DG_whole_chat.Columns[0].Width = 125;
            DG_whole_chat.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            //Style of Column 1, Author
            DG_whole_chat.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            DG_whole_chat.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;

            //Style of Column 2, Message
            DG_whole_chat.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG_whole_chat.Columns[2].Name = "Message";
            DG_whole_chat.Columns[2].ReadOnly = false;
            DG_whole_chat.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;
            //.SortMode = DataGridViewColumnSortMode.Automatic;


            //DG_whole_chat.Bin

            //DG_whole_chat.DataBindingComplete += Sort;



            // DG_whole_chat.Sort(DG_whole_chat.Columns[0], ListSortDirection.Descending);



            progressBar1.Hide();
            //
            //Remove [nothing]
            //
            words.Remove("");
            //
            //count total words
            //
            foreach (var item in words)
            {
                words_count = words_count + words[item.Key][2];
                //count words for every author
                foreach (var author in words[item.Key][3])
                {
                    authors_sum_of_words[author.Key] += words[item.Key][3][author.Key];
                }
            }





            //where to put all this data?
            /*
            //percentages authors words        
            Single[] percent_words = new Single[3];
            percent_words[0] = 100 * Convert.ToSingle(authors_sum_of_words["Keni"]) / Convert.ToSingle(words_count);
            percent_words[1] = 100 * Convert.ToSingle(authors_sum_of_words["Marius Hild"]) / Convert.ToSingle(words_count);
            percent_words[2] = 100 * Convert.ToSingle(authors_sum_of_words["Alex"]) / Convert.ToSingle(words_count);
            
            //percentages authors messages
            Single[] percent_messages = new Single[3];
            percent_messages[0] = 100 * Convert.ToSingle(authors_sum_of_messages["Keni"]) / Convert.ToSingle(lines.Count());
            percent_messages[1] = 100 * Convert.ToSingle(authors_sum_of_messages["Marius Hild"]) / Convert.ToSingle(lines.Count());
            percent_messages[2] = 100 * Convert.ToSingle(authors_sum_of_messages["Alex"]) / Convert.ToSingle(lines.Count());

            //words per message by author
            //sum words / sum messages
            Single[] words_per_message = new Single[3];
            words_per_message[0] = Convert.ToSingle(authors_sum_of_words["Keni"]) / Convert.ToSingle(authors_sum_of_messages["Keni"]);
            words_per_message[1] = Convert.ToSingle(authors_sum_of_words["Marius Hild"]) / Convert.ToSingle(authors_sum_of_messages["Marius Hild"]);
            words_per_message[2] = Convert.ToSingle(authors_sum_of_words["Alex"]) / Convert.ToSingle(authors_sum_of_messages["Alex"]);
            */

            //Create temporary dictionary to sort afterwards
            Dictionary<string, int> words_temp = new Dictionary<string, int>();
            //Create sorted dictionary
            Dictionary<string, int> words_sorted = new Dictionary<string, int>();
            /*
            //fill temporary dict
            foreach (var element in words)
            {
                words_temp.Add(element.Key, words[element.Key][2]);
            }
            */
            /*
            //and sort into words_sorted dictionary
            foreach (KeyValuePair<string, int> item in words_temp.OrderByDescending(key => key.Value))
            {
                words_sorted.Add(item.Key, item.Value);
            }
            */

            //
            //Fill DataGridView DG_words with words + sum
            //

            // DG_words.Column


            add_author_columns_to_DG_words(authors);
            fill_author_columns_of_DG_words(words);

            DG_words.Sort(DG_words.Columns[1], ListSortDirection.Descending);


            Dictionary<string, int> pie_data = new Dictionary<string, int>();
            pie_data.Add(DG_words.Rows[0].Cells[0].Value.ToString(), Convert.ToInt32(DG_words.Rows[0].Cells[1].Value));
            pie_data.Add(DG_words.Rows[1].Cells[0].Value.ToString(), Convert.ToInt32(DG_words.Rows[1].Cells[1].Value));
            pie_data.Add(DG_words.Rows[2].Cells[0].Value.ToString(), Convert.ToInt32(DG_words.Rows[2].Cells[1].Value));
            pie_data.Add(DG_words.Rows[3].Cells[0].Value.ToString(), Convert.ToInt32(DG_words.Rows[3].Cells[1].Value));
            pie_data.Add(DG_words.Rows[4].Cells[0].Value.ToString(), Convert.ToInt32(DG_words.Rows[4].Cells[1].Value));

            Chart_Words.DataSource = pie_data;
            Chart_Words.Visible = true;
            //Chart_Words.Series.Add()
        }



        public int get_author_count(Collection<string> authors)
        {
            int i = 0;
            foreach (var author in authors)
            {
                i++;
            }
            return i;
        }

        public void fill_author_columns_of_DG_words(Dictionary<string, dynamic[]> words)
        {
            //create a row to populate DG_word
            DataGridViewRow row = new DataGridViewRow();

            //for every word in words
            foreach (var word in words.Keys)
            {
                row = DG_words.Rows[DG_words.Rows.Add()];

                //name column1 to assign a value
                DG_words.Columns[0].Name = "Word";
                row.Cells["Word"].Value = word;
                //name column2 to assign a value
                DG_words.Columns[1].Name = "Sum";
                row.Cells["Sum"].Value = words[word][2];

                int i = 2;

                progressBar2.Minimum = 0;
                progressBar2.Maximum = words.Count();

                //for every author in a word
                foreach (var author_dict in words[word][3])
                {
                    //name column x to assign a value
                    DG_words.Columns[i].Name = author_dict.Key;
                    row.Cells[author_dict.Key].Value = words[word][3][author_dict.Key];
                    i++;
                }

                progressBar2.Increment(1);

            }
            progressBar2.Hide();
        }

        //get all authors and populate DG_words with all authors, in order to fill it with values
        public void add_author_columns_to_DG_words(Collection<string> authors)
        {
            foreach (var author in authors)
            {
                DataGridViewColumn temporary_author_col = new DataGridViewColumn();
                DataGridViewCell temporary_cell = new DataGridViewTextBoxCell();
                
                temporary_author_col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
                temporary_author_col.HeaderText = author;
                temporary_author_col.Name = "DG_words_col_" + author;
                temporary_author_col.ReadOnly = false;
                temporary_author_col.SortMode = DataGridViewColumnSortMode.Automatic;
                temporary_author_col.Width = 50;
                temporary_author_col.CellTemplate = temporary_cell;

                if(author == "System")
                temporary_author_col.Visible = false;

                DG_words.Columns.Add(temporary_author_col);
            }
        }

        /*
        //Fill ListBox with authors
        public void fill_listbox_with_authors (Line[] lines, ListBox lb)
        {
            String[] list = new string[lines.Count()];

            for (int i = 0; i < lines.Count(); i++)
            {
                list[i] = lines[i].getAuthor();
            }

            lb.Items.AddRange(list);

        }

        //Fill ListBox with literal messages
        public void fill_listbox_with_messages(Line[] lines, ListBox lb)
        {
            String[] list = new string[lines.Count()];

            for (int i = 0; i < lines.Count(); i++)
            {
                list[i] = lines[i].getLiteral();
            }

            lb.Items.AddRange(list);
        }

        //Fill ListBox with DateTime
        public void fill_listbox_with_datetime(Line[] lines, ListBox lb)
        {
            String[] list = new string[lines.Count()];

            for (int i = 0; i < lines.Count(); i++)
            {
                list[i] = lines[i].getDateTime().ToString();
            }

            lb.Items.AddRange(list);
        }
        */
        //Check all authors
        /*
        private void button3_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }
        */
        //Uses LineID to output a message
        public ListViewItem get_Message(int i)
        {
            return new ListViewItem(new[] { lines[i].getDateTime().ToString(), lines[i].getAuthor(), lines[i].getLiteral() }); ;
        }


        /*When selection changes, update listview3, bottom one
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                //assign currently selected word to s
                string s;
                s = listView1.SelectedItems[0].Text;


                //assign limit via index count
                int lim = words[s][0].Count;

                //list of LineIDs
                List<int> list = words[s][0];

                //clear all items
                listView3.Items.Clear();

                //fill listview3 by using lineIDs
                foreach (var item in list)
                {
                    listView3.Items.Add(get_Message(item));
                }
            }
        }
        */
        
        /*When clicking an item, jump to the part in the big list
        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                //assign selection to s
                string s = listView3.SelectedItems[0].SubItems[2].Text;
                int i = 0;

                foreach (var item in lines)
                {
                    if (item.getLiteral() == s)
                    {
                        break;
                    }
                    i++;
                }
                //jump to selected message
                //listView2.Items[i].EnsureVisible();
                //listView2.Items[i].Selected = true;

                //DG_whole_chat.ScrollIntoView
            }
        }
        */

        private void DG_whole_chat_SelectionChanged(object sender, EventArgs e)
        {
            this.DG_whole_chat.ClearSelection();
        }

        private void split_DG_whole_chat_DG_words_MouseDown(object sender, MouseEventArgs e)
        {
            // This disables the normal move behavior
            ((SplitContainer)sender).IsSplitterFixed = true;
        }

        private void split_DG_whole_chat_DG_words_MouseUp(object sender, MouseEventArgs e)
        {
            // This allows the splitter to be moved normally again
            ((SplitContainer)sender).IsSplitterFixed = false;
        }

        private void split_DG_whole_chat_DG_words_MouseMove(object sender, MouseEventArgs e)
        {
            // Check to make sure the splitter won't be updated by the
            // normal move behavior also
            if (((SplitContainer)sender).IsSplitterFixed)
            {
                // Make sure that the button used to move the splitter
                // is the left mouse button
                if (e.Button.Equals(MouseButtons.Left))
                {
                    // Checks to see if the splitter is aligned Vertically
                    if (((SplitContainer)sender).Orientation.Equals(Orientation.Vertical))
                    {
                        // Only move the splitter if the mouse is within
                        // the appropriate bounds
                        if (e.X > 0 && e.X < ((SplitContainer)sender).Width)
                        {
                            // Move the splitter & force a visual refresh
                            ((SplitContainer)sender).SplitterDistance = e.X;
                            ((SplitContainer)sender).Refresh();
                        }
                    }
                    // If it isn't aligned vertically then it must be
                    // horizontal
                    else
                    {
                        // Only move the splitter if the mouse is within
                        // the appropriate bounds
                        if (e.Y > 0 && e.Y < ((SplitContainer)sender).Height)
                        {
                            // Move the splitter & force a visual refresh
                            ((SplitContainer)sender).SplitterDistance = e.Y;
                            ((SplitContainer)sender).Refresh();
                        }
                    }
                }
                // If a button other than left is pressed or no button
                // at all
                else
                {
                    // This allows the splitter to be moved normally again
                    ((SplitContainer)sender).IsSplitterFixed = false;
                }
            }
        }

        //This function reads the selected line to get LineID of the selected word
        //LineID will be used to filter a DataGridView showing all Messages containing
        //this word or LineID
        private void DG_words_SelectionChanged(object sender, EventArgs e)
        {
            //selected word
            string word = "";
            try
            {
                word = DG_words.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch { }
            //DG_whole_chat_filteredByWord.Sort
        }
    }
}
