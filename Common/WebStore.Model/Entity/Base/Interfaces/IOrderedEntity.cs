﻿namespace WebStore.Domain.Entity.Base.Interfaces
{
    public interface IOrderedEntity : IBaseEntity
    {
        /// <summary>Порядковый номер</summary>
        int Order { get; set; }
    }
}
