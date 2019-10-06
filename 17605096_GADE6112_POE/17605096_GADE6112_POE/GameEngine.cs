using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _17605096_GADE6112_POE
{
    [Serializable]
    class GameEngine
    {
        int x;
        int y;
        Map map;
        private int roundnum;
        Random r = new Random();
        GroupBox GBMap;
        FactoryBuilding fb;

        public int RoundNum
        {
            get { return roundnum; }
        }

        public GameEngine(int numUnits, int numBuildings, TextBox txtInfo, GroupBox GMap, int x, int y)
        {
            GBMap = GMap;
            map = new Map(numUnits, numBuildings, txtInfo);
            map.Generate();
            map.Display(GBMap, x, y);
            roundnum = 1;
        }
        public void Update(int x, int y, int temp)
        {
            for (int i = 0; i < map.Units.Count; i++)
            {
                if (map.Units[i] is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)map.Units[i];
                    if (mu.Health <= mu.MaxHealth * 0.25)
                    {
                        mu.Move(r.Next(0, 4));
                    }
                    else
                    {
                        (Unit closest, int distanceTo) = mu.Closest(map.Units);

                        if (distanceTo <= mu.Attackrange)
                        {
                            mu.IsAttacking = true;
                            mu.Combat(closest);
                        }
                        else
                        {
                            if (closest is MeleeUnit)
                            {
                                MeleeUnit closestMu = (MeleeUnit)closest;
                                if (mu.Xpos > closestMu.Xpos) 
                                {
                                    mu.Move(0);
                                }
                                else if (mu.Xpos < closestMu.Xpos) 
                                {
                                    mu.Move(2);
                                }
                                else if (mu.Ypos > closestMu.Ypos) 
                                {
                                    mu.Move(3);
                                }
                                else if (mu.Ypos < closestMu.Ypos)
                                {
                                    mu.Move(1);
                                }
                            }
                            else if (closest is RangedUnit)
                            {
                                RangedUnit closestRu = (RangedUnit)closest;
                                if (mu.Xpos > closestRu.Xpos) 
                                {
                                    mu.Move(0);
                                }
                                else if (mu.Xpos < closestRu.Xpos) 
                                {
                                    mu.Move(2);
                                }
                                else if (mu.Ypos > closestRu.Ypos)
                                {
                                    mu.Move(3);
                                }
                                else if (mu.Ypos < closestRu.Ypos)
                                {
                                    mu.Move(1);
                                }
                            }
                            else if(closest is WizardUnit)
                            {
                                WizardUnit closestwu = (WizardUnit)closest;
                                if(mu.Xpos > closestwu.Xpos)
                                {
                                    mu.Move(0);
                                }
                                else if(mu.Xpos < closestwu.Xpos)
                                {
                                    mu.Move(2);
                                }
                                else if(mu.Ypos > closestwu.Ypos)
                                {
                                    mu.Move(3);
                                }
                                else if(mu.Ypos < closestwu.Ypos)
                                {
                                    mu.Move(1);
                                }
                            }
                        }

                    }
                }
                else if (map.Units[i] is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)map.Units[i];

                    (Unit closest, int distanceTo) = ru.Closest(map.Units);

                  
                    if (distanceTo <= ru.Attackrange)
                    {
                        ru.isAttacking = true;
                        ru.Combat(closest);
                    }
                    else 
                    {
                        if (closest is MeleeUnit)
                        {
                            MeleeUnit closestMu = (MeleeUnit)closest;
                            if (ru.Xpos > closestMu.Xpos) 
                            {
                                ru.Move(0);
                            }
                            else if (ru.Xpos < closestMu.Xpos)
                            {
                                ru.Move(2);
                            }
                            else if (ru.Ypos > closestMu.Ypos) 
                            {
                                ru.Move(3);
                            }
                            else if (ru.Ypos < closestMu.Ypos)
                            {
                                ru.Move(1);
                            }
                        }
                        else if (closest is RangedUnit)
                        {
                            RangedUnit closestRu = (RangedUnit)closest;
                            if (ru.Xpos > closestRu.Xpos)
                            {
                                ru.Move(0);
                            }
                            else if (ru.Xpos < closestRu.Xpos)
                            {
                                ru.Move(2);
                            }
                            else if (ru.Ypos > closestRu.Ypos)
                            {
                                ru.Move(3);
                            }
                            else if (ru.Ypos < closestRu.Ypos) 
                            {
                                ru.Move(1);
                            }
                        }
                        else if(closest is WizardUnit)
                        {
                            WizardUnit closestwu = (WizardUnit)closest;
                            if(ru.Xpos > closestwu.Xpos)
                            {
                                ru.Move(0);
                            }
                            else if(ru.Xpos < closestwu.Xpos)
                            {
                                ru.Move(2);
                            }
                            else if(ru.Ypos > closestwu.Ypos)
                            {
                                ru.Move(3);
                            }
                            else if(ru.Ypos < closestwu.Ypos)
                            {
                                ru.Move(1);
                            }
                        }
                    }
                }
                else if(map.Units[i] is WizardUnit)
                {
                    WizardUnit wu = (WizardUnit)map.Units[i];

                    (Unit closest, int distanceto) = wu.Closest(map.Units);
                    
                    if(distanceto <= wu.Attackrange)
                    {
                        wu.isAttacking = true;
                        wu.Combat(closest);
                    }
                    else
                    {
                        if(closest is MeleeUnit)
                        {
                            MeleeUnit closestmu = (MeleeUnit)closest;
                            if(wu.Xpos > closestmu.Xpos)
                            {
                                wu.Move(0);
                            }
                            else if(wu.Xpos < closestmu.Xpos)
                            {
                                wu.Move(2);
                            }
                            else if(wu.Ypos > closestmu.Ypos)
                            {
                                wu.Move(3);
                            }
                            else if(wu.Ypos < closestmu.Ypos)
                            {
                                wu.Move(1);
                            }
                        }
                        else if(closest is RangedUnit)
                        {
                            RangedUnit closestru = (RangedUnit)closest;
                            if(wu.Xpos > closestru.Xpos)
                            {
                                wu.Move(0);
                            }
                            else if (wu.Xpos < closestru.Xpos)
                            {
                                wu.Move(2);
                            }
                            else if(wu.Ypos > closestru.Ypos)
                            {
                                wu.Move(3);
                            }
                            else if (wu.Ypos < closestru.Ypos)
                            {
                                wu.Move(1);
                            }
                        }
                        else if(closest is WizardUnit)
                        {
                            WizardUnit closestwu = (WizardUnit)closest;
                            if(wu.Xpos > closestwu.Xpos)
                            {
                                wu.Move(0);
                            }
                            else if(wu.Xpos < closestwu.Xpos)
                            {
                                wu.Move(2);
                            }
                            else if(wu.Ypos > closestwu.Ypos)
                            {
                                wu.Move(3);
                            }
                            else if(wu.Ypos < closestwu.Ypos)
                            {
                                wu.Move(1);
                            }
                        }
                    }
                }
                /*if(map.Buildings[i] is FactoryBuilding)
                {
                    FactoryBuilding fb = (FactoryBuilding)map.Buildings[i];
                    (Unit closest, int distanceTo) = fb.Closest(map.Units);

                    if(distanceTo <= 2)
                    {
                        fb.Combat(closest);
                    }
                }*/
            }
            map.Display(GBMap,x,y);
            roundnum++;
            int genspeed = 5;
            temp++;
            if(temp == genspeed)
            {
                fb.UnitProduce(genspeed);
            }
            
            

        }

        public int DistanceTo(Unit a, Unit b)
        {
            int distance = 0;

            if (a is MeleeUnit && b is MeleeUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.Xpos - end.Xpos) + Math.Abs(start.Ypos - end.Ypos);
            }
            else if (a is RangedUnit && b is MeleeUnit)
            {
                RangedUnit start = (RangedUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.Xpos - end.Xpos) + Math.Abs(start.Ypos - end.Ypos);
            }
            else if (a is RangedUnit && b is RangedUnit)
            {
                RangedUnit start = (RangedUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.Xpos - end.Xpos) + Math.Abs(start.Ypos - end.Ypos);
            }
            else if (a is MeleeUnit && b is RangedUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.Xpos - end.Xpos) + Math.Abs(start.Ypos - end.Ypos);
            }
            else if(a is MeleeUnit && b is WizardUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                WizardUnit end = (WizardUnit)b;
                distance = Math.Abs(start.Xpos - end.Xpos) + Math.Abs(start.Ypos - end.Ypos);
            }
            else if(a is RangedUnit && b is WizardUnit)
            {
                RangedUnit start = (RangedUnit)a;
                WizardUnit end = (WizardUnit)b;
                distance = Math.Abs(start.Xpos - end.Xpos) + Math.Abs(start.Ypos - end.Ypos);
            }
            return distance;
        }

        public void Read()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fin = new FileStream("Save.dat", FileMode.Open, FileAccess.Read, FileShare.None);
            
        }

       
        
    }
}
