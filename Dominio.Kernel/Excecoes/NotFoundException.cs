﻿using System;

namespace Dominio.Kernel.Excecoes
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public int Id { get; private set; }

        public NotFoundException()
        {
        }

        public NotFoundException(int id)
        {
            Id = id;
        }

        public NotFoundException(string message, int id) : base(message)
        {
            Id = id;
        }
    }
}
