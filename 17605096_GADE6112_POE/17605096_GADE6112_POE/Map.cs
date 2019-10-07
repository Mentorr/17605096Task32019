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
    [Serializable]
    public class Map
    {
        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }


        List<Unit> units;
        Random r = new Random();
        int numUnits = 0;
        int numBuildings = 0;
        TextBox txtInfo;
        FactoryBuilding fb;
        Map map;

        public List<Unit> Units
        {
            get { return units; }
            set { units = value; }
        }
        List<Building> buildings;
        public List<Building> Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }

        public Map(int n, int bu, TextBox txt)
        {
            units = new List<Unit>();
            buildings = new List<Building>();
            numUnits = n;
            numBuildings = bu;
            txtInfo = txt;
        }

        public void Generate()
        {
           // int rng = r.Next(0, 2);
            for (int i = 0; i < numUnits; i++)
            {
                if (r.Next(0, 2) == 0)
                {
                    MeleeUnit m = new MeleeUnit(r.Next(0, 20),
                                                r.Next(0, 20),
                                                100,
                                                1,
                                                20,
                                                (i % 2 == 0 ? 1 : 0),
                                                "M", "Grunt");
                    units.Add(m);
                }
                else if(r.Next(0,2) == 1)
                {
                    RangedUnit ru = new RangedUnit(r.Next(0, 20),
                                                r.Next(0, 20),
                                                100,
                                                1,
                                                20,
                                                5,
                                                (i % 2 == 0 ? 1 : 0),
                                                "R", "Archer");
                    units.Add(ru);
                }
                else
                {
                    WizardUnit wu = new WizardUnit(r.Next(0, 20),
                                                   r.Next(0, 20),
                                                   100,
                                                   1,
                                                   20,
                                                   10,
                                                   (i % 2 == 0 ? 1 : 0),
                                                   "W", "Wizard");
                    units.Add(wu);
                }
            }
            for (int i = 0; i < numBuildings; i++)
            {
                if(r.Next(0,2) == 0)
                {                    
                     FactoryBuilding fb = new FactoryBuilding(r.Next(0, 20),
                                                              r.Next(0, 20),
                                                              200,
                                                              r.Next(0, 2),
                                                              "F");
                     buildings.Add(fb);                    
                }
                else
                {
                    ResourceBuilding rb = new ResourceBuilding(r.Next(0, 20),
                                                               r.Next(0, 20),
                                                               200,
                                                               r.Next(0, 2),
                                                               "RB");
                    buildings.Add(rb);
                }
            }    
        }

        public void Display(GroupBox groupBox, int x,int y)     //int x and y are to determine size of grid
        {
            groupBox.Controls.Clear(); 
            groupBox.Size = new Size(x,y);
            foreach (Unit u in units)
            {
                Button b = new Button();
                if (u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    b.Size = new Size(20, 20);
                    b.Location = new Point(mu.Xpos * 20, mu.Ypos * 20);
                    b.Text = mu.Symbol;
                    if (mu.Faction == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Green;
                    }
                }                                                                   //MeleeUnit's spawn/display
                else if (u is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)u;
                    b.Size = new Size(20, 20);
                    b.Location = new Point(ru.Xpos * 20, ru.Ypos * 20);
                    b.Text = ru.Symbol;
                    if (ru.Faction == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Green;
                    }
                }                                                                   //RangedUnit's spawn/display
                else if(u is WizardUnit)
                {
                    WizardUnit wu = (WizardUnit)u;
                    b.Size = new Size(20, 20);
                    b.Location = new Point(wu.Xpos * 20, wu.Ypos * 20);
                    b.Text = wu.Symbol;
                    if(wu.Faction == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else if(wu.Faction == 1)
                    {
                        b.ForeColor = Color.Green;                          //wizards can belong on both teams as well as an independent team (as the brief didn't say it had to be only an independent team)
                    }
                    else if(wu.Faction == 2)
                    {
                        b.ForeColor = Color.Aqua;                           //3rd team. Highly unlikely to spawn however unless max units on load is increased
                    }
                    
                    
                }
                b.Click += Unit_Click;
                groupBox.Controls.Add(b);
            }
            foreach(Building bu in buildings)
            {
                Button b = new Button();
                if(bu is FactoryBuilding)
                {
                    FactoryBuilding fb = (FactoryBuilding)bu;
                    b.Size = new Size(40, 40);
                    b.Location = new Point(fb.Xpos * 40, fb.Ypos * 40);
                    b.Text = fb.Symbol;
                    if(fb.Faction == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Green;
                    }

                }
                b.Click += Building_Click;
                groupBox.Controls.Add(b);
                groupBox.Controls.Add(b); groupBox.Controls.Add(b); groupBox.Controls.Add(b);
            }                                                               //all buildings spawn
        }

        public void Unit_Click(object sender, EventArgs e)
        {
            int x, y;
            Button b = (Button)sender;
            x = b.Location.X / 20;
            y = b.Location.Y / 20;
            foreach (Unit u in units)
            {
                
                if (u is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)u;
                    if (ru.Xpos == x && ru.Ypos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = ru.ToString();
                    }
                }
                else if (u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    if (mu.Xpos == x && mu.Ypos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = mu.ToString();
                    }
                }
                else if (u is WizardUnit)
                {
                    WizardUnit wu = (WizardUnit)u;
                    if (wu.Xpos == x && wu.Ypos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = wu.ToString();
                    }
                }
            }
            foreach(Building bu in buildings)
            {
                if(bu is FactoryBuilding)
                {
                    FactoryBuilding fb = (FactoryBuilding)bu;
                    if(fb.Xpos == x && fb.Ypos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = fb.ToString();
                    }
                }
                else if(bu is ResourceBuilding)
                {
                    ResourceBuilding rb = (ResourceBuilding)bu;
                    if(rb.Xpos == x && rb.Ypos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = rb.ToString();
                    }                                                           //when a building is clicked, ToString is called
                }
            }
        }
        public void Building_Click(object sender, EventArgs e)
        {
            int x, y;
            Button b = (Button)sender;
            x = b.Location.X / 20;
            y = b.Location.Y / 20;
            foreach(Building bu in buildings)
            {
                if(bu is FactoryBuilding)
                {
                    FactoryBuilding fb = (FactoryBuilding)bu;
                    if (fb.Xpos == x && fb.Ypos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = fb.ToString();
                    }
                }
                else if (bu is ResourceBuilding)
                {
                    ResourceBuilding rb = (ResourceBuilding)bu;
                    if (rb.Xpos == x && rb.Ypos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = rb.ToString();
                    }                                                           //when a building is clicked, ToString is called
                }
            }
        }
        public void Save()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fout = new FileStream("Save.dat", FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                using (fout)
                {
                    bf.Serialize(fout, map);                                                                        //save method for saving objects to file
                    MessageBox.Show("Info Saved");
                }
            }
            catch (FileNotFoundException exc)
            {
                MessageBox.Show("Error Occured " + exc.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Error Occured " + ex.Message);                                                     //if it cannot be saved, throw an error instead of crashing
            }
        }
    }
}

