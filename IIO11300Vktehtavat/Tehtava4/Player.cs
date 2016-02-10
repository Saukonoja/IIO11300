using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JAMK.IT.IIO11300 {
    class Player {

        #region Variables
        private string fname;
        private string lname;
        private int price;
        private string team;
        #endregion

        #region Properties
        public string Fname {
            get { return fname;}
            set { fname = value;}
        }
        public string Lname {
            get { return lname; }
            set { lname = value; }
        }
        public int Price {
            get { return price; }
            set { price = value; }
        }
        public string Team {
            get { return team; }
            set { team = value; }
        }
        public string Fullname {
            get { return (fname + " " + lname); }
        }
        public string Showname {
            get { return (Fullname + ", " + team); }
        }
        #endregion

        #region Constructors
        public Player() { }
        public Player(string fname, string lname, int price, string team) {
            this.fname = fname;
            this.lname = lname;
            this.price = price;
            this.team = team;
        }
        #endregion

        #region Methods
        public static void SaveToFile(List<Player> players) {
            try {
                Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
                dialog.FileName = "Players";
                dialog.DefaultExt = ".txt";
                dialog.Filter = "Text documents (.txt)|*.txt";

                Nullable<bool> result = dialog.ShowDialog();
                if (result == true) {
                    StreamWriter sw = File.AppendText(dialog.FileName);
                    foreach(var player in players) {
                        sw.WriteLine(player);
                    }
                    sw.Close();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public override string ToString() {
            return Showname;
        }
        #endregion

    }
}
