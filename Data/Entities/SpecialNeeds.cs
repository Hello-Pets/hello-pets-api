﻿namespace HelloPets.Data.Entities
{
    public class SpecialNeeds
    {
        public int Id { get; set; }

        public int PetId { get; set; }

        public string Value { get; set; }

        public bool IsActive { get; set; }
    }
}
