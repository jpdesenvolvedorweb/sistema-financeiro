﻿using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Category
    {
        private string idCategory;
        private string name;
        private string description;
        private int state;

        public Category()
        {

        }

        public Category(string idCategory)
        {
            this.idCategory = idCategory;
        }

        public Category(string idCategory, string name, string description)
        {
            this.idCategory = idCategory;
            this.name = name;
            this.description = description;
        }

        public string IdCategory
        {

            get => idCategory;
            set => idCategory = value;

        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public int State
        {
            get => state;
            set => state = value;
        }
    }
}
