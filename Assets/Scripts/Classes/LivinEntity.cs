using System.Text;
using System;

namespace Characters
{
    public abstract class LivinEntity
    {
        private string id;
        private string name;
        private float percentage;

        /// <summary>
        /// Create a living entity with base stats.
        /// </summary>
        public LivinEntity()
        {
            this.id = generateID("TmpDino");
            this.name = id;
            this.percentage = 0.0f;
        }

        /// <summary>
        /// Create a living entity with given stats
        /// </summary>
        /// <param name="name">Name of the entity</param>
        public LivinEntity(string name)
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
