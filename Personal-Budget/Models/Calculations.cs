﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

namespace Personal_Budget.Models
{
    public class Calculations
    {
        SQLiteConnection conn; // adding an SQLite connection
        string path = "Findata.sqlite"; // Name of the database must be the same

        public double DebtCalculation()
        {
            /// Initializing a database
            conn = new SQLiteConnection(path);
            // Creating table
            conn.CreateTable<Debt>();

            //// getting values of debt
            var SumQuery1 = conn.Query<Debt>("SELECT * FROM Debt");
            var sumProdQty1 = SumQuery1.AsEnumerable().Sum(o => o.DebtAmount);
            double SUMOF = sumProdQty1;
            return SUMOF;
        }

        public double FullValuation()
        {
            double Temp1 = AssetCalculation() + AccountTotal();
            return Temp1;
        }

        public double AssetCalculation()
        {
            conn = new SQLiteConnection(path);
            // Creating table
            conn.CreateTable<Assets>();

            double _Tot;
            var SumQuery = conn.Query<Assets>("SELECT * FROM Assets");
            var sumProdQty = SumQuery.AsEnumerable().Sum(o => o.AssetValue);
            _Tot = sumProdQty;
            return _Tot;
        }

        public double AccountTotal()
        {
            conn = new SQLiteConnection(path);
            // Creating table
            conn.CreateTable<Accounts>();

            //// getting values
            double Toto;
            var SumQuery = conn.Query<Accounts>("SELECT * FROM Accounts");
            var sumProdQty = SumQuery.AsEnumerable().Sum(o => o.InitialAmount);
            Toto = sumProdQty;
            return Toto;
        }

        public double PercentageScore()
        {
            double TotalAssetincome = FullValuation();
            double percentage = (-DebtCalculation() / (TotalAssetincome) * 100);
            return percentage;
        }

        public string CreditRatio()
        {
            string CreditRating;
            double Percentage = PercentageScore();

            if(Percentage >= 100)
            {
                CreditRating = "D";
                return CreditRating;
            }
            else 
            {
                if (Percentage > 90 || Percentage >= 100)
                {
                    CreditRating = "CCC";
                    return CreditRating;
                }
                else
                {
                    if (Percentage > 80 || Percentage >= 90)
                    {
                        CreditRating = "B";
                        return CreditRating;
                    }
                    else
                    {
                        if (Percentage > 70 || Percentage >= 80)
                        {
                            CreditRating = "BB";
                            return CreditRating;
                        }
                        else
                        {
                            if (Percentage > 60 || Percentage >= 70)
                            {
                                CreditRating = "BBB";
                                return CreditRating;
                            }
                            else
                            {
                                if (Percentage > 50 || Percentage >= 60)
                                {
                                    CreditRating = "A";
                                    return CreditRating;
                                }
                                else
                                {
                                    if (Percentage > 40 || Percentage >= 50)
                                    {
                                        CreditRating = "A+";
                                        return CreditRating;
                                    }
                                    else
                                    {
                                        if (Percentage > 30 || Percentage >= 40)
                                        {
                                            CreditRating = "AA";
                                            return CreditRating;
                                        }
                                        else
                                        {
                                            if (Percentage > 20 || Percentage >= 30)
                                            {
                                                CreditRating = "AA+";
                                                return CreditRating;
                                            }
                                            else
                                            {
                                                if (Percentage >= 10 || Percentage >= 20)
                                                {
                                                    CreditRating = "AAA";
                                                    return CreditRating;
                                                }
                                                else
                                                {
                                                     CreditRating = "AAA++";
                                                     return CreditRating;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }

        }

    }
}
