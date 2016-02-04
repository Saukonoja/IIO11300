using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JAMK.IT.IIO11300 {
    public class MittausData {
        #region PROPERTIES
        private string kello;
        public string Kello {
            get { return kello; }
            set { kello = value; }
        }
        private string mittaus;

        public string Mittaus {
            get { return mittaus; }
            set { mittaus = value; }
        }
        #endregion
        #region CONSTRUCTORS
        //luokalle tehdään kaksi konstruktoria
        public MittausData() {
            kello = "0:00";
            mittaus = "empty";
        }
        public MittausData(string klo, string mdata) {
            this.kello = klo;
            this.mittaus = mdata;
        }
        #endregion
        #region METHODS
        //ylikirjoitetaan ToString
        public override string ToString() {
            //return base.ToString();
            return kello + "=" + mittaus;
        }
        public static void SaveToFile(string filename, List<MittausData> datat) {
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
                foreach (var item in datat) {
                    sw.WriteLine(item);
                }
                sw.Close();
            }
            catch (Exception ex) {

                throw ex;
            }
        }
        public static List<MittausData> ReadFromFile(string filename) {
            try {
                if (File.Exists(filename)) {
                    //luetaan tekstiteidosto ja muutetaan se MittausData-olioksi
                    MittausData md;
                    List<MittausData> luetut = new List<MittausData>();
                    string rivi = "";
                    StreamReader sr = File.OpenText(filename);
                    while ((rivi = sr.ReadLine()) != null) {
                        if (rivi.Length > 3 && rivi.Contains("=")) {
                            string[] split = rivi.Split(new char[] { '=' });
                            //alimerkkijonoista luodaan olio
                            md = new MittausData(split[0], split[1]);
                            luetut.Add(md);
                        }
                    }
                    //palautetaan muuttuja
                    return luetut;
                }
               else {
                    throw new FileNotFoundException();
                }
               

            } catch(Exception ex) {
                throw ex;
            }
        }
    }
	
    #endregion
}
