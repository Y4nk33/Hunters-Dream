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
using System.Threading;

namespace Forms_Wurds
{
    public partial class Form1 : Form
    {
        //Global Variables

        //DateTime Format
        static string DateTime_Format = "dd/MM/yyyy, HH:mm:ss";
        //Used in DG_whole_chat
        SortableBindingList<Line[]> sortablelines = new SortableBindingList<Line[]>();
        //Name der zu lesenden Datei
        static string path = Txt_Lesen("mary");
        //Ab Wann der Name beginnt
        static int index_name_start = 22;
        //Length of DateTime
        static int datetime_length = 20;
        //all lines
        static string[] lines_literal = File.ReadAllLines(path);
        //NEW, all words
        static Dictionary<string, Word> Wurds = new Dictionary<string, Word>();
        //all lines
        Line[] lines = new Line[File.ReadAllLines(path).Count()];
        //all authors
        static Collection<string> authors = new Collection<string>();

        public Form1()
        {
            InitializeComponent();
        }

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
            if (line.Length >= 12 && line[2] == '/' && line[5] == '/' && line[10] == ',')
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
                return DateTime.ParseExact(line.Substring(0, datetime_length), DateTime_Format, System.Globalization.CultureInfo.InvariantCulture);
            else
                return previous_datetime;
        }

        //Find all authors in a file
        public void set_allAuthors()
        {
            string author = "";
            for (int i = 0; i < lines_literal.Count(); i++)
            {
                author = get_Author(lines_literal[i], "");

                if (authors.Contains(author) == false && author != "")
                {
                    authors.Add(author);
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

        //Word trimmed of Blacklisted characters
        public static string trimmed_string(string word)
        {
            //chars to trim
            char[] charstotrim = { '\\', '/', '!', '?', '"', '.', '[', ']', ',', '(', ')', ':', '-', '*'};

            //is word a number?
            if (Regex.IsMatch(word, @"^\d+$"))
                return "";

            //trim emoji
            word = Regex.Replace(word, @"\p{Cs}", "");
            
            //trim images, videos
            word = word.Replace("<image", "");
            word = word.Replace("<video", "");
            word = word.Replace("<audio", "");
            word = word.Replace("omitted>", "");

            //trim chars
            foreach (char item in charstotrim)
            {
                word = word.Replace(item.ToString(), "");
            }

            return word;
        }

        //Gets rid of the DateTime
        public static String TrimDateTime(String line)
        {
            return line.Substring(index_name_start);
        }

        //Checks the prebuilt authors collection to get the author //I think it's faster this way than using get_Author()
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

        public void Dissect_Chat()
        {
            //  1 Loop = 1 Line 
            for (int i = 0; i < lines.Count(); i++)
            {
                lines[i] = new Line();
                string current_author = "System";

                //If first Line
                if (i == 0)
                {
                    //fill initial line into array
                    string initialauthor = "System";
                    DateTime initialdatetime = DateTime.ParseExact("01/01/01", "dd/mm/yy", System.Globalization.CultureInfo.InvariantCulture);

                    //set Author
                    current_author = get_Author_byCollection(lines_literal[i], initialauthor);
                    lines[i].setAuthor(current_author);
                    //set DateTime
                    lines[i].setDateTime(get_DateTime(lines_literal[i], initialdatetime));
                }
                //not first line...
                else
                {
                    //set Author
                    current_author = get_Author_byCollection(lines_literal[i], lines[i - 1].getAuthor());
                    lines[i].setAuthor(current_author);
                    //set DateTime
                    lines[i].setDateTime(get_DateTime(lines_literal[i], lines[i - 1].getDateTime()));
                }

                //set Literal
                lines[i].setLiteral(get_message(lines_literal[i], lines[i].getAuthor().Length));
                //Separate every line into array of words
                string[] split = trimmed_string(lines[i].getLiteral().ToLower()).Split(' ');



                //
                //
                //  Inner loop to fill Wurds (that kill, would you speak them to me?)
                //  "for every word, do this..."
                //  1 Loop = 1 Word
                //
                for (int j = 0; j < split.Count(); j++)
                {
                    //Current treated word
                    string current_word = split[j];

                    //Check if word is NOT already contained
                    if (!Wurds.Keys.Contains(current_word))
                    {
                        //Add it then
                        Wurds.Add(current_word, new Word(authors));
                    }
                    //in any case, do the following
                    //
                    //add lineKEY
                    Wurds[current_word].add_lineKEY(i);
                    //
                    //add author occurrence
                    Wurds[current_word].add_author_occurrence(current_author);
                }
            }
            Wurds.Remove("");
        }

        public static Dictionary<string, int> Fill_Author_Dictionary(Collection<string> Authors)
        {
            Dictionary<string, int> Total_Occurrence_per_Author = new Dictionary<string, int>();

            foreach (string Author in Authors)
            {
                Total_Occurrence_per_Author.Add(Author, 0);
            }

            return Total_Occurrence_per_Author;
        }

        public void Fill_DG_whole_chat()
        {
            //Content of Whole Chat
            sortablelines.Add(lines);
            DG_whole_chat.DataSource = sortablelines[0].OrderBy(x => x.getDateTime()).ToList();

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

        }

        private void Analysis(Dictionary<string, Word> words)
        {
            Dictionary<string, int> Total_Occurrence_per_Author = new Dictionary<string, int>(Fill_Author_Dictionary(authors));

            //Count of every unique used word
            int Total_unique_Word_Count = 0;
            //Count of total words
            int Total_Word_Count = 0;

            //Loops through words to fill various variables
            foreach (string word in words.Keys)
            {
                Total_unique_Word_Count++;
                foreach (string author in words[word].get_author_occurrence().Keys)
                {
                    Total_Occurrence_per_Author[author] += words[word].get_author_occurrence()[author];
                    Total_Word_Count += words[word].get_author_occurrence()[author];
                }
            }

            Total_Word_Count -= Total_Occurrence_per_Author["System"];
            Total_Occurrence_per_Author.Remove("System");
            Total_Occurrence_per_Author.Remove("");

            fill_Chart_Words(Total_Occurrence_per_Author, Total_Word_Count);












            //DG_whole_chat.Bin

            //DG_whole_chat.DataBindingComplete += Sort;



            // DG_whole_chat.Sort(DG_whole_chat.Columns[0], ListSortDirection.Descending);
            //
            //Remove [nothing]
            //

            //
            //count total words
            //
            /*
            foreach (var item in words)
            {
                words_count = words_count + words[item.Key][2];
                //count words for every author
                foreach (var author in words[item.Key][3])
                {
                    authors_sum_of_words[author.Key] += words[item.Key][3][author.Key];
                }
            }
            */



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


            Chart_Words.Visible = true;
            //Chart_Words.Series.Add()

            //Task task = new Task(fill_author_columns_of_DG_words);


            //fill_author_columns_of_DG_words(Wurds);


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

       void fill_author_columns_of_DG_words(Dictionary<string, Word> words)
       {
            add_author_columns_to_DG_words(authors);

            DataGridViewRow row = new DataGridViewRow();

            int i = 2;

            //name column1 to assign a value
            DG_words.Columns[0].Name = "Word";
            //name column2 to assign a value
            DG_words.Columns[1].Name = "Sum";

            //counter to sort midway through
            int counter = 1;

            //for every word in words //for loop represents one row-fill
            foreach (var word in words.Keys)
            {
                DG_words.Invoke(new MethodInvoker(delegate{
                    row = DG_words.Rows[DG_words.Rows.Add()];
                }));

                DG_words.Invoke(new MethodInvoker(delegate {
                    row.Cells["Word"].Value = word;
                }));
                row.Cells["Sum"].Value = words[word].get_totaloccurrences();

                i = 2;
                //for every author in a word
                foreach (var author_dict in words[word].get_author_occurrence())
                {
                    //name column x to assign a value
                    DG_words.Invoke(new MethodInvoker(delegate {
                        DG_words.Columns[i].Name = author_dict.Key;
                    }));
                    row.Cells[author_dict.Key].Value = words[word].get_author_occurrence()[author_dict.Key];
                    i++;
                }

                counter++; 
                //temporarily sort
                if(counter == 50)
                DG_words.Invoke(new MethodInvoker(delegate {
                    DG_words.Sort(DG_words.Columns[1], ListSortDirection.Descending);
                }));
            }
            //finally sort
            DG_words.Invoke(new MethodInvoker(delegate {
                DG_words.Sort(DG_words.Columns[1], ListSortDirection.Descending);
            }));
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

                DG_words.Invoke(new MethodInvoker(delegate {
                    DG_words.Columns.Add(temporary_author_col);
                }));
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
        public void Update_DG_whole_chat_filteredByWord()
        {
            try
            {
                //assign word
                string word = DG_words.SelectedRows[0].Cells[0].Value.ToString();
                //clear all rows
                DG_whole_chat_filteredByWord.Invoke(new MethodInvoker(delegate {
                    DG_whole_chat_filteredByWord.Rows.Clear();
                }));
                //get all LineIDs
                List<int> lineKEYs = new List<int>(Wurds[word].get_lineKEY());
                foreach (int i in lineKEYs)
                {
                    DG_whole_chat_filteredByWord.Invoke(new MethodInvoker(delegate {
                        DataGridViewRow row = DG_whole_chat_filteredByWord.Rows[DG_whole_chat_filteredByWord.Rows.Add()];
                        row.Cells[0].Value = lines[i].getDateTime();
                        row.Cells[1].Value = lines[i].getAuthor();
                        row.Cells[2].Value = lines[i].getLiteral();
                        row.Cells[3].Value = i;
                    }));
                }
                DG_whole_chat_filteredByWord.ClearSelection();
            }

            catch { }
        }


        private void DG_words_SelectionChanged(object sender, EventArgs e)
        {
            Task.Factory.StartNew(Update_DG_whole_chat_filteredByWord, TaskCreationOptions.LongRunning);
        }

        //Uses the selected header to perform a reorder
        private void DG_whole_chat_Reorder(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.ColumnIndex;
            if(i==0)
            DG_whole_chat.DataSource = sortablelines[0].OrderBy(x => x.getDateTime()).ToList();

            if (i == 1)
            DG_whole_chat.DataSource = sortablelines[0].OrderBy(x => x.getAuthor()).ToList();

            if (i == 2)
            DG_whole_chat.DataSource = sortablelines[0].OrderBy(x => x.getLiteral()).ToList();
        }

        //Uses the selected header to perform a reorder, but descending!
        private void DG_whole_chat_ReorderDescending(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.ColumnIndex;
            if (i == 0)
            DG_whole_chat.DataSource = sortablelines[0].OrderByDescending(x => x.getDateTime()).ToList();

            if (i == 1)
            DG_whole_chat.DataSource = sortablelines[0].OrderByDescending(x => x.getAuthor()).ToList();

            if (i == 2)
            DG_whole_chat.DataSource = sortablelines[0].OrderByDescending(x => x.getLiteral()).ToList();
        }

        public void fill_Chart_Words(Dictionary<string, int> Total_Occurrence_per_Author, int Total_Word_Count)
        {
            //Chart_Words.Series.Add("Series");
            foreach (string author in Total_Occurrence_per_Author.Keys)
            {
                double percent = Math.Round(100 * Convert.ToSingle(Total_Occurrence_per_Author[author] / Convert.ToSingle(Total_Word_Count)), 2);
                DataPoint Temp_DataPoint = new DataPoint();
                Temp_DataPoint.AxisLabel = author + "\n"+percent.ToString() + "%";
                Temp_DataPoint.YValues = new double[] { Total_Occurrence_per_Author[author] };
                Chart_Words.Series["Series1"].Points.Add(Temp_DataPoint);
            }

            /*
            DataPoint dp2 = new DataPoint();
            dp2.AxisLabel = "Test2";
            dp2.YValues = new double[] { 55 };

            Chart_Words.Series.Add("SeriesTest");
            Chart_Words.Series["SeriesTest"].ChartType = SeriesChartType.Pie;
            Chart_Words.Series["SeriesTest"].Points.Add(dp1);
            Chart_Words.Series["SeriesTest"].Points.Add(dp2);
            //Chart_Words.Series["SeriesTest"].Points.AddY(50);
            Chart_Words.Series["SeriesTest"].ChartArea = "ChartArea1";
            */
        }

        //This is executed when the form is done loading
        private void Form_done_loading(object sender, EventArgs e)
        {
            //MessageBox.Show("form done loading");
            set_allAuthors();

            //Chop it apart and fill it into Word
            Dissect_Chat();

            //Loops through words to fill various variables
            Analysis(Wurds);

            Fill_DG_whole_chat();

            Task.Factory.StartNew(() => fill_author_columns_of_DG_words(Wurds), TaskCreationOptions.LongRunning);
        }

        private void DG_whole_chat_filteredByWord_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(DG_whole_chat_filteredByWord.SelectedRows[0].Cells[3].Value);
                DG_whole_chat.FirstDisplayedScrollingRowIndex = i;
                //DG_whole_chat.Rows[i].Selected = true;
            }
            catch { }
        }
    }
}
