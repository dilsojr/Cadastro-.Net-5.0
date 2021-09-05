using System;

namespace Site.Negocios.Entidades
{
    public abstract class Entidade
    {
        public Guid Id { get; set; } 

        protected Entidade()
        {
            Id = Guid.NewGuid();
        }
    }
}
