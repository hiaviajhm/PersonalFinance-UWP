﻿    //Personal Finance App to manage your income and expenses.
    //Copyright(C) 2016  Jijo Bose

    //This program is free software: you can redistribute it and/or modify
    //it under the terms of the GNU Affero General Public License as published
    //by the Free Software Foundation, either version 3 of the License, or
    //(at your option) any later version.

    //This program is distributed in the hope that it will be useful,
    //but WITHOUT ANY WARRANTY; without even the implied warranty of
    //MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
    //GNU Affero General Public License for more details.

    //You should have received a copy of the GNU Affero General Public License
    //along with this program.If not, see<http://www.gnu.org/licenses/>.
    
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Budget.Models
{
    public class Transactions
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public DateTime DateOfTran { get; set; }

        public string Account { get; set; }

        public string Description { get; set; }
        public string TranType { get; set; }
        public double Amount { get; set; }
    }
}
