﻿using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Model.Entity.Base;

namespace WebStore.Model.Entity
{
    public class Employee : HumanEntity
    {
        private DateTime _birthDay;
        private DateTime _hiringDate;
        public DateTime BirthDay
        {
            get => _birthDay;
            set => _birthDay = value;
        }
        public DateTime HiringDate
        {
            get => _hiringDate;
            set => _hiringDate = value;
        }
    }
}
