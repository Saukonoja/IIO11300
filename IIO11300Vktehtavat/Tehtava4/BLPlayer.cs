using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JAMK.IT.IIO11300 {
    class BLPlayer {

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
        #endregion

        #region Constructors
        public BLPlayer() { }
        public BLPlayer(string fname, string lname, int price, string team) {
            this.fname = fname;
            this.lname = lname;
            this.price = price;
            this.team = team;
        }
        #endregion

        #region Methods
        public static void SaveToFile(List<BLPlayer> players) {
            try {
                StreamWriter sw;
                //tarkastetaan onko tiedosto jo olemassa
                if (File.Exists(filename)) {
                    //liitetään olemassa olevaan tiedostoon
                    sw = File.AppendText(filename);
                } else {
                    //luodaan uusi
                    sw = File.CreateText(filename);
                }
                //kirjoitus
                foreach (var item in players) {
                    sw.WriteLine(item);
                }
                sw.Close();
            } catch (Exception ex) {

                throw ex;
            }
        }
        #endregion

    }
}
