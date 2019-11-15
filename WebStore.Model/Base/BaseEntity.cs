﻿using System;

namespace WebStore.Model.Base
{
    public abstract class BaseEntity
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => _id = value;
        }
    }
}
