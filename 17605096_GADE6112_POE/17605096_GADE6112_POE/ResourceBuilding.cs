using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _17605096_GADE6112_POE
{
    class ResourceBuilding : Building
    {
        Map map;
        Unit un;
        FactoryBuilding fb;
        public bool IsDead { get; set; }

        public int Xpos
        {
            get { return base.xpos; }
            set { base.xpos = value; }
        }
        public int Ypos
        {
            get { return base.ypos; }
            set { base.ypos = value; }
        }
        public int Health
        {
            get { return base.health; }
            set { base.health = value; }
        }
        public int Faction
        {
            get { return base.faction; }
            set { base.faction = value; }
        }
        public string Symbol
        {
            get { return base.symbol; }
            set { base.symbol = value; }
        }
        public int MaxHealth
        {
            get { return base.maxHealth; }
        }

        private string ResType;     //Resource Type (Gold, Silver, etc)
        private int ResGen;         //Resources Generated Number
        private int ResPR;          //Resources Per Round
        private int ResRem;         //Resources Remaining

        public ResourceBuilding(int x, int y, int h, int f, string symb)
        {
            Xpos = x;
            Ypos = y;
            Health = h;
            Faction = f;
            Symbol = symb;
        }
        public void ResGenerate()
        {
            ResGen += ResPR;
            ResRem -= ResPR;

            while(ResRem>=0)
            {
                fb.UnitProduce(5);
            }
        }
        public override void Death()
        {
            symbol = "X";
            IsDead = true;
        }
        public override string ToString()
        {
            string temp = "";
            temp += "Building: ";
            temp += "{" + Symbol + "}";
            temp += " " + ResType + " ";
            temp += " " + ResRem + " ";
            temp += "(" + Xpos + ")";
            temp += Health;
            temp += (IsDead ? "Destroyed" : "Active");
            return temp;
        }
        public override void Save()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fout = new FileStream("Save.dat", FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                using (fout)
                {
                    bf.Serialize(fout, map);
                    MessageBox.Show("Info Saved");
                }
            }
            catch (FileNotFoundException exc)
            {
                MessageBox.Show("Error Occured " + exc.Message);
            }
        }

        public override void Combat(Unit other)
        {
            if(other is MeleeUnit)
            {
                Health = Health - ((MeleeUnit)other).Attack;
            }
            else if(other is RangedUnit)
            {
                RangedUnit ru = (RangedUnit)other;
                Health = Health - (ru.Attack-ru.Attackrange);
            }
            if(Health <= 0)
            {
                Death();
            }
        }
        public override (Unit, int) Closest(List<Unit> units)
        {
            int shortest = 100;
            Unit closest = (Unit)un;
            foreach (Unit u in units)
            {
                if (u is MeleeUnit && u != un)
                {
                    MeleeUnit otherMU = (MeleeUnit)u;
                    int distance = Math.Abs(this.Xpos - otherMU.Xpos) + Math.Abs(this.Ypos = otherMU.Ypos);
                    if (distance < shortest)
                    {
                        shortest = distance; ;
                        closest = otherMU;
                    }
                }
                else if (u is RangedUnit && u != un)
                {

                    RangedUnit otherRU = (RangedUnit)u;
                    int distance = Math.Abs(this.Xpos - otherRU.Xpos) + Math.Abs(this.Ypos - otherRU.Ypos);

                    if (distance < shortest)
                    {
                        shortest = distance;
                        closest = otherRU;
                    }
                }
            }
            return (closest, shortest);
        }
    }
}
