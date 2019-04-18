using System.Text;
using System;
using UnityEngine;

namespace Characters
{
    public class LivingEntity : MonoBehaviour
    {
        private string id;
        protected string name;
        protected float percentage;

        /// <summary>
        /// Create a living entity with base stats.
        /// </summary>
        public LivingEntity()
        {
            this.id = generateID("TmpDino");
            this.name = id;
            this.percentage = 0.0f;
        }

        /// <summary>
        /// Create a living entity with given stats
        /// </summary>
        /// <param name="name">Name of the entity</param>
        public LivingEntity(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }
            else
            {
                name = name.Trim();
            }

            this.id = generateID(name);
            this.name = name;
            this.percentage = 0;
        }

        public void Init(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }
            else
            {
                name = name.Trim();
            }

            this.id = generateID(name);
            this.name = name;
            this.percentage = 0;
        }

        /// <summary>
        /// Summary of the Class
        /// </summary>
        /// <returns>Summary in string format</returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append("LivingEntity: ").Append("ID: " + id).Append(", Name: " + name).Append(", Percentage: " + percentage.ToString());

            return ret.ToString();
        }

        /// <summary>
        /// Generate unique ID 
        /// </summary>
        /// <param name="name">Source Word</param>
        /// <returns>New unique ID with name</returns>
        private string generateID(string name)
        {
            return string.Format("{0}_{1:N}", name, Guid.NewGuid());
        }

        #region Getter&Setter
        public string Name {
            get { return name; }
        }

        public string ID {
            get { return id; }
        }

        public float Percentage {
            get { return percentage; }
        }
        #endregion
    }
}
