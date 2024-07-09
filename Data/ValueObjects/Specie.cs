﻿namespace HelloPets.Data.ValueObjects
{
    public class Specie
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
    }
}
